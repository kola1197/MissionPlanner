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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDAL;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MissionPlanner.GCSViews;
using MissionPlanner.Maps;
using MissionPlanner;
using MissionPlanner.NewClasses;
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
        private bool cellEditEnded = false;

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

            //this.BackColor = Color.FromArgb(32, 32, 32);
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
            // regions_LB.Invoke((Action)(() => regions_LB.DataSource = regionsBindingSource));
            regions_LB.DataSource = regionsBindingSource;

            _latIndex = latLong_DGV.Columns["Latitude"].Index;
            _lngIndex = latLong_DGV.Columns["Longitude"].Index;

            // colorPanel.DataBindings.Add(new Binding("BackColor", regions_LB, "", true));
            // timer1.Enabled = true;
        }

        //global brushes with ordinary/selected colors
        private SolidBrush reportsForegroundBrushSelected = new SolidBrush(Color.White);
        private SolidBrush reportsForegroundBrush = new SolidBrush(Color.Black);
        private SolidBrush reportsBackgroundBrushSelected = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
        private SolidBrush reportsBackgroundBrush1 = new SolidBrush(Color.White);
        private SolidBrush reportsBackgroundBrush2 = new SolidBrush(Color.Gray);

//custom method to draw the items, don't forget to set DrawMode of the ListBox to OwnerDrawFixed
        // private void lbReports_DrawItem(object sender, DrawItemEventArgs e)
        // {
        //     e.DrawBackground();
        //     bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
        //
        //     int index = e.Index;
        //     if (index >= 0 && index < lbReports.Items.Count)
        //     {
        //         string text = lbReports.Items[index].ToString();
        //         Graphics g = e.Graphics;
        //
        //         //background:
        //         SolidBrush backgroundBrush;
        //         if (selected)
        //             backgroundBrush = reportsBackgroundBrushSelected;
        //         else if ((index % 2) == 0)
        //             backgroundBrush = reportsBackgroundBrush1;
        //         else
        //             backgroundBrush = reportsBackgroundBrush2;
        //         g.FillRectangle(backgroundBrush, e.Bounds);
        //
        //         //text:
        //         SolidBrush foregroundBrush = (selected) ? reportsForegroundBrushSelected : reportsForegroundBrush;
        //         g.DrawString(text, e.Font, foregroundBrush, lbReports.GetItemRectangle(index).Location);
        //     }
        //
        //     e.DrawFocusRectangle();
        // }

        private string RemoveDigitsFromString(string input)
        {
            return new String(input.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());
        }

        private void editTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                string text = _editTextBox.Text;
                int selectionStart = _editTextBox.SelectionStart;
                if (selectionStart > 0 && !Char.IsDigit(text[selectionStart - 1]) && text[selectionStart - 1] != '-' &&
                    text[selectionStart - 1] != '.')
                {
                    _editTextBox.SelectionStart--;
                    _editTextBox.SelectionLength = 0;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }

            if (e.KeyCode == Keys.Delete || Control.IsKeyLocked(Keys.Insert))
            {
                string text = _editTextBox.Text;
                int selectionStart = _editTextBox.SelectionStart;

                if (selectionStart != text.Length && !Char.IsDigit(text[selectionStart]) &&
                    text[selectionStart] != '-' && text[selectionStart] != '.')
                {
                    _editTextBox.SelectionStart++;
                    _editTextBox.SelectionLength = 0;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }

            // if (e.KeyCode == Keys.Enter)
            // {
            //     latLong_DGV.EndEdit();
            //     e.Handled = true;
            //     e.SuppressKeyPress = true;
            // }

            if (_editTextBox.SelectionLength > 0)
            {
                _editTextBox.SelectionStart = _editTextBox.Text.Length;
                e.Handled = true;
            }
        }


        private void EditTextBoxOnKeyPress(object sender, KeyPressEventArgs e)
        {
            // if (e.KeyChar == (char) 13)
            // {
            //     latLong_DGV.EndEdit();
            //     e.Handled = true;
            // }

            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void RemoveSelection(Object obj)
        {
            TextBox textbox = obj as TextBox;
            if (textbox != null)
            {
                textbox.SelectionLength = 0;
            }
        }

        private void editTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            RemoveSelection(sender);
        }

        private void editTextBox_GotFocus(object sender, EventArgs e)
        {
            RemoveSelection(sender);
            _editTextBox.SelectionStart = _editTextBox.Text.Length;
        }

        private void editTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            RemoveSelection(sender);
        }

        private void editTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            RemoveSelection(sender);
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

        private bool HasResetPropertiesBindings()
        {
            regionsBindingSource.ResetBindings(true);
            if (regionsBindingSource.Count == 0 || regionsBindingSource.Current == null)
                return false;

            pointsBindingSource.DataSource = ((GMapPolygon) regionsBindingSource.Current).Points;
            pointsBindingSource.ResetBindings(true);
            return true;
        }

        private async Task UpdateControlBindingsAsync()
        {
            regionsProperties_GB.Enabled = FlightPlanner.RegionsOverlay.Polygons.Count != 0;
            ClearPropertiesBindings();
            if (!HasResetPropertiesBindings())
                return;

            name_TB.DataBindings.Add(new Binding("Text", regionsBindingSource.Current, "Name", true));
            colorPanel.DataBindings.Add(new Binding("BackColor", regionsBindingSource.Current, "PolyColor", true));

            Latitude.DataPropertyName = "Lat";
            Longitude.DataPropertyName = "Lng";
            latLong_DGV.DataSource = pointsBindingSource;

            if (latLong_DGV.Columns.Contains("IsEmpty"))
                latLong_DGV.Columns.Remove("IsEmpty");

            // Invalidate();
        }

        public async Task UpdateBindings()
        {
            await UpdateControlBindingsAsync();
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

        public void RedrawPolygonSurvey(GMapPolygon polygon) //here wp markers lived
        {
            if (polygon == null)
                return;

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
                if (FlightPlanner.regionActive)
                {
                    addPolygonMarkerGrid(tag.ToString(), x.Lng, x.Lat, 0);
                }
            });

            FlightPlanner.instance.MainMap.UpdatePolygonLocalPosition(polygon);

            FlightPlanner.instance.MainMap.Invalidate();
        }

        private void addPolygonMarkerGrid(string tag, double lng, double lat, int alt)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, GMarkerGoogleType.yellow);
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
                    // e.Value = Convert.ToDouble(e.Value).ToString("F6", new CultureInfo("en-US"));
                    UniversalCoordinatsController controller =
                        new UniversalCoordinatsController(new WGSCoordinats(GetPointByRow(e.RowIndex).Lat,
                            GetPointByRow(e.RowIndex).Lng));
                    bool isLatitude = e.ColumnIndex == 1;
                    e.Value = FormatCoordinateFromWgs(controller, isLatitude);
                }

                e.FormattingApplied = true;
            }
            catch (Exception exception)
            {
                e.Value = 0.0;
                Console.WriteLine(exception);
            }
        }

        private void ReadEditedValueFromTextBox()
        {
            double editedCoordinate;

            Tuple<string, string> readingPoint;
            PointLatLng convertedPoint;
            double coordToParse;
            if (latLong_DGV.CurrentCell.ColumnIndex == _latIndex)
            {
                string lat = _editTextBox.Text.Replace('.', ',');
                // string lat = _editTextBox.Text;
                string lng = latLong_DGV.Rows[_rowInEdit].Cells[_lngIndex].FormattedValue.ToString().Replace('.', ',');
                readingPoint = new Tuple<string, string>(lat, lng);
                if (!TryConvertToLatLng(readingPoint, out convertedPoint))
                {
                    readingPoint = new Tuple<string, string>(latLong_DGV.CurrentCell.Value.ToString(),
                        latLong_DGV.Rows[_rowInEdit].Cells[_lngIndex].Value.ToString());
                    TryConvertToLatLng(readingPoint, out convertedPoint);
                }

                coordToParse = convertedPoint.Lat;
            }
            else
            {
                string lat = latLong_DGV.Rows[_rowInEdit].Cells[_lngIndex].FormattedValue.ToString().Replace('.', ',');
                // string lng = _editTextBox.Text;
                string lng = _editTextBox.Text.Replace('.', ',');
                readingPoint = new Tuple<string, string>(lat, lng);
                if (!TryConvertToLatLng(readingPoint, out convertedPoint))
                {
                    readingPoint = new Tuple<string, string>(
                        latLong_DGV.Rows[_rowInEdit].Cells[_lngIndex].Value.ToString(),
                        latLong_DGV.CurrentCell.Value.ToString());
                    TryConvertToLatLng(readingPoint, out convertedPoint);
                }

                coordToParse = convertedPoint.Lng;
            }


            // if (!double.TryParse(coordToParse.Replace('.', ','), out editedCoordinate))
            // {
            //     editedCoordinate = Convert.ToDouble(latLong_DGV.CurrentCell.Value);
            //     // CustomMessageBox.Show("Введите корректные координаты", "Неправильный формат введенных данных");
            // }


            if (latLong_DGV.CurrentCell.ColumnIndex == _latIndex)
            {
                _pointInEdit.Lat = coordToParse;
            }
            else
            {
                _pointInEdit.Lng = coordToParse;
            }
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
        }

        private void latLong_DGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
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
            // MessageBox.Show(latLong_DGV.CurrentCell.Value.ToString());
        }

        private void latLong_DGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (latLong_DGV.CurrentCell.OwningColumn == Num)
            {
                return;
            }

            _editTextBox = e.Control as TextBox;

            // _editTextBox.TextChanged += EditTextBoxOnTextChanged;
            _editTextBox.KeyPress += EditTextBoxOnKeyPress;
            // _editTextBox.MouseUp += editTextBox_MouseUp;
            // _editTextBox.KeyUp += editTextBox_KeyUp;
            _editTextBox.KeyDown += editTextBox_OnKeyDown;
            // _editTextBox.GotFocus += editTextBox_GotFocus;
            // _editTextBox.MouseMove += editTextBox_MouseMove;
        }

        private void ClearEditTbEvents()
        {
            // _editTextBox.TextChanged -= EditTextBoxOnTextChanged;
            _editTextBox.KeyPress -= EditTextBoxOnKeyPress;
            // _editTextBox.MouseUp -= editTextBox_MouseUp;
            // _editTextBox.KeyUp -= editTextBox_KeyUp;
            _editTextBox.KeyDown -= editTextBox_OnKeyDown;
            // _editTextBox.GotFocus -= editTextBox_GotFocus;
            // _editTextBox.MouseMove -= editTextBox_MouseMove;
        }

        private void latLong_DGV_CancelRowEdit(object sender, System.Windows.Forms.QuestionEventArgs e)
        {
        }

        private void latLong_DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                // get current cell
                var cell = ((DataGridView) sender).Rows[e.RowIndex].Cells[e.ColumnIndex];

                // check new value.
                var c0 = 0.0;

                Tuple<string, string> readingPoint;
                PointLatLng convertedPoint;
                double coordToParse;
                string lat, lng;
                bool isLatitude = e.ColumnIndex == 1;
                if (latLong_DGV.CurrentCell.ColumnIndex == _latIndex)
                {
                    lat = e.FormattedValue.ToString();
                    lng = latLong_DGV.Rows[_rowInEdit].Cells[_lngIndex].Value.ToString();

                    UniversalCoordinatsController controller =
                        new UniversalCoordinatsController(
                            new WGSCoordinats(latLong_DGV.Rows[_rowInEdit].Cells[_latIndex].Value.ToString(), lng));
                    lng = FormatCoordinateFromWgs(controller, isLatitude);
                }
                else
                {
                    lat = latLong_DGV.Rows[_rowInEdit].Cells[_lngIndex].Value.ToString();
                    lng = e.FormattedValue.ToString();

                    UniversalCoordinatsController controller =
                        new UniversalCoordinatsController(
                            new WGSCoordinats(latLong_DGV.Rows[_rowInEdit].Cells[_lngIndex].Value.ToString(), lng));
                    lat = FormatCoordinateFromWgs(controller, isLatitude);
                }

                lat = lat.Replace('.', ',');
                lng = lng.Replace('.', ',');

                readingPoint = new Tuple<string, string>(lat, lng);

                if (e.FormattedValue == null || !TryConvertToLatLng(readingPoint, out convertedPoint))
                {
                    cell.Value = cell.Value; // this way we return 'old' value
                    e.Cancel = true; // this way we make user not leave the cell until he pastes the value we expect
                }

                //
                // if (e.FormattedValue == null || !Double.TryParse(e.FormattedValue.ToString(), NumberStyles.Number,
                //     new CultureInfo("en-US"), out c0))
                // {
                //     // bad value inserted
                //
                //     // e.FormattedValue - is new value
                //     // cell.Value - contains 'old' value
                //
                //     // choose any:
                //     cell.Value = cell.Value; // this way we return 'old' value
                //     e.Cancel = true; // this way we make user not leave the cell until he pastes the value we expect
                // }
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
            regions_LB.SelectedIndexChanged -= regions_LB_SelectedIndexChanged;

            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = "Polygon (*.poly)|*.poly";
                fd.ShowDialog();
                if (File.Exists(fd.FileName))
                {
                    StreamReader sr = new StreamReader(fd.OpenFile());
                    GMapOverlay regionsOverlay = FlightPlanner.RegionsOverlay;

                    List<PointLatLng> points = new List<PointLatLng>();
                    GMapPolygon polygon = new GMapPolygon(points, "Load");
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (!line.StartsWith("#"))
                        {
                            if (line.StartsWith("Name:"))
                            {
                                polygon = new GMapPolygon(points, line.Replace("Name:", ""));
                                regionsOverlay.Polygons.Add(polygon);
                            }
                            else
                            {
                                if (line.StartsWith("Color:"))
                                {
                                    string colorPattern = @"(?<=R=)(.*)(?=, G)|(?<=G=)(.*)(?=, B)|(?<=B=)(.*)(?=\])";
                                    Regex rg = new Regex(colorPattern);
                                    MatchCollection colorsMatch = rg.Matches(line);
                                    if (colorsMatch.Count == 3)
                                    {
                                        int red = int.Parse(colorsMatch?[0].Value);
                                        int green = int.Parse(colorsMatch?[1].Value);
                                        int blue = int.Parse(colorsMatch?[2].Value);
                                        polygon.PolyColor = Color.FromArgb(red, green, blue);
                                    }
                                }
                                else
                                {
                                    string[] items = line.Split(new[] {' ', '\t'},
                                        StringSplitOptions.RemoveEmptyEntries);

                                    if (items.Length < 2)
                                        continue;

                                    polygon.Points.Add(new PointLatLng(
                                        double.Parse(items[0], CultureInfo.InvariantCulture),
                                        double.Parse(items[1], CultureInfo.InvariantCulture)));
                                    // addPolygonMarkerGrid(DrawingPolygon.Points.Count.ToString(),
                                    //     double.Parse(items[1], CultureInfo.InvariantCulture),
                                    //     double.Parse(items[0], CultureInfo.InvariantCulture), 0);
                                }
                            }
                        }
                    }

                    foreach (var poly in regionsOverlay.Polygons)
                    {
                        // remove loop close
                        if (poly.Points.Count > 1 &&
                            poly.Points[0] == poly.Points[poly.Points.Count - 1])
                        {
                            poly.Points.RemoveAt(poly.Points.Count - 1);
                        }
                    }

                    RedrawAllPolygons();
                    FlightPlanner.instance.MainMap.ZoomAndCenterMarkers(regionsOverlay.Id);
                }
            }

            regions_LB.SelectedIndexChanged += regions_LB_SelectedIndexChanged;
        }

        private void saveRegions_BUT_Click(object sender, EventArgs e)
        {
            if (FlightPlanner.RegionsOverlay.Polygons.Count == 0)
                return;
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "Polygon (*.poly)|*.poly";
                var result = sf.ShowDialog();
                if (sf.FileName != "" && result == DialogResult.OK)
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter(sf.OpenFile());

                        sw.WriteLine("#saved by Mission Planner " + Application.ProductVersion);

                        foreach (var polygon in FlightPlanner.RegionsOverlay.Polygons)
                        {
                            if (polygon.Points.Count > 0)
                            {
                                sw.WriteLine("Name:" + polygon.Name);
                                sw.WriteLine("Color:" + polygon.PolyColor.ToString());
                                foreach (var point in polygon.Points)
                                {
                                    sw.WriteLine(point.Lat.ToString(CultureInfo.InvariantCulture) + " " +
                                                 point.Lng.ToString(CultureInfo.InvariantCulture));
                                }

                                PointLatLng startPoint = polygon.Points[0];

                                sw.WriteLine(startPoint.Lat.ToString(CultureInfo.InvariantCulture) + " " +
                                             startPoint.Lng.ToString(CultureInfo.InvariantCulture));
                            }
                        }

                        sw.Close();
                    }
                    catch
                    {
                        CustomMessageBox.Show("Failed to write region file");
                    }
                }
            }
        }

        private void latLong_DGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // DataGridView dgv = sender as DataGridView;
            // UniversalCoordinatsController controller =
            //     new UniversalCoordinatsController(new WGSCoordinats(GetPointByRow(e.RowIndex).Lat,
            //         GetPointByRow(e.RowIndex).Lng));
            // bool isLatitude = e.ColumnIndex == 1;
            // string oldValue = FormatCoordinateFromWgs(controller, isLatitude);
            //
            // dgv[e.ColumnIndex, e.RowIndex].Value = oldValue;
            e.Cancel = false;
            e.ThrowException = false;
            // if (e.RowIndex == _latIndex)
            // {
            //     dgv[e.ColumnIndex, e.RowIndex].Value = _pointInEdit.Lat.ToString("N6");
            // }
            // else
            // {
            //     dgv[e.ColumnIndex, e.RowIndex].Value = _pointInEdit.Lng.ToString("N6");
            // }
        }

        private bool TryConvertToLatLng(Tuple<string, string> pointFrom, out PointLatLng pointTo)
        {
            UniversalCoordinatsController controller;
            if (TryCreateController(pointFrom, out controller))
            {
                pointTo = new PointLatLng(controller.wgs.Lat, controller.wgs.Lng);
                return true;
            }
            else
            {
                pointTo = _pointInEdit;
                return false;
            }
        }

        private PointLatLng GetPointByRow(int rowIndex)
        {
            return GetCurrentPolygon().Points[rowIndex];
        }

        private string FormatCoordinateFromWgs(UniversalCoordinatsController controller, bool isLat)
        {
            switch (MainV2.coordinatsShowMode)
            {
                case 0:
                    if (isLat)
                    {
                        return controller.wgs.Lat.ToString("F6", new CultureInfo("en-US"));
                        ;
                    }
                    else
                    {
                        return controller.wgs.Lng.ToString("F6", new CultureInfo("en-US"));
                        ;
                    }
                    break;
                case 1:
                    if (isLat)
                    {
                        return controller.wgs.to_GM_View_lat();
                    }
                    else
                    {
                        return controller.wgs.to_GM_View_lon();
                    }

                    break;
                case 2:
                    if (isLat)
                    {
                        return controller.wgs.to_GMS_View_lat();
                    }
                    else
                    {
                        return controller.wgs.to_GMS_View_lon();
                    }

                    break;
                case 3:
                    if (isLat)
                    {
                        return controller.wgs.toSK42().Lat.ToString("F6", new CultureInfo("en-US"));
                    }
                    else
                    {
                        return controller.wgs.toSK42().Lng.ToString("F6", new CultureInfo("en-US"));
                    }

                    break;
                case 4:
                    if (isLat)
                    {
                        return controller.wgs.ToSk42_GM().Item1;
                    }
                    else
                    {
                        return controller.wgs.ToSk42_GM().Item2;
                    }

                    break;
                case 5:
                    if (isLat)
                    {
                        return controller.wgs.ToSk42_GMS().Item1;
                    }
                    else
                    {
                        return controller.wgs.ToSk42_GMS().Item2;
                    }

                    break;
                case 6:
                    if (isLat)
                    {
                        return controller.wgs.toRect().x.ToString("F2", new CultureInfo("en-US"));
                    }
                    else
                    {
                        return controller.wgs.toRect().y.ToString("F2", new CultureInfo("en-US"));
                    }

                    break;
                default:
                    return "-1.0";
            }
        }

        // private PointLatLng ConvertFromLatLng(PointLatLng point)
        // {
        //     
        // }

        private bool TryCreateController(Tuple<string, string> point, out UniversalCoordinatsController controller)
        {
            bool successfullyCreated = false;
            controller = null;
            try
            {
                controller = new UniversalCoordinatsController(new WGSCoordinats(point.Item1, point.Item2));
                switch (MainV2.coordinatsShowMode)
                {
                    case 0:
                        controller = new UniversalCoordinatsController(new WGSCoordinats(point.Item1, point.Item2));
                        successfullyCreated = true;
                        break;
                    case 1:
                        controller = new UniversalCoordinatsController(new WGSCoordinats(point.Item1, point.Item2));
                        successfullyCreated = true;
                        break;
                    case 2:
                        controller = new UniversalCoordinatsController(new WGSCoordinats(point.Item1, point.Item2));
                        successfullyCreated = true;
                        break;
                    case 3:
                        controller = new UniversalCoordinatsController(new SK42Coordinats(point.Item1, point.Item2));
                        successfullyCreated = true;
                        break;
                    case 4:
                        controller = new UniversalCoordinatsController(new SK42Coordinats(point.Item1, point.Item2));
                        successfullyCreated = true;
                        break;
                    case 5:
                        controller = new UniversalCoordinatsController(new SK42Coordinats(point.Item1, point.Item2));
                        successfullyCreated = true;
                        break;
                    case 6:
                        controller = new UniversalCoordinatsController(new RectCoordinats(point.Item1, point.Item2));
                        successfullyCreated = true;
                        break;
                }
            }
            catch
            {
                successfullyCreated = false;
            }
            return successfullyCreated;
        }

        private async Task CallCellEndEditAsync()
        {
        }

        private void latLong_DGV_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
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

            ClearEditTbEvents();

            RedrawPolygonSurvey(GetCurrentPolygon());

            cellEditEnded = true;
        }
    }
}