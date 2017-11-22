using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace trans
{
    public partial class Form1 : Form
    {
        private static Form1 _instance;
        Star s = new Star();
        public Form1()
        {
            _instance = this;    

            InitializeComponent();
            Star s = new Star();
           




        }
        public static Form1 getinstance()
        {

            return Form1._instance;
        }
        void Form1_Load(object sender, EventArgs e)
        {
           

            
        }

      
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;//this.CreateGraphics();
            s.draw_star(g);
            Bitmap bm = new Bitmap(this.Size.Width-25, this.Size.Height-25);
           
            this.DrawToBitmap(bm, new Rectangle(0, 0, this.Size.Width-25, this.Size.Height-25));
            bm.Save(@"d:\\test.png");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            if (e.KeyChar == 'u')
            {
                s.Chg_star(0);
                // UP = 0,
                g.Clear(this.BackColor);
                s.draw_star(g);
            }
            if (e.KeyChar == 'd')
            {
                s.Chg_star(1);
                // DOWN = 1, 
                g.Clear(this.BackColor);
                s.draw_star(g);
            }
            if (e.KeyChar == 'l')
            {
                s.Chg_star(2);
                //LEFT = 2,  
                g.Clear(this.BackColor);
                s.draw_star(g);
            }
            if (e.KeyChar == 'r')
            {
                s.Chg_star(3);
                //RIGHT = 3, 
                g.Clear(this.BackColor);
                s.draw_star(g);
            }
            if (e.KeyChar == 'i')
            {
                s.Chg_star(4);
                //SMALL = 4, 
                g.Clear(this.BackColor);
                s.draw_star(g);
            }
            if (e.KeyChar == 'o')
            {
                s.Chg_star(5);
                //LARGE = 5, 
                g.Clear(this.BackColor);
                s.draw_star(g);
            }
            if (e.KeyChar == 'L')
            {
                s.Chg_star(6);
                //ROTATE_R = 6, 
                g.Clear(this.BackColor);
                s.draw_star(g);
            }
            if (e.KeyChar == 'R')
            {
                s.Chg_star(7);
                //ROTATE_L = 7;
                g.Clear(this.BackColor);
                s.draw_star(g);
            }


        }





  



    }
}
