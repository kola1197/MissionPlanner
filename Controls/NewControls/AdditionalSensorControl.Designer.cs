namespace MissionPlanner.Controls.NewControls
{
    partial class AdditionalSensorControl
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sensorName_label = new System.Windows.Forms.Label();
            this.sensorValue_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bindingSourceCurrentState = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCurrentState)).BeginInit();
            this.SuspendLayout();
            // 
            // sensorName_label
            // 
            this.sensorName_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorName_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sensorName_label.ForeColor = System.Drawing.Color.White;
            this.sensorName_label.Location = new System.Drawing.Point(0, 99);
            this.sensorName_label.MinimumSize = new System.Drawing.Size(135, 21);
            this.sensorName_label.Name = "sensorName_label";
            this.sensorName_label.Size = new System.Drawing.Size(135, 21);
            this.sensorName_label.TabIndex = 0;
            this.sensorName_label.Text = "Температура";
            this.sensorName_label.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // sensorValue_label
            // 
            this.sensorValue_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorValue_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sensorValue_label.ForeColor = System.Drawing.Color.White;
            this.sensorValue_label.Location = new System.Drawing.Point(0, 51);
            this.sensorValue_label.MinimumSize = new System.Drawing.Size(138, 29);
            this.sensorValue_label.Name = "sensorValue_label";
            this.sensorValue_label.Size = new System.Drawing.Size(138, 29);
            this.sensorValue_label.TabIndex = 1;
            this.sensorValue_label.Text = "0";
            this.sensorValue_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bindingSourceCurrentState
            // 
            this.bindingSourceCurrentState.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // AdditionalSensorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::MissionPlanner.Properties.Resources.Group141;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.sensorValue_label);
            this.Controls.Add(this.sensorName_label);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(135, 135);
            this.Name = "AdditionalSensorControl";
            this.Size = new System.Drawing.Size(135, 135);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCurrentState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label sensorName_label;
        private System.Windows.Forms.Label sensorValue_label;
        private System.Windows.Forms.BindingSource bindingSourceCurrentState;
        private System.Windows.Forms.Timer timer1;
    }
}
