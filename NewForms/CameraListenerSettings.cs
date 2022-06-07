using System;
using System.Linq;
using System.Threading.Tasks;
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
                FlightPlanner.CameraAreaOverlay.Polygons.First().PolyColor = cameraListener.activeAreaColor;
            }
            UpdateColors();
        }

        private void CameraOldViewAreaColor_MouseClick(object sender, MouseEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                cameraListener.outdatedAreaColor = colorDialog1.Color;
                FlightPlanner.CameraAreaOverlay.Polygons.First().PolyColor = cameraListener.outdatedAreaColor;
            }
            UpdateColors();
            //FlightPlanner.CameraAreaOverlay.Markers.Clear();
            Task.Run(() => { FlightPlanner.instance.setCameraPolygon(); });
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
            UpdateColors();
        }

        private void drawCrossHairCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            cameraListener.SetCrossHairVisible(drawCrossHairCheckBox.Checked);
            UpdateColors();

        }

        private void CameraListenerSettings_VisibleChanged(object sender, EventArgs e)
        {
            UpdateColors();
        }

        private void CameraListenerSettings_LocationChanged(object sender, EventArgs e)
        {
            UpdateColors();
        }
    }
}