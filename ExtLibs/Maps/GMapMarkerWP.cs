using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace MissionPlanner.Maps
{
    [Serializable]
    
    public class GMapMarkerWP : GMarkerGoogle
    {
        

        public string wpno = "";
        public bool selected = false;
        public bool drawNumber = false;
        SizeF txtsize = SizeF.Empty;
        static Dictionary<string, Bitmap> fontBitmaps = new Dictionary<string, Bitmap>();
        static Font font;
        
        public GMapMarkerWP(PointLatLng p, string wpno, GMarkerGoogleType type = GMarkerGoogleType.yellow)
            : base(p, type)
        {
            this.wpno = wpno;
            if (font == null)
                font = SystemFonts.DefaultFont;
            
            if (!fontBitmaps.ContainsKey(wpno))
            {
                Bitmap temp = new Bitmap(100,30, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(temp))
                {
                    txtsize = g.MeasureString(wpno, font);

                    g.DrawString(wpno, font, Brushes.Black, new PointF(0, 0));
                }
                fontBitmaps[wpno] = temp;
            }
        }

        public override void OnRender(IGraphics g)
        {
            if (selected)
            {
                g.FillEllipse(Brushes.Red, new Rectangle(this.LocalPosition, this.Size));
                g.DrawArc(Pens.Red, new Rectangle(this.LocalPosition, this.Size), 0, 360);
            }
            
            base.OnRender(g);

            var midw = LocalPosition.X + 7;//+ 10;
            var midh = LocalPosition.Y + 3;

            //if (txtsize.Width > 15)
            //    midw -= 4;
            if (wpno.Length == 3)
            {
                midw = LocalPosition.X + 4;
            }
            if (wpno.Length == 2)
            {
                midw = LocalPosition.X + 7;
            }
            if (wpno.Length == 1)
            {
                midw = LocalPosition.X + 10;
            }
            drawNumber = true;
            
            if ((Overlay.Control.Zoom> 16 || IsMouseOver || true) && drawNumber)
                g.DrawImageUnscaled(fontBitmaps[wpno], midw,midh);
        }
    }
}