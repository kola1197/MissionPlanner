namespace MissionPlanner.Controls.NewControls
{
    partial class RouteSlidingScale
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
            this.alt_SlidingScale = new TB.Instruments.SlidingScale();
            this.SuspendLayout();
            // 
            // alt_SlidingScale
            // 
            this.alt_SlidingScale.BackColor = System.Drawing.Color.White;
            this.alt_SlidingScale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alt_SlidingScale.CenterRectangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.alt_SlidingScale.CenterValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.alt_SlidingScale.ForeColor = System.Drawing.Color.Black;
            this.alt_SlidingScale.LargeTicksCount = 10;
            this.alt_SlidingScale.LargeTicksLength = 20;
            this.alt_SlidingScale.Location = new System.Drawing.Point(0, 0);
            this.alt_SlidingScale.Name = "alt_SlidingScale";
            this.alt_SlidingScale.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.alt_SlidingScale.ScaleRange = 1000D;
            this.alt_SlidingScale.Size = new System.Drawing.Size(83, 237);
            this.alt_SlidingScale.SmallTickLength = 7;
            this.alt_SlidingScale.TabIndex = 0;
            this.alt_SlidingScale.Value = 80D;
            this.alt_SlidingScale.ValueChanged += new System.EventHandler<MissionPlanner.ValueChangedEventArgs>(this.alt_SlidingScale_ValueChanged);
            this.alt_SlidingScale.MouseDown += new System.Windows.Forms.MouseEventHandler(this.alt_SlidingScale_MouseDown);
            this.alt_SlidingScale.MouseMove += new System.Windows.Forms.MouseEventHandler(this.alt_SlidingScale_MouseMove);
            this.alt_SlidingScale.MouseUp += new System.Windows.Forms.MouseEventHandler(this.alt_SlidingScale_MouseUp);
            // 
            // RouteSlidingScale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.alt_SlidingScale);
            this.Name = "RouteSlidingScale";
            this.Size = new System.Drawing.Size(86, 240);
            this.ResumeLayout(false);

        }

        #endregion

        private TB.Instruments.SlidingScale alt_SlidingScale;
    }
}
