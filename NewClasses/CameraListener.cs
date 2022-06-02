using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
        private const int port = 13200;
        string server = "127.0.0.1";
        /// <summary>
        /// TODO: Switch to Task
        /// </summary>
        private Thread thread;
        private bool threadActive = false;
        public CameraListener()
        {
            points = new List<Point>();
            thread = new Thread(threadVoid);
        }

        public void start()
        {
            var mapStartPoints = new List<PointLatLng>();
            FlightPlanner.CameraAreaOverlay.Polygons.Add(new GMapPolygon(mapStartPoints, "cameraPolygon"));
            FlightPlanner.CameraAreaOverlay.Polygons.First().PolyColor = Color.Yellow;
            // FlightPlanner.CameraAreaOverlay.Polygons.First().Stroke = new Pen(Color.Red, 2);
            thread.Start();
        }

        public void stop()
        {
            threadActive = false;
        }

        private void threadVoid()
        {
            threadActive = true;
            
            while (threadActive)
            {
                try {
                    TcpClient client = new TcpClient();
                    client.Connect(server, port);
                    NetworkStream stream = client.GetStream();

                    while (true)
                    {
                        byte[] data = new byte[256];
                        StringBuilder response = new StringBuilder();
                        List<byte> bigData = new List<byte>();


                        int i = 0;
                        while (stream.DataAvailable == true)
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

                                List<byte> viewData = new List<byte>();
                                for (int j = 0; j < len1; j++)
                                {
                                    viewData.Add(bigData[j + 22]);
                                }

                                InfoPacket infoPacket = InfoPacket.Parser.ParseFrom(smallData.ToArray());
                                //
                                //Console.WriteLine(infoPacket.ToString());
                                
                                ViewArea viewArea = ViewArea.Parser.ParseFrom(infoPacket.Data);
                                // Console.WriteLine(viewArea.ToString());
                                //string points = " ";
                                // Console.WriteLine(viewArea.Points.ToString());
                                points.Clear();
                                foreach (Point point in viewArea.Points)
                                {
                                    //Console.WriteLine(point.Geo.ToString());
                                    //points += point.Geo.Latitude + ", " + point.Geo.Longitude + ", " + point.Geo.Altitude +" | ";
                                    points.Add(point);
                                }
                                //Console.WriteLine("----------");
                                FlightPlanner.instance.setCameraPolygon();
                            }
                            catch (Exception e)
                            {
                            }
                        }
                        // Thread.Sleep(1000);
                    }
                    stream.Close();
                    client.Close();
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: {0}", e.Message);
                }
            }
        }
    }
}