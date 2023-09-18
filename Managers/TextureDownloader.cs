using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using xkr_gmod_instalador_texturas.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace xkr_gmod_instalador_texturas.Managers
{
    class TextureDownloader
    {
        public static async Task<int> Download(string path, string url, Action<double, double, double> progressCallback)
        {

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var httpResponseMessage = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);

                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return (int)httpResponseMessage.StatusCode;
                    }

                    using (var fileStream = new FileStream(Path.Combine(path, Path.GetFileName(new Uri(url).LocalPath)), FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        var totalBytes = httpResponseMessage.Content.Headers.ContentLength.GetValueOrDefault();
                        double totalMBs = totalBytes / (1024.0 * 1024.0);

                        using (var downloadStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;
                            long totalRead = 0;

                            while ((bytesRead = await downloadStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);

                                totalRead += bytesRead;
                                double percentage = (double)totalRead / totalBytes * 100;
                                double downloadedMBs = totalRead / (1024.0 * 1024.0);

                                progressCallback(percentage, downloadedMBs, totalMBs);
                            }
                        }
                    }

                    return 200;
                }
                catch
                {
                    return 0; // Error desconocido
                }
            }
        }



        public static async Task<bool> DownloadGuide(string path, string url)
        {
            Console.Clear();
            LogoPrinter.PrintXekroServers();
            Console.WriteLine("Se va a proceder a descargar las texturas.");
            //Console.WriteLine("Pulsa enter para continuar...");
            //Console.ReadKey();

            // FALTA COMPROBAR SHA DEL FICHERO Y LUEGO PREGUNTAR SI QUIERE VOLVER A DESCARGAR O NO PREGUNTAR SI EL SHA ES DISTINTO
            if (File.Exists(path + "CSSContent_Jun2018.zip"))
            {
                Console.WriteLine("Se han encontrado las texturas ya descargadas. ¿Desea volver a descargarlas? (SI/NO)");
                string userInput = Console.ReadLine().ToUpper();

                while (!(userInput == "SI") && !(userInput == "NO"))
                {
                    Console.WriteLine("Introduzca SI o NO:");
                    userInput = Console.ReadLine().ToUpper();
                }

                if (userInput == "NO")
                {
                    return true;
                }
                else
                {
                    File.Delete(path + "CSSContent_Jun2018.zip");
                }
            }


            Console.WriteLine("\n");
            Console.WriteLine("Descargando texturas:");
            int resultCode = await Download(path, url, ProgressBar.Show);
            Console.WriteLine("\n\n");


            switch (resultCode)
            {
                case 200:
                    return true; // Se descargó correctamente
                case >= 400 and < 500:
                    Console.WriteLine($"Error del cliente: {resultCode}");
                    return false;
                case >= 500:
                    Console.WriteLine($"Error del servidor: {resultCode}");
                    return false;
                default:
                    Console.WriteLine("Error desconocido.");
                    return false;
            }
        }

        internal static void ClearDownloads()
        {
            if (Directory.Exists(Path.GetTempPath() + "CSSContent")) Directory.Delete(Path.GetTempPath() + "CSSContent", recursive: true);
            if (File.Exists(Path.GetTempPath() + "CSSContent_Jun2018.zip")) File.Delete(Path.GetTempPath() + "CSSContent_Jun2018.zip");
        }
    }
}
