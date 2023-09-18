using GmodTexurasCsharp;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xkr_gmod_instalador_texturas
{
    class TextureInstaller
    {
        static async Task ExtractZipAsync(string pathZip, string pathDestination, Action<double, double, double> callback)
        {
            await Task.Run(() =>
            {
                if (Directory.Exists(pathDestination + "CSSContent")) Directory.Delete(pathDestination + "CSSContent", recursive: true);
                using (ZipArchive archive = ZipFile.OpenRead(pathZip))
                {
                    long totalBytes = archive.Entries.Sum(entry => entry.Length);
                    long extractedBytes = 0;

                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        var extractedFileOrFolder = entry.FullName;
                        var fullPath = Path.Combine(pathDestination, entry.FullName);

                        try
                        {
                            var destDirPath = Path.GetDirectoryName(fullPath);
                            if (destDirPath != null)
                            {
                                Directory.CreateDirectory(destDirPath);
                            }

                            entry.ExtractToFile(fullPath, true);
                            extractedBytes += entry.Length;

                            double percentage = ((double)extractedBytes / totalBytes) * 100;
                            callback(percentage, extractedBytes / (1024.0 * 1024), totalBytes / (1024.0 * 1024));
                        }
                        catch (DirectoryNotFoundException dnfe)
                        {
                            //Console.WriteLine("Omitido: " + fullPath);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            });
        }

        static async Task CopyFilesAsync(string fromFolder, string toFolder, Action<double, double, double> callback)
        {
            await Task.Run(() =>
            {
                var files = Directory.EnumerateFiles(fromFolder, "*.*", SearchOption.AllDirectories).ToList();
                long totalBytes = files.Sum(file => new FileInfo(file).Length);
                long copiedBytes = 0;

                foreach (string from in files)
                {
                    string text = from.Replace(fromFolder, toFolder);
                    string directoryName = Path.GetDirectoryName(text);
                    if (!string.IsNullOrWhiteSpace(directoryName))
                    {
                        Directory.CreateDirectory(directoryName);
                    }
                    var fileInfo = new FileInfo(from);
                    File.Copy(from, text, true);
                    copiedBytes += fileInfo.Length;

                    double percentage = ((double)copiedBytes / totalBytes) * 100;
                    callback(percentage, copiedBytes / (1024.0 * 1024), totalBytes / (1024.0 * 1024));
                }
            });
        }

        public static async Task ExtractGuide(string pathZip, string pathDestinationGmod)
        {
            Console.Clear();
            LogoPrinter.PrintXekroServers();
            Console.WriteLine("\nSe va a instalar las texturas en el directorio de Garry's Mod.");
            
            Console.WriteLine("\n· Descomprimiendo las texturas:");
            await ExtractZipAsync(pathZip, Path.GetTempPath(), ProgressBar.Show);

            Console.WriteLine("\n\n· Moviendo las texturas al directorio de Garry's Mod:");
            await CopyFilesAsync(Path.GetTempPath() + "\\CSSContent", pathDestinationGmod, ProgressBar.Show);
        }
    }
}
