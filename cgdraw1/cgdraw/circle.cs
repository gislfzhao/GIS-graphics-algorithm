using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace cgdraw
{
    class circle
    {
        #region  显示圆的八个点
        public static void CirclePoints(IntPtr hDC, int x, int y,int x0, int y0, Color c)//(x0,y0)代表圆心
        {
            int cc = useApi.GetCustomColor(c);
            useApi.SetPixel(hDC, x0 + x, y0 + y, cc);
            useApi.SetPixel(hDC, x0 + x, y0 - y, cc);
            useApi.SetPixel(hDC, x0 - x, y0 + y, cc);
            useApi.SetPixel(hDC, x0 - x, y0 - y, cc);
            useApi.SetPixel(hDC, x0 + y, y0 + x, cc);
            useApi.SetPixel(hDC, x0 + y, y0 - x, cc);
            useApi.SetPixel(hDC, x0 - y, y0 + x, cc);
            useApi.SetPixel(hDC, x0 - y, y0 - x, cc);
        }
        #endregion

        #region 中点圆算法
        public static string MidpotCircle(IntPtr hDC, int x0, int y0, int x1, int y1, Color c)
        {
            Stopwatch mysw = new Stopwatch();
            mysw.Start();
            int r = (int)Math.Sqrt((x0 - x1)* (x0 - x1) + (y0 - y1)*(y0 - y1));
            double f = 1.25 - r;
            int x = 0;
            int y = r;
            CirclePoints(hDC, x, y,x0,y0 ,c);
            while (x <= r/Math.Sqrt(2))
            {
                if (f < 0)
                {
                    f += 2 * x + 3;
                   

                }
                else
                {
                    f += 2 * x - 2*y + 5;
                    y -= 1;
                }
                x++;
                CirclePoints(hDC, x, y, x0, y0, c);
            }
            mysw.Stop();
            TimeSpan ts2 = mysw.Elapsed;
            string str = "种子填充算法花费" + ts2.TotalMilliseconds + "ms.";
            return str;

        }
        #endregion

        #region Bresenham算法
        public static string BresenhamPotCircle(IntPtr hDC, int x0, int y0, int x1, int y1, Color c)
        {
            Stopwatch mysw = new Stopwatch();
            mysw.Start();
            int r = (int)Math.Sqrt((x0 - x1) * (x0 - x1) + (y0 - y1) * (y0 - y1));
            int f = 3 - 2*r;
            int x = 0;
            int y = r;
            CirclePoints(hDC, x, y, x0, y0, c);
            while (x <= r / Math.Sqrt(2))
            {
                if (f < 0)
                {
                    f += 4 * x + 6;


                }
                else
                {
                    f +=4 * x - 4 * y + 10;
                    y -= 1;
                }
                x++;
                CirclePoints(hDC, x, y, x0, y0, c);
            }
            mysw.Stop();
            TimeSpan ts2 = mysw.Elapsed;
            string str = "种子填充算法花费" + ts2.TotalMilliseconds + "ms.";
            return str;
        }

        #endregion
    }
}
