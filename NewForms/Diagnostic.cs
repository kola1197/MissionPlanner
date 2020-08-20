using Flurl.Util;
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
    public partial class DiagnosticForm : Form
    {
        public DiagnosticForm()
        {
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine(MainV2.CurrentAircraftNum.ToString());
            updateInfo();
        }

        public void updateInfo() 
        {
            //label3.Text = MainV2.comPort.;
        }
    
    }
}
