using System;
using System.Drawing;
using System.Windows.Forms;
using MissionPlanner.NewForms;

namespace MissionPlanner.Controls.NewControls
{
    public partial class SNSControl : UserControl
    {
        private static ModeChangeForm _modeChangeForm = new ModeChangeForm {Visible = false};
        private static SNSInfo _snsInfo = new SNSInfo {Visible = false};
        private static VibeGraph _frm = new VibeGraph {Visible = false};
        private static ParachuteForm _parachuteForm = new ParachuteForm {Visible = false};
        bool colorsChanged;

        public SNSControl()
        {
            InitializeComponent();
        }

        public void setButtonColors()
        {
            if (!colorsChanged)
            {
                colorsChanged = true;
                myButton1.BGGradBot = Color.FromArgb(196, 196,
                    196);
                myButton2.BGGradBot = Color.FromArgb(196, 196,
                    196);
                myButton3.BGGradBot = Color.FromArgb(196, 196,
                    196);
                myButton4.BGGradBot = Color.FromArgb(196, 196,
                    196);
                cameraSettingsButton.BGGradBot = Color.FromArgb(196, 196,
                    196);

                myButton1.BGGradTop = Color.FromArgb(196, 196,
                    196);
                myButton2.BGGradTop = Color.FromArgb(196, 196,
                    196);
                myButton3.BGGradTop = Color.FromArgb(196, 196,
                    196);
                myButton4.BGGradTop = Color.FromArgb(196, 196,
                    196);
                cameraSettingsButton.BGGradTop = Color.FromArgb(196, 196,
                    196);

                myButton1.ForeColor = Color.Black;
                myButton2.ForeColor = Color.Black;
                myButton3.ForeColor = Color.Black;
                myButton4.ForeColor = Color.Black;
                cameraSettingsButton.ForeColor = Color.Black;

                myButton1.TextColor = Color.Black;
                myButton2.TextColor = Color.Black;
                myButton3.TextColor = Color.Black;
                myButton4.TextColor = Color.Black;
                cameraSettingsButton.TextColor = Color.Black;
            }
        }

        private void myButton1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_snsInfo.IsDisposed || !_snsInfo.Visible)
            {
                _snsInfo = new SNSInfo();
                _snsInfo.SetFormLocation();
                MainV2.FormConnector.ConnectForm(_snsInfo);
                _snsInfo.Show();
            }
            else
            {
                _snsInfo.Close();
            }
        }

        private void myButton2_MouseUp(object sender, EventArgs e)
        {
            if (_modeChangeForm.IsDisposed || !_modeChangeForm.Visible)
            {
                _modeChangeForm = new ModeChangeForm {Visible = false};
                _modeChangeForm.SetFormLocation();
                MainV2.FormConnector.ConnectForm(_modeChangeForm);
                _modeChangeForm.Show();
            }
            else
            {
                _modeChangeForm.Close();
            }
        }


        private void myButton3_MouseUp(object sender, MouseEventArgs e)
        {
            if (_frm.IsDisposed || !_frm.Visible)
            {
                _frm = new VibeGraph {Visible = false};
                _frm.SetFormLocation();
                MainV2.FormConnector.ConnectForm(_frm);
                _frm.timer1.Enabled = true;
                _frm.Show();
            }
            else
            {
                _frm.Close();
            }
            //frm = new Vibration();
        }

        public void openParachuteForm()
        {
            if (_parachuteForm.IsDisposed || !_parachuteForm.Visible)
            {
                _parachuteForm = new ParachuteForm {Visible = false};
                _parachuteForm.SetFormLocation();
                MainV2.FormConnector.ConnectForm(_parachuteForm);
                _parachuteForm.Show();
            }
            else
            {
                _parachuteForm.Close();
            }
        }

        private void myButton4_MouseUp(object sender, MouseEventArgs e)
        {
            //openParachuteForm();
            // if (parachuteForm != null)
            // {
            //     parachuteForm.Close();
            // }
            // parachuteForm = new ParachuteForm();
            // parachuteForm.TopMost = true;
            // parachuteForm.Show();
            Invoke((MethodInvoker) delegate { openParachuteForm(); });
        }

        private void cameraSettingsButton_MouseUp(object sender, MouseEventArgs e)
        {
            MainV2.instance.cameraListenerSettings?.Close();
            MainV2.instance.cameraListenerSettings = new CameraListenerSettings(ref MainV2.cameraListener)
                {Visible = false};
            MainV2.instance.cameraListenerSettings.SetFormLocation();
            MainV2.FormConnector.ConnectForm(MainV2.instance.cameraListenerSettings);
            MainV2.instance.cameraListenerSettings.Show();
        }
    }
}