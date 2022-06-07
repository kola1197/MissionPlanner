using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.GCSViews;
using MissionPlanner.NewClasses;

namespace MissionPlanner.NewForms
{
    public partial class CameraListenerSettings : Form, IFormConnectable
    {
        private CameraListener cameraListener;

        public CameraListenerSettings(ref CameraListener _cameraListener)
        {
            cameraListener = _cameraListener;
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            UpdateColors();
        }

        private void activeCameraViewAreaColorBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                cameraListener.activeAreaColor = colorDialog1.Color;
                if (cameraListener.cyclesWithoutPacket <= 5)
                {
                    FlightPlanner.CameraAreaOverlay.Polygons.First().PolyColor = cameraListener.activeAreaColor;
                }
            }

            UpdateColors();
        }

        private void CameraOldViewAreaColor_MouseClick(object sender, MouseEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                cameraListener.outdatedAreaColor = colorDialog1.Color;
                if (cameraListener.cyclesWithoutPacket > 5)
                {
                    FlightPlanner.CameraAreaOverlay.Polygons.First().PolyColor = cameraListener.outdatedAreaColor;
                }
            }

            UpdateColors();
            //FlightPlanner.CameraAreaOverlay.Markers.Clear();
            Task.Run(() => { FlightPlanner.instance.setCameraPolygon(); });
        }

        // TODO: Bindings
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
            SetToTop();
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

        public void SetFormLocation()
        {
            Location = new Point(MainV2.instance.Location.X + 670,
                MainV2.instance.GetLowerPanelLocation().Y - this.Height + 20);
        }

        public void SetToTop()
        {
            TopMost = true;
        }

        private void CameraListenerSettings_Leave(object sender, EventArgs e)
        {
            UpdateColors();
        }


        private void cameraOutdatedViewAreaColorBox_Enter(object sender, EventArgs e)
        {
            UpdateColors();
        }

        private void CameraListenerSettings_Move(object sender, EventArgs e)
        {
        }

        private void CameraListenerSettings_Paint(object sender, PaintEventArgs e)
        {
        }

        private void CameraListenerSettings_MouseEnter(object sender, EventArgs e)
        {
        }

        private void cameraOutdatedViewAreaColorBox_BackColorChanged(object sender, EventArgs e)
        {
            UpdateColors();
        }

        private void activeCameraViewAreaColorBox_BackColorChanged(object sender, EventArgs e)
        {
            UpdateColors();
        }
    }
}