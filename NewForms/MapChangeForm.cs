﻿using System;
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
    public partial class MapChangeForm : Form
    {
        public MapChangeForm()
        {
            InitializeComponent();
        }

        private void comboBoxMapType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainV2.selectedItem = comboBoxMapType.SelectedIndex;
        }
    }
}
