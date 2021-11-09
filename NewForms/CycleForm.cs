using System;
using System.Drawing;
using System.Windows.Forms;


namespace MissionPlanner.NewForms
{
    public partial class CycleForm : Form
    {
        public CycleForm()
        {
            InitializeComponent();
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
        }

        private void startPoint_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            bool b = int.TryParse(startPoint.Text, out i);
            if (b && i > 0)
            {
                label4.Visible = false;
            }
            else
            {
                label4.ForeColor = Color.Crimson;
                label4.Visible = true;
            }      
        }

        private void endPoint_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            bool b = int.TryParse(endPoint.Text, out i);
            if (b && i > 0)
            {
                label5.Visible = false;
            }
            else
            {
                label5.ForeColor = Color.Crimson;
                label5.Visible = true;
            }      
        }

        private void countOfRepeats_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            bool b = int.TryParse(countOfRepeats.Text, out i);
            if (b && i > 0)
            {
                label6.Visible = false;
            }
            else
            {
                label6.ForeColor = Color.Crimson;
                label6.Visible = true;
            }              }
    }
}