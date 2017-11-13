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
        polygon mypoly;
        string str ;
        Point pt1, pt2;
        //int count = 0;
        //bool controlMouseDown = false;//保证鼠标移动划线是在鼠标点击之后开始进行

        private IntPtr hwnd;
        private IntPtr hdc;
        Color mColor = Color.Red;
        public Form1()
        {
            InitializeComponent();
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
        private void MidpotCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCicleType = 1;
        }
        private void bresenhamCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCicleType = 2;
        }

        private void MidPotEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mEllipseType = 1;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mPolygonType == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    hdc = useApi.GetDC(hwnd);
                    Point newpoint = new Point(e.X, e.Y);
                    mypoly.AddVertex(newpoint);
                    if (mypoly.m_NumVertex >= 2)
                        line.bresenhamLine(hdc, mypoly.getPoint(mypoly.m_NumVertex - 1).X, mypoly.getPoint(mypoly.m_NumVertex - 1).Y, mypoly.getPoint(mypoly.m_NumVertex).X, mypoly.getPoint(mypoly.m_NumVertex).Y, Color.Red);
                    useApi.ReleaseDC(hwnd, hdc);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    hdc = useApi.GetDC(hwnd);
                    Point newpoint = new Point(e.X, e.Y);
                    mypoly.AddVertex(newpoint);
                    // if (mypoly.m_NumVertex >= 2)
                    line.bresenhamLine(hdc, mypoly.getPoint(mypoly.m_NumVertex - 1).X, mypoly.getPoint(mypoly.m_NumVertex - 1).Y, mypoly.getPoint(mypoly.m_NumVertex).X, mypoly.getPoint(mypoly.m_NumVertex).Y, Color.Red);
                    line.bresenhamLine(hdc, mypoly.getPoint(1).X, mypoly.getPoint(1).Y, mypoly.getPoint(mypoly.m_NumVertex).X, mypoly.getPoint(mypoly.m_NumVertex).Y, Color.Red);

                    useApi.ReleaseDC(hwnd, hdc);

                }
            }
            if (mPolygonType == 2)
            {
                hdc = useApi.GetDC(hwnd);
                Point newseed = new Point(e.X, e.Y);
                string str = mypoly.seedfill(hdc, newseed, Color.Blue, Color.Red);
                useApi.ReleaseDC(hwnd, hdc);
                MessageBox.Show(str);


            }
            #region 绘图
            pt1.X = e.X;
            pt1.Y = e.Y;
            #endregion
            //controlMouseDown = true;

            #region 只需要点击两点就生成直线
            //if (mLineType == 1||mLineType==2)
            //{
            //    if (count == 0)
            //    {
            //        pt1.X = e.X;
            //        pt1.Y = e.Y;
            //    }
            //    if (count == 1)
            //    {
            //        pt2.X = e.X;
            //        pt2.Y = e.Y;

            //    }

            //}
            #endregion
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            #region 鼠标移动
            //if (mLineType != -1)
            //{
            //    //保证鼠标移动时出轨迹
            //    if (controlMouseDown)
            //    {
            //        if (mLineType != -1)
            //        {
            //            pt2.X = e.X;
            //            pt2.Y = e.Y;
            //            sPaint();
            //            pt1.X = pt2.X;
            //            pt1.Y = pt2.Y;
            //        }
            //    }
            //}
            #endregion

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            #region 绘图
            if (mPolygonType != -1)
            {

            }
            if (mLineType != -1 || mCicleType != -1 || mEllipseType != -1)
            {
                pt2.X = e.X;
                pt2.Y = e.Y;
            }
            if (mLineType != -1)
            {
                sPaint();
                //controlMouseDown = false;
            }
            if (mCicleType != -1)
            {
                line.ddaLine(hdc, pt1.X, pt1.Y, pt2.X, pt2.Y, mColor);
                CirclePaint();
            }
            if (mEllipseType != -1)
            {
                EllipsePaint();
            }
            if (str != null)
            {
                MessageBox.Show(str);
            }
            #endregion

            #region 只需要点击两点就生成直线
            //if (mLineType == 1 || mLineType == 2)
            //{
            //    if (count == 1)
            //    {
            //        sPaint();
            //        count++;
            //    }
            //    if (count == 0)
            //        count++;
            //    if (count == 2)
            //        count = 0;
            //}
            #endregion
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
                str =line.bresenhamLine(hdc, pt1.X, pt1.Y, pt2.X, pt2.Y, mColor);

            }
            useApi.ReleaseDC(hwnd, hdc);

        }
        public void CirclePaint()
        {
            hdc = useApi.GetDC(hwnd);
            if (mCicleType == 1)
            {
                str=circle.MidpotCircle(hdc, pt1.X, pt1.Y, pt2.X, pt2.Y, mColor);
            }
            if (mCicleType == 2)
            {
                str=circle.BresenhamPotCircle(hdc, pt1.X, pt1.Y, pt2.X, pt2.Y, mColor);
            }
            useApi.ReleaseDC(hwnd, hdc);
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
                str=ellipse.MidpotEllipse(hdc, pt1.X, pt1.Y, pt2.X, pt2.Y, mColor);
            }
            useApi.ReleaseDC(hwnd, hdc);
        }
        public void fillingPaint()
        {
            hdc = useApi.GetDC(hwnd);
            if (mPolygonType == 3)
            {
                mypoly.linefill(hdc, Color.Pink);
            }
            useApi.ReleaseDC(hwnd, hdc);
        }

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

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("您确定退出吗？","提示信息",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                System.Environment.Exit(0);
            }
            
        }

        
        private void 画线算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mCicleType != -1 || mEllipseType != -1)
            {
                mEllipseType = -1;
                mCicleType = -1;
            }
        }

        private void 画圆算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mLineType != -1 || mEllipseType != -1)
            {
                mEllipseType = -1;
                mLineType = -1;
            }
        }

        private void 画椭圆算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mLineType != -1|| mCicleType != -1)
            {
                mCicleType = -1;
                mLineType = -1;
            }
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Restart();
            this.Refresh();
        }

        private void PolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mLineType != -1 || mEllipseType != -1 || mCicleType != -1)
            {
                mEllipseType = -1;
                mLineType = -1;
                mCicleType = -1;
            }
        }

        private void ColorSetMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog mcolorDig = new ColorDialog();
            if (mcolorDig.ShowDialog() == DialogResult.OK)
                mColor = mcolorDig.Color;
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
        
    }
}
