using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace cgdraw
{
    class useApi
    {

        //得到窗口的句柄
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string classname, string windowname);

        //根据句柄得到一个剪辑区域
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        //根据句柄得到一个剪辑区域
        [DllImport("user32.dll")]
        public static extern IntPtr GetClientDC(IntPtr hwnd);

        // 释放设备
        [DllImport("user32.dll")]
        public static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        //获得指定坐标点的像素的RGB颜色值
        [DllImport("gdi32.dll")]
        public static extern int GetPixel(IntPtr hdc, int nXPos, int nYPos);

        //指定点赋值
        [DllImport("gdi32.dll")]
        public static extern int SetPixel(IntPtr hDC, int x, int y, int color);


        //返回指定窗口的边框矩形的尺寸
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle rect);

        //color转int
        public static int GetCustomColor(Color color)
        {

            int nColor = color.ToArgb();
            int blue = nColor & 255;
            int green = nColor >> 8 & 255;
            int red = nColor >> 16 & 255;
            return Convert.ToInt32(blue << 16 | green << 8 | red);

        }
        //int转color
        public Color GetArgbColor(int color)
        {

            int blue = color & 255;
            int green = color >> 8 & 255;
            int red = color >> 16 & 255;
            return Color.FromArgb(blue, green, red);

        }
        //public static Color GetPixelColor(int x, int y)
        //{
        //    IntPtr hdc = GetDC(IntPtr.Zero);
        //    int pixel = GetPixel(hdc, x, y);
        //    ReleaseDC(IntPtr.Zero, hdc);
        //    Color color = Color.FromArgb((int)(pixel & 0x000000FF),
        //    (int)(pixel & 0x0000FF00) >> 8,
        //    (int)(pixel & 0x00FF0000) >> 16);
        //    return color;
        //}
    }
}
