using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.Diagnostics;

namespace cgdraw
{
    class polygon
    {
        List<Point> polygonVertex;
        public int m_NumVertex;

        public polygon()
        {
            polygonVertex = new List<Point>();
            m_NumVertex = 0;


        }

        #region 获得多边形顶点的值

        public Point getPoint(int num)
        {
            if (num < 0 || num > polygonVertex.Count())
                throw new ArgumentOutOfRangeException("num",
                                                  "num指定值超出顶点数范围");
            return polygonVertex[num - 1];
        }
        #endregion

        public void AddVertex(Point vertext)
        {
            polygonVertex.Add(vertext);
            m_NumVertex = polygonVertex.Count();

        }

        #region 返回Y最小值为Ymin的边
        /// <summary>
        /// 返回Y最小值为Ymin的边
        /// </summary>
        /// <param name="y">Ymin = y</param>
        /// <returns>新边链表</returns>
        private ArrayList getYmin(int y)
        {

            ArrayList NET = new ArrayList();
            for (int i = 0; i < m_NumVertex; i++)
            {
                int x1, x2, y1, y2;
                if (i != m_NumVertex - 1)
                {
                    x1 = polygonVertex[i].X;
                    x2 = polygonVertex[i + 1].X;
                    y1 = polygonVertex[i].Y; ;
                    y2 = polygonVertex[i + 1].Y;

                }
                else
                {
                    x1 = polygonVertex[m_NumVertex - 1].X;
                    x2 = polygonVertex[0].X;
                    y1 = polygonVertex[m_NumVertex - 1].Y;
                    y2 = polygonVertex[0].Y;
                }
                int ymax = 0;
                int x = 0;
                bool hasValue = false;
                if (y1 == y && y2 >= y1)
                {
                    ymax = y2;
                    x = x1;
                    hasValue = true;
                }
                else if (y2 == y && y1 >= y2)
                {
                    ymax = y1;
                    x = x2;
                    hasValue = true;
                }
                if (hasValue)
                {
                    float k = (float)(y1 - y2) / (float)(x1 - x2);
                    float tx;
                    if (k != 0)
                    {
                        tx = 1 / k;
                    }
                    else
                        tx = 0;
                    //第一位存x 第二位存△x 第三位存Ymax 最后存 下一条边
                    ArrayList val = new ArrayList();
                    val.Add((float)x);
                    val.Add(tx);
                    val.Add(ymax);

                    NET.Add(val);

                }

            }

            return NET;

        }

        #endregion

        public void linefill(IntPtr hDC, Color color)
        {
            //找出最大最小y

            int Ymin, Ymax;
            Ymin = polygonVertex[0].Y;
            Ymax = polygonVertex[0].Y;
            for (int i = 1; i < m_NumVertex; i++)
            {
                if (polygonVertex[i].Y < Ymin)
                {
                    Ymin = polygonVertex[i].Y;
                }
            }
            for (int i = 1; i < m_NumVertex; i++)
            {
                if (polygonVertex[i].Y > Ymax)
                {
                    Ymax = polygonVertex[i].Y;
                }
            }

            //
            int LineNum = Ymax - Ymin + 1;


            //新边表头指针NET[i]
            ArrayList[] NET = new ArrayList[LineNum];
            for (int i = 0; i < LineNum; i++)
            {
                //初始化新边表头指针NET[i] ;
                NET[i] = new ArrayList();
                //把 Ymin = i 的边放进边表NET[i] ;

                NET[i] = getYmin(Ymin + i);
            }


            // y = 最低扫描线号 ;
            int y = Ymin;

            //   Graphics g = this.CreateGraphics();
            //  Pen pen = new Pen(Color.Blue, 1);

            //初始化活性边表AET为空 ;
            ArrayList AET = new ArrayList();
            for (int i = 0; i < LineNum; i++)
            {
                //把NET[i]中的边节点用插入排序法插入AET表,使之按x坐标递增顺序排列;


                //先把NET[i]中元素全部插入到AET
                if (NET[i] != null || NET[i].Count != 0)
                    for (int j = 0; j < NET[i].Count; j++)
                    {
                        AET.Add(NET[i][j]);
                    }

                //再排序


                for (int t = AET.Count - 1; t > 0; t--)
                {
                    for (int j = AET.Count - 1; j > AET.Count - 1 - t; j--)
                    {
                        if (getItemX((ArrayList)AET[j - 1]) > getItemX((ArrayList)AET[j]))
                        {
                            ArrayList temp = (ArrayList)AET[j - 1];
                            AET[j - 1] = AET[j];
                            AET[j] = temp;
                        }

                    }
                }


                //遍历AET表,画线
                for (int j = 0; j < AET.Count - 1; j++)
                {

                    int x1 = (int)(getItemX((ArrayList)AET[j]) + 0.5);
                    int x2 = (int)(getItemX((ArrayList)AET[j + 1]) + 0.5);
                    int y1 = i + y;

                    line.bresenhamLine(hDC, x1, y1, x2, y1, color);
                    //    g.DrawLine(pen, x1, y1, x2, y1);

                    j++;

                }


                //遍历AET表,把 Ymax = i+1 的结点从AET表中删除,并把 Ymax > i+1 结点的 x 值递增 △x ;
                Stack stack = new Stack();
                for (int j = 0; j < AET.Count; j++)
                {

                    if (getItemYmax((ArrayList)AET[j]) == i + y + 1)
                    {
                        stack.Push(j);
                    }
                    else if (getItemYmax((ArrayList)AET[j]) > i + y + 1)
                        UpdateItemX(AET, j);
                }
                while (stack.Count > 0)
                {
                    int tempa = (int)stack.Pop();
                    AET.RemoveAt(tempa);
                }


            }
        }




        #region 获得ArrayList元素的x值

        protected float getItemX(ArrayList lst)
        {
            if (lst == null)
                return 0;
            return (float)lst[0];
        }
        #endregion

        #region 获得ArrayList元素的Ymax值

        protected int getItemYmax(ArrayList lst)
        {
            if (lst == null)
                return 0;
            return (int)lst[2];
        }
        #endregion

        #region 获得ArrayList元素的△x值

        protected float getItemtx(ArrayList lst)
        {
            if (lst == null)
                return 0;
            return (float)lst[1];
        }
        #endregion

        #region 更新ArrayList元素的x值 使X=X+△x

        protected void UpdateItemX(ArrayList lst, int index)
        {
            if (lst == null)
                return;
            if (index >= lst.Count)
            {
                Console.WriteLine("Err");
                return;

            }

            try
            {
                //Console.WriteLine("index=" + index);
                ArrayList l = (ArrayList)lst[index];
                float x = (float)l[0];
                float tx = (float)l[1];
                //四舍五入计算x
                x = x + tx;
                l[0] = x;
                lst[index] = l;
            }
            catch { }

        }
        #endregion


        public string seedfill(IntPtr hDC, Point seed, Color boundcolor, Color fillcolor)
        {
            drawploygon(hDC, boundcolor);

            Stopwatch mysw = new Stopwatch();

            int bc = useApi.GetCustomColor(boundcolor);
            int fc = useApi.GetCustomColor(fillcolor);
            mysw.Start();
            Stack fillstack = new Stack();
            fillstack.Push(seed);
            while (fillstack.Count > 0)
            {
                Point p = (Point)fillstack.Pop();
                if (useApi.GetPixel(hDC, p.X, p.Y) != bc && useApi.GetPixel(hDC, p.X, p.Y) != fc)
                {
                    useApi.SetPixel(hDC, p.X, p.Y, fc);
                    if (useApi.GetPixel(hDC, p.X - 1, p.Y) != bc && useApi.GetPixel(hDC, p.X - 1, p.Y) != fc)
                        fillstack.Push(new Point(p.X - 1, p.Y));
                    if (useApi.GetPixel(hDC, p.X + 1, p.Y) != bc && useApi.GetPixel(hDC, p.X + 1, p.Y) != fc)
                        fillstack.Push(new Point(p.X + 1, p.Y));
                    if (useApi.GetPixel(hDC, p.X, p.Y - 1) != bc && useApi.GetPixel(hDC, p.X, p.Y - 1) != fc)
                        fillstack.Push(new Point(p.X, p.Y - 1));
                    if (useApi.GetPixel(hDC, p.X, p.Y + 1) != bc && useApi.GetPixel(hDC, p.X, p.Y + 1) != fc)
                        fillstack.Push(new Point(p.X, p.Y + 1));
                }
            }
            mysw.Stop();
            TimeSpan ts2 = mysw.Elapsed;
            string str = "种子填充算法花费" + ts2.TotalMilliseconds + "ms.";
            return str;

        }

        private void drawploygon(IntPtr hDC, Color color)
        {
            for (int i = 0; i < m_NumVertex; i++)
            {
                if (i != m_NumVertex - 1)
                {
                    line.potLine(hDC, polygonVertex[i].X, polygonVertex[i].Y, polygonVertex[i + 1].X, polygonVertex[i + 1].Y, color);

                }
                else
                {
                    line.potLine(hDC, polygonVertex[i].X, polygonVertex[i].Y, polygonVertex[0].X, polygonVertex[0].Y, color);

                }
            }

        }
    }
}
