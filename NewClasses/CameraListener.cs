using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;
using MissionPlanner.GCSViews;
using Rdmp;
using Point = Rdmp.Point;

namespace MissionPlanner.NewClasses
{
    public class CameraListener
    {
        public List<Point> points;
        public Point CrossHairPoint;
        private const int port = 13200;
        string server = "127.0.0.1";
        /// <summary>
        /// TODO: Switch to Task
        /// </summary>
        private Thread thread;
        private bool needToStop = false;
        private bool areaVisible = true;
        private bool crossHairVisible = true;
        private int cyclesWithoutPacket = 0;
        private bool pointUpdated = true;
        public Color activeAreaColor = Color.Yellow;
        public Color outdatedAreaColor = Color.Black;
        public CameraListener()
        {
            points = new List<Point>();
            // thread = new Thread(threadVoid);
            // thread.IsBackground = true;
        }

        public void start()
        {
            var mapStartPoints = new List<PointLatLng>();
            FlightPlanner.CameraAreaOverlay.Polygons.Add(new GMapPolygon(mapStartPoints, "cameraPolygon"));
            FlightPlanner.CameraAreaOverlay.Polygons.First().PolyColor = activeAreaColor;
            // FlightPlanner.CameraAreaOverlay.Polygons.First().Stroke = new Pen(Color.Red, 2);
            //thread.Start();
            Task.Run(() => { threadVoid(); });
        }

        public void stop()
        {
            needToStop = true;
        }

        public void SetAreaVisible(bool _visible)
        {
            areaVisible = _visible;
            FlightPlanner.CameraAreaOverlay.IsVisibile = areaVisible;
        }
        
        public bool GetAreaVisible()
        {
            return areaVisible;
        }
        
        public void SetCrossHairVisible(bool _visible)
        {
            crossHairVisible = _visible;
            FlightPlanner.CameraCrosshairOverlay.IsVisibile = crossHairVisible;
        }
        
        public bool GetCrossHairVisible()
        {
            return crossHairVisible;
        }

        private void threadVoid()
        {
            needToStop = false;
            while (!needToStop)
            {
                try {
                    TcpClient client = new TcpClient();
                    client.Connect(server, port);
                    NetworkStream stream = client.GetStream();
                    cyclesWithoutPacket = 0;
                    while (cyclesWithoutPacket < 10 && !needToStop)
                    {
                        pointUpdated = false;
                        byte[] data = new byte[256];
                        StringBuilder response = new StringBuilder();
                        List<byte> bigData = new List<byte>();


                        int i = 0;
                        while (stream.DataAvailable && !needToStop)
                        {
                            bigData.Add((byte) stream.ReadByte());
                            i++;
                        }

                        if (bigData.ToArray().Length > 0)
                        {
                            try
                            {
                                byte[] first = new byte[4];
                                byte[] second = new byte[8];
                                for (int j = 0; j < 4; j++)
                                {
                                    first[j] = bigData[j];
                                }

                                for (int j = 0; j < 8; j++)
                                {
                                    second[j] = bigData[j + 4];
                                }

                                int len1 = BitConverter.ToInt32(first,0);
                                int len2 = BitConverter.ToInt32(second,0);

                                List<byte> smallData = new List<byte>();
                                for (int j = 0; j < len1; j++)
                                {
                                    smallData.Add(bigData[j + 14]);
                                }

                                InfoPacket infoPacket = InfoPacket.Parser.ParseFrom(smallData.ToArray());
                                ViewArea viewArea = ViewArea.Parser.ParseFrom(infoPacket.Data);
                                points.Clear();
                                double lat = 0;
                                double lon = 0;
                                double alt = 0;
                                string s = "P: "; foreach (Point point in viewArea.Points)
                                { 
                                    points.Add(point);
                                    pointUpdated = true;
                                    cyclesWithoutPacket = 0;
                                    FlightPlanner.CameraAreaOverlay.Polygons.First().PolyColor = activeAreaColor;
                                    s += point.Geo.Latitude.ToString() + ", " + point.Geo.Longitude.ToString() + 
                                         "  || ";
                                    lat += point.Geo.Latitude;
                                    lon += point.Geo.Longitude;
                                    alt += point.Geo.Altitude;
                                    
                                    //MainV2.instance.debugLabel.Text = "got pt: " + point.ToString();
                                }

                                GeoCoordinates geo = new GeoCoordinates{ Latitude= lat/4,Longitude = lon/4,Altitude = alt/4};
                                CrossHairPoint = new Point{Geo = geo};
                                MainV2.instance.debugLabel.Text = s;
                                FlightPlanner.instance.SetCameraCrosshair();
                                FlightPlanner.instance.setCameraPolygon();
                            }
                            catch (Exception e)
                            {
                                MainV2.instance.debugLabel.Text = e.ToString();
                            }
                        }
                        if (!pointUpdated)
                        {
                            cyclesWithoutPacket++;
                            MainV2.instance.debugLabel.Text = "CWP = " + cyclesWithoutPacket.ToString();
                            if (cyclesWithoutPacket >= 5)
                            {
                                FlightPlanner.CameraAreaOverlay.Polygons.First().PolyColor = outdatedAreaColor;
                            }
                            FlightPlanner.instance.SetCameraCrosshair();
                            FlightPlanner.instance.setCameraPolygon();
                        }
                        Thread.Sleep(1000);
                    }
                    stream.Close();
                    client.Close();
                }
                catch (SocketException e)
                {
                    System.Diagnostics.Debug.WriteLine("SocketException: {0}", e);
                    MainV2.instance.debugLabel.Text = e.ToString();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Exception: {0}", e.Message);
                    MainV2.instance.debugLabel.Text = e.ToString();
                }
            }
        }
    }
}