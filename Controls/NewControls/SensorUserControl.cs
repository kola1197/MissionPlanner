﻿using System;
using System.Drawing;
using System.Windows.Forms;
using MissionPlanner.Orlan;

namespace MissionPlanner.Controls.NewControls
{
    public partial class SensorUserControl : UserControl, ICustomClick
    {
        public SensorUserControl()
        {
            InitializeComponent();
        }

        public virtual System.Drawing.Size ControlSize { get; }
        public virtual event EventHandler CustomOnClick;
    }
}