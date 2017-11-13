using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace cgdraw
{
    public partial class Form1 : Form
    {
        int mLineType = -1;
        int mCicleType = -1;
        int mEllipseType = -1;
        int mPolygonType = -1;
        int mCutType = -1;
        int mCutLineType = -1;
        int mCutPolygonType = -1;
        polygon mypoly;
        string str ;
        Point pt1, pt2,ptTemp;
        bool lineControlDown = false;
        Stack<Point> stacks = new Stack<Point>();
        List<Point> lineCutPoints;
        List<Point> lineClipRegionPoints;
        List<StoreLine> storeLines;
        List<Point> polygonCutPoints;
        List<Point> polygonClipRegionPoints;
        private IntPtr hwnd;
        private IntPtr hdc;
        Color mColor = Color.Red;
        public Form1()
        {
            InitializeComponent();
        }

 
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            pt1.X = e.X;
            pt1.Y = e.Y;
            lineControlDown = true;
            if (mPolygonType != -1)
            {
                if (mPolygonType == 1)
                {
                    hdc = useApi.GetDC(hwnd);
                    if (e.Button == MouseButtons.Left)
                    {
                        Point newpoint = new Point(e.X, e.Y);
                        mypoly.AddVertex(newpoint);
                        if (mypoly.m_NumVertex >= 2)
                            line.bresenhamLine(hdc, mypoly.getPoint(mypoly.m_NumVertex - 1).X, mypoly.getPoint(mypoly.m_NumVertex - 1).Y, mypoly.getPoint(mypoly.m_NumVertex).X, mypoly.getPoint(mypoly.m_NumVertex).Y, Color.Red);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        line.bresenhamLine(hdc, mypoly.getPoint(1).X, mypoly.getPoint(1).Y, mypoly.getPoint(mypoly.m_NumVertex).X, mypoly.getPoint(mypoly.m_NumVertex).Y, Color.Red);

                    }
                    useApi.ReleaseDC(hwnd, hdc);


                }
                if (mPolygonType == 2)
                {
                    hdc = useApi.GetDC(hwnd);
                    Point newseed = new Point(e.X, e.Y);
                    string str = mypoly.seedfill(hdc, newseed, Color.Blue, Color.Red);
                    useApi.ReleaseDC(hwnd, hdc);
                    MessageBox.Show(str);


                }
            }
            if(mCutType != -1)
            {
                if (mCutType == 1)
                {
                    if (mCutLineType == 1)
                    {

                        lineCutPoints.Add(pt1);
                    }
                    if (mCutLineType == 2)
                    {
                        //lineCutPoints.Add(pt1);
                        lineClipRegionPoints.Add(pt1);
                    }

                }
                if(mCutType == 2)
                {
                    if(mCutPolygonType == 1)
                    {
                        hdc = useApi.GetDC(hwnd);
                        if (e.Button == MouseButtons.Left)
                        {
                            Point newpoint = new Point(e.X, e.Y);
                            polygonCutPoints.Add(newpoint);
                            if (polygonCutPoints.Count >= 2)
                                line.ddaLine(hdc, polygonCutPoints[polygonCutPoints.Count - 2].X, polygonCutPoints[polygonCutPoints.Count - 2].Y, polygonCutPoints[polygonCutPoints.Count - 1].X, polygonCutPoints[polygonCutPoints.Count - 1].Y, Color.Red);
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            line.ddaLine(hdc, polygonCutPoints[0].X, polygonCutPoints[0].Y, polygonCutPoints[polygonCutPoints.Count - 1].X, polygonCutPoints[polygonCutPoints.Count - 1].Y, Color.Red);

                        }
                        useApi.ReleaseDC(hwnd, hdc);
                    }
                    if(mCutPolygonType == 2)
                    {
                        polygonClipRegionPoints.Add(pt1);
                    }
                }
            }
            

            
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           if(mLineType != -1)
            {

                if (lineControlDown)
                {
                    if (stacks.Count != 0)
                    {
                        while (stacks.Count > 0)
                        {
                            pt2 = stacks.Pop();
                            mColor = BackColor;
                            sPaint();
                            mColor = Color.Red;
                        }
                    }
                    if(stacks.Count == 0)
                    {
                        pt2.X = e.X;
                        pt2.Y = e.Y;
                        sPaint();
                        stacks.Push(pt2);
                    }

                }

            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            pt2.X = e.X;
            pt2.Y = e.Y;
            if(mCutType != -1)
            {
                if (mCutType == 1)
                {
                    if (mCutLineType == 1)
                    {

                        lineCutPoints.Add(pt2);
                        hdc = useApi.GetDC(hwnd);
                        line.ddaLine(hdc, lineCutPoints[0].X, lineCutPoints[0].Y, lineCutPoints[1].X, lineCutPoints[1].Y, mColor);
                        StoreLine sline = new StoreLine(lineCutPoints[0], lineCutPoints[1], mColor);
                        storeLines.Add(sline);
                        lineCutPoints = new List<Point>();
                        useApi.ReleaseDC(hwnd, hdc);
                    }

                    if (mCutLineType == 2)
                    {
                        //lineCutPoints.Add(pt2);
                        lineClipRegionPoints.Add(pt2);
                        hdc = useApi.GetDC(hwnd);
                        mColor = Color.Black;
                        line.ddaLine(hdc, lineClipRegionPoints[1].X, lineClipRegionPoints[1].Y, lineClipRegionPoints[1].X, lineClipRegionPoints[0].Y, mColor);
                        line.ddaLine(hdc, lineClipRegionPoints[1].X, lineClipRegionPoints[0].Y, lineClipRegionPoints[0].X, lineClipRegionPoints[0].Y, mColor);
                        line.ddaLine(hdc, lineClipRegionPoints[0].X, lineClipRegionPoints[1].Y, lineClipRegionPoints[0].X, lineClipRegionPoints[0].Y, mColor);
                        line.ddaLine(hdc, lineClipRegionPoints[0].X, lineClipRegionPoints[1].Y, lineClipRegionPoints[1].X, lineClipRegionPoints[1].Y, mColor);
                        useApi.ReleaseDC(hwnd, hdc);
                        mColor = Color.Red;
                    }
                }
                if(mCutType == 2)
                {
                    if(mCutPolygonType == 2)
                    {
                        polygonClipRegionPoints.Add(pt2);
                        hdc = useApi.GetDC(hwnd);
                        mColor = Color.Black;
                        line.ddaLine(hdc, polygonClipRegionPoints[0].X, polygonClipRegionPoints[0].Y, polygonClipRegionPoints[0].X, polygonClipRegionPoints[1].Y, mColor);
                        line.ddaLine(hdc, polygonClipRegionPoints[0].X, polygonClipRegionPoints[1].Y, polygonClipRegionPoints[1].X, polygonClipRegionPoints[1].Y, mColor);
                        line.ddaLine(hdc, polygonClipRegionPoints[1].X, polygonClipRegionPoints[0].Y, polygonClipRegionPoints[1].X, polygonClipRegionPoints[1].Y, mColor);
                        line.ddaLine(hdc, polygonClipRegionPoints[1].X, polygonClipRegionPoints[0].Y, polygonClipRegionPoints[0].X, polygonClipRegionPoints[0].Y, mColor);
                        useApi.ReleaseDC(hwnd, hdc);
                        mColor = Color.Red;
                    }
                }
            }
            if (mLineType != -1)
            {
                sPaint();
                lineControlDown = false;
            }
            if (mCicleType != -1)
            {
                hdc = useApi.GetDC(hwnd);
                line.ddaLine(hdc, pt1.X, pt1.Y, pt2.X, pt2.Y, mColor);
                CirclePaint();
                useApi.ReleaseDC(hwnd, hdc);
            }
            if (mEllipseType != -1)
            {
                EllipsePaint();
            }

            //if (str != null)
            //{
            //    MessageBox.Show(str);
            //    str = null;
            //}
        }

        #region From窗口加载
        private void Form1_Load(object sender, EventArgs e)
        {
            hwnd = useApi.FindWindow(null, "GIS图形算法程序"); //获取窗口句柄
            hdc = useApi.GetDC(hwnd);          //获取设备



            //if (hwnd != IntPtr.Zero)
            //{
            //    MessageBox.Show("找到窗口");
            //}
            //else
            //{
            //    MessageBox.Show("没有找到窗口");
            //}

        }
        #endregion


        #region 画线算法
        private void 画线算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mEllipseType = -1;
            mCicleType = -1;
            mPolygonType = -1;
            mCutType = -1;
        }
        private void DotLineMenuItem_Click(object sender, EventArgs e)
        {
            mLineType = 1;
        }
        private void DDAMenuItem_Click(object sender, EventArgs e)
        {
            mLineType = 2;
        }
        private void BresenhamMenuItem_Click(object sender, EventArgs e)
        {
            mLineType = 3;
        }
        public void sPaint()
        {
            hdc = useApi.GetDC(hwnd);
            if (mLineType == 1)
            {
                str = line.potLine(hdc, pt1.X, pt1.Y, pt2.X, pt2.Y, mColor);

            }
            if (mLineType == 2)
            {
                str = line.ddaLine(hdc, pt1.X, pt1.Y, pt2.X, pt2.Y, mColor);
            }
            if (mLineType == 3)
            {
                str = line.bresenhamLine(hdc, pt1.X, pt1.Y, pt2.X, pt2.Y, mColor);

            }
            useApi.ReleaseDC(hwnd, hdc);

        }
        #endregion


        #region 画圆算法
        private void 画圆算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mEllipseType = -1;
            mLineType = -1;
            mPolygonType = -1;
            mCutType = -1;
        }
        private void MidpotCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCicleType = 1;
        }
        private void bresenhamCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCicleType = 2;
        }
        public void CirclePaint()
        {
            hdc = useApi.GetDC(hwnd);
            if (mCicleType == 1)
            {
                str = circle.MidpotCircle(hdc, pt1.X, pt1.Y, pt2.X, pt2.Y, mColor);
            }
            if (mCicleType == 2)
            {
                str = circle.BresenhamPotCircle(hdc, pt1.X, pt1.Y, pt2.X, pt2.Y, mColor);
            }
            useApi.ReleaseDC(hwnd, hdc);
        }
        #endregion


        #region 画椭圆算法
        private void 画椭圆算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCicleType = -1;
            mLineType = -1;
            mPolygonType = -1;
            mCutType = -1;
        }
        private void MidPotEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mEllipseType = 1;
        }
        public void EllipsePaint()
        {
            hdc = useApi.GetDC(hwnd);
            line.ddaLine(hdc, pt1.X, pt1.Y, pt2.X, pt1.Y, mColor);
            line.ddaLine(hdc, pt1.X, pt1.Y, pt1.X, pt2.Y, mColor);
            line.ddaLine(hdc, pt1.X, pt2.Y, pt2.X, pt2.Y, mColor);
            line.ddaLine(hdc, pt2.X, pt1.Y, pt2.X, pt2.Y, mColor);
            if (mEllipseType == 1)
            {
                str = ellipse.MidpotEllipse(hdc, pt1.X, pt1.Y, pt2.X, pt2.Y, mColor);
            }
            useApi.ReleaseDC(hwnd, hdc);
        }
        #endregion


        #region 裁剪
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mEllipseType = -1;
            mLineType = -1;
            mCicleType = -1;
            mPolygonType = -1;
        }

        #region 线裁剪
        private void LineCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCutType = 1;
        }
        private void DrawLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineCutPoints = new List<Point>();
            storeLines = new List<StoreLine>();
            mCutLineType = 1;

        }
        private void CutRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCutLineType = 2;
            lineClipRegionPoints = new List<Point>();
        }
        private void CohenSutherlandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            mCutLineType = 3;
            this.Refresh();
            hdc = useApi.GetDC(hwnd);
            for(int i = 0; i<storeLines.Count;i++)
            {
                LineCut.cohenSutherland(hdc, storeLines[i].firstPoint, storeLines[i].lastPoint, lineClipRegionPoints[0], lineClipRegionPoints[1], Color.Blue);
            }
            storeLines = new List<StoreLine>();
            lineClipRegionPoints = new List<Point>();
            useApi.ReleaseDC(hwnd, hdc);
        }
        private void LiangYouDongBarskyLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCutLineType = 4;
            selectClipMethods(mCutLineType);
        }
        private void MidSeparateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCutLineType = 5;
            selectClipMethods(mCutLineType);
        }
        private void CyrusBeckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCutLineType = 6;
            selectClipMethods(mCutLineType);
        }
        private void SlopeCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCutLineType = 7;
            selectClipMethods(mCutLineType);
        }
        private void selectClipMethods(int mcutlineType)
        {
            this.Refresh();
            hdc = useApi.GetDC(hwnd);
            for (int i = 0; i < storeLines.Count; i++)
            {
                List<Point> points = new List<Point>();
                points.Add(storeLines[i].firstPoint);
                points.Add(storeLines[i].lastPoint);
                points.Add(lineClipRegionPoints[0]);
                points.Add(lineClipRegionPoints[1]);
                if(mcutlineType == 4)
                {
                    LineCut.liangyoudongBarsky(hdc, points, Color.Blue);
                }
                else if(mcutlineType == 5)
                {
                    LineCut.midSeparate(hdc, points, Color.Blue);
                }
                else if(mcutlineType == 6)
                {

                }
                else if(mcutlineType == 7)
                {
                    LineCut.slopeCut(hdc, points, Color.Blue);
                }
                
            }
            storeLines = new List<StoreLine>();
            lineClipRegionPoints = new List<Point>();
            useApi.ReleaseDC(hwnd, hdc);
        }
        #endregion

        #region 多边形裁剪
        private void PolygonCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCutType = 2;
        }
        private void DrawPolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCutPolygonType = 1;
            polygonCutPoints = new List<Point>();
        }

        private void PolygonCutRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCutPolygonType = 2;
            polygonClipRegionPoints = new List<Point>();
        }

        private void SutherlandHodgmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCutPolygonType = 3;
            this.Refresh();
            hdc = useApi.GetDC(hwnd);
            PolygonCut.sutherlandHodgmanClipPolygon(hdc, polygonCutPoints, polygonClipRegionPoints, Color.Blue);
            polygonCutPoints = new List<Point>();
            polygonClipRegionPoints = new List<Point>();
            useApi.ReleaseDC(hwnd, hdc);

        }

        private void WeilerAthertonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCutPolygonType = 4;
        }
        #endregion

        #endregion


        #region 文件
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定退出吗？", "提示信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                System.Environment.Exit(0);
            }

        }
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            //Invalidate();
            GC.Collect();
        }
        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        #endregion


        #region 多边形
        private void PolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mEllipseType = -1;
            mLineType = -1;
            mCicleType = -1;
            mCutType = -1;
        }
        private void draw_polygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mPolygonType = 1;
            mypoly = new polygon();
        }
        private void Seed_FillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mPolygonType = 2;
        }
        private void line_fillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mPolygonType = 3;
            fillingPaint();
        }
        private void fillingPaint()
        {
            hdc = useApi.GetDC(hwnd);
            if (mPolygonType == 3)
            {
                mypoly.linefill(hdc, Color.Pink);
            }
            useApi.ReleaseDC(hwnd, hdc);
        }

        #endregion


        #region 设置
        private void ColorSetMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog mcolorDig = new ColorDialog();
            if (mcolorDig.ShowDialog() == DialogResult.OK)
                mColor = mcolorDig.Color;
        }
        #endregion


       


    }
}
