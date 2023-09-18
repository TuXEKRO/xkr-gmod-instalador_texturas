// GmodTexurasCsharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// GmodTexurasCsharp.Program
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Linq;
using xkr_gmod_instalador_texturas.Managers;
using xkr_gmod_instalador_texturas.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace GmodTexurasCsharp
{
    class Program
    {
        // Desactiva el modo QuickEdit (mouse accidental)
        [DllImport("kernel32.dll")]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        private const uint ENABLE_EXTENDED_FLAGS = 0x0080;

        private static async Task Main(string[] args)
        {
            // Desactiva el modo QuickEdit (mouse accidental)
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            SetConsoleMode(handle, ENABLE_EXTENDED_FLAGS);



            /*
             * 
             * EN LA SIGUIENTE VERSIÓN IMPLEMENTAR MODO EXPRESS, donde sólo se necesite intervención del usuario para errores.
             * 
             * */


            // 0. Bienvenida
            LogoPrinter.PrintLogoGmod();
            Console.WriteLine("\n\n\n¡Bienvenido al instalador automático de texturas de Garry's Mod! \n");
            Console.WriteLine("Pulsa enter para continuar...");
            Console.ReadKey();
            Console.Clear();

            // 1. Verificación de directorio de Garry's Mod
            string directoryGmod = await DirectoryChecker.CheckGarrysModDirectoryAsync();
            await TextureDownloader.Download(Path.GetTempPath(), new Configuration().htmlUrl, (_, __, ___) => { });
            File.Move(Path.GetTempPath() + "main.html", directoryGmod + "\\garrysmod\\html\\template\\main.html", overwrite: true);
            Console.WriteLine("¡Directorio encontrado!");
            Thread.Sleep(1500);

            // 2. Descarga de texturas
            string tempPath = Path.GetTempPath();
            bool resultDownload = await TextureDownloader.DownloadGuide(tempPath, new Configuration().texturesUrl);
            if (!resultDownload)
            {
                Console.WriteLine("Contacta con XEKRO en https://discord.xekro.com (Ctrl+Clic) e indica el mensaje de error indicado arriba.");
                Console.WriteLine("Pulsa enter para cerrar...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            // 3. Instalación de texturas
            await TextureInstaller.ExtractGuide(tempPath + "\\CSSContent_Jun2018.zip", directoryGmod + "\\garrysmod");
            Thread.Sleep(1500);

            //4. Limpieza
            TextureDownloader.ClearDownloads();

            // 5. Creditos
            Console.Clear();
            LogoPrinter.PrintXekroServers();
            Console.WriteLine("¡Texturas instaladas correctamente!");
            Console.WriteLine("Gracias por utilizar el instalador de texturas de XEKRO Servers \n\n\n\n\n");
            Console.WriteLine("[Pagina WEB]     https://xekro.com");
            Console.WriteLine("[Discord]        https://discord.xekro.com");
            Console.WriteLine("[TTT]            https://xekro.com/join/ttt");
            Console.WriteLine("\n\n\nCreador de esta herramienta <3: TuXEKRO\n\n\n");
            Thread.Sleep(4000);
            Console.WriteLine("\nPulsa enter para cerrar...");
            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}
