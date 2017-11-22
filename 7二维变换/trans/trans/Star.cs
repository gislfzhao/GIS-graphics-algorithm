using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;




namespace trans
{
    class Star
    {

        const double SCALE_X=0.9,SCALE_Y=0.9,THETA=.1;
        const int UP = 0, DOWN = 1, LEFT = 2, RIGHT = 3, SMALL = 4, LARGE = 5, ROTATE_R = 6, ROTATE_L = 7; 
        double MOV_X,MOV_Y;
        float[,] star1 = new float[6, 3];

        public Star()
        {
            MOV_X = 6; MOV_Y = 3;
            idde();
        }
       
       

        public void idde()
        {
            star1[0, 0] = 320;
            star1[0, 1] = 100;
            star1[0, 2] = 1;
            star1[1, 0] = 379;
            star1[1, 1] = 281;
            star1[1, 2] = 1;
            star1[2, 0] = 225;
            star1[2, 1] = 170;
            star1[2, 2] = 1;
            star1[3, 0] = 415;
            star1[3, 1] = 170;
            star1[3, 2] = 1;
            star1[4, 0] = 261;
            star1[4, 1] = 281;
            star1[4, 2] = 1;
            star1[5, 0] = 320;
            star1[5, 1] = 200;
            star1[5, 2] = 1;
                       
        }
      

        public void draw_star(Graphics g)
        {
            int j;
            Pen pen = new Pen(Color.Black);
            Font drawFont = new Font("宋体", 10);

            g.DrawString("说明：u为UP，d为DOWN ,l为LEFT,r为RIGHT，i为SMALL,o为LARGE,R为ROTATE_R,L为ROTATE_L", drawFont, Brushes.Black, new Point(5, 20));
           // Form1.getinstance().Label1.text = "dfdfdf";
            for (j = 0; j < 5; j++)
                if (j != 5 - 1)
                    g.DrawLine(pen, star1[j, 0], star1[j,1], (int)star1[j + 1,0], (int)star1[j + 1,1]);
                else
                    g.DrawLine(pen, (int)star1[j,0], (int)star1[j,1], (int)star1[0,0], (int)star1[0,1]);

            g.DrawEllipse(pen, (int)star1[5,0], (int)star1[5,1], 2, 2);
        }

      
        public  void Chg_star(int mode)
       {
	    double[,] tt= new double[3,3];
	    double angle = THETA;
	    double scale_x = SCALE_X,scale_y = SCALE_Y;
	    int i,j;

	  /* 初始化变换矩阵 */
	    for (i=0;i<3;i++)  
            for(j=0;j<3;j++) 
                tt[i,j]=0;
	     tt[0,0]=1;
	     tt[1,1]=1;
	     tt[2,2]=1;

	    switch(mode){  
            /* 变换矩阵计算 */
	   case LEFT:  tt[2,0]=-MOV_X;break;
	   case RIGHT: tt[2,0]=MOV_X;break;
	   case UP:    tt[2,1]=-MOV_Y;break;
	   case DOWN:  tt[2,1]=MOV_Y;break;
       case ROTATE_L: angle = -THETA; tt[0, 0] = Math.Cos(angle);
           tt[0, 1] = Math.Sin(angle);
           tt[1, 0] = -Math.Sin(angle);
           tt[1, 1] = Math.Cos(angle);
           tt[2, 0] = (1 - Math.Cos(angle)) * star1[5, 0] + Math.Sin(angle) * star1[5, 1];
           tt[2, 1] = (1 - Math.Cos(angle)) * star1[5, 1] - Math.Sin(angle) * star1[5, 0]; break;
	   case ROTATE_R:
		  tt[0,0]=Math.Cos(angle);
		  tt[0,1]=Math.Sin(angle);
		  tt[1,0]=-Math.Sin(angle);
		  tt[1,1]=Math.Cos(angle);
          tt[2, 0] = (1 - Math.Cos(angle)) * star1[5,0] + Math.Sin(angle) * star1[5,1];
          tt[2, 1] = (1 - Math.Cos(angle)) * star1[5,1] - Math.Sin(angle) * star1[5,0];
          break;
       case LARGE: scale_x = 1 / SCALE_X; scale_y = 1 / SCALE_Y; tt[0, 0] = scale_x;
          tt[1, 1] = scale_y;
          tt[2, 0] = (1 - scale_x) * star1[5, 0];
          tt[2, 1] = (1 - scale_y) * star1[5, 1];break;
	   case SMALL:    
           tt[0,0]=scale_x;
           tt[1,1]=scale_y;
           tt[2, 0] = (1 - scale_x) * star1[5, 0];
           tt[2, 1] = (1 - scale_y) * star1[5, 1];
		   break;
	    }
        matrix( tt, 6, 3, 3);

      }



      public  void matrix(double[,] bb, int l, int m, int n)

      {
      double[,] cc= new double[6,3];
      int i,j,k;
        for(i=0;i<l;i++) {
                for(j=0;j<n;j++){
                        cc[i,j]=0;
                        for (k = 0; k < m; k++) cc[i, j] = cc[i, j] + (double)star1[i,k] * bb[k, j];
               }
        }
        for(i=0;i<l;i++)
            for (j = 0; j < n; j++) star1[i,j] = (float)cc[i, j];



      }


    }
}
