using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace cgdraw
{
    class StoreLine
    {
        public Point firstPoint;
        public Point lastPoint;
        public Color lineColor;
        public StoreLine()
        {
            firstPoint = new Point();
            lastPoint = new Point();
            lineColor = Color.White;
        }
        public StoreLine(Point firstpoint,Point lastpoint,Color linecolor)
        {
            firstPoint = firstpoint;
            lastPoint = lastpoint;
            lineColor = linecolor;
        }
    }
}
