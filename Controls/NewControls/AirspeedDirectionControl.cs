using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.Controls.NewControls
{
    public partial class AirspeedDirectionControl : UserControl
    {
        public AirspeedDirectionControl()
        {
            InitializeComponent();
        }
        Bitmap bitmap;
        Bitmap bitmap1;
        int counter = 0;
        public void updateData() 
        {
            label1.Text = MainV2.comPort.MAV.cs.airspeed.ToString("0.0");
            bitmap = new Bitmap(global::MissionPlanner.Properties.Resources.airspeedDirection);
            if (MainV2.comPort.MAV.cs.connected)
            {
                bitmap1 = RotateImage(bitmap, MainV2.comPort.MAV.cs.wind_dir);
            }
            else 
            {
                bitmap1 = RotateImage(bitmap, counter);
                //counter++;
            }
            this.BackgroundImage = bitmap1;

        }

        private Bitmap RotateImage(Bitmap bmp, float angle)
        {
            Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
            rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Set the rotation point to the center in the matrix
                g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                // Rotate
                g.RotateTransform(angle);
                // Restore rotation point in the matrix
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                // Draw the image on the bitmap
                g.DrawImage(bmp, new Point(0, 0));
            }

            return rotatedImage;
        }
    }
}
