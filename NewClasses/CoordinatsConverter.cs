using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionPlanner.NewClasses
{
    public class CoordinatsConverter
    {
        private static string to_GM(double coord) 
        {
            string result = "";
            int grad = (int)Math.Truncate(coord);
            double min = coord - grad;
            min *= 60;
            result = grad.ToString() + "°." + min.ToString("0.0000") + "'";
            return result;
        }


        private static string to_GMS(double coord)
        {
            string result = "";
            int grad = (int)Math.Truncate(coord);
            double min = coord - grad;
            min *= 60;
            double sec = min;
            min = Math.Truncate(min);
            sec -= min;
            sec *= 60;
            result = grad.ToString() + "°." + min.ToString() + "'"+sec.ToString("0.00")+"\"";
            return result;
        }

        public static string toWGS_G(double Lat, double Lon, double alt)
        {
            string result = Lat.ToString("0.000000") + "°, " + Lon.ToString("0.000000")+ "°";
            return result;
        }

        public static string toWGS_GM(double Lat, double Lon, double alt)
        {
            string result = to_GM(Lat) + ", " + to_GM(Lon);
            return result;
        }

        public static string toWGS_GMS(double Lat, double Lon, double alt)
        {
            string result = to_GMS(Lat) + ", " + to_GMS(Lon);
            return result;
        }

        public static string toSK42_G(double Lat,double Lon,double alt) 
        {
            string result = WGS84_SK42_Lat(Lat,Lon,alt).ToString("0.000000")+ "°, " + WGS84_SK42_Long(Lat, Lon, alt).ToString("0.000000")+ "°";
            return result;
        }
        public static string toSK42_GM(double Lat, double Lon, double alt)
        {
            string result = to_GM(WGS84_SK42_Lat(Lat, Lon, alt)) + ", " + to_GM(WGS84_SK42_Long(Lat, Lon, alt));
            return result;
        }
        public static string toSK42_GMS(double Lat, double Lon, double alt)
        {
            string result = to_GMS(WGS84_SK42_Lat(Lat, Lon, alt)) + ", " + to_GMS(WGS84_SK42_Long(Lat, Lon, alt));
            return result;
        }

        const double piConverter = 1;
        public static string toRectFromWGS(double Lat, double Lon, double alt) 
        {
            string result = "";
            double X = (N(Lat) + alt) * Math.Cos(Lat* piConverter) * Math.Cos(Lon* piConverter);
            double Y = (N(Lat) + alt) * Math.Cos(Lat*piConverter) * Math.Sin(Lon* piConverter);
            result = X.ToString("0.0") + ", " + Y.ToString("0.0");
            return result;

        }

        private static double N(double B ) 
        {
            double aa = 6378137;
            double aaa = 1 / 298.257223563;
            //double b = 6356863.019;
            double sqre = 2 * aaa - aaa * aaa;//(aa*aa - b*b)/(aa*aa);
            return aa / Math.Sqrt(1 - sqre*Math.Sin(B * piConverter) *Math.Sin(B * piConverter));
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////from excel

        const double Pi  = 3.14159265358979; // Число Пи
        const double ro  = 206264.8062; // Число угловых секунд в радиане

        // Эллипсоид Красовского
        const double aP = 6378245; // Большая полуось
        const double alP = 1 / 298.3; // Сжатие
        const double e2P = 2 * alP - alP * alP; // Квадрат эксцентриситета

        // Эллипсоид WGS84 (GRS80, эти два эллипсоида сходны по большинству параметров)
        const double aW = 6378137; // Большая полуось
        const double alW = 1 / 298.257223563; // Сжатие
        const double e2W = 2 * alW - alW * alW; // Квадрат эксцентриситета

        // Вспомогательные значения для преобразования эллипсоидов
        const double a = (aP + aW) / 2;
        const double e2 = (e2P + e2W) / 2;
        const double da = aW - aP;
        const double de2 = e2W - e2P;

        // Линейные элементы трансформирования, в метрах
        const double dx = 23.92;
        const double dy = -141.27;
        const double dz = -80.9;

        // Угловые элементы трансформирования, в секундах
        const double wx = 0;
        const double wy = 0;
        const double wz = 0;

        // Дифференциальное различие масштабов
        const double ms = 0;

        private static double dL(double Bd, double Ld, double H) 
        {
            double B, L, N;
            B = Bd * Pi / 180;
            L = Ld * Pi / 180;
            N = a * Math.Pow((1 - e2 * Math.Sin(B) * Math.Sin(B)), -0.5);
            double result = ro / ((N + H) * Math.Cos(B)) * (-dx * Math.Sin(L) + dy * Math.Cos(L))  + Math.Tan(B) * (1 - e2) * (wx * Math.Cos(L) + wy * Math.Sin(L)) - wz;
            return result;
        }

        private static double dB(double Bd,double Ld,double H) {
            double B, L, M, N;
            B = Bd * Pi / 180;
            L = Ld * Pi / 180;
            M = a * (1 - e2) / (Math.Pow((1 - e2 * Math.Sin(B) * Math.Sin(B)), 1.5));
            N = a * Math.Pow((1 - e2 * Math.Sin(B) * Math.Sin(B)) , -0.5);
            return  ro / (M + H) * (N / a * e2 * Math.Sin(B) * Math.Cos(B) * da + (N * N / (a * a) + 1) * N * Math.Sin(B) * Math.Cos(B) * de2 / 2 
                - (dx * Math.Cos(L) + dy * Math.Sin(L)) * Math.Sin(B) + dz * Math.Cos(B)) - wx * Math.Sin(L) * (1 + e2 * Math.Cos(2 * B)) + wy
                * Math.Cos(L) * (1 + e2 * Math.Cos(2 * B)) - ro * ms * e2 * Math.Sin(B) * Math.Cos(B);
        }

        private static double WGS84_SK42_Lat(double Bd, double Ld, double H) 
        {
            return Bd - dB(Bd, Ld, H) / 3600;
        }

        private static double WGS84_SK42_Long(double Bd, double Ld, double H)
        {
            return Ld - dL(Bd, Ld, H) / 3600;
        }

    }
}
