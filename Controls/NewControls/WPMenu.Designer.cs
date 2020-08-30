namespace MissionPlanner.Controls.NewControls
{
    partial class WPMenu
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
            this.mainButton = new MissionPlanner.Controls.MyButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.myButton1 = new MissionPlanner.Controls.MyButton();
            this.myButton2 = new MissionPlanner.Controls.MyButton();
            this.myButton3 = new MissionPlanner.Controls.MyButton();
            this.myButton4 = new MissionPlanner.Controls.MyButton();
            this.myButton5 = new MissionPlanner.Controls.MyButton();
            this.myButton6 = new MissionPlanner.Controls.MyButton();
            this.SuspendLayout();
            // 
            // mainButton
            // 
            this.mainButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mainButton.Location = new System.Drawing.Point(3, 447);
            this.mainButton.Name = "mainButton";
            this.mainButton.Size = new System.Drawing.Size(89, 76);
            this.mainButton.TabIndex = 0;
            this.mainButton.Text = "Дом";
            this.mainButton.UseVisualStyleBackColor = true;
            this.mainButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 431);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "14";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 431);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "14";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 526);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "31356.0 км";
            // 
            // myButton1
            // 
            this.myButton1.Location = new System.Drawing.Point(6, 93);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(86, 23);
            this.myButton1.TabIndex = 10;
            this.myButton1.Text = "myButton1";
            this.myButton1.UseVisualStyleBackColor = true;
            // 
            // myButton2
            // 
            this.myButton2.Location = new System.Drawing.Point(6, 131);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(86, 23);
            this.myButton2.TabIndex = 11;
            this.myButton2.Text = "myButton2";
            this.myButton2.UseVisualStyleBackColor = true;
            // 
            // myButton3
            // 
            this.myButton3.Location = new System.Drawing.Point(6, 169);
            this.myButton3.Name = "myButton3";
            this.myButton3.Size = new System.Drawing.Size(86, 23);
            this.myButton3.TabIndex = 12;
            this.myButton3.Text = "myButton3";
            this.myButton3.UseVisualStyleBackColor = true;
            // 
            // myButton4
            // 
            this.myButton4.Location = new System.Drawing.Point(6, 207);
            this.myButton4.Name = "myButton4";
            this.myButton4.Size = new System.Drawing.Size(86, 23);
            this.myButton4.TabIndex = 13;
            this.myButton4.Text = "myButton4";
            this.myButton4.UseVisualStyleBackColor = true;
            // 
            // myButton5
            // 
            this.myButton5.Location = new System.Drawing.Point(6, 247);
            this.myButton5.Name = "myButton5";
            this.myButton5.Size = new System.Drawing.Size(86, 23);
            this.myButton5.TabIndex = 14;
            this.myButton5.Text = "myButton5";
            this.myButton5.UseVisualStyleBackColor = true;
            // 
            // myButton6
            // 
            this.myButton6.Location = new System.Drawing.Point(6, 285);
            this.myButton6.Name = "myButton6";
            this.myButton6.Size = new System.Drawing.Size(86, 23);
            this.myButton6.TabIndex = 15;
            this.myButton6.Text = "myButton6";
            this.myButton6.UseVisualStyleBackColor = true;
            // 
            // WPMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myButton6);
            this.Controls.Add(this.myButton5);
            this.Controls.Add(this.myButton4);
            this.Controls.Add(this.myButton3);
            this.Controls.Add(this.myButton2);
            this.Controls.Add(this.myButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainButton);
            this.Location = new System.Drawing.Point(500, 500);
            this.Name = "WPMenu";
            this.Size = new System.Drawing.Size(95, 545);
            this.Load += new System.EventHandler(this.WPMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyButton mainButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MyButton myButton1;
        private MyButton myButton2;
        private MyButton myButton3;
        private MyButton myButton4;
        private MyButton myButton5;
        private MyButton myButton6;
    }
}
