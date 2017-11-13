using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace cgdraw
{
    class ellipse
    {
        #region  显示椭圆四个点
        public static void EllipsePoints(IntPtr hDC, int x, int y, int x0, int y0, Color c)//(x0,y0)代表圆心
        {
            int cc = useApi.GetCustomColor(c);
            useApi.SetPixel(hDC, x0 + x, y0 + y, cc);
            useApi.SetPixel(hDC, x0 + x, y0 - y, cc);
            useApi.SetPixel(hDC, x0 - x, y0 + y, cc);
            useApi.SetPixel(hDC, x0 - x, y0 - y, cc);
        }
        #endregion  中点画椭圆
        public static string MidpotEllipse(IntPtr hDC, int x0, int y0, int x1, int y1, Color c)
        {
            Stopwatch mysw = new Stopwatch();
            mysw.Start();
            int longAxis = Math.Abs(x1 - x0) / 2;
            int shortAxis = Math.Abs(y1 - y0) / 2;
            double f = Math.Pow(shortAxis, 2) + Math.Pow(longAxis, 2) * (0.25 - shortAxis);
            int mid_x = (x0 + x1) / 2;
            int mid_y = (y0 + y1) / 2;
            int x = 0;
            int y = shortAxis;
            #region  方法一
            //while (x <= longAxis && y >= 0)
            //{
            //    if (2 * shortAxis * shortAxis * x < 2 * longAxis * longAxis * y)
            //    {
            //        if (f < 0)
            //        {
            //            f += shortAxis * shortAxis * (2 * x + 3);
            //        }
            //        else
            //        {
            //            f += shortAxis * shortAxis * (2 * x + 3) + longAxis * longAxis * (-2 * y + 2);
            //            y -= 1;
            //        }
            //        x++;
            //        if (2 * shortAxis * shortAxis * x >= 2 * longAxis * longAxis * y)
            //        {
            //            change_f = true;
            //        }
            //        while (change_f)
            //        {
            //            f = shortAxis * shortAxis * (x + 0.5) * (x + 0.5) + longAxis * longAxis * (y - 1) * (y - 1) - shortAxis * shortAxis * longAxis * longAxis;
            //            change_f = false;
            //        }
            //    }
            //    else
            //    {
            //        if (f < 0)
            //        {
            //            f += shortAxis * shortAxis * (2 * x + 2) + longAxis * longAxis * (-2 * y + 3);
            //            x += 1;
            //        }
            //        else
            //        {
            //            f += longAxis * longAxis * (-2 * y + 3);
            //        }
            //        y--;

            //    }
            //    if (judge)
            //    {
            //        EllipsePoints(hDC, y, x, mid_x, mid_y, c);
            //    }
            //    else
            //    {
            //        EllipsePoints(hDC, x, y, mid_x, mid_y, c);
            //    }
            //}
            #endregion

            #region 方法二
            
            while (2 * Math.Pow(shortAxis, 2) * x < 2 * Math.Pow(longAxis, 2) * y)
            {
                if (f < 0)
                {
                    f += Math.Pow(shortAxis, 2) * (2 * x + 3);
                }
                else
                {
                    f += Math.Pow(shortAxis, 2) * (2 * x + 3) + Math.Pow(longAxis, 2) * (-2 * y + 2);
                    y -= 1;
                }
                x++;
                EllipsePoints(hDC, x, y, mid_x, mid_y, c);
            }
            f = Math.Pow(shortAxis, 2) * Math.Pow(x + 0.5, 2) + Math.Pow(longAxis, 2) * Math.Pow(y - 1, 2) - Math.Pow(shortAxis, 2) * Math.Pow(longAxis, 2);
            while (2 * Math.Pow(shortAxis, 2) * x >= 2 * Math.Pow(longAxis, 2) * y)
            {
                if (y <= 0)
                {
                    break;
                }
                if (f < 0)
                {
                    f += Math.Pow(shortAxis, 2) * (2 * x + 2) + Math.Pow(longAxis, 2) * ((-2 * y) + 3);
                    x += 1;
                }
                else
                {
                    f += Math.Pow(longAxis, 2) * ((-2 * y) + 3);
                }
                y--;
                EllipsePoints(hDC, x, y, mid_x, mid_y, c);
            }
            #endregion
            mysw.Stop();
            TimeSpan ts2 = mysw.Elapsed;
            string str = "种子填充算法花费" + ts2.TotalMilliseconds + "ms.";
            return str;

        }
        #region

        #endregion

        #region

        #endregion
    }
}
