using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotSpatial.Topology;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MissionPlanner.GCSViews;
using MissionPlanner.NewClasses;
using HRGN = System.IntPtr;
using HWND = System.IntPtr;

namespace MissionPlanner.Controls.NewControls
{
    public partial class WPMenu : UserControl
    {
        // [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        // private static extern IntPtr CreateRoundRectRgn
        // (
        //    int nLeftRect, // x-coordinate of upper-left corner
        //    int nTopRect, // y-coordinate of upper-left corner
        //    int nRightRect, // x-coordinate of lower-right corner
        //    int nBottomRect, // y-coordinate of lower-right corner
        //    int nWidthEllipse, // height of ellipse
        //    int nHeightEllipse // width of ellipse
        // );

        public bool IsWpDistanceDrawing = false;
        public bool fieldActive = false;
        public WPMenu()
        {
            InitializeComponent();
            Region = ControlDrawingTools.CreateRoundRectRgn(-20, 0, Width, Height, 25);
            this.BackColor = Color.FromArgb(200,64,64,64);
            //this.label3.Parent = this.mainButton;
            //updateField();
        }

        public bool progressBarVisible = false;

        private void updateField()
        {
           
            //this.Location = fieldActive ? new System.Drawing.Point(now.X,now.Y - diff) : new System.Drawing.Point(now.X, now.Y + diff);

            //panel1.Visible = fieldActive;
            //panel2.Visible = fieldActive;
            //panel3.Visible = fieldActive;
            //panel4.Visible = fieldActive;
            //panel5.Visible = fieldActive;
            //panel6.Visible = fieldActive;
            loadButton.Visible = fieldActive;
            saveButton.Visible = fieldActive;
            altButton.Visible = fieldActive;
            writeButton.Visible = fieldActive;
            getButton.Visible = fieldActive;
            deleteButton.Visible = fieldActive;
            myButton1.Visible = fieldActive;
            label11.Visible = fieldActive;
            label10.Visible = fieldActive;
            label9.Visible = fieldActive;
            label8.Visible = fieldActive;
            label7.Visible = fieldActive;
            label6.Visible = fieldActive;
            label5.Visible = fieldActive;
            this.Size = fieldActive ? new Size(95, 733) : new Size(95, 125);
            this.BackColor = Color.FromArgb(200, 32, 32, 32);
            //MainV2.wpLoadMenuAcrive = 

            System.Drawing.Point now = this.Location;
            int diff = 420;
        }

        private void myButton5_Click(object sender, EventArgs e)
        {

        }

        private void mainButton_Click(object sender, EventArgs e)
        {

        }

        private void mainButton_Click(object sender, MouseEventArgs e)
        {
            fieldActive = !fieldActive;
            updateField();
        }

        private void WPMenu_Load(object sender, EventArgs e)
        {
            fieldActive = !fieldActive;
            updateField();
            fieldActive = !fieldActive;
            updateField();
        }

        /*private void driweForm(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath form_path = new System.Drawing.Drawing2D.GraphicsPath();
            form_path.
        }*/

        private void updateValues() 
        {
            try
            {
                if (progressBar1.Visible != progressBarVisible)
                {
                    progressBar1.Value = 0;
                    progressBar1.Visible = progressBarVisible;
                }

                //label1.Text = MainV2.comPort.MAV.cs.wpno.ToString();
                mainButton.Text = FlightPlanner.WpSerialNum.SerialNum.ToString();
                label2.Text = MainV2.instance.FlightPlanner.Commands.Rows.Count.ToString();
                label3.Text = MainV2.comPort.MAV.cs.wp_dist.ToString();
            }
            catch
            {
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateValues();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void loadButton_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void myButton1_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsWpDistanceDrawing = !IsWpDistanceDrawing;
        }
    }
}
