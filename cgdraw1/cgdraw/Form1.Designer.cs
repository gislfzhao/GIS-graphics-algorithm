namespace cgdraw
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripFrm = new System.Windows.Forms.MenuStrip();
            this.画线算法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DotLineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DDAMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BresenhamMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画圆算法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MidpotCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画椭圆算法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MidPotEllipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDA椭圆算法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.draw_polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Seed_FillingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.line_fillingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LineCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CohenSutherlandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LiangYouDongBarskyLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MidSeparateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CyrusBeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SlopeCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PolygonCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PolygonCutRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SutherlandHodgmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WeilerAthertonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorSetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripFrm.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripFrm
            // 
            this.menuStripFrm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.menuStripFrm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.画线算法ToolStripMenuItem,
            this.画圆算法ToolStripMenuItem,
            this.画椭圆算法ToolStripMenuItem,
            this.PolygonToolStripMenuItem,
            this.CutToolStripMenuItem,
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStripFrm.Location = new System.Drawing.Point(0, 0);
            this.menuStripFrm.Name = "menuStripFrm";
            this.menuStripFrm.Size = new System.Drawing.Size(635, 25);
            this.menuStripFrm.TabIndex = 0;
            this.menuStripFrm.Text = "menuStripFrm";
            // 
            // 画线算法ToolStripMenuItem
            // 
            this.画线算法ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DotLineMenuItem,
            this.DDAMenuItem,
            this.BresenhamMenuItem});
            this.画线算法ToolStripMenuItem.Name = "画线算法ToolStripMenuItem";
            this.画线算法ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.画线算法ToolStripMenuItem.Text = "画线算法";
            this.画线算法ToolStripMenuItem.Click += new System.EventHandler(this.画线算法ToolStripMenuItem_Click);
            // 
            // DotLineMenuItem
            // 
            this.DotLineMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DotLineMenuItem.Name = "DotLineMenuItem";
            this.DotLineMenuItem.Size = new System.Drawing.Size(165, 22);
            this.DotLineMenuItem.Text = "逐点比较法";
            this.DotLineMenuItem.Click += new System.EventHandler(this.DotLineMenuItem_Click);
            // 
            // DDAMenuItem
            // 
            this.DDAMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DDAMenuItem.Name = "DDAMenuItem";
            this.DDAMenuItem.Size = new System.Drawing.Size(165, 22);
            this.DDAMenuItem.Text = "DDA数字微分";
            this.DDAMenuItem.Click += new System.EventHandler(this.DDAMenuItem_Click);
            // 
            // BresenhamMenuItem
            // 
            this.BresenhamMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BresenhamMenuItem.Name = "BresenhamMenuItem";
            this.BresenhamMenuItem.Size = new System.Drawing.Size(165, 22);
            this.BresenhamMenuItem.Text = "Bresenham算法";
            this.BresenhamMenuItem.Click += new System.EventHandler(this.BresenhamMenuItem_Click);
            // 
            // 画圆算法ToolStripMenuItem
            // 
            this.画圆算法ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MidpotCircleToolStripMenuItem,
            this.bresenhamCircleToolStripMenuItem});
            this.画圆算法ToolStripMenuItem.Name = "画圆算法ToolStripMenuItem";
            this.画圆算法ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.画圆算法ToolStripMenuItem.Text = "画圆算法";
            this.画圆算法ToolStripMenuItem.Click += new System.EventHandler(this.画圆算法ToolStripMenuItem_Click);
            // 
            // MidpotCircleToolStripMenuItem
            // 
            this.MidpotCircleToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MidpotCircleToolStripMenuItem.Name = "MidpotCircleToolStripMenuItem";
            this.MidpotCircleToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.MidpotCircleToolStripMenuItem.Text = "中点圆算法";
            this.MidpotCircleToolStripMenuItem.Click += new System.EventHandler(this.MidpotCircleToolStripMenuItem_Click);
            // 
            // bresenhamCircleToolStripMenuItem
            // 
            this.bresenhamCircleToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bresenhamCircleToolStripMenuItem.Name = "bresenhamCircleToolStripMenuItem";
            this.bresenhamCircleToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.bresenhamCircleToolStripMenuItem.Text = "Bresenham算法";
            this.bresenhamCircleToolStripMenuItem.Click += new System.EventHandler(this.bresenhamCircleToolStripMenuItem_Click);
            // 
            // 画椭圆算法ToolStripMenuItem
            // 
            this.画椭圆算法ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MidPotEllipseToolStripMenuItem,
            this.dDA椭圆算法ToolStripMenuItem});
            this.画椭圆算法ToolStripMenuItem.Name = "画椭圆算法ToolStripMenuItem";
            this.画椭圆算法ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.画椭圆算法ToolStripMenuItem.Text = "画椭圆算法";
            this.画椭圆算法ToolStripMenuItem.Click += new System.EventHandler(this.画椭圆算法ToolStripMenuItem_Click);
            // 
            // MidPotEllipseToolStripMenuItem
            // 
            this.MidPotEllipseToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MidPotEllipseToolStripMenuItem.Name = "MidPotEllipseToolStripMenuItem";
            this.MidPotEllipseToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.MidPotEllipseToolStripMenuItem.Text = "中点椭圆算法";
            this.MidPotEllipseToolStripMenuItem.Click += new System.EventHandler(this.MidPotEllipseToolStripMenuItem_Click);
            // 
            // dDA椭圆算法ToolStripMenuItem
            // 
            this.dDA椭圆算法ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dDA椭圆算法ToolStripMenuItem.Name = "dDA椭圆算法ToolStripMenuItem";
            this.dDA椭圆算法ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.dDA椭圆算法ToolStripMenuItem.Text = "DDA椭圆算法";
            // 
            // PolygonToolStripMenuItem
            // 
            this.PolygonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.draw_polygonToolStripMenuItem,
            this.Seed_FillingToolStripMenuItem,
            this.line_fillingToolStripMenuItem});
            this.PolygonToolStripMenuItem.Name = "PolygonToolStripMenuItem";
            this.PolygonToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.PolygonToolStripMenuItem.Text = "多边形";
            this.PolygonToolStripMenuItem.Click += new System.EventHandler(this.PolygonToolStripMenuItem_Click);
            // 
            // draw_polygonToolStripMenuItem
            // 
            this.draw_polygonToolStripMenuItem.Name = "draw_polygonToolStripMenuItem";
            this.draw_polygonToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.draw_polygonToolStripMenuItem.Text = "绘制多边形";
            this.draw_polygonToolStripMenuItem.Click += new System.EventHandler(this.draw_polygonToolStripMenuItem_Click);
            // 
            // Seed_FillingToolStripMenuItem
            // 
            this.Seed_FillingToolStripMenuItem.Name = "Seed_FillingToolStripMenuItem";
            this.Seed_FillingToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.Seed_FillingToolStripMenuItem.Text = "种子填充算法";
            this.Seed_FillingToolStripMenuItem.Click += new System.EventHandler(this.Seed_FillingToolStripMenuItem_Click);
            // 
            // line_fillingToolStripMenuItem
            // 
            this.line_fillingToolStripMenuItem.Name = "line_fillingToolStripMenuItem";
            this.line_fillingToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.line_fillingToolStripMenuItem.Text = "扫描线填充算法";
            this.line_fillingToolStripMenuItem.Click += new System.EventHandler(this.line_fillingToolStripMenuItem_Click);
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LineCutToolStripMenuItem,
            this.PolygonCutToolStripMenuItem});
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.CutToolStripMenuItem.Text = "裁剪";
            this.CutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // LineCutToolStripMenuItem
            // 
            this.LineCutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DrawLineToolStripMenuItem,
            this.CutRegionToolStripMenuItem,
            this.CohenSutherlandToolStripMenuItem,
            this.LiangYouDongBarskyLineToolStripMenuItem,
            this.MidSeparateToolStripMenuItem,
            this.CyrusBeckToolStripMenuItem,
            this.SlopeCutToolStripMenuItem});
            this.LineCutToolStripMenuItem.Name = "LineCutToolStripMenuItem";
            this.LineCutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LineCutToolStripMenuItem.Text = "线裁剪";
            this.LineCutToolStripMenuItem.Click += new System.EventHandler(this.LineCutToolStripMenuItem_Click);
            // 
            // DrawLineToolStripMenuItem
            // 
            this.DrawLineToolStripMenuItem.Name = "DrawLineToolStripMenuItem";
            this.DrawLineToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.DrawLineToolStripMenuItem.Text = "画线";
            this.DrawLineToolStripMenuItem.Click += new System.EventHandler(this.DrawLineToolStripMenuItem_Click);
            // 
            // CutRegionToolStripMenuItem
            // 
            this.CutRegionToolStripMenuItem.Name = "CutRegionToolStripMenuItem";
            this.CutRegionToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.CutRegionToolStripMenuItem.Text = "裁剪的区域";
            this.CutRegionToolStripMenuItem.Click += new System.EventHandler(this.CutRegionToolStripMenuItem_Click);
            // 
            // CohenSutherlandToolStripMenuItem
            // 
            this.CohenSutherlandToolStripMenuItem.Name = "CohenSutherlandToolStripMenuItem";
            this.CohenSutherlandToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.CohenSutherlandToolStripMenuItem.Text = "cohen-sutherland算法";
            this.CohenSutherlandToolStripMenuItem.Click += new System.EventHandler(this.CohenSutherlandToolStripMenuItem_Click);
            // 
            // LiangYouDongBarskyLineToolStripMenuItem
            // 
            this.LiangYouDongBarskyLineToolStripMenuItem.Name = "LiangYouDongBarskyLineToolStripMenuItem";
            this.LiangYouDongBarskyLineToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.LiangYouDongBarskyLineToolStripMenuItem.Text = "梁友栋-Barsky直线算法";
            this.LiangYouDongBarskyLineToolStripMenuItem.Click += new System.EventHandler(this.LiangYouDongBarskyLineToolStripMenuItem_Click);
            // 
            // MidSeparateToolStripMenuItem
            // 
            this.MidSeparateToolStripMenuItem.Name = "MidSeparateToolStripMenuItem";
            this.MidSeparateToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.MidSeparateToolStripMenuItem.Text = "中点分割法";
            this.MidSeparateToolStripMenuItem.Click += new System.EventHandler(this.MidSeparateToolStripMenuItem_Click);
            // 
            // CyrusBeckToolStripMenuItem
            // 
            this.CyrusBeckToolStripMenuItem.Name = "CyrusBeckToolStripMenuItem";
            this.CyrusBeckToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.CyrusBeckToolStripMenuItem.Text = "Cyrus-Beck算法";
            this.CyrusBeckToolStripMenuItem.Click += new System.EventHandler(this.CyrusBeckToolStripMenuItem_Click);
            // 
            // SlopeCutToolStripMenuItem
            // 
            this.SlopeCutToolStripMenuItem.Name = "SlopeCutToolStripMenuItem";
            this.SlopeCutToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.SlopeCutToolStripMenuItem.Text = "斜率裁剪法";
            this.SlopeCutToolStripMenuItem.Click += new System.EventHandler(this.SlopeCutToolStripMenuItem_Click);
            // 
            // PolygonCutToolStripMenuItem
            // 
            this.PolygonCutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DrawPolygonToolStripMenuItem,
            this.PolygonCutRegionToolStripMenuItem,
            this.SutherlandHodgmanToolStripMenuItem,
            this.WeilerAthertonToolStripMenuItem});
            this.PolygonCutToolStripMenuItem.Name = "PolygonCutToolStripMenuItem";
            this.PolygonCutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.PolygonCutToolStripMenuItem.Text = "多边形裁剪";
            this.PolygonCutToolStripMenuItem.Click += new System.EventHandler(this.PolygonCutToolStripMenuItem_Click);
            // 
            // DrawPolygonToolStripMenuItem
            // 
            this.DrawPolygonToolStripMenuItem.Name = "DrawPolygonToolStripMenuItem";
            this.DrawPolygonToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.DrawPolygonToolStripMenuItem.Text = "多边形绘制";
            this.DrawPolygonToolStripMenuItem.Click += new System.EventHandler(this.DrawPolygonToolStripMenuItem_Click);
            // 
            // PolygonCutRegionToolStripMenuItem
            // 
            this.PolygonCutRegionToolStripMenuItem.Name = "PolygonCutRegionToolStripMenuItem";
            this.PolygonCutRegionToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.PolygonCutRegionToolStripMenuItem.Text = "裁剪区域";
            this.PolygonCutRegionToolStripMenuItem.Click += new System.EventHandler(this.PolygonCutRegionToolStripMenuItem_Click);
            // 
            // SutherlandHodgmanToolStripMenuItem
            // 
            this.SutherlandHodgmanToolStripMenuItem.Name = "SutherlandHodgmanToolStripMenuItem";
            this.SutherlandHodgmanToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.SutherlandHodgmanToolStripMenuItem.Text = "Sutherland-Hodgman算法";
            this.SutherlandHodgmanToolStripMenuItem.Click += new System.EventHandler(this.SutherlandHodgmanToolStripMenuItem_Click);
            // 
            // WeilerAthertonToolStripMenuItem
            // 
            this.WeilerAthertonToolStripMenuItem.Name = "WeilerAthertonToolStripMenuItem";
            this.WeilerAthertonToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.WeilerAthertonToolStripMenuItem.Text = "Weiler-Atherton算法";
            this.WeilerAthertonToolStripMenuItem.Click += new System.EventHandler(this.WeilerAthertonToolStripMenuItem_Click);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseToolStripMenuItem,
            this.ClearToolStripMenuItem,
            this.RestartToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.CloseToolStripMenuItem.Text = "退出";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ClearToolStripMenuItem.Text = "清除";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // RestartToolStripMenuItem
            // 
            this.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem";
            this.RestartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RestartToolStripMenuItem.Text = "重启";
            this.RestartToolStripMenuItem.Click += new System.EventHandler(this.RestartToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorSetMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // ColorSetMenuItem
            // 
            this.ColorSetMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ColorSetMenuItem.Name = "ColorSetMenuItem";
            this.ColorSetMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ColorSetMenuItem.Text = "颜色";
            this.ColorSetMenuItem.Click += new System.EventHandler(this.ColorSetMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 528);
            this.Controls.Add(this.menuStripFrm);
            this.MainMenuStrip = this.menuStripFrm;
            this.Name = "Form1";
            this.Text = "GIS图形算法程序";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStripFrm.ResumeLayout(false);
            this.menuStripFrm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripFrm;
        private System.Windows.Forms.ToolStripMenuItem 画线算法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DotLineMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColorSetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BresenhamMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DDAMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 画圆算法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MidpotCircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenhamCircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 画椭圆算法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MidPotEllipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDA椭圆算法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PolygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Seed_FillingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem line_fillingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem draw_polygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LineCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DrawLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CutRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CohenSutherlandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LiangYouDongBarskyLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MidSeparateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CyrusBeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SlopeCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PolygonCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DrawPolygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PolygonCutRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SutherlandHodgmanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WeilerAthertonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestartToolStripMenuItem;
    }
}

