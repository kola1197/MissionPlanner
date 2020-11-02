using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.NewForms;

namespace MissionPlanner.Controls.NewControls
{
    public partial class SNSControl : UserControl
    {
        private ModeChangeForm modeChangeForm;
        private SNSInfo snsInfo;
        private VibeGraph frm;
        private ParachuteForm parachuteForm;
        bool colorsChanged=false;
        public SNSControl()
        {
            InitializeComponent();
            

        }

        public void setButtonColors() 
        {
            if (!colorsChanged)
            {
                colorsChanged = true;
                myButton1.BGGradBot = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
                myButton2.BGGradBot = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
                myButton3.BGGradBot = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
                myButton4.BGGradBot = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));

                myButton1.BGGradTop = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
                myButton2.BGGradTop = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
                myButton3.BGGradTop = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
                myButton4.BGGradTop = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));

                myButton1.ForeColor = Color.Black;
                myButton2.ForeColor = Color.Black;
                myButton3.ForeColor = Color.Black;
                myButton4.ForeColor = Color.Black;
                myButton1.TextColor = Color.Black;
                myButton2.TextColor = Color.Black;
                myButton3.TextColor = Color.Black;
                myButton4.TextColor = Color.Black;
            }
        }

        private void myButton1_MouseUp(object sender, MouseEventArgs e)
        {
            if (snsInfo != null) 
            {
                snsInfo.Close();
            }
            snsInfo = new SNSInfo();
            snsInfo.Show();
        }

        private void myButton2_MouseUp(object sender, EventArgs e)
        {
            modeChangeForm = new ModeChangeForm();
            modeChangeForm.Show();
        }

        

        private void myButton3_MouseUp(object sender, MouseEventArgs e)
        {
            if (frm != null) {
                frm.Close();
            }
            //frm = new Vibration();
            frm = new VibeGraph();
            frm.TopMost = true;
            frm.timer1.Enabled = true;
            frm.Show();
        }

        public void openParachuteForm() 
        {
            if (parachuteForm != null)
            {
                parachuteForm.Close();
            }
            else
            {
                parachuteForm = new ParachuteForm();
                parachuteForm.TopMost = true;
                parachuteForm.Show();
            }
        }

        private void myButton4_MouseUp(object sender, MouseEventArgs e)
        {
            //openParachuteForm();
            if (parachuteForm != null)
            {
                parachuteForm.Close();
            }
            parachuteForm = new ParachuteForm();
            parachuteForm.TopMost = true;
            parachuteForm.Show();

        }
    }
}
