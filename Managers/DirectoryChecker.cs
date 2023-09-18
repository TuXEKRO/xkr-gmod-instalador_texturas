// GmodTexurasCsharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// GmodTexurasCsharp.Program
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using xkr_gmod_instalador_texturas;
using xkr_gmod_instalador_texturas.Utilities;

namespace xkr_gmod_instalador_texturas.Managers
{
    internal class DirectoryChecker
    {
        public static async Task<string> CheckGarrysModDirectoryAsync()
        {
            string directory = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\GarrysMod";
            //directory = "D:\\windows11\\steam\\steamapps\\common\\GarrysMod";

            LogoPrinter.PrintXekroServers();
            Console.WriteLine("Se va a comprobar el directorio por defecto de Garry's Mod.");
            //Console.WriteLine("Pulsa enter para continuar...");
            //Console.ReadKey();

            if (IsValidGmodDirectory(directory)) return directory;

            Console.Clear();
            LogoPrinter.PrintXekroServers();
            Console.WriteLine("No se ha encontrado el directorio de Garry's Mod.\n\n");
            Console.WriteLine("Introduzca el directorio manualmente: (Steam > Biblioteca > Garry's Mod > Propiedades > Archivos locales > Explorar)");
            directory = Console.ReadLine();
            while (!IsValidGmodDirectory(directory))
            {
                Console.WriteLine("¡ERROR! El directorio introducido no es válido.");
                Console.Beep();
                directory = Console.ReadLine();
            }

            return directory;
        }

        private static bool IsValidGmodDirectory(string directory)
        {
            return File.Exists(Path.Combine(directory, "hl2.exe"));
        }
    }
}