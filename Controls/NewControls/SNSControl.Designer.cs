﻿namespace MissionPlanner.Controls.NewControls
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
            this.myButton3 = new MissionPlanner.Controls.MyButton();
            this.myButton4 = new MissionPlanner.Controls.MyButton();
            this.SuspendLayout();
            // 
            // myButton1
            // 
            this.myButton1.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton1.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton1.Location = new System.Drawing.Point(0, 2);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(40, 23);
            this.myButton1.TabIndex = 0;
            this.myButton1.Text = "СНС";
            this.myButton1.UseVisualStyleBackColor = true;
            this.myButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton1_MouseUp);
            // 
            // myButton2
            // 
            this.myButton2.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton2.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton2.Location = new System.Drawing.Point(39, 2);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(62, 23);
            this.myButton2.TabIndex = 1;
            this.myButton2.Text = "Режим";
            this.myButton2.UseVisualStyleBackColor = true;
            this.myButton2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton2_MouseUp);
            // 
            // myButton3
            // 
            this.myButton3.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton3.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton3.Location = new System.Drawing.Point(100, 2);
            this.myButton3.Name = "myButton3";
            this.myButton3.Size = new System.Drawing.Size(62, 23);
            this.myButton3.TabIndex = 2;
            this.myButton3.Text = "Vibe";
            this.myButton3.UseVisualStyleBackColor = true;
            this.myButton3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton3_MouseUp);
            // 
            // myButton4
            // 
            this.myButton4.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton4.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton4.Location = new System.Drawing.Point(160, 2);
            this.myButton4.Name = "myButton4";
            this.myButton4.Size = new System.Drawing.Size(62, 23);
            this.myButton4.TabIndex = 3;
            this.myButton4.Text = "Посадка";
            this.myButton4.UseVisualStyleBackColor = true;
            this.myButton4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton4_MouseUp);
            // 
            // SNSControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MissionPlanner.Properties.Resources.bgdark;
            this.Controls.Add(this.myButton4);
            this.Controls.Add(this.myButton3);
            this.Controls.Add(this.myButton2);
            this.Controls.Add(this.myButton1);
            this.Name = "SNSControl";
            this.Size = new System.Drawing.Size(235, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private MyButton myButton1;
        private MyButton myButton2;
        private MyButton myButton3;
        private MyButton myButton4;
    }
}
