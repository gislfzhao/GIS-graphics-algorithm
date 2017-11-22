using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace hull
{
    public partial class Form1 : Form
    {
        public static int MAX = 200;
        public Bitmap mbmp = null;//位图定义。用来绘制图形的模板
        Graphics g_bmp = null;//基于位图的图形对象控制，该对象下的绘制是绘制在位图上的
       
        int Num,i,index,k,j;
        
        float[] x= new float[MAX];//  坐标
        float[] y= new float[MAX];
        float[] angle= new float[MAX];//角度
        float[] hx= new float[MAX/2];
        float[] hy= new float[MAX/2];
        float temp;
        
        public Form1()
        {
            InitializeComponent();
            string path = @"d:\tk.txt";
            if (!File.Exists(path))
            {
                MessageBox.Show("该文件不存在");

            }
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                Num = 0;
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {   bool flag = false;
                    string[] str = s.Split(' ');
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i]!="")
                        {
                            if (!flag)
                            {
                                x[Num] = Convert.ToSingle(str[i]);
                                flag = true;
                            }
                            else
                            {
                                y[Num] = float.Parse(str[i]);
                                Num++;
                            }
                        }
                    
                    }
                  

                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            mbmp = new Bitmap(350, 320);
            g_bmp = Graphics.FromImage(mbmp);
            //原离散点绘制
            g_bmp.DrawRectangle(Pens.Red, 5, 5, 340, 310);
            for (int i = 0; i < Num; i++) /*Search the Smallest Point*/
            {
                g_bmp.DrawEllipse(Pens.Black,x[i]/2-2,y[i]/2-2,4,4);

                 if (y[index] > y[i]) index = i;
                
            }
            e.Graphics.DrawImage(mbmp, new Point(0, 0));

            mbmp = new Bitmap(350, 320);
            g_bmp = Graphics.FromImage(mbmp);
            g_bmp.DrawRectangle(Pens.Red, 5, 5, 340, 310);

            hx[0] = x[index];
            hy[0] = y[index];

            g_bmp.DrawEllipse(Pens.Blue, x[index] / 2 - 2, y[index] / 2 - 2, 4, 4);
            x[Num] = x[0]; x[0] = x[index]; x[index] = x[Num];
            y[Num] = y[0]; y[0] = y[index]; y[index] = y[Num];

            for (int i = 1; i < Num; i++)  /* 角度排序*/
                angle[i] = (x[i] - x[0]) /(float) Math.Sqrt(Math.Pow(x[i] - x[0], 2) + Math.Pow(y[i] - y[0], 2));
            for (i = 1; i < Num - 1; i++)
            {
                index = i;
                for (j = i + 1; j < Num; j++)
                    if (angle[index] < angle[j]) index = j;
                angle[Num] = angle[i];
                angle[i] = angle[index];
                angle[index] = angle[Num];
                x[Num] = x[i]; x[i] = x[index]; x[index] = x[Num];
                y[Num] = y[i]; y[i] = y[index]; y[index] = y[Num];
            }


            g_bmp.DrawEllipse(Pens.Blue, x[0] / 2 - 2, y[0] / 2 - 2, 4, 4);
            
            for (i = 1; i < Num; i++)   /*Link the Vertex*/
            {
                g_bmp.DrawEllipse(Pens.Blue, x[i] / 2 - 2, y[i] / 2 - 2, 4, 4);
                g_bmp.DrawLine(Pens.Black, x[i] / 2, y[i] / 2, x[0] / 2, y[0] / 2);
                
            }

            e.Graphics.DrawImage(mbmp, new Point(350, 0));
            mbmp = new Bitmap(350, 320);
            g_bmp = Graphics.FromImage(mbmp);
            g_bmp.DrawRectangle(Pens.Red, 5, 5, 340, 310);
            
            x[Num] = x[0];
            y[Num] = y[0];
            
            for (i = 0; i < Num; i++)
            {
                g_bmp.DrawEllipse(Pens.Blue, x[i] / 2 - 2, y[i] / 2 - 2, 4, 4);
                g_bmp.DrawLine(Pens.Black, x[i] / 2, y[i] / 2, x[i+1] / 2, y[i+1] / 2);
                
            }
            e.Graphics.DrawImage(mbmp, new Point(0, 320));


            mbmp = new Bitmap(350, 320);
            g_bmp = Graphics.FromImage(mbmp);
            g_bmp.DrawRectangle(Pens.Red, 5, 5, 340, 310);

            for (i = 1, k = 1; i < Num; i++) /*凸壳计算*/
            {
                temp = (x[i] - hx[k - 1]) * (y[i + 1] - y[i]) - (x[i + 1] - x[i]) * (y[i] - hy[k - 1]);//以i+1到i的直线的右侧为正，等同于逆时针确定的顶点方向
                if (temp >= 0)
                {
                    hx[k] = x[i];
                    hy[k] = y[i];
                    for (j = k; j > 1; j--)  /*移除非凸壳点*/
                    {
                        temp =  (hy[j] - hy[j - 1])*(hx[j - 1] - hx[j - 2])  -(hx[j] - hx[j - 1]) * (hy[j - 1] - hy[j - 2]);
                        if (temp < 0)//j点在直线j-1~j-2的左侧，则j-1不是凸壳上的点
                        {
                            hx[j - 1] = hx[j];
                            hy[j - 1] = hy[j];
                            k--;
                        }
                        else break;
                    }
                    k++;
                }
            }
            hx[k] = hx[0];
            hy[k] = hy[0];
            
            for (i = 0; i < Num; i++)
            {
               
                g_bmp.DrawEllipse(Pens.Blue, x[i] / 2 - 2, y[i] / 2 - 2, 4, 4);
            }
            
            for (i = 0; i < k; i++)
            {
                g_bmp.DrawLine(Pens.Black, hx[i] / 2, hy[i] / 2, hx[i + 1] / 2, hy[i + 1] / 2);
            }

            e.Graphics.DrawImage(mbmp, new Point(350, 320));


        }
    }
}
