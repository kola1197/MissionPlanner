using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.NewForms
{
    public partial class EngineControlForm : Form
    {
        public EngineControlForm()
        {
            InitializeComponent();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString() + "%";
        }


        private void myButton1_MouseUp(object sender, MouseEventArgs e)
        {
            Button senderButton = (Button)sender;
            string tag = senderButton.Tag.ToString();
            int i = int.Parse(tag);
            MainV2.currentEngineMode = i; 
            updateButtons(MainV2.currentEngineMode);
        }

        private void updateButtons(int i) 
        {
            System.Drawing.Color Botok = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(226)))), ((int)(((byte)(150)))));
            System.Drawing.Color Topok = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(193)))), ((int)(((byte)(31)))));
            System.Drawing.Color BotActive = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            System.Drawing.Color TopActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));

            myButton1.BGGradBot = 0 == i ? BotActive : Botok;
            myButton1.BGGradTop = 0 == i ? TopActive : Topok;

            myButton3.BGGradBot = 1 == i ? BotActive : Botok;
            myButton3.BGGradTop = 1 == i ? TopActive : Topok;

            myButton4.BGGradBot = 2 == i ? BotActive : Botok;
            myButton4.BGGradTop = 2 == i ? TopActive : Topok;

            myButton5.BGGradBot = 3 == i ? BotActive : Botok;
            myButton5.BGGradTop = 3 == i ? TopActive : Topok;

            myButton6.BGGradBot = 4 == i ? BotActive : Botok;
            myButton6.BGGradTop = 4 == i ? TopActive : Topok;
            label1.Text = trackBar1.Value.ToString() + "%";
        }

        private void EngineControlForm_Load(object sender, EventArgs e)
        {
            updateButtons(MainV2.currentEngineMode);
        }
    }
}
