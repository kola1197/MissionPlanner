namespace MissionPlanner.Controls.NewControls
{
    partial class SNSControl
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
            this.myButton1 = new MissionPlanner.Controls.MyButton();
            this.myButton2 = new MissionPlanner.Controls.MyButton();
            this.SuspendLayout();
            // 
            // myButton1
            // 
            this.myButton1.BackgroundImage = global::MissionPlanner.Properties.Resources.bgdark;
            this.myButton1.Location = new System.Drawing.Point(0, 2);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(40, 23);
            this.myButton1.TabIndex = 0;
            this.myButton1.Text = "СНС";
            this.myButton1.UseVisualStyleBackColor = true;
            // 
            // myButton2
            // 
            this.myButton2.Location = new System.Drawing.Point(46, 2);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(62, 23);
            this.myButton2.TabIndex = 1;
            this.myButton2.Text = "Режим";
            this.myButton2.UseVisualStyleBackColor = true;
            // 
            // SNSControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MissionPlanner.Properties.Resources.bgdark;
            this.Controls.Add(this.myButton2);
            this.Controls.Add(this.myButton1);
            this.Name = "SNSControl";
            this.Size = new System.Drawing.Size(108, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private MyButton myButton1;
        private MyButton myButton2;
    }
}
