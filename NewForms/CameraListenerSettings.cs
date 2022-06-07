using System;
using System.Windows.Forms;
using MissionPlanner.GCSViews;
using MissionPlanner.NewClasses;

namespace MissionPlanner.NewForms
{
    public partial class CameraListenerSettings : Form
    {
        private CameraListener cameraListener;
        public CameraListenerSettings(ref CameraListener _cameraListener)
        {
            cameraListener = _cameraListener;
            InitializeComponent();
            UpdateColors();
        }

        

        private void activeCameraViewAreaColorBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                cameraListener.activeAreaColor = colorDialog1.Color;
            }
            UpdateColors();
        }

        private void CameraOldViewAreaColor_MouseClick(object sender, MouseEventArgs e)
        {
            /*if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                cameraListener.outdatedAreaColor = colorDialog1.Color;
            }
            UpdateColors();
            FlightPlanner.CameraAreaOverlay.Markers.Clear();
            FlightPlanner.instance.setCameraPolygon();*/
        }

        private void UpdateColors()
        {
            activeCameraViewAreaColorBox.BackColor = cameraListener.activeAreaColor;
            cameraOutdatedViewAreaColorBox.BackColor = cameraListener.outdatedAreaColor;
            drawCameraAreaCheckBox.Checked = cameraListener.GetAreaVisible();
            drawCrossHairCheckBox.Checked = cameraListener.GetCrossHairVisible();
        }

        private void CameraListenerSettings_Shown(object sender, EventArgs e)
        {
            UpdateColors();
        }

        private void drawCameraAreaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            cameraListener.SetAreaVisible(drawCameraAreaCheckBox.Checked);
        }

        private void drawCrossHairCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            cameraListener.SetCrossHairVisible(drawCrossHairCheckBox.Checked);

        }
    }
}