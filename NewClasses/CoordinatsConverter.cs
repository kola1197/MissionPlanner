using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionPlanner.NewClasses
{
    public class UniversalCoordinatsController
    {
        public WGSCoordinats wgs;
        public UniversalCoordinatsController(WGSCoordinats _wgs) 
        {
            wgs = _wgs;
        }

        public UniversalCoordinatsController(SK42Coordinats _sk42)
        {
            wgs = _sk42.toWGS();
        }

        public UniversalCoordinatsController(RectCoordinats _rect)
        {
            wgs = _rect.toWGS();
        }
    }

    public class CoordinatsPoint
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public double Alt { get; set; }
        public CoordinatsPoint()
        {
            Lat = 0;
            Lng = 0;
            Alt = 0;
        }

        public CoordinatsPoint(double _lat, double lng, double _alt = 0)
        {
            Lat = _lat;
            Lng = lng;
            Alt = _alt;
        }

        public CoordinatsPoint(string _lat, string _lon, string _alt = "0")
        {
            if (_lat.Contains('\"'))   //GMS
            {
                double[] values = splitFromString(_lat);
                Lat = values[0] + (values[1] + values[2] / 60) / 60;
                values = splitFromString(_lon);
                Lng = values[0] + (values[1] + values[2] / 60) / 60;
                values = splitFromString(_alt);
                Alt = values[0] + (values[1] + values[2] / 60) / 60;
            }
            else if (_lat.Contains('\'')) //GM
            {
                double[] values = splitFromString(_lat);
                Lat = values[0] + (values[1]) / 60;
                values = splitFromString(_lon);
                Lng = values[0] + (values[1]) / 60;
                values = splitFromString(_alt);
                Alt = values[0] + (values[1]) / 60;
            }
            else //G
            {
                Lat = double.Parse(_lat);
                Lng = double.Parse(_lon);
                Alt = double.Parse(_alt);
            }
        }

        private double[] splitFromString(string input)
        {
            double[] result = new double[] {0,0,0};
            input = input.Replace("\""," ");
            input = input.Replace("\'", " ");
            input = input.Replace("°", " ");
            string[] values = input.Split(' ');
            result = new double[values.Length];
            for (int i = 0; i < values.Length; i++) 
            {
                result[i] = double.Parse(values[i]);
            }
            return result; 
        }

        public string to_G_View() 
        {
            return Lat.ToString("0.00") + "°, " + Lng.ToString("0.00°");
        }

        public string to_GM_View_lat()
        {
            return CoordinatsConverter.to_GM(Lat);
        }

        public string to_GM_View_lon()
        {
            return CoordinatsConverter.to_GM(Lng);
        }

        public string to_GM_View() 
        {
            return CoordinatsConverter.to_GM(Lat) + ", " + CoordinatsConverter.to_GM(Lng);
        }
        public string to_GMS_View_lat()
        {
            return CoordinatsConverter.to_GMS(Lat);
        }

        public string to_GMS_View_lon()
        {
            return CoordinatsConverter.to_GMS(Lng);
        }

        public string to_GMS_View()
        {
            return CoordinatsConverter.to_GMS(Lat) + ", " + CoordinatsConverter.to_GMS(Lng);
        }

    }



    public class WGSCoordinats : CoordinatsPoint 
    {
        public WGSCoordinats(double _lat, double lng, double _alt) : base(_lat, lng, _alt)
        {  }

        public WGSCoordinats(double _lat, double lng) : base(_lat, lng)
        { }

        public WGSCoordinats() : base()
        { }

        public WGSCoordinats(string _lat, string _lon, string _alt) : base(_lat, _lon, _alt)
        { }

        public WGSCoordinats(string _lat, string _lon) : base(_lat, _lon)
        { }

        public SK42Coordinats toSK42() 
        {
            SK42Coordinats result = new SK42Coordinats(CoordinatsConverter.WGS84_SK42_Lat(Lat, Lng, Alt), CoordinatsConverter.WGS84_SK42_Long(Lat, Lng, Alt));

            return result;
        }

        public RectCoordinats toRect() 
        {
            SK42Coordinats s = toSK42();
            double _lat = s.Lat;
            double _lon = s.Lng;

            var _latrad = Math.PI * _lat / 180;
            var _lonrad = Math.PI * _lon / 180;

            var nzone = Math.Ceiling(_lon / 6);
            var _lonaxis = 6 * nzone - 3;
            var l = Math.PI * (_lon - _lonaxis) / 180;

            var N = 6399698.902 - (21562.267 - (108.973 - 0.612 * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2);
            var a0 = 32140.404 - (135.3302 - (0.7092 - 0.0040 * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2);
            var a3 = (0.3333333 + 0.001123 * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2) - 0.1666667;
            var a4 = (0.25 + 0.00252 * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2) - 0.04166;
            var a5 = 0.0083 - (0.1667 - (0.1968 + 0.0040 * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2);
            var a6 = (0.166 * Math.Pow(Math.Cos(_latrad), 2) - 0.084) * Math.Pow(Math.Cos(_latrad), 2);

            var tx = 6367558.4969 * _latrad - (a0 - (0.5 + (a4 + a6 * l * l) * l * l) * l * l * N) * Math.Sin(_latrad) * Math.Cos(_latrad);
            var ty = (1 + (a3 + a5 * l * l) * l * l) * l * N * Math.Cos(_latrad);
            ty = 500000 + ty;

            double y = double.Parse(nzone.ToString() + ty.ToString());
            RectCoordinats result = new RectCoordinats(tx,y);
            return result;
        }

        public override string ToString()
        {
            return Lat.ToString("0.0") + ", " + Lng.ToString("0.0");
        }
    }

    public class SK42Coordinats : CoordinatsPoint
    {
        public SK42Coordinats(double _lat, double lng, double _alt) : base(_lat, lng, _alt)
        { }

        public SK42Coordinats(double _lat, double lng) : base(_lat, lng)
        { }

        public SK42Coordinats() : base()
        { }

        public SK42Coordinats(string _lat, string _lon, string _alt) : base(_lat, _lon, _alt)
        { }

        public SK42Coordinats(string _lat, string _lon) : base(_lat, _lon)
        { }

        public WGSCoordinats toWGS() 
        {
            WGSCoordinats result = new WGSCoordinats(CoordinatsConverter.SK42_WGS84_Lat(Lat, Lng, Alt), CoordinatsConverter.SK42_WGS84_Long(Lat, Lng, Alt));
            return result;
        }

        public RectCoordinats toRect()
        {
            double _lat = Lat;
            double _lon = Lng;

            var _latrad = Math.PI * _lat / 180;
            var _lonrad = Math.PI * _lon / 180;

            var nzone = Math.Ceiling(_lon / 6);
            var _lonaxis = 6 * nzone - 3;
            var l = Math.PI * (_lon - _lonaxis) / 180;

            var N = 6399698.902 - (21562.267 - (108.973 - 0.612 * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2);
            var a0 = 32140.404 - (135.3302 - (0.7092 - 0.0040 * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2);
            var a3 = (0.3333333 + 0.001123 * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2) - 0.1666667;
            var a4 = (0.25 + 0.00252 * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2) - 0.04166;
            var a5 = 0.0083 - (0.1667 - (0.1968 + 0.0040 * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2)) * Math.Pow(Math.Cos(_latrad), 2);
            var a6 = (0.166 * Math.Pow(Math.Cos(_latrad), 2) - 0.084) * Math.Pow(Math.Cos(_latrad), 2);

            var tx = 6367558.4969 * _latrad - (a0 - (0.5 + (a4 + a6 * l * l) * l * l) * l * l * N) * Math.Sin(_latrad) * Math.Cos(_latrad);
            var ty = (1 + (a3 + a5 * l * l) * l * l) * l * N * Math.Cos(_latrad);
            ty = 500000 + ty;

            double y = double.Parse(nzone.ToString() + ty.ToString());
            RectCoordinats result = new RectCoordinats(tx, y);
            return result;
        }

        public override string ToString()
        {
            return Lat.ToString("0.0") + ", " + Lng.ToString("0.0");
        }
    }

    public class RectCoordinats
    {
        public double x { get; set; }
        public double y { get; set; }

        public RectCoordinats()
        {
            x = 0;
            y = 0;
        }

        public RectCoordinats(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public RectCoordinats(string _x, string _y)
        {
            x = double.Parse(_x);
            y = double.Parse(_y);
        }

        public SK42Coordinats toSK42() 
        {
            var rho = 206264.8062;
            var beta = (x / 6367558.4969) * rho;
            var nzone = y < 1000000 ? Math.Floor(y / 100000) : Math.Floor(y / 1000000);
            var zoneaxis = nzone * 6 - 3;
            var y1 = y - nzone * 1000000;
            var yl = y1 - 500000;
            var betarad = Math.PI * (beta / 3600) / 180;

            var phixsec = beta + (50221746 + (293622 + (2350 + 22 * Math.Pow(Math.Cos(betarad), 2)) * Math.Pow(Math.Cos(betarad), 2)) * Math.Pow(Math.Cos(betarad), 2)) * Math.Pow(10, -10) * Math.Sin(betarad) * Math.Cos(betarad) * rho;
            var phixrad = Math.PI * (phixsec / 3600) / 180;

            var Nx = 6399698.902 - (21562.267 - (108.973 - 0.612 * Math.Pow(Math.Cos(phixrad), 2)) * Math.Pow(Math.Cos(phixrad), 2)) * Math.Pow(Math.Cos(phixrad), 2);

            var z = yl / (Nx * Math.Cos(phixrad));

            var b2 = (0.5 + 0.003369 * Math.Pow(Math.Cos(phixrad), 2)) * Math.Sin(phixrad) * Math.Cos(phixrad);
            var b3 = 0.333333 - (0.166667 - 0.001123 * Math.Pow(Math.Cos(phixrad), 2)) * Math.Pow(Math.Cos(phixrad), 2);
            var b4 = 0.25 + (0.16161 + 0.00562 * Math.Pow(Math.Cos(phixrad), 2)) * Math.Pow(Math.Cos(phixrad), 2);
            var b5 = 0.2 - (0.1667 - 0.0088 * Math.Pow(Math.Cos(phixrad), 2)) * Math.Pow(Math.Cos(phixrad), 2);

            var l = (1 - (b3 - b5 * z * z) * z * z) * z * rho;
            var phi = phixsec - (1 - (b4 - 0.12 * z * z) * z * z) * z * z * b2 * rho;
            var lambda = zoneaxis + (l / 3600);
            SK42Coordinats result = new SK42Coordinats(phi / 3600, lambda);
            return result;
        }

        public WGSCoordinats toWGS()
        {
            WGSCoordinats result = toSK42().toWGS();
            return result;
        }

        public override string ToString()
        {
            return x.ToString("0.0")+", "+y.ToString("0.0");
        }

    }

    public class CoordinatsConverter
    {
        public static string to_GM(double coord) 
        {
            string result = "";
            int grad = (int)Math.Truncate(coord);
            double min = coord - grad;
            min *= 60;
            result = grad.ToString() + "°." + min.ToString("0.0000") + "'";
            return result;
        }

        public static string to_GMS(double coord)
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
        /*public static string toRectFromWGS(double Lat, double Lon, double alt) 
        {
            double B = Lat;
            double L = Lon;
            double H = alt;
            string result = "";
            double n = Math.Truncate((6+L)/6);
            double l = (L - (3 + 6*(n-1)))/57.29577951;
            double x = 6367558.4968 * B - Math.Sin(2 * B) * (16002.8900 + 66.9607 * Math.Sin(B) * Math.Sin(B) + 0.3515 * Math.Pow(Math.Sin(B), 4) - 
                l * l * (1594561.25 + 5336.535 * Math.Sin(B) * Math.Sin(B) + 26.790 * Math.Pow(Math.Sin(B), 4) + 0.149 * Math.Pow(Math.Sin(B), 6) + l * l * (672483.4 -
                811219.9 * Math.Sin(B) * Math.Sin(B) + 5420.0 * Math.Pow(Math.Sin(B), 4) - 10.6 * Math.Pow(Math.Sin(B), 6) + l * l * (278194 - 830174 * Math.Sin(B) * Math.Sin(B)+
                + 572434 * Math.Pow(Math.Sin(B), 4) - 16010 * Math.Pow(Math.Sin(B), 6) + l * l * (109500 - 574700 * Math.Sin(B) * Math.Sin(B) + 863700 * Math.Pow(Math.Sin(B), 4) -
                398600 * Math.Pow(Math.Sin(B), 6) )))));
            double y = (5 + 10 * n) * 100000 + l * Math.Cos(B) * (6378245 + 21346.1415 * Math.Sin(B) * Math.Sin(B) + 107.1590 * Math.Pow(Math.Sin(B), 4) +
                0.5977 * Math.Pow(Math.Sin(B), 6) + l * l * (1070204.16 - 2136826.66 * Math.Sin(B) * Math.Sin(B) + 17.98 * Math.Pow(Math.Sin(B), 4) - 11.99 * Math.Pow(Math.Sin(B), 6) + 
                l * l * (270806 - 1523417 * Math.Sin(B) * Math.Sin(B) + 1327645 * Math.Pow(Math.Sin(B), 4) - 21701 * Math.Pow(Math.Sin(B), 6) + l * l * ( 79690 -
                866190 * Math.Sin(B) * Math.Sin(B) + 1730360 * Math.Pow(Math.Sin(B), 4) - 945460 * Math.Pow(Math.Sin(B), 6) ))));



            result = x.ToString("0.0") + ", " + y.ToString("0.0");
            return result;
        }*/

        public static string toRectFromWGSwithFuckingJavaScript(double LatWGS, double LonWGS, double alt)
        {

            double lat = WGS84_SK42_Lat(LatWGS, LonWGS, alt);
            double lon = WGS84_SK42_Long(LatWGS, LonWGS, alt);
            string result = "";
            var latrad = Math.PI * lat / 180;
            var lonrad = Math.PI * lon / 180;

            var nzone = Math.Ceiling(lon / 6);
            var lonaxis = 6 * nzone - 3;
            var l = Math.PI * (lon - lonaxis) / 180;


            var N = 6399698.902 - (21562.267 - (108.973 - 0.612 * Math.Pow(Math.Cos(latrad), 2)) * Math.Pow(Math.Cos(latrad), 2)) * Math.Pow(Math.Cos(latrad), 2);
            var a0 = 32140.404 - (135.3302 - (0.7092 - 0.0040 * Math.Pow(Math.Cos(latrad), 2)) * Math.Pow(Math.Cos(latrad), 2)) * Math.Pow(Math.Cos(latrad), 2);
            var a3 = (0.3333333 + 0.001123 * Math.Pow(Math.Cos(latrad), 2)) * Math.Pow(Math.Cos(latrad), 2) - 0.1666667;
            var a4 = (0.25 + 0.00252 * Math.Pow(Math.Cos(latrad), 2)) * Math.Pow(Math.Cos(latrad), 2) - 0.04166;
            var a5 = 0.0083 - (0.1667 - (0.1968 + 0.0040 * Math.Pow(Math.Cos(latrad), 2)) * Math.Pow(Math.Cos(latrad), 2)) * Math.Pow(Math.Cos(latrad), 2);
            var a6 = (0.166 * Math.Pow(Math.Cos(latrad), 2) - 0.084) * Math.Pow(Math.Cos(latrad), 2);

            var tx = 6367558.4969 * latrad - (a0 - (0.5 + (a4 + a6 * l * l) * l * l) * l * l * N) * Math.Sin(latrad) * Math.Cos(latrad);
            var ty = (1 + (a3 + a5 * l * l) * l * l) * l * N * Math.Cos(latrad);
            ty = 500000 + ty;

            //var pr = PCF.getCalcPrecision();
            //ty = ty.toFixed(pr);
            double y = double.Parse(nzone.ToString() + ty.ToString());
            //x.SetValue(tx);
            //y.SetValue(Number(nzone.toString() + ty));
            result = tx.ToString("0.00") + ", " + y.ToString("0.00");
            return result;
        }

        public static string toWGS_From_Rect(double x, double y) 
        {
            string result = "";
            var rho = 206264.8062;
            var beta = (x / 6367558.4969) * rho;
            var nzone = y < 1000000 ? Math.Floor(y / 100000) : Math.Floor(y / 1000000);
            var zoneaxis = nzone * 6 - 3;
            var y1 = y - nzone * 1000000;
            var yl = y1 - 500000;
            var betarad = Math.PI * (beta / 3600) / 180;

            var phixsec = beta + (50221746 + (293622 + (2350 + 22 * Math.Pow(Math.Cos(betarad), 2)) * Math.Pow(Math.Cos(betarad), 2)) * Math.Pow(Math.Cos(betarad), 2)) * Math.Pow(10, -10) * Math.Sin(betarad) * Math.Cos(betarad) * rho;
            var phixrad = Math.PI * (phixsec / 3600) / 180;

            var Nx = 6399698.902 - (21562.267 - (108.973 - 0.612 * Math.Pow(Math.Cos(phixrad), 2)) * Math.Pow(Math.Cos(phixrad), 2)) * Math.Pow(Math.Cos(phixrad), 2);

            var z = yl / (Nx * Math.Cos(phixrad));

            var b2 = (0.5 + 0.003369 * Math.Pow(Math.Cos(phixrad), 2)) * Math.Sin(phixrad) * Math.Cos(phixrad);
            var b3 = 0.333333 - (0.166667 - 0.001123 * Math.Pow(Math.Cos(phixrad), 2)) * Math.Pow(Math.Cos(phixrad), 2);
            var b4 = 0.25 + (0.16161 + 0.00562 * Math.Pow(Math.Cos(phixrad), 2)) * Math.Pow(Math.Cos(phixrad), 2);
            var b5 = 0.2 - (0.1667 - 0.0088 * Math.Pow(Math.Cos(phixrad), 2)) * Math.Pow(Math.Cos(phixrad), 2);

            var l = (1 - (b3 - b5 * z * z) * z * z) * z * rho;
            var phi = phixsec - (1 - (b4 - 0.12 * z * z) * z * z) * z * z * b2 * rho;
            var lambda = zoneaxis + (l / 3600);
            result = (phi / 3600).ToString() + ", " + lambda.ToString();
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

        public static double WGS84_SK42_Lat(double Bd, double Ld, double H) 
        {
            return Bd - dB(Bd, Ld, H) / 3600;
        }

        public static double WGS84_SK42_Long(double Bd, double Ld, double H)
        {
            return Ld - dL(Bd, Ld, H) / 3600;
        }

        public static double SK42_WGS84_Lat(double Bd, double Ld, double H)
        {
            return Bd + dB(Bd, Ld, H) / 3600;
        }

        public static double SK42_WGS84_Long(double Bd, double Ld, double H)
        {
            return Ld + dL(Bd, Ld, H) / 3600;
        }

    }
}
