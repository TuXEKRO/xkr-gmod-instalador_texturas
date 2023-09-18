// GmodTexurasCsharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// GmodTexurasCsharp.Program
namespace GmodTexurasCsharp
{
    internal class LogoPrinter
    {
        public static void PrintLogoGmod()
        {
            string[] logoLines = {
                "                                       ``....................................``     ",
                "                                     `-+ssssssssssssssssssssssssssssssssssssss+-`   ",
                "                                    `.ssssssssssssssssssssssssssssssssssssssssss.`  ",
                "                                    `-sssssssssssssso+:-.``.-/os/:::::osssssssss-`  ",
                "                                    `-sssssssssssso:`          -`     osssssssss-`  ",
                "                                    `-sssssssssss+`       `.`         osssssssss-`  ",
                "                                    `-sssssssssso`     .+ossso/`      osssssssss-`  ",
                "                                    `-ssssssssss:     `osssssss+      osssssssss-`  ",
                "                                    `-ssssssssss.     :sssssssss`     osssssssss-`  ",
                "                                    `-ssssssssss-     :sssssssss.     osssssssss-`  ",
                "                                    `-ssssssssss:     .ossssssso      osssssssss-`  ",
                "                                    `-sssssssssso      .osssss+`      osssssssss-`  ",
                "                                    `-sssssssssss/       .---`        osssssssss-`  ",
                "                                    `-sssssssssssso-           .      osssssssss-`  ",
                "                                    `-sssssssssssssso/:..``..:+o      osssssssss-`  ",
                "                                    `-ssssssssss-````.osssssssso      osssssssss-`  ",
                "                                    `-ssssssssss:     -ossssso/`     .ssssssssss-`  ",
                "                                    `-sssssssssss-      `.-.`       .ossssssssss-`  ",
                "                                    `-ssssssssssss+.              ./ssssssssssss-`  ",
                "                                    `-sssssssssssssso/-.``  ``.-/ossssssssssssss-`  ",
                "                                    `.ssssssssssssssssssssssssssssssssssssssssss.`  ",
                "                                     `-+osssssssssssssssssssssssssssssssssssss+-`   ",
                "                                       ``....................................``     "
            };

            foreach (string line in logoLines)
            {
                Console.WriteLine(line);
                //Thread.Sleep(100);
                Thread.Sleep(1);
            }
            Console.Beep();
        }

        public static void PrintXekroServers()
        {
            string[] logoLines = {
                "",
                "                        __  _______ _  ______   ___    ____                           _     ",
                "                        \\ \\/ / ____| |/ /  _ \\ / _ \\  / ___|  ___ _ ____   _____ _ __( )___ ",
                "                         \\  /|  _| | ' /| |_) | | | | \\___ \\ / _ \\ '__\\ \\ / / _ \\ '__|// __|",
                "                         /  \\| |___| . \\|  _ <| |_| |  ___) |  __/ |   \\ V /  __/ |    \\__ \\",
                "                        /_/\\_\\_____|_|\\_\\_| \\_\\\\___/  |____/ \\___|_|    \\_/ \\___|_|    |___/",
                "\n\n\n"
            };
            foreach (string line in logoLines)
            {
                Console.WriteLine(line);
            }
            Console.Beep();
        }
    }
}