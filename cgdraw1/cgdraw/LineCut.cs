using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cgdraw
{
    class LineCut
    {
        static int lineLeft = 1;
        static int lineRight = 2;
        static int lineBottom = 4;
        static int lineTop = 8;
        static int xLeft;
        static int xRight;
        static int yBottom;
        static int yTop;

        private static void get_xy_LRBT(Point pt1 ,Point pt2)
        {
            if(pt1.X > pt2.X)
            {
                xLeft = pt2.X;
                xRight = pt1.X;
            }
            else
            {
                xLeft = pt1.X;
                xRight = pt2.X;
            }
            if (pt1.Y > pt2.Y)
            {
                yBottom = pt1.Y;
                yTop = pt2.Y;
            }
            else
            {
                yBottom = pt2.Y;
                yTop = pt1.Y;
            }
        }
        private static int encode(Point pcode)
        {
            int c = 0;
            if(pcode.X < xLeft)
            {
                c = c | lineLeft;
            }
            else if(pcode.X > xRight)
            {
                c = c | lineRight;
            }
            if(pcode.Y < yTop)
            {
                c = c | lineTop;
            }
            else if(pcode.Y > yBottom)
            {
                c = c | lineBottom;
            }
            return c;
        }
        public static void cohenSutherland(IntPtr hDC,Point pt1,Point pt2,Point pt3,Point pt4, Color c)
        {
            get_xy_LRBT(pt3,pt4);
            int first = encode(pt1);
            int last = encode(pt2);
            int x = 0;
            int y = 0;
            int judge = 0;
            int code;
            int x1 = pt1.X;
            int x2 = pt2.X;
            int y1 = pt1.Y;
            int y2 = pt2.Y;
            while ((first != 0) || (last != 0))//排除全在裁剪区域内的情况
            {
                if ((first & last) != 0)//线全在裁剪区域外
                {
                    judge = 1;
                    break;
                }
                code = first;
                if (first == 0)
                {
                    code = last;
                }
                if ((lineLeft & code) != 0)
                {
                    x = xLeft;
                    y = y1 + (y2 - y1) * (xLeft - x1) / (x2 - x1);
                }
                else if ((lineRight & code) != 0)
                {
                    x = xRight;
                    y = y1 + (y2 - y1) * (xRight - x1) / (x2 - x1);
                }
                else if ((lineTop & code) != 0)
                {
                    y = yTop;
                    x = x1 + (x2 - x1) * (yTop - y1) / (y2 - y1);
                }
                else if ((lineBottom & code) != 0)
                {
                    y = yBottom;
                    x = x1 + (x2 - x1) * (yBottom - y1) / (y2 - y1);
                }
                if (code == first)
                {
                    x1 = x;
                    y1 = y;
                    Point ptfirst = new Point(x1, y1);
                    first = encode(ptfirst);
                }
                else
                {
                    x2 = x;
                    y2 = y;
                    Point plast = new Point(x2, y2);
                    last = encode(plast);
                }
                judge = 2;
            }
            if (judge != 1)
            {
                line.ddaLine(hDC, x1, y1, x2, y2, c);
            }



        }

        private static Point xGetY(Point pt1, Point pt2,int x)
        {
            Point pt;
            int y = pt1.Y + (pt2.Y - pt1.Y) * (x - pt1.X) / (pt2.X - pt1.X);
            pt = new Point(x, y);
            return pt;

        }
        private static Point yGetX(Point pt1, Point pt2, int y)
        {
            Point pt;
            int x = pt1.X + (pt2.X - pt1.X) * (y - pt1.Y) / (pt2.Y - pt1.Y);
            pt = new Point(x, y);
            return pt;
        }
        private static double distance(Point pt1, Point pt2)
        {
            return Math.Pow(Math.Abs(pt1.X - pt2.X), 2) + Math.Pow(Math.Abs(pt1.Y - pt2.Y), 2);
        } 
        private static Point Min(Point pt1, Point pt2, Point pt3, Point pt4)
        {
            double dist = Math.Min(Math.Min(distance(pt1, pt4), distance(pt2, pt4)), distance(pt3, pt4));
            if (dist == distance(pt1, pt4))
            {
                return pt1;
            }
            else if (dist == distance(pt2, pt4))
            {
                return pt2;
            }
            else
            {
                return pt3;
            }
        }
        public static void liangyoudongBarsky(IntPtr hDC,List<Point> pts, Color c)//存在问题
        {
            Point first1, first2;
            Point last1, last2;
            get_xy_LRBT(pts[2], pts[3]);
            first1 = xGetY(pts[0], pts[1], xLeft);
            first2 = yGetX(pts[0], pts[1], yTop);
            last1 = xGetY(pts[0], pts[1], xRight);
            last2 = yGetX(pts[0], pts[1], yBottom);
            Point first = Min(first1, first2, pts[0], pts[1]);
            Point last = Min(last1, last2, pts[1], pts[0]);
            if((last.X - first.X) > 0 && (last.Y - first.Y) > 0)
            {
                line.ddaLine(hDC, first.X, first.Y, last.X, last.Y, c);
            }
            else
            {

            }
        }

        private static bool judgePointsInOutSide(Point pt1, Point pt2)
        {
            int first = encode(pt1);
            int last = encode(pt2);
            int x1 = pt1.X;
            int x2 = pt2.X;
            int y1 = pt1.Y;
            int y2 = pt2.Y;
            int code;
            int x;
            int y;
            if(first == 0 || last == 0)
            {
                return false;
            }
            else
            {
                if ((first & last) != 0)//线全在裁剪区域外
                {
                    return true;
                }
                else
                {
                    code = first;
                    if ((lineLeft & code) != 0)
                    {
                        x = xLeft;
                        y = y1 + (y2 - y1) * (xLeft - x1) / (x2 - x1);
                    }
                    else if ((lineRight & code) != 0)
                    {
                        x = xRight;
                        y = y1 + (y2 - y1) * (xRight - x1) / (x2 - x1);
                    }
                    else if ((lineTop & code) != 0)
                    {
                        y = yTop;
                        x = x1 + (x2 - x1) * (yTop - y1) / (y2 - y1);
                    }
                    else if ((lineBottom & code) != 0)
                    {
                        y = yBottom;
                        x = x1 + (x2 - x1) * (yBottom - y1) / (y2 - y1);
                    }
                    else
                    {
                        x = pt1.X;
                        y = pt1.Y;
                    }
                    Point ptfirst = new Point(x, y);
                    first = encode(ptfirst);
                    if ((first & last) != 0)//线全在裁剪区域外
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }
        private static Point getNearPoint(Point pt1, Point pt2)
        {
            Point nearPt1;
            Point midPt = new Point();
            int first = encode(pt1);
            if (first == 0)
            {
                nearPt1 = pt1;
            }
            else
            {
                while(true)
                {
                    midPt.X = (pt1.X + pt2.X) / 2;
                    midPt.Y = (pt1.Y + pt2.Y) / 2;
                    if(Math.Pow((midPt.X - pt2.X),2) + Math.Pow((midPt.Y - pt2.Y), 2) < 5.0)
                    {
                        nearPt1 = midPt;
                        break;
                    }
                    else
                    {
                        if(judgePointsInOutSide(pt1,midPt))
                        {
                            pt1 = midPt;
                        }
                        else
                        {
                            pt2 = midPt;
                        }
                    }
                }
            }
            return nearPt1;
        }
        public static void midSeparate(IntPtr hDC, List<Point> pts, Color c)
        {
            get_xy_LRBT(pts[2], pts[3]);
            int first = encode(pts[0]);
            int last = encode(pts[1]);
            Point nearPt1;
            Point nearPt2;
            if(first == 0 && last ==0)
            {
                nearPt1 = pts[0];
                nearPt2 = pts[1];
            }
            else
            {
                if(judgePointsInOutSide(pts[0], pts[1]))
                {
                    return;
                }
                else
                {
                    nearPt1 = getNearPoint(pts[0], pts[1]);
                    nearPt2 = getNearPoint(pts[1], pts[0]);
                }
            }
            line.ddaLine(hDC, nearPt1.X, nearPt1.Y, nearPt2.X, nearPt2.Y, c);


        }

        public static void cyrusBeck()
        {

        }

        public static void slopeCut(IntPtr hDC, List<Point> pts, Color c)
        {
            get_xy_LRBT(pts[2], pts[3]);
            Point temp;
            if (pts[0].X > pts[1].X)
            {
                temp = pts[0];
                pts[0] = pts[1];
                pts[1] = temp;
            }
            int x1 = pts[0].X;
            int y1 = pts[0].Y;
            int x2 = pts[1].X;
            int y2 = pts[1].Y;
            if(x2 < xLeft || x1 > xRight)
            {
                return;
            }
            if(y1 < y2)
            {
                if(y2 < yTop || y1 > yBottom)
                {
                    return;
                }
                if(x1 == x2)
                {
                    if (y1 < yTop)
                    {
                        x1 = (yTop - y1) * (x2 - x1) / (y2 - y1) + x1;
                        y1 = yTop;
                    }
                    if (y2 > yBottom)
                    {
                        x2 = (yBottom - y2) * (x2 - x1) / (y2 - y1) + x2;
                        y2 = yBottom;
                    }
                }
                if(x1 < xLeft)
                {
                    y1 = (y2 - y1) * (xLeft - x1) / (x2 - x1) + y1;
                    x1 = xLeft;
                    if(y1 > yBottom)
                    {
                        return;
                    }
                }
                if(x2 > xRight)
                {
                    y2 = (y2 - y1) * (xRight - x2) / (x2 - x1) + y2;
                    x2 = xRight;
                    if(y2 < yTop)
                    {
                        return;
                    }
                }
                if (y1 < yTop)
                {
                    x1 = (yTop - y1) * (x2 - x1) / (y2 - y1) + x1;
                    y1 = yTop;
                }
                if (y2 > yBottom)
                {
                    x2 = (yBottom - y2) * (x2 - x1) / (y2 - y1) + x2;
                    y2 = yBottom;
                }
            }
            else
            {
                if(y1 < yTop || y2 > yBottom)
                {
                    return;
                }
                if(y1 == y2)
                {
                    if (x1 < xLeft)
                    {
                        x1 = xLeft;
                    }
                    if (x2 > xRight)
                    {
                        x2 = xRight;
                    }
                }
                if (x1 < xLeft)
                {
                    y1 = (y2 - y1) * (xLeft - x1) / (x2 - x1) + y1;
                    x1 = xLeft;
                    if (y1 < yTop)
                    {
                        return;
                    }
                }
                if (x2 > xRight)
                {
                    y2 = (y2 - y1) * (xRight - x2) / (x2 - x1) + y2;
                    x2 = xRight;
                    if (y2 > yBottom)
                    {
                        return;
                    }
                }
                if (y2 < yTop)
                {
                    x2 = (yTop - y2) * (x2 - x1) / (y2 - y1) + x2;
                    y2 = yTop;
                }
                if (y1 > yBottom)
                {
                    x1 = (yBottom - y1) * (x2 - x1) / (y2 - y1) + x1;
                    y1 = yBottom;
                }
            }
            line.ddaLine(hDC, x1, y1, x2, y2, c);
        }
    }
}
