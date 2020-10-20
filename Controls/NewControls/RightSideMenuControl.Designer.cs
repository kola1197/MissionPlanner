namespace MissionPlanner.Controls.NewControls
{
    partial class RightSideMenuControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ppkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antennaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::MissionPlanner.Properties.Resources.nonefon;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ppkToolStripMenuItem,
            this.regionsToolStripMenuItem,
            this.gskToolStripMenuItem,
            this.antennaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(126, 300);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            // 
            // ppkToolStripMenuItem
            // 
            this.ppkToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ppkToolStripMenuItem.Image = global::MissionPlanner.Properties.Resources.ppkV1;
            this.ppkToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ppkToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ppkToolStripMenuItem.Margin = new System.Windows.Forms.Padding(-6, 0, -6, -4);
            this.ppkToolStripMenuItem.Name = "ppkToolStripMenuItem";
            this.ppkToolStripMenuItem.Size = new System.Drawing.Size(125, 68);
            this.ppkToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.ppkToolStripMenuItem.Click += new System.EventHandler(this.ppkToolStripMenuItem_Click);
            // 
            // regionsToolStripMenuItem
            // 
            this.regionsToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.regionsToolStripMenuItem.Image = global::MissionPlanner.Properties.Resources.regionsV1;
            this.regionsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.regionsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.regionsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(-6, 0, -6, -4);
            this.regionsToolStripMenuItem.Name = "regionsToolStripMenuItem";
            this.regionsToolStripMenuItem.Size = new System.Drawing.Size(125, 68);
            this.regionsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.regionsToolStripMenuItem.Click += new System.EventHandler(this.regionsToolStripMenuItem_Click);
            // 
            // gskToolStripMenuItem
            // 
            this.gskToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.gskToolStripMenuItem.Image = global::MissionPlanner.Properties.Resources.gskV1;
            this.gskToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gskToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.gskToolStripMenuItem.Margin = new System.Windows.Forms.Padding(-6, 0, -6, -4);
            this.gskToolStripMenuItem.Name = "gskToolStripMenuItem";
            this.gskToolStripMenuItem.Size = new System.Drawing.Size(125, 68);
            this.gskToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // antennaToolStripMenuItem
            // 
            this.antennaToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.antennaToolStripMenuItem.Image = global::MissionPlanner.Properties.Resources.antV1;
            this.antennaToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.antennaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.antennaToolStripMenuItem.Margin = new System.Windows.Forms.Padding(-6, 0, -6, -4);
            this.antennaToolStripMenuItem.Name = "antennaToolStripMenuItem";
            this.antennaToolStripMenuItem.Size = new System.Drawing.Size(125, 68);
            this.antennaToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.antennaToolStripMenuItem.Click += new System.EventHandler(this.antennaToolStripMenuItem_Click);
            // 
            // RightSideMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(35, 300);
            this.Name = "RightSideMenuControl";
            this.Size = new System.Drawing.Size(35, 300);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ppkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem antennaToolStripMenuItem;
        
    }
}
