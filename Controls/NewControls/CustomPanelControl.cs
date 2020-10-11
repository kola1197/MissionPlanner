using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.Orlan;

namespace MissionPlanner.Controls.NewControls
{
    public partial class CustomPanelControl : UserControl, ICustomClick
    {
        public CustomPanelControl()
        {
            InitializeComponent();
        }

        public virtual event EventHandler CustomOnClick;
    }
}
