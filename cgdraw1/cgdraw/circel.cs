using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace cgdraw
{
    class circel
    {
        #region ZDY
        public static void ZDY(IntPtr hDC, int x0, int y0, int x1, int y1, Color c)
        {
            int r = (int)Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
            int x=x0,y=y0-r;
            int cc = useApi.GetCustomColor(c);
            int d = -1;
            int k=0;
            useApi.SetPixel(hDC, x0, y0-r, cc);
           while (k<-1)
           {
            if (d < 0)
            {
                d = d + 2 * x + 3;
                x += 1;
            }
            else
            {
                d = d + 2 * x - 2 * y + 5;
                y -= 1;
            }
            useApi.SetPixel(hDC, x, y, cc);
               k=(y0-y)/(x0-x);
           }

        #endregion

        }
    }
}
