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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sensorName_label = new System.Windows.Forms.Label();
            this.sensorValue_label = new System.Windows.Forms.Label();
            this.bindingSourceCurrentState = new System.Windows.Forms.BindingSource(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCurrentState)).BeginInit();
            this.SuspendLayout();
            // 
            // sensorName_label
            // 
            this.sensorName_label.Location = new System.Drawing.Point(3, 87);
            this.sensorName_label.Name = "sensorName_label";
            this.sensorName_label.Size = new System.Drawing.Size(117, 36);
            this.sensorName_label.TabIndex = 0;
            this.sensorName_label.Text = "label1";
            this.sensorName_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sensorValue_label
            // 
            this.sensorValue_label.AutoSize = true;
            this.sensorValue_label.Location = new System.Drawing.Point(43, 49);
            this.sensorValue_label.Name = "sensorValue_label";
            this.sensorValue_label.Size = new System.Drawing.Size(35, 13);
            this.sensorValue_label.TabIndex = 1;
            this.sensorValue_label.Text = "label2";
            this.sensorValue_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bindingSourceCurrentState
            // 
            this.bindingSourceCurrentState.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AdditionalSensorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sensorValue_label);
            this.Controls.Add(this.sensorName_label);
            this.Name = "AdditionalSensorControl";
            this.Size = new System.Drawing.Size(123, 123);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCurrentState)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sensorName_label;
        private System.Windows.Forms.Label sensorValue_label;
        private System.Windows.Forms.BindingSource bindingSourceCurrentState;
        private System.Windows.Forms.Timer timer1;
    }
}
