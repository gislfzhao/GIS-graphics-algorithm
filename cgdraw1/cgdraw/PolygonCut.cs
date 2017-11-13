using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cgdraw
{
    class PolygonCut
    {
        static int xLeft;
        static int xRight;
        static int yBottom;
        static int yTop;

        private static void get_xy_LRBT(Point pt1, Point pt2)
        {
            if (pt1.X > pt2.X)
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
        public static void sutherlandHodgmanClipPolygon(IntPtr hDC,List<Point> polygonCutPoints,List<Point> polygonClipRegionPoints,Color c)
        {
            get_xy_LRBT(polygonClipRegionPoints[0],polygonClipRegionPoints[1]);
            polygonCutPoints = clipSingleEdge(polygonCutPoints, "Right");
            polygonCutPoints = clipSingleEdge(polygonCutPoints, "Left");
            polygonCutPoints = clipSingleEdge(polygonCutPoints, "Top");
            polygonCutPoints = clipSingleEdge(polygonCutPoints, "Bottom");
            drawClipPolygon(hDC,polygonCutPoints,c);

        }
        private static List<Point> clipSingleEdge(List<Point> pts,string EdgeType)
        {
            List<Point> clips = new List<Point>();
            for (int i = 0; i < judgePointAndEdge(pts[pts.Count-1],pts[0],EdgeType).Count; i++)
            {
                clips.Add(judgePointAndEdge(pts[pts.Count - 1], pts[0], EdgeType)[i]);
            }
            for (int i=1;i < pts.Count;i++)
            {
                for (int j = 0; j < judgePointAndEdge(pts[i-1], pts[i], EdgeType).Count; j++)
                {
                    clips.Add(judgePointAndEdge(pts[i-1], pts[i], EdgeType)[j]);
                }
            }
            return clips;
        }
        private static List<Point> judgePointAndEdge(Point pt_S ,Point pt_P,string EdgeType)
        {
            List<Point> pts = new List<Point>();
            int x_S = pt_S.X;
            int y_S = pt_S.Y;//先前处理的顶点S
            int x_P = pt_P.X;
            int y_P = pt_P.Y;//当前正在处理的顶点P
            int judgeIn = 0;
            switch(EdgeType)
            {
                case "Right":
                    if (x_P <= xRight)
                    {
                        if (x_S <= xRight)
                            judgeIn = 1;
                        else
                            judgeIn = 4;
                    }
                    else
                    {
                        if (x_S <= xRight)
                            judgeIn = 3;
                        else
                            judgeIn = 2;
                    }
                    break;

                case "Left":
                    if (x_P >= xLeft)
                    {
                        if (x_S >= xLeft)
                            judgeIn = 1;
                        else
                            judgeIn = 4;
                    }
                    else
                    {
                        if (x_S >= xLeft)
                            judgeIn = 3;
                        else
                            judgeIn = 2;
                    }
                    break;

                case "Top":
                    if (y_P >= yTop)
                    {
                        if (y_S >= yTop)
                            judgeIn = 1;
                        else
                            judgeIn = 4;
                    }
                    else
                    {
                        if (y_S >= yTop)
                            judgeIn = 3;
                        else
                            judgeIn = 2;
                    }
                    break;

                case "Bottom":
                    if (y_P <= yBottom)
                    {
                        if (y_S <= yBottom)
                            judgeIn = 1;
                        else
                            judgeIn = 4;
                    }
                    else
                    {
                        if (y_S <= yBottom)
                            judgeIn = 3;
                        else
                            judgeIn = 2;
                    }
                    break;

                default: break;
            }
            if(judgeIn == 1)
            {
                pts.Add(pt_P);
            }
            else if(judgeIn ==3 || judgeIn ==4)
            {
                int x = 0;
                int y = 0;
                if (EdgeType == "Right" || EdgeType == "Left")
                {
                    if(EdgeType == "Right")
                    {
                        x = xRight;
                    }
                    else if(EdgeType == "Left")
                    {
                        x = xLeft;
                    }
                    y = y_S + (y_P - y_S) * (x - x_S) / (x_P - x_S);
                }
                else if(EdgeType == "Top" || EdgeType == "Bottom")
                {
                    if(EdgeType == "Top")
                    {
                        y = yTop;
                    }
                    else if(EdgeType == "Bottom")
                    {
                        y = yBottom;
                    }
                    x = x_S +  (x_P - x_S)* (y - y_S) / (y_P - y_S);
                }
                Point I = new Point(x, y);
                pts.Add(I);
                if(judgeIn == 4)
                {
                    pts.Add(pt_P);
                }
            }
            return pts;
        }
        private static void drawClipPolygon(IntPtr hDC, List<Point> points, Color c)
        {
            for(int i =0;i< points.Count-1;i++)
            {
                line.ddaLine(hDC,points[i].X,points[i].Y, points[i+1].X, points[i+1].Y,c);
            }
            line.ddaLine(hDC, points[0].X, points[0].Y, points[points.Count - 1].X, points[points.Count - 1].Y, c);
        }
        //private static int judgeType((Point pt_S, Point pt_P,string EdgeType)
        //{
        //    int x_S = pt_S.X;
        //    int y_S = pt_S.Y;//先前处理的顶点S
        //    int x_P = pt_P.X;
        //    int y_P = pt_P.Y;//当前正在处理的顶点P
        //    int first = 0;
        //    int last = 0;
        //    int edgeJudge = 0;
        //    if(EdgeType == "Right"|| EdgeType =="Left")
        //    {
        //        first = x_S;
        //        last = x_P;
        //        if(EdgeType == "Right")
        //        {
        //            edgeJudge = xRight;
        //        }
        //        if (EdgeType == "Left")
        //        {
        //            edgeJudge = xLeft;
        //        }
        //    }
        //    else if (EdgeType == "Top" || EdgeType == "Bottom")
        //    {
        //        first = y_S;
        //        last = y_P;
        //        if (EdgeType == "Top")
        //        {
        //            edgeJudge = yTop;
        //        }
        //        if (EdgeType == "Bottom")
        //        {
        //            edgeJudge = yBottom;
        //        }
        //    }
        //    if(first > edgeJudge && last > edgeJudge)
        //    {

        //    }
        //}
    }
}
