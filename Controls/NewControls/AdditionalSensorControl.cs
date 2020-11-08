using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.Utilities;

namespace MissionPlanner.Controls.NewControls
{
    public partial class AdditionalSensorControl : SensorUserControl
    {
        public override System.Drawing.Size ControlSize => this.MinimumSize;

        private Binding textBinding;
        private BindingSource textBindingSource;

        public string sensorName
        {
            get { return sensorName_label.Text; }
            set
            {
                //sensorName_label.Text = value;
                switch (value)
                {
                    case "Напряжение":
                        textBinding = new Binding("Text", textBindingSource, "battery_voltage",
                            true);
                        textBinding.Format += voltage_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        sensorName_label.Text = "Напряжение";
                        break;
                    case "Температура двигателя":
                        textBinding = new Binding("Text", textBindingSource, "rpm2",
                            true);
                        textBinding.Format += temp_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        sensorName_label.Text = "Т. двигателя";
                        break;
                    case "Топливо":
                        textBinding = new Binding("Text", textBindingSource, "battery_voltage2",
                            true);
                        textBinding.Format += fuel_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        sensorName_label.Text = "Топливо";
                        break;
                    case "Воздушная скорость":
                        textBinding = new Binding("Text", textBindingSource, "airspeed",
                            true);
                        textBinding.Format += speed_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        sensorName_label.Text = "Воз. скорость";
                        break;
                    case "Путевая скорость":
                        textBinding = new Binding("Text", textBindingSource, "groundspeed",
                            true);
                        textBinding.Format += speed_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        sensorName_label.Text = "Пут. скорость";
                        break;
                    case "Высота (СНС)":
                        textBinding = new Binding("Text", textBindingSource, "altasl",
                            true);
                        textBinding.Format += alt_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        sensorName_label.Text = "Высота (СНС)";
                        break;
                    case "Магнитный курс":
                        textBinding = new Binding("Text", textBindingSource, "yaw",
                            true);
                        textBinding.Format += bearing_format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        sensorName_label.Text = "Магн. курс";
                        break;
                    case "Следующая точка":
                        textBinding = new Binding("Text", textBindingSource, "SerialNum",
                            true);
                        textBinding.Format += nextWP_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        sensorName_label.Text = "След. точка";
                        break;
                    case "Сила тока":
                        textBinding = new Binding("Text", textBindingSource, "current",
                            true);
                        textBinding.Format += amperage_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        sensorName_label.Text = "Сила тока";
                        break;
                    default:
                        sensorValue = "wrong sensor name";
                        break;
                }
            }
        }

        public string sensorValue
        {
            get { return sensorValue_label.Text; }
            set { sensorValue_label.Text = sensorValue; }
        }

        private void bearing_format(object sender, ConvertEventArgs e)
        {
            int bearing =  (int) Math.Truncate(Convert.ToDouble(e.Value));
            e.Value = bearing + "°";
        }
        
        private void voltage_Format(object sender, ConvertEventArgs e)
        {
            double voltage = (double) e.Value;
            e.Value = voltage.ToString("F1") + " V";
        }

        private void temp_Format(object sender, ConvertEventArgs e)
        {
            double temp = (float) e.Value;
            e.Value = temp.ToString("F1") + "°";
        }

        private void fuel_Format(object sender, ConvertEventArgs e)
        {
            double fuel = (double) e.Value;
            e.Value = StatusControlPanel.instance.CalcFuelPercentage() + "%";
        }

        private void speed_Format(object sender, ConvertEventArgs e)
        {
            double speed = (float) e.Value * 3.6;
            e.Value = speed.ToString("F0") + " км/ч";
        }

        private void alt_Format(object sender, ConvertEventArgs e)
        {
            double alt = (float) e.Value;
            e.Value = alt.ToString("F0") + " м";
        }

        private void nextWP_Format(object sender, ConvertEventArgs e)
        {
            e.Value = "№ " + e.Value.ToString();
        }

        private void amperage_Format(object sender, ConvertEventArgs e)
        {
            double amp = (double) e.Value;
            e.Value = amp.ToString("F1") + " A";
        }

        public AdditionalSensorControl(BindingSource bindingSource)
        {
            textBindingSource = bindingSource;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void AdditionalSensorControl_Click(object sender, EventArgs e)
        {
            StatusControlPanel.instance.sensorsStrip_Click(sender, e);
        }

        public override event EventHandler CustomOnClick
        {
            add
            {
                base.Click += value;
                foreach (Control control in Controls)
                {
                    control.Click += value;
                }
            }
            remove
            {
                base.Click -= value;
                foreach (Control control in Controls)
                {
                    control.Click -= value;
                }
            }
        }
    }
}