using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace cgdraw
{
    class line
    {
        #region 交换数
        private static void swap(ref int a, ref int b)//交换两个数
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }
        #endregion

        #region 逐点比较法
        public static string potLine(IntPtr hDC, int x0, int y0, int x1, int y1, Color c)
        {
            Stopwatch mysw = new Stopwatch();
            mysw.Start();
            int x, y;
            int abs_x = Math.Abs(x1 - x0);
            int abs_y = Math.Abs(y1 - y0);
            int f = 0;
            int num = abs_x + abs_y;
            int cc = useApi.GetCustomColor(c);
            int k = 0;
            if ((x1 - x0) * (y1 - y0) >= 0)
            {
                k = 1;
                if ((x1 <= x0) && (y1 <= y0))
                {
                    swap(ref x1, ref x0);
                    swap(ref y1, ref y0);
                }

            }
            else
            {
                k = -1;
                if (x0 >= x1)
                {
                    swap(ref x1, ref x0);
                    swap(ref y1, ref y0);
                }
            }
            x = x0;
            y = y0;
            useApi.SetPixel(hDC, x, y, cc);
            while (num > 0)
            {
                if (Math.Abs(f - k * abs_y) <= Math.Abs(f + k * abs_x))
                {
                    x += 1;
                    f = f - k * abs_y;
                }
                else
                {
                    y += k * 1;
                    f = f + k * abs_x;
                }

                useApi.SetPixel(hDC, x, y, cc);
                num--;
            }
            mysw.Stop();
            TimeSpan ts2 = mysw.Elapsed;
            string str = "种子填充算法花费" + ts2.TotalMilliseconds + "ms.";
            return str;

        }
        #endregion

        #region DDA
        public static string ddaLine(IntPtr hDC,int x0, int y0, int x1, int y1, Color c)
        {
            Stopwatch mysw = new Stopwatch();
            mysw.Start();
            float incremental_x, incremental_y, x, y;
            int abs_x = Math.Abs(x0 - x1);
            int abs_y = Math.Abs(y0 - y1);
            int cc = useApi.GetCustomColor(c);
            int steps, k;
            if (abs_x > abs_y)
                steps = abs_x;
            else
                steps = abs_y;
            incremental_x = (float)(x1 - x0) / (float)steps;
            incremental_y = (float)(y1 - y0) / (float)steps;
            //上述增量有正负，不需要去考虑象限
            x = x0;
            y = y0;
            useApi.SetPixel(hDC, (int)x, (int)y, cc);
            for(k=1;k<=steps;k++)
            {
                x += incremental_x;
                y += incremental_y;
                useApi.SetPixel(hDC, (int)x, (int)y, cc);
            }
            mysw.Stop();
            TimeSpan ts2 = mysw.Elapsed;
            string str = "种子填充算法花费" + ts2.TotalMilliseconds + "ms.";
            return str;
        }
        
        #endregion

        #region Bresenham算法
        public static string bresenhamLine(IntPtr hDC, int x0, int y0, int x1, int y1, Color c)
        {
            Stopwatch mysw = new Stopwatch();
            mysw.Start();
            int dx, dy, x, y, p, const1, const2, inc;
            int cc = useApi.GetCustomColor(c);
            if ((x1-x0) * (y1-y0) >= 0)//准备x或y的单位递变量
            {
                inc = 1;
                if ((x1 <= x0) && (y1 <= y0))
                {
                    swap(ref x1, ref x0);
                    swap(ref y1, ref y0);
                }
            }
            else
            {
                inc = -1;
                if (x0 >= x1 && (Math.Abs(x1 - x0) >= Math.Abs(y1 - y0)))
                {
                    swap(ref x1, ref x0);
                    swap(ref y1, ref y0);
                }
                if (y0 >= y1 && (Math.Abs(x1 - x0) <= Math.Abs(y1 - y0)))
                {
                    swap(ref x1, ref x0);
                    swap(ref y1, ref y0);
                }
                //这样交换保证了x++和y++
            }

            dx = Math.Abs(x1 - x0); 
            dy = Math.Abs(y1 - y0);
            
            if (Math.Abs(dx) >= Math.Abs(dy))
            {
               
                p = 2 * dy - dx;
                const1 = 2 * dy;
                const2 = 2 * (dy - dx);
                x = x0;
                y = y0;
                useApi.SetPixel(hDC, x, y, cc);
                while (x <= x1)
                {
                    x++;
                    if (p < 0)
                    {
                        y += 0;
                        p += const1;
                    }
                    else
                    {
                        y += inc;
                        p += const2;
                    }
                    useApi.SetPixel(hDC, x, y, cc);
                }
            }
            else
            { 
                p = 2 * dx - dy;
                const1 = 2 * dx;
                const2 = 2 * (dx - dy);
                x = x0;
                y = y0;
                useApi.SetPixel(hDC, x, y, cc);
                while (y <= y1)
                {
                    y++;
                    if (p < 0)
                    {
                        p += const1;
                        x += 0;
                    }
                    else
                    {
                        x += inc;
                        p += const2;
                    }
                    useApi.SetPixel(hDC, x, y, cc);
                }
            }
            mysw.Stop();
            TimeSpan ts2 = mysw.Elapsed;
            string str = "种子填充算法花费" + ts2.TotalMilliseconds + "ms.";
            return str;
        }
        #endregion

    }
}
