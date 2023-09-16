// GmodTexurasCsharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// GmodTexurasCsharp.Program
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("                                       ``....................................``     ");
        Thread.Sleep(100);
        Console.WriteLine("                                     `-+ssssssssssssssssssssssssssssssssssssss+-`   ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `.ssssssssssssssssssssssssssssssssssssssssss.`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-sssssssssssssso+:-.``.-/os/:::::osssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-sssssssssssso:`          -`     osssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-sssssssssss+`       `.`         osssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-sssssssssso`     .+ossso/`      osssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-ssssssssss:     `osssssss+      osssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-ssssssssss.     :sssssssss`     osssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-ssssssssss-     :sssssssss.     osssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-ssssssssss:     .ossssssso      osssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-sssssssssso      .osssss+`      osssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-sssssssssss/       .---`        osssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-sssssssssssso-           .      osssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-sssssssssssssso/:..``..:+o      osssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-ssssssssss-````.osssssssso      osssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-ssssssssss:     -ossssso/`     .ssssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-sssssssssss-      `.-.`       .ossssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-ssssssssssss+.              ./ssssssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `-sssssssssssssso/-.``  ``.-/ossssssssssssss-`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                    `.ssssssssssssssssssssssssssssssssssssssssss.`  ");
        Thread.Sleep(100);
        Console.WriteLine("                                     `-+osssssssssssssssssssssssssssssssssssss+-`   ");
        Thread.Sleep(100);
        Console.WriteLine("                                       ``....................................``     ");
        Thread.Sleep(100);
        Console.Beep();
        Console.WriteLine("\n\n\n¡Bienvenido al instalador automático de texturas de Garry's Mod! \n");
        Console.WriteLine("Pulsa enter para continuar...");
        Console.ReadKey();
        Console.Clear();
        LogoXekro();
        Console.WriteLine("Se va a comprobar el directorio de Garry's Mod.");
        Console.WriteLine("Pulsa enter para continuar...");
        Console.ReadKey();
        string text = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\GarrysMod";
        if (!ComprobarDirectorio(text))
        {
            Console.Clear();
            LogoXekro();
            Console.WriteLine("No se ha encontrado el directorio de Garry's Mod.\n\n");
            Console.WriteLine("Introduzca el directorio manualmente: ");
            string text2;
            do
            {
                Console.WriteLine("¡ERROR! El directorio introducido no es válido.");
                Console.Beep();
                text2 = Console.ReadLine();
            }
            while (!ComprobarDirectorio(text2));
            text = text2;
        }
        Console.WriteLine("\n¡ÉXITO!");
        Console.WriteLine("El directorio de Garry's Mod se ha encontrado correctamente.");
        string tempPath = Path.GetTempPath();
        WebClient webClient = new WebClient();
        webClient.DownloadFile("https://xekro.com/temporal/atextura/main.html", tempPath + "main.html");
        File.Move(tempPath + "main.html", text + "\\garrysmod\\html\\template\\main.html", overwrite: true);
        Thread.Sleep(1500);
        Console.Clear();
        LogoXekro();
        Console.WriteLine("Se va a proceder a descargar las texturas.");
        Console.WriteLine("Pulsa enter para continuar...");
        Console.ReadKey();
        Console.Clear();
        LogoXekro();
        if (File.Exists(tempPath + "\\CSSContent_Jun2018.zip"))
        {
            Console.WriteLine("Se han encontrado las texturas ya descargadas. ¿Desea volver a descargarlas?");
            string text3 = Console.ReadLine();
            do
            {
                Console.WriteLine("Introduzca SI o NO (en mayúsculas):");
                text3 = Console.ReadLine();
                Console.WriteLine(text3 == "SI");
            }
            while (!(text3 == "SI") && !(text3 == "NO"));
            if (text3 == "SI")
            {
                Console.WriteLine("...Descargando texturas (720MB)...");
                Console.WriteLine("Espere por favor.");
                File.Delete(tempPath + "CSSContent_Jun2018.zip");
                webClient.DownloadFile("https://xekro.com/temporal/atextura/CSSContent_Jun2018.zip", tempPath + "CSSContent_Jun2018.zip");
            }
        }
        else
        {
            Console.WriteLine("...Descargando texturas (720MB)...");
            Console.WriteLine("Espere por favor.");
            webClient.DownloadFile("https://xekro.com/temporal/atextura/CSSContent_Jun2018.zip", tempPath + "CSSContent_Jun2018.zip");
        }
        Console.Clear();
        LogoXekro();
        Console.WriteLine("\n¡Texturas descargadas correctamente!");
        Console.WriteLine("\nSe va a instalar las texturas en el directorio de Garry's Mod.");
        Console.WriteLine("Pulsa enter para continuar...");
        Console.ReadKey();
        if (Directory.Exists(tempPath + "CSSContent"))
        {
            Directory.Delete(tempPath + "CSSContent", recursive: true);
            ZipFile.ExtractToDirectory(tempPath + "CSSContent_Jun2018.zip", tempPath);
        }
        else
        {
            ZipFile.ExtractToDirectory(tempPath + "CSSContent_Jun2018.zip", tempPath);
        }
        Copy(tempPath + "CSSContent", text + "\\garrysmod");
        if (Directory.Exists(tempPath + "CSSContent"))
        {
            Directory.Delete(tempPath + "CSSContent", recursive: true);
        }
        if (File.Exists(tempPath + "CSSContent_Jun2018.zip"))
        {
            File.Delete(tempPath + "CSSContent_Jun2018.zip");
        }
        Console.Clear();
        LogoXekro();
        Console.WriteLine("¡Texturas instaladas correctamente!");
        Console.WriteLine("Gracias por utilizar el instalador de texturas de XEKRO Server's \n\n\n\n\n");
        Console.WriteLine("Pagina WEB: xekro.com");
        Console.WriteLine("Discord: discord.xekro.com");
        Console.WriteLine("TTT: ttt.xekro.com");
        Console.WriteLine("\nCreador de la herramienta: TuXEKRO\n\n\n\n");
        Thread.Sleep(4000);
        Console.WriteLine("\n\nPulsa enter para continuar...");
        Console.ReadKey();
    }

    private static bool ComprobarDirectorio(string directorio)
    {
        if (File.Exists(directorio + "\\hl2.exe"))
        {
            return true;
        }
        return false;
    }

    private static void LogoXekro()
    {
        Console.WriteLine("");
        Console.WriteLine("                        __  _______ _  ______   ___    ____                           _     ");
        Console.WriteLine("                        \\ \\/ / ____| |/ /  _ \\ / _ \\  / ___|  ___ _ ____   _____ _ __( )___ ");
        Console.WriteLine("                         \\  /|  _| | ' /| |_) | | | | \\___ \\ / _ \\ '__\\ \\ / / _ \\ '__|// __|");
        Console.WriteLine("                         /  \\| |___| . \\|  _ <| |_| |  ___) |  __/ |   \\ V /  __/ |    \\__ \\");
        Console.WriteLine("                        /_/\\_\\_____|_|\\_\\_| \\_\\\\___/  |____/ \\___|_|    \\_/ \\___|_|    |___/");
        Console.WriteLine("\n\n\n");
        Console.Beep();
    }

    private static void Copy(string fromFolder, string toFolder, bool overwrite = true)
    {
        Directory.EnumerateFiles(fromFolder, "*.*", SearchOption.AllDirectories).AsParallel().ForAll(delegate (string from)
        {
            string text = from.Replace(fromFolder, toFolder);
            string directoryName = Path.GetDirectoryName(text);
            if (!string.IsNullOrWhiteSpace(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            File.Copy(from, text, overwrite);
        });
    }
}
