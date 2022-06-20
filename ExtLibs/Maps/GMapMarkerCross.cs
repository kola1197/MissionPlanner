using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace MissionPlanner.Maps
{
    [Serializable]
    public class GMapMarkerCross : GMapMarker
    {
        private static readonly Bitmap icong = new Bitmap(global::MissionPlanner.Maps.Resources.cross.ToBitmap(), new Size(60, 60));

        public GMapMarkerCross(PointLatLng p)
            : base(p)
        {
            // used for hitarea
            Size = icong.Size;
            Offset = new Point(-Size.Width / 2, -Size.Height / 2);
        }

        public override void OnRender(IGraphics g)
        {
            var temp = g.Transform;
            g.TranslateTransform(LocalPosition.X, LocalPosition.Y);
            g.DrawImageUnscaled(icong, 0, 0);// icong.Width / -2, icong.Height / -2);
            g.Transform = temp;
        }
    }
}