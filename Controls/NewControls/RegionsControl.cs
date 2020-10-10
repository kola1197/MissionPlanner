using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.IO;
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
        private static int _regionNum = 0;
        private int _rowInEdit = -1;
        private PointLatLng _pointInEdit;
        private ArrayList _regionPoints = new ArrayList();
        private int _latIndex, _lngIndex;
        private TextBox _editTextBox;

        private int RegionNum
        {
            get
            {
                _regionNum++;
                return _regionNum;
            }
        }

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

            _latIndex = latLong_DGV.Columns["Latitude"].Index;
            _lngIndex = latLong_DGV.Columns["Longitude"].Index;

            // colorPanel.DataBindings.Add(new Binding("BackColor", regions_LB, "", true));
            // timer1.Enabled = true;
        }

        private void EditTextBoxOnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void EditTextBoxOnTextChanged(object sender, EventArgs e)
        {
        }

        public void ClearRegionsProperties()
        {
            regionsProperties_GB.Enabled = false;
            latLong_DGV.Rows.Clear();
            latLong_DGV.Refresh();
            name_TB.Text = "";
        }

        private void ClearPropertiesBindings()
        {
            name_TB.DataBindings.Clear();
            colorPanel.DataBindings.Clear();
        }

        private bool ResetPropertiesBindings()
        {
            regionsBindingSource.ResetBindings(true);
            if (regionsBindingSource.Count == 0 || regionsBindingSource.Current == null)
                return false;

            pointsBindingSource.DataSource = ((GMapPolygon) regionsBindingSource.Current).Points;
            pointsBindingSource.ResetBindings(true);
            return true;
        }

        public void UpdateBindings()
        {
            regionsProperties_GB.Enabled = FlightPlanner.RegionsOverlay.Polygons.Count != 0;
            ClearPropertiesBindings();
            if (!ResetPropertiesBindings())
                return;

            name_TB.DataBindings.Add(new Binding("Text", regionsBindingSource.Current, "Name", true));
            colorPanel.DataBindings.Add(new Binding("BackColor", regionsBindingSource.Current, "PolyColor", true));

            Latitude.DataPropertyName = "Lat";
            Longitude.DataPropertyName = "Lng";
            latLong_DGV.DataSource = pointsBindingSource;

            if (latLong_DGV.Columns.Contains("IsEmpty"))
                latLong_DGV.Columns.Remove("IsEmpty");

            Invalidate();
        }

        private void addRegion_BUT_Click(object sender, EventArgs e)
        {
            List<PointLatLng> points = new List<PointLatLng>();
            GMapPolygon polygon = new GMapPolygon(points, "Регион " + RegionNum);

            FlightPlanner.RegionsOverlay.Polygons.Add(polygon);

            polygon.SetRandomColor();

            UpdateBindings();
            regions_LB.SelectedIndex = regions_LB.Items.Count - 1;

            RedrawAllPolygons();
        }

        // private void CreateRegions()
        // {
        //     //testThrottle();
        //     //FlightPlanner.MainMap.Size = new Size(1920, FlightPlanner.MainMap.Size.Height);
        //
        //     List<PointLatLng> points = new List<PointLatLng>();
        //     points.Add(new PointLatLng(30.098767, 30));
        //     points.Add(new PointLatLng(60, 30));
        //     points.Add(new PointLatLng(60, 60));
        //     points.Add(new PointLatLng(30, 60));
        //     GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
        //     // polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Yellow));
        //     // polygon.Stroke = new Pen(Color.Yellow, 1);
        //     FlightPlanner.RegionsOverlay.Polygons.Add(polygon);
        //
        //     List<PointLatLng> points1 = new List<PointLatLng>();
        //     points1.Add(new PointLatLng(20, 20));
        //     points1.Add(new PointLatLng(0, 30));
        //     points1.Add(new PointLatLng(0, 0));
        //     points1.Add(new PointLatLng(30, 0));
        //     GMapPolygon polygon1 = new GMapPolygon(points1, "mypolygon1");
        //     // polygon1.Fill = new SolidBrush(Color.FromArgb(50, Color.Blue));
        //     // polygon1.Stroke = new Pen(Color.Blue, 1);
        //     FlightPlanner.RegionsOverlay.Polygons.Add(polygon1);
        //
        //     foreach (var overlayPolygon in FlightPlanner.RegionsOverlay.Polygons)
        //     {
        //         if (overlayPolygon.Points.Count > 1 &&
        //             overlayPolygon.Points[0] == overlayPolygon.Points[overlayPolygon.Points.Count - 1])
        //         {
        //             overlayPolygon.Points.RemoveAt(overlayPolygon.Points.Count - 1); // unmake a full loop
        //         }
        //
        //         redrawPolygonSurvey(overlayPolygon);
        //     }
        //
        //     // regions_LB.Items.Add(polygon.Name);
        //     // regions_LB.Items.Add(polygon1.Name);
        //
        //     // GMapOverlay polyOverlay1 = new GMapOverlay("polygons");
        //     // polyOverlay1.Polygons.Add(polygon1);
        //     // FlightPlanner.MainMap.Overlays.Add(polyOverlay1);
        //     // //regionActive = !regionActive;
        // }

        public void RedrawPolygonSurvey(GMapPolygon polygon) //here wp markers lived
        {
            UpdateBindings();
            if (polygon.Points.Count == 0)
            {
                FlightPlanner.RegionsOverlay.Markers.Clear();
                FlightPlanner.instance.MainMap.Invalidate();
                return;
            }

            PointLatLng[] pointCopyList = new PointLatLng[polygon.Points.Count];
            polygon.Points.CopyTo(pointCopyList);
            polygon.Points.Clear();
            FlightPlanner.RegionsOverlay.Markers.Clear();

            int tag = 0;
            pointCopyList.ForEach(x =>
            {
                tag++;
                polygon.Points.Add(x);
                addPolygonMarkerGrid(tag.ToString(), x.Lng, x.Lat, 0);
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

        private void addPolygonMarkerGrid(string tag, double lng, double lat, int alt)
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
                RedrawPolygonSurvey(GetCurrentPolygon());
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


        private void latLong_DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    e.Value = (e.RowIndex + 1).ToString();
                }
                else
                {
                    e.Value = Convert.ToDouble(e.Value).ToString("F6", new CultureInfo("en-US"));
                }

                e.FormattingApplied = true;
            }
            catch (Exception exception)
            {
                e.Value = 0.0;
                Console.WriteLine(exception);
            }

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

        private void ReadEditedValueFromTextBox()
        {
            double editedCoordinate;
            if (!double.TryParse(_editTextBox.Text.Replace('.', ','), out editedCoordinate))
            {
                editedCoordinate = Convert.ToDouble(latLong_DGV.CurrentCell.Value);
                // CustomMessageBox.Show("Введите корректные координаты", "Неправильный формат введенных данных");
            }

            if (latLong_DGV.CurrentCell.ColumnIndex == _latIndex)
            {
                _pointInEdit.Lat = editedCoordinate;
            }
            else
            {
                _pointInEdit.Lng = editedCoordinate;
            }
        }

        private void latLong_DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Total shitcode but no clue how to do properly
            if (regionsBindingSource.Count == 0)
            {
                return;
            }

            ReadEditedValueFromTextBox();

            GMapPolygon currentPolygon = GetCurrentPolygon();
            ArrayList updatedPoints = new ArrayList();


            foreach (DataGridViewRow row in latLong_DGV.Rows)
            {
                double lat, lng;
                if (row.Index == _rowInEdit)
                {
                    lat = _pointInEdit.Lat;
                    lng = _pointInEdit.Lng;
                }
                else
                {
                    lat = Convert.ToDouble(row.Cells[_latIndex].Value);
                    lng = Convert.ToDouble(row.Cells[_lngIndex].Value);
                }

                updatedPoints.Add(new PointLatLng(lat, lng));
            }

            currentPolygon.Points.Clear();

            foreach (PointLatLng point in updatedPoints)
            {
                currentPolygon.Points.Add(new PointLatLng(point.Lat, point.Lng));
            }

            RedrawPolygonSurvey(GetCurrentPolygon());
        }

        private void latLong_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(latLong_DGV.CurrentCellAddress.ToString());
        }

        private void latLong_DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // // Total shitcode but no clue how to do properly
            // if (regionsBindingSource.Count == 0)
            // {
            //     return;
            // }
            //
            // GMapPolygon currentPolygon = GetCurrentPolygon();
            // ArrayList updatedPoints = new ArrayList();
            //
            // var latIndex = latLong_DGV.Columns["Latitude"].Index;
            // var lngIndex = latLong_DGV.Columns["Longitude"].Index;
            //
            // foreach (DataGridViewRow row in latLong_DGV.Rows)
            // {
            //     var lat = Convert.ToDouble(row.Cells[latIndex].Value);
            //     var lng = Convert.ToDouble(row.Cells[lngIndex].Value);
            //     updatedPoints.Add(new PointLatLng(lat, lng));
            // }
            //
            // currentPolygon.Points.Clear();
            //
            // foreach (PointLatLng point in updatedPoints)
            // {
            //     currentPolygon.Points.Add(new PointLatLng(point.Lat, point.Lng));
            // }

            //
            // PointLatLng point = ;
            // if (latLong_DGV.CurrentCell.OwningColumn == Latitude)
            // {
            //     GetCurrentPolygon().Points. = Convert.ToDouble(latLong_DGV.CurrentCell.Value);
            // }
            // else
            // {
            //     point.Lng = Convert.ToDouble(latLong_DGV.CurrentCell.Value);
            // }
        }

        private void latLong_DGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // pointsBindingSource.DataSource = null;
            // latLong_DGV.VirtualMode = true;
            // latLong_DGV.CellValueNeeded += new DataGridViewCellValueEventHandler(latLong_DGV_CellValueNeeded);
            // latLong_DGV.CellValuePushed += new DataGridViewCellValueEventHandler(latLong_DGV_CellValuePushed);
            if (e.ColumnIndex == 0)
            {
                return;
            }

            _rowInEdit = e.RowIndex;
            double lat = Convert.ToDouble(latLong_DGV.CurrentRow.Cells[_latIndex].Value);
            double lng = Convert.ToDouble(latLong_DGV.CurrentRow.Cells[_lngIndex].Value);
            _pointInEdit = new PointLatLng(lat, lng);
        }

        private void latLong_DGV_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            // If this is the row for new records, no values are needed.
            // if (e.RowIndex == latLong_DGV.RowCount - 1)
            //     return;

            PointLatLng? pointTmp = null;

            if (e.RowIndex == _rowInEdit)
            {
                pointTmp = _pointInEdit;
            }
            else
            {
                pointTmp = (PointLatLng) pointsBindingSource.List[e.RowIndex];
            }

            switch (latLong_DGV.Columns[e.ColumnIndex].Name)
            {
                case "Latitude":
                    e.Value = pointTmp.Value.Lat;
                    break;

                case "Longitude":
                    e.Value = pointTmp.Value.Lng;
                    break;
            }
        }

        private void latLong_DGV_CellValuePushed(object sender,
            System.Windows.Forms.DataGridViewCellValueEventArgs e)
        {
            MessageBox.Show(latLong_DGV.CurrentCell.Value.ToString());
            // PointLatLng pointTmp;

            // // Store a reference to the PointLatLng object for the row being edited.
            // if (e.RowIndex < _regionPoints.Count)
            // {
            //     // If the user is editing a new row, create a new PointLatLng object.
            //     pointInEdit = new PointLatLng(
            //         ((PointLatLng) _regionPoints[e.RowIndex]).Lat,
            //         ((PointLatLng) _regionPoints[e.RowIndex]).Lng);
            //     pointTmp = pointInEdit;
            //     rowInEdit = e.RowIndex;
            // }
            // else
            // {
            //     pointTmp = pointInEdit;
            // }
            //
            // // Set the appropriate PointLatLng property to the cell value entered.
            // Double newValue = Convert.ToDouble(e.Value);
            // switch (latLong_DGV.Columns[e.ColumnIndex].Name)
            // {
            //     case "Latitude":
            //         pointTmp.Lat = newValue;
            //         break;
            //
            //     case "Longitude":
            //         pointTmp.Lng = newValue;
            //         break;
            // }
        }

        private void latLong_DGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (latLong_DGV.CurrentCell.OwningColumn == Num)
            {
                return;
            }

            _editTextBox = e.Control as TextBox;
            _editTextBox.TextChanged += EditTextBoxOnTextChanged;
            _editTextBox.KeyPress += EditTextBoxOnKeyPress;

            // if (latLong_DGV.CurrentCell.OwningColumn == Latitude)
            // {
            //     _pointInEdit.Lat = Convert.ToDouble(_editTextBox.Text);
            // }
            // else
            // {
            //     _pointInEdit.Lng = Convert.ToDouble(_editTextBox.Text);
            // }
        }

        private void latLong_DGV_CancelRowEdit(object sender,
            System.Windows.Forms.QuestionEventArgs e)
        {
            // if (this.rowInEdit == this.dataGridView1.Rows.Count - 2 &&
            //     this.rowInEdit == this.customers.Count)
            // {
            //     // If the user has canceled the edit of a newly created row,
            //     // replace the corresponding Customer object with a new, empty one.
            //     this.customerInEdit = new Customer();
            // }
            // else
            // {
            // If the user has canceled the edit of an existing row,
            // release the corresponding Customer object.
            // this._pointInEdit = new PointLatLng();
            // this._rowInEdit = -1;
            // }
        }

        private void latLong_DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                // get current cell
                var cell = ((DataGridView) sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                // check new value.
                var c0 = 0.0;
                if (e.FormattedValue == null || !Double.TryParse(e.FormattedValue.ToString(), NumberStyles.Number,
                    new CultureInfo("en-US"), out c0))
                {
                    // bad value inserted

                    // e.FormattedValue - is new value
                    // cell.Value - contains 'old' value

                    // choose any:
                    cell.Value = cell.Value; // this way we return 'old' value
                    e.Cancel = true; // this way we make user not leave the cell until he pastes the value we expect
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RedrawAllPolygons()
        {
            if (FlightPlanner.RegionsOverlay.Polygons.Count == 0)
            {
                FlightPlanner.RegionsOverlay.Markers.Clear();
                FlightPlanner.instance.MainMap.Invalidate();
                ClearRegionsProperties();
                UpdateBindings();
                return;
            }

            foreach (var overlayPolygon in FlightPlanner.RegionsOverlay.Polygons)
            {
                RedrawPolygonSurvey(overlayPolygon);
            }
        }

        private void deleteRegion_BUT_Click(object sender, EventArgs e)
        {
            regions_LB.SelectedIndexChanged -= regions_LB_SelectedIndexChanged;
            if (FlightPlanner.RegionsOverlay.Polygons.Count == 0)
                return;

            ClearPropertiesBindings();
            
            FlightPlanner.RegionsOverlay.Polygons.RemoveAt(regions_LB.SelectedIndex);

            RedrawAllPolygons();
            regions_LB.SelectedIndexChanged += regions_LB_SelectedIndexChanged;
            regions_LB.SelectedIndex = regions_LB.Items.Count - 1;
        }

        private void loadRegions_BUT_Click(object sender, EventArgs e)
        {
        }

        private void saveRegions_BUT_Click(object sender, EventArgs e)
        {
            // if (DrawingPolygon.Points.Count == 0)
            // {
            //     return;
            // }
            //
            //
            // using (SaveFileDialog sf = new SaveFileDialog())
            // {
            //     sf.Filter = "Polygon (*.poly)|*.poly";
            //     var result = sf.ShowDialog();
            //     if (sf.FileName != "" && result == DialogResult.OK)
            //     {
            //         try
            //         {
            //             StreamWriter sw = new StreamWriter(sf.OpenFile());
            //
            //             sw.WriteLine("#saved by Mission Planner " + Application.ProductVersion);
            //
            //             if (DrawingPolygon.Points.Count > 0)
            //             {
            //                 foreach (var pll in DrawingPolygon.Points)
            //                 {
            //                     sw.WriteLine(pll.Lat.ToString(CultureInfo.InvariantCulture) + " " +
            //                                  pll.Lng.ToString(CultureInfo.InvariantCulture));
            //                 }
            //
            //                 PointLatLng pll2 = DrawingPolygon.Points[0];
            //
            //                 sw.WriteLine(pll2.Lat.ToString(CultureInfo.InvariantCulture) + " " +
            //                              pll2.Lng.ToString(CultureInfo.InvariantCulture));
            //             }
            //
            //             sw.Close();
            //         }
            //         catch
            //         {
            //             CustomMessageBox.Show("Failed to write fence file");
            //         }
            //     }
            // }
        }

        private void latLong_DGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.RowIndex == _latIndex)
            {
                dgv[e.ColumnIndex, e.RowIndex].Value = _pointInEdit.Lat.ToString("N6");
            }
            else
            {
                dgv[e.ColumnIndex, e.RowIndex].Value = _pointInEdit.Lng.ToString("N6");
            }
        }
    }
}