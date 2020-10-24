using System;

namespace MissionPlanner.NewForms
{
    partial class RouteAltForm
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
            this.alt_SlidingScale = new TB.Instruments.SlidingScale();
            this.route_BUT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // alt_SlidingScale
            // 
            this.alt_SlidingScale.BackColor = System.Drawing.Color.White;
            this.alt_SlidingScale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alt_SlidingScale.CenterFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.alt_SlidingScale.CenterRectangleDisabledColor = System.Drawing.Color.FromArgb(((int) (((byte) (200)))), ((int) (((byte) (128)))), ((int) (((byte) (128)))), ((int) (((byte) (128)))));
            this.alt_SlidingScale.CenterRectangleEnabledColor = System.Drawing.Color.FromArgb(((int) (((byte) (200)))), ((int) (((byte) (30)))), ((int) (((byte) (144)))), ((int) (((byte) (255)))));
            this.alt_SlidingScale.CenterValueColor = System.Drawing.Color.FromArgb(((int) (((byte) (240)))), ((int) (((byte) (255)))), ((int) (((byte) (255)))));
            this.alt_SlidingScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.alt_SlidingScale.ForeColor = System.Drawing.Color.Black;
            this.alt_SlidingScale.LargeTicksCount = 10;
            this.alt_SlidingScale.LargeTicksLength = 20;
            this.alt_SlidingScale.Location = new System.Drawing.Point(2, 30);
            this.alt_SlidingScale.MaxValue = 5100D;
            this.alt_SlidingScale.MinValue = 80D;
            this.alt_SlidingScale.Name = "alt_SlidingScale";
            this.alt_SlidingScale.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.alt_SlidingScale.ScaleRange = 1000D;
            this.alt_SlidingScale.Size = new System.Drawing.Size(83, 237);
            this.alt_SlidingScale.SmallTickLength = 7;
            this.alt_SlidingScale.TabIndex = 1;
            this.alt_SlidingScale.Value = 80D;
            this.alt_SlidingScale.ValueChanged += new System.EventHandler<MissionPlanner.ValueChangedEventArgs>(this.alt_SlidingScale_ValueChanged);
            this.alt_SlidingScale.MouseDown += new System.Windows.Forms.MouseEventHandler(this.alt_SlidingScale_MouseDown);
            this.alt_SlidingScale.MouseMove += new System.Windows.Forms.MouseEventHandler(this.alt_SlidingScale_MouseMove);
            this.alt_SlidingScale.MouseUp += new System.Windows.Forms.MouseEventHandler(this.alt_SlidingScale_MouseUp);
            // 
            // route_BUT
            // 
            this.route_BUT.Location = new System.Drawing.Point(2, 1);
            this.route_BUT.Name = "route_BUT";
            this.route_BUT.Size = new System.Drawing.Size(83, 32);
            this.route_BUT.TabIndex = 2;
            this.route_BUT.Text = "Маршрут";
            this.route_BUT.UseVisualStyleBackColor = true;
            this.route_BUT.Click += new System.EventHandler(this.route_BUT_Click);
            // 
            // RouteAltForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(88, 289);
            this.Controls.Add(this.route_BUT);
            this.Controls.Add(this.alt_SlidingScale);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RouteAltForm";
            this.Text = "RouteAltForm";
            this.ResumeLayout(false);
            this.Shown += new EventHandler(this.RouteAltForm_Shown);
        }

        private TB.Instruments.SlidingScale alt_SlidingScale;
        private System.Windows.Forms.Button route_BUT;

        #endregion
    }
}