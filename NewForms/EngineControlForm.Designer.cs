namespace MissionPlanner.NewForms
{
    partial class EngineControlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.longestTimeThr_But = new MissionPlanner.Controls.MyButton();
            this.smallThr_but = new MissionPlanner.Controls.MyButton();
            this.fullThr_But = new MissionPlanner.Controls.MyButton();
            this.autoThr_But = new MissionPlanner.Controls.MyButton();
            this.throttle_TrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.manualThr_But = new MissionPlanner.Controls.MyButton();
            ((System.ComponentModel.ISupportInitialize) (this.throttle_TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // longestTimeThr_But
            // 
            this.longestTimeThr_But.BGGradBot = System.Drawing.Color.FromArgb(((int) (((byte) (32)))), ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.longestTimeThr_But.BGGradTop = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.longestTimeThr_But.DefaultTheme = false;
            this.longestTimeThr_But.Location = new System.Drawing.Point(12, 50);
            this.longestTimeThr_But.Name = "longestTimeThr_But";
            this.longestTimeThr_But.Outline = System.Drawing.Color.Black;
            this.longestTimeThr_But.Size = new System.Drawing.Size(75, 23);
            this.longestTimeThr_But.TabIndex = 0;
            this.longestTimeThr_But.Tag = "0";
            this.longestTimeThr_But.Text = "Время";
            this.longestTimeThr_But.TextColor = System.Drawing.Color.White;
            this.longestTimeThr_But.UseVisualStyleBackColor = true;
            this.longestTimeThr_But.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ThrottleMode_But_MouseUp);
            // 
            // smallThr_but
            // 
            this.smallThr_but.BGGradBot = System.Drawing.Color.FromArgb(((int) (((byte) (32)))), ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.smallThr_but.BGGradTop = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.smallThr_but.DefaultTheme = false;
            this.smallThr_but.Location = new System.Drawing.Point(12, 93);
            this.smallThr_but.Name = "smallThr_but";
            this.smallThr_but.Outline = System.Drawing.Color.Black;
            this.smallThr_but.Size = new System.Drawing.Size(75, 23);
            this.smallThr_but.TabIndex = 2;
            this.smallThr_but.Tag = "1";
            this.smallThr_but.Text = "Малый";
            this.smallThr_but.TextColor = System.Drawing.Color.White;
            this.smallThr_but.UseVisualStyleBackColor = true;
            this.smallThr_but.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ThrottleMode_But_MouseUp);
            // 
            // fullThr_But
            // 
            this.fullThr_But.BGGradBot = System.Drawing.Color.FromArgb(((int) (((byte) (32)))), ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.fullThr_But.BGGradTop = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.fullThr_But.DefaultTheme = false;
            this.fullThr_But.Location = new System.Drawing.Point(109, 93);
            this.fullThr_But.Name = "fullThr_But";
            this.fullThr_But.Outline = System.Drawing.Color.Black;
            this.fullThr_But.Size = new System.Drawing.Size(75, 23);
            this.fullThr_But.TabIndex = 3;
            this.fullThr_But.Tag = "2";
            this.fullThr_But.Text = "Полный";
            this.fullThr_But.TextColor = System.Drawing.Color.White;
            this.fullThr_But.UseVisualStyleBackColor = true;
            this.fullThr_But.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ThrottleMode_But_MouseUp);
            // 
            // autoThr_But
            // 
            this.autoThr_But.BGGradBot = System.Drawing.Color.FromArgb(((int) (((byte) (32)))), ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.autoThr_But.BGGradTop = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.autoThr_But.DefaultTheme = false;
            this.autoThr_But.Location = new System.Drawing.Point(109, 50);
            this.autoThr_But.Name = "autoThr_But";
            this.autoThr_But.Outline = System.Drawing.Color.Black;
            this.autoThr_But.Size = new System.Drawing.Size(75, 23);
            this.autoThr_But.TabIndex = 4;
            this.autoThr_But.Tag = "3";
            this.autoThr_But.Text = "Авто";
            this.autoThr_But.TextColor = System.Drawing.Color.White;
            this.autoThr_But.UseVisualStyleBackColor = true;
            this.autoThr_But.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ThrottleMode_But_MouseUp);
            // 
            // throttle_TrackBar
            // 
            this.throttle_TrackBar.Location = new System.Drawing.Point(12, 197);
            this.throttle_TrackBar.Maximum = 100;
            this.throttle_TrackBar.Name = "throttle_TrackBar";
            this.throttle_TrackBar.Size = new System.Drawing.Size(173, 45);
            this.throttle_TrackBar.TabIndex = 5;
            this.throttle_TrackBar.Value = 20;
            this.throttle_TrackBar.Scroll += new System.EventHandler(this.throttle_TrackBar_Scroll);
            this.throttle_TrackBar.ValueChanged += new System.EventHandler(this.throttle_TrackBar_ValueChanged);
            this.throttle_TrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.throttle_TrackBar_MouseDown);
            this.throttle_TrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.throttle_TrackBar_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // manualThr_But
            // 
            this.manualThr_But.BGGradBot = System.Drawing.Color.FromArgb(((int) (((byte) (32)))), ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.manualThr_But.BGGradTop = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.manualThr_But.DefaultTheme = false;
            this.manualThr_But.Location = new System.Drawing.Point(12, 137);
            this.manualThr_But.Name = "manualThr_But";
            this.manualThr_But.Outline = System.Drawing.Color.Black;
            this.manualThr_But.Size = new System.Drawing.Size(172, 23);
            this.manualThr_But.TabIndex = 7;
            this.manualThr_But.Tag = "4";
            this.manualThr_But.Text = "Ручной";
            this.manualThr_But.TextColor = System.Drawing.Color.White;
            this.manualThr_But.UseVisualStyleBackColor = true;
            this.manualThr_But.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ThrottleMode_But_MouseUp);
            // 
            // EngineControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (32)))), ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.ClientSize = new System.Drawing.Size(197, 254);
            this.Controls.Add(this.manualThr_But);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.throttle_TrackBar);
            this.Controls.Add(this.autoThr_But);
            this.Controls.Add(this.fullThr_But);
            this.Controls.Add(this.smallThr_but);
            this.Controls.Add(this.longestTimeThr_But);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EngineControlForm";
            this.Text = "EngineControlForm";
            this.Load += new System.EventHandler(this.EngineControlForm_Load);
            this.Shown += new System.EventHandler(this.EngineControlForm_Shown);
            ((System.ComponentModel.ISupportInitialize) (this.throttle_TrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MissionPlanner.Controls.MyButton autoThr_But;
        private MissionPlanner.Controls.MyButton fullThr_But;
        private MissionPlanner.Controls.MyButton longestTimeThr_But;
        private MissionPlanner.Controls.MyButton manualThr_But;
        private MissionPlanner.Controls.MyButton smallThr_but;
        private System.Windows.Forms.TrackBar throttle_TrackBar;

        #endregion

        private System.Windows.Forms.Label label1;
    }
}