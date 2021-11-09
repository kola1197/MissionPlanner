using System.ComponentModel;

namespace MissionPlanner.NewForms
{
    partial class CycleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startPoint = new System.Windows.Forms.TextBox();
            this.endPoint = new System.Windows.Forms.TextBox();
            this.countOfRepeats = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Начальная точка:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Конечная точка:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Количество проходов:";
            // 
            // startPoint
            // 
            this.startPoint.Location = new System.Drawing.Point(170, 38);
            this.startPoint.Name = "startPoint";
            this.startPoint.Size = new System.Drawing.Size(100, 20);
            this.startPoint.TabIndex = 3;
            this.startPoint.TextChanged += new System.EventHandler(this.startPoint_TextChanged);
            // 
            // endPoint
            // 
            this.endPoint.Location = new System.Drawing.Point(170, 61);
            this.endPoint.Name = "endPoint";
            this.endPoint.Size = new System.Drawing.Size(100, 20);
            this.endPoint.TabIndex = 4;
            this.endPoint.TextChanged += new System.EventHandler(this.endPoint_TextChanged);
            // 
            // countOfRepeats
            // 
            this.countOfRepeats.Location = new System.Drawing.Point(170, 84);
            this.countOfRepeats.Name = "countOfRepeats";
            this.countOfRepeats.Size = new System.Drawing.Size(100, 20);
            this.countOfRepeats.TabIndex = 5;
            this.countOfRepeats.TextChanged += new System.EventHandler(this.countOfRepeats_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(276, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Данные не корректны";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(276, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Данные не корректны";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(276, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Данные не корректны";
            this.label6.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(260, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Сбросить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(94, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(285, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "Убедитесь, что конечная точка является маршрутной";
            // 
            // CycleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 140);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.countOfRepeats);
            this.Controls.Add(this.endPoint);
            this.Controls.Add(this.startPoint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CycleForm";
            this.Text = "Зацикливание";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label7;

        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

        public System.Windows.Forms.TextBox countOfRepeats;
        public System.Windows.Forms.TextBox endPoint;
        public System.Windows.Forms.TextBox startPoint;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        #endregion
    }
}