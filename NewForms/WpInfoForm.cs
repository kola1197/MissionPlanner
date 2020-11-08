using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.Utilities;
using CustomMessageBox = MissionPlanner.MsgBox.CustomMessageBox;

namespace MissionPlanner.NewForms
{
    public partial class WpInfoForm : Form
    {
        public WpInfoForm()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(200, 32, 32, 32);
            this.wpInfoControl.BackColor = Color.FromArgb(200, 32, 32, 32);
            DoubleBuffered = true;
        }
    }
}
