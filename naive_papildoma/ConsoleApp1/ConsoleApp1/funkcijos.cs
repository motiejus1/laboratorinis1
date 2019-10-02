using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Funkcijos
    {
        //duomenu pasklidimas
        public static double Pasklidimas(this IEnumerable<double> source)
        {
            double avg = source.Average();
            double d = source.Aggregate(0.0, (total, next) => total += Math.Pow(next - avg, 2));
            return d / (source.Count() - 1);
        }
        //Vidurkis
        public static double Mean(this IEnumerable<double> source)
        {
            if (source.Count() < 1)
                return 0.0;

            double length = source.Count();
            double sum = source.Sum();
            return sum / length;
        }
        //Gauso pasiskirstymo skaiciavimas
        public static double NormalDist(double x, double mean, double standard_dev)
        {
            double fact = standard_dev * Math.Sqrt(2.0 * Math.PI);
            double expo = (x - mean) * (x - mean) / (2.0 * standard_dev * standard_dev);
            return Math.Exp(-expo) / fact;
        }

        //saknties traukimas
        public static double SquareRoot(double source)
        {
            return Math.Sqrt(source);
        }
    }
}
