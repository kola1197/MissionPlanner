using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MissionPlanner.GCSViews;
using MissionPlanner.Maps;
using MissionPlanner.Orlan;
using MissionPlanner.Utilities;

namespace MissionPlanner.Controls.NewControls
{
    public partial class RegionsControl : UserControl
    {
        public static RegionsControl instance;
        private static int _regionNum = 1;

        public RegionsControl()
        {
            InitializeComponent();
            instance = this;
        }

        public GMapPolygon GetCurrentPolygon()
        {
            return (GMapPolygon) regionsBindingSource.Current;
        }

        public void Init()
        {
            regionsBindingSource.DataSource = FlightPlanner.RegionsOverlay.Polygons;

            regions_LB.DisplayMember = "Name";
            // regions_LB.ValueMember = "Name";
            regions_LB.DataSource = regionsBindingSource;

            // colorPanel.DataBindings.Add(new Binding("BackColor", regions_LB, "", true));
            // timer1.Enabled = true;
        }

        public void UpdateBindings()
        {
            if (regionsBindingSource.Count == 0)
            {
                return;
            }

            name_TB.DataBindings.Clear();
            colorPanel.DataBindings.Clear();

            regionsBindingSource.ResetBindings(false);

            // Pen polygonPen = ((GMapPolygon) regionsBindingSource.Current).Stroke;
            name_TB.DataBindings.Add(new Binding("Text", regionsBindingSource.Current, "Name", true));
            colorPanel.DataBindings.Add(new Binding("BackColor", regionsBindingSource.Current, "PolyColor", true));

            Latitude.DataPropertyName = "Lat";
            Longitude.DataPropertyName = "Lng";
            latLong_DGV.DataSource = ((GMapPolygon) regionsBindingSource.Current).Points;

            if (latLong_DGV.Columns.Contains("IsEmpty"))
            {
                latLong_DGV.Columns.Remove("IsEmpty");
            }
            this.Invalidate();
        }

        private void addRegion_BUT_Click(object sender, EventArgs e)
        {
            // CreateRegions();
            List<PointLatLng> points = new List<PointLatLng>();
            GMapPolygon polygon = new GMapPolygon(points, "Регион " + _regionNum);
            _regionNum++;
            FlightPlanner.RegionsOverlay.Polygons.Add(polygon);

            foreach (var overlayPolygon in FlightPlanner.RegionsOverlay.Polygons)
            {
                redrawPolygonSurvey(overlayPolygon);
            }

            UpdateBindings();
        }

        private void CreateRegions()
        {
            //testThrottle();
            //FlightPlanner.MainMap.Size = new Size(1920, FlightPlanner.MainMap.Size.Height);

            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(30.098767, 30));
            points.Add(new PointLatLng(60, 30));
            points.Add(new PointLatLng(60, 60));
            points.Add(new PointLatLng(30, 60));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            // polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Yellow));
            // polygon.Stroke = new Pen(Color.Yellow, 1);
            FlightPlanner.RegionsOverlay.Polygons.Add(polygon);

            List<PointLatLng> points1 = new List<PointLatLng>();
            points1.Add(new PointLatLng(20, 20));
            points1.Add(new PointLatLng(0, 30));
            points1.Add(new PointLatLng(0, 0));
            points1.Add(new PointLatLng(30, 0));
            GMapPolygon polygon1 = new GMapPolygon(points1, "mypolygon1");
            // polygon1.Fill = new SolidBrush(Color.FromArgb(50, Color.Blue));
            // polygon1.Stroke = new Pen(Color.Blue, 1);
            FlightPlanner.RegionsOverlay.Polygons.Add(polygon1);

            foreach (var overlayPolygon in FlightPlanner.RegionsOverlay.Polygons)
            {
                if (overlayPolygon.Points.Count > 1 &&
                    overlayPolygon.Points[0] == overlayPolygon.Points[overlayPolygon.Points.Count - 1])
                {
                    overlayPolygon.Points.RemoveAt(overlayPolygon.Points.Count - 1); // unmake a full loop
                }

                redrawPolygonSurvey(overlayPolygon);
            }

            // regions_LB.Items.Add(polygon.Name);
            // regions_LB.Items.Add(polygon1.Name);

            // GMapOverlay polyOverlay1 = new GMapOverlay("polygons");
            // polyOverlay1.Polygons.Add(polygon1);
            // FlightPlanner.MainMap.Overlays.Add(polyOverlay1);
            // //regionActive = !regionActive;
        }

        public void redrawPolygonSurvey(GMapPolygon polygon) //here wp markers lived
        {
            if (polygon.Points.Count == 0)
            {
                FlightPlanner.instance.MainMap.Invalidate();
                return;
            }
            UpdateBindings();

            PointLatLng[] pointCopyList = new PointLatLng[polygon.Points.Count];
            polygon.Points.CopyTo(pointCopyList);
            polygon.Points.Clear();
            FlightPlanner.RegionsOverlay.Markers.Clear();

            int tag = 0;
            pointCopyList.ForEach(x =>
            {
                tag++;
                polygon.Points.Add(x);
                addpolygonmarkergrid(tag.ToString(), x.Lng, x.Lat, 0);
            });

            FlightPlanner.instance.MainMap.UpdatePolygonLocalPosition(polygon);

            // foreach (var pointLatLngAlt in polygon.Points.CloseLoop().PrevNowNext())
            // {
            //     var now = pointLatLngAlt.Item2;
            //     var next = pointLatLngAlt.Item3;
            //
            //     if (now == null || next == null)
            //         continue;
            //
            //     var mid = new PointLatLngAlt((now.Lat + next.Lat) / 2, (now.Lng + next.Lng) / 2, 0);
            //
            //     var pnt = new GMapMarkerPlus(mid);
            //     pnt.Tag = new FlightPlanner.midline() { now = now, next = next };
            //     FlightPlanner.RegionsOverlay.Markers.Add(pnt);
            // }


            FlightPlanner.instance.MainMap.Invalidate();
        }

        private void addpolygonmarkergrid(string tag, double lng, double lat, int alt)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, GMarkerGoogleType.red);
                m.ToolTipMode = MarkerTooltipMode.Never;
                m.ToolTipText = "grid" + tag;
                m.Tag = "grid" + tag;

                //MissionPlanner.GMapMarkerRectWPRad mBorders = new MissionPlanner.GMapMarkerRectWPRad(point, (int)float.Parse(TXT_WPRad.Text), MainMap);
                GMapMarkerRect mBorders = new GMapMarkerRect(point);
                {
                    mBorders.InnerMarker = m;
                }

                FlightPlanner.RegionsOverlay.Markers.Add(m);
                FlightPlanner.RegionsOverlay.Markers.Add(mBorders);
            }
            catch (Exception ex)
            {
                MainV2.log.Info(ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // this.Invalidate();
            // regionsBindingSource.ResetBindings(false);
        }

        private void regions_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GetCurrentPolygon() != null)
            {
                redrawPolygonSurvey(GetCurrentPolygon());
            }
        }

        private void name_TB_TextChanged(object sender, EventArgs e)
        {
            if (!name_TB.Focused)
            {
                return;
            }

            FlightPlanner.RegionsOverlay.Polygons[regions_LB.SelectedIndex].Name = name_TB.Text;
            UpdateBindings();
        }

        private void colorPanel_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ((GMapPolygon) regionsBindingSource.Current).PolyColor = colorDialog1.Color;
            }

            UpdateBindings();
        }

        private void deleteRegion_BUT_Click(object sender, EventArgs e)
        {
            GMapPolygon polygon = FlightPlanner.RegionsOverlay.Polygons[0];
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Yellow));
            polygon.Stroke = new Pen(Color.Yellow, 1);
        }

        private void latLong_DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*if (e.ColumnIndex == 0 && e.RowIndex > 0)
            {
                e.Value = e.RowIndex + 1;
                e.FormattingApplied = true;
                return;
            }

            try
            {
                e.Value = Convert.ToDouble(e.Value).ToString("F6");
                e.FormattingApplied = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
*/
        }

        private void latLong_DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void latLong_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(latLong_DGV.CurrentCellAddress.ToString());
        }

        private void latLong_DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (regionsBindingSource.Count == 0)
            {
                return;
            }

            for (int i = 0; i < ((GMapPolygon) regionsBindingSource.Current).Points.Count; i++)
            {
                PointLatLng point = ((GMapPolygon) regionsBindingSource.Current).Points[i];

                point.Lat = Convert.ToDouble(latLong_DGV.Rows[i].Cells[Latitude.Index].Value);
                point.Lng = Convert.ToDouble(latLong_DGV.Rows[i].Cells[Longitude.Index].Value);
            }
        }
    }
}