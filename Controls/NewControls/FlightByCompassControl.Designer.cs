﻿namespace MissionPlanner.Controls.NewControls
{
    partial class FlightByCompassControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.directionNowLabel = new System.Windows.Forms.Label();
            this.turnOnButton = new MissionPlanner.Controls.MyButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(106, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Полет по компасу";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(173, 127);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(84, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Полет по компасу";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Текущий курс";
            // 
            // directionNowLabel
            // 
            this.directionNowLabel.AutoSize = true;
            this.directionNowLabel.Location = new System.Drawing.Point(170, 169);
            this.directionNowLabel.Name = "directionNowLabel";
            this.directionNowLabel.Size = new System.Drawing.Size(13, 13);
            this.directionNowLabel.TabIndex = 4;
            this.directionNowLabel.Text = "0";
            // 
            // turnOnButton
            // 
            this.turnOnButton.BGGradBot = System.Drawing.Color.Empty;
            this.turnOnButton.BGGradTop = System.Drawing.Color.Empty;
            this.turnOnButton.Location = new System.Drawing.Point(119, 88);
            this.turnOnButton.Name = "turnOnButton";
            this.turnOnButton.Size = new System.Drawing.Size(75, 23);
            this.turnOnButton.TabIndex = 5;
            this.turnOnButton.Text = "Включить";
            this.turnOnButton.UseVisualStyleBackColor = true;
            this.turnOnButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.turnOnButton_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FlightByCompassControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.turnOnButton);
            this.Controls.Add(this.directionNowLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FlightByCompassControl";
            this.Size = new System.Drawing.Size(311, 400);
            this.VisibleChanged += new System.EventHandler(this.FlightByCompassControl_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label directionNowLabel;
        private MyButton turnOnButton;
        private System.Windows.Forms.Timer timer1;
    }
}
