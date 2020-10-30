﻿using System.Windows.Forms;

namespace MissionPlanner
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();

            string strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //TXT_version.Text = "Version: " + Application.ProductVersion; // +" Build " + strVersion;

            if (Program.Logo != null)
            {
                pictureBox1.BackgroundImage = MissionPlanner.Properties.Resources.bgdark;
                pictureBox1.Image = Program.Logo;
                pictureBox1.Visible = true;
            }
            Text = "Загрузка НПУ";
        }

        private void label3_Click(object sender, System.EventArgs e)
        {

        }

        private void label2_Click(object sender, System.EventArgs e)
        {

        }
    }
}