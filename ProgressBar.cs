using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xkr_gmod_instalador_texturas
{
    public static class ProgressBar
    {
        static DateTime startTime;
        static ProgressBar()
        {
            startTime = DateTime.Now;
        }
        public static void Show(double percentage, double downloadedMBs, double totalMBs)
        {
            int barSize = 50;
            int chars = (int)Math.Floor(percentage / 100 * barSize);
            string bar = new string('\u2588', chars) + new string('\u2591', barSize - chars);

            // Cálculo del ETA
            double secondsRemaining = (DateTime.Now - startTime).TotalSeconds * (100.0 - percentage) / percentage;
            string etaString = secondsRemaining > 3600 ? $"{Math.Round(secondsRemaining / 3600)}h" :
                             secondsRemaining > 60 ? $"{Math.Round(secondsRemaining / 60)}m" :
                             $"{Math.Round(secondsRemaining)}s";

            Console.Write($"\r {bar} {percentage:F2}% | ETA: {etaString} | {downloadedMBs:F2}MB/{totalMBs:F2}MB");
        }
            
    }
}
