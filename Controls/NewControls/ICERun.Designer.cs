namespace MissionPlanner.Controls.NewControls
{
    partial class ICERun
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
            this.startButton = new MissionPlanner.Controls.MyButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tempLabel = new System.Windows.Forms.Label();
            this.spedsLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startButton.BGGradBot = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.startButton.BGGradTop = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.startButton.ColorMouseDown = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.startButton.ColorMouseOver = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.startButton.ColorNotEnabled = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.startButton.DefaultTheme = false;
            this.startButton.Location = new System.Drawing.Point(133, 311);
            this.startButton.Name = "startButton";
            this.startButton.Outline = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.startButton.Size = new System.Drawing.Size(148, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Запуск двигателя";
            this.startButton.TextColor = System.Drawing.Color.Black;
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.startButton_MouseUp);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(130, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Температура:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(152, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Обороты:";
            // 
            // tempLabel
            // 
            this.tempLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tempLabel.AutoSize = true;
            this.tempLabel.ForeColor = System.Drawing.Color.White;
            this.tempLabel.Location = new System.Drawing.Point(213, 121);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(13, 13);
            this.tempLabel.TabIndex = 3;
            this.tempLabel.Text = "0";
            // 
            // spedsLabel
            // 
            this.spedsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spedsLabel.AutoSize = true;
            this.spedsLabel.ForeColor = System.Drawing.Color.White;
            this.spedsLabel.Location = new System.Drawing.Point(213, 154);
            this.spedsLabel.Name = "spedsLabel";
            this.spedsLabel.Size = new System.Drawing.Size(13, 13);
            this.spedsLabel.TabIndex = 4;
            this.spedsLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(152, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Нагрев не идет";
            // 
            // ICERun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (32)))), ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.spedsLabel);
            this.Controls.Add(this.tempLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.Name = "ICERun";
            this.Size = new System.Drawing.Size(432, 432);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MyButton startButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.Label spedsLabel;
        private System.Windows.Forms.Label label3;
    }
}
