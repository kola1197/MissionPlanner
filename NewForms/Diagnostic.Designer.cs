namespace MissionPlanner.NewForms
{
    partial class DiagnosticForm
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
            this.myButton1 = new MissionPlanner.Controls.MyButton();
            this.myButton2 = new MissionPlanner.Controls.MyButton();
            this.myButton3 = new MissionPlanner.Controls.MyButton();
            this.myButton4 = new MissionPlanner.Controls.MyButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // myButton1
            // 
            this.myButton1.Location = new System.Drawing.Point(12, 12);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(40, 40);
            this.myButton1.TabIndex = 0;
            this.myButton1.Text = "1";
            this.myButton1.UseVisualStyleBackColor = true;
            // 
            // myButton2
            // 
            this.myButton2.Location = new System.Drawing.Point(58, 12);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(40, 40);
            this.myButton2.TabIndex = 1;
            this.myButton2.Text = "2";
            this.myButton2.UseVisualStyleBackColor = true;
            // 
            // myButton3
            // 
            this.myButton3.Location = new System.Drawing.Point(104, 12);
            this.myButton3.Name = "myButton3";
            this.myButton3.Size = new System.Drawing.Size(40, 40);
            this.myButton3.TabIndex = 2;
            this.myButton3.Text = "3";
            this.myButton3.UseVisualStyleBackColor = true;
            // 
            // myButton4
            // 
            this.myButton4.Location = new System.Drawing.Point(150, 12);
            this.myButton4.Name = "myButton4";
            this.myButton4.Size = new System.Drawing.Size(40, 40);
            this.myButton4.TabIndex = 3;
            this.myButton4.Text = "4";
            this.myButton4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "EKF:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "None";
            // 
            // DiagnosticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 246);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myButton4);
            this.Controls.Add(this.myButton3);
            this.Controls.Add(this.myButton2);
            this.Controls.Add(this.myButton1);
            this.Name = "DiagnosticForm";
            this.Text = "Diagnostic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Controls.MyButton myButton1;
        public Controls.MyButton myButton2;
        public Controls.MyButton myButton3;
        public Controls.MyButton myButton4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}