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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainButton = new MissionPlanner.Controls.MyButton();
            this.label3 = new System.Windows.Forms.Label();
            this.loadButton = new MissionPlanner.Controls.MyButton();
            this.saveButton = new MissionPlanner.Controls.MyButton();
            this.altButton = new MissionPlanner.Controls.MyButton();
            this.writeButton = new MissionPlanner.Controls.MyButton();
            this.getButton = new MissionPlanner.Controls.MyButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.deleteButton = new MissionPlanner.Controls.MyButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainButton
            // 
            this.mainButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mainButton.BackColor = System.Drawing.Color.Transparent;
            this.mainButton.BackgroundImage = global::MissionPlanner.Properties.Resources.home_v1;
            this.mainButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mainButton.BGGradBot = System.Drawing.Color.Empty;
            this.mainButton.BGGradTop = System.Drawing.Color.Empty;
            this.mainButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.mainButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.mainButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.mainButton.FlatAppearance.BorderSize = 0;
            this.mainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.mainButton.Location = new System.Drawing.Point(0, 527);
            this.mainButton.Name = "mainButton";
            this.mainButton.Outline = System.Drawing.Color.Empty;
            this.mainButton.Size = new System.Drawing.Size(95, 125);
            this.mainButton.TabIndex = 0;
            this.mainButton.Text = "Дом";
            this.mainButton.TextColor = System.Drawing.Color.Empty;
            this.mainButton.UseVisualStyleBackColor = false;
            this.mainButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Image = global::MissionPlanner.Properties.Resources.home_v1;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(0, 609);
            this.label3.MinimumSize = new System.Drawing.Size(95, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 43);
            this.label3.TabIndex = 9;
            this.label3.Text = "31356.0 км";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.Transparent;
            this.loadButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_dow;
            this.loadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.loadButton.BGGradBot = System.Drawing.Color.Empty;
            this.loadButton.BGGradTop = System.Drawing.Color.Empty;
            this.loadButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.loadButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.loadButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.loadButton.FlatAppearance.BorderSize = 0;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Location = new System.Drawing.Point(0, 0);
            this.loadButton.Name = "loadButton";
            this.loadButton.Outline = System.Drawing.Color.Empty;
            this.loadButton.Size = new System.Drawing.Size(95, 54);
            this.loadButton.TabIndex = 10;
            this.loadButton.TextColor = System.Drawing.Color.Empty;
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_save;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveButton.BGGradBot = System.Drawing.Color.Empty;
            this.saveButton.BGGradTop = System.Drawing.Color.Empty;
            this.saveButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.saveButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.saveButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(0, 84);
            this.saveButton.Name = "saveButton";
            this.saveButton.Outline = System.Drawing.Color.Empty;
            this.saveButton.Size = new System.Drawing.Size(95, 54);
            this.saveButton.TabIndex = 11;
            this.saveButton.TextColor = System.Drawing.Color.Empty;
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // altButton
            // 
            this.altButton.BackColor = System.Drawing.Color.Transparent;
            this.altButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_alt;
            this.altButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.altButton.BGGradBot = System.Drawing.Color.Empty;
            this.altButton.BGGradTop = System.Drawing.Color.Empty;
            this.altButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.altButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.altButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.altButton.FlatAppearance.BorderSize = 0;
            this.altButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.altButton.Location = new System.Drawing.Point(0, 172);
            this.altButton.Name = "altButton";
            this.altButton.Outline = System.Drawing.Color.Empty;
            this.altButton.Size = new System.Drawing.Size(95, 54);
            this.altButton.TabIndex = 12;
            this.altButton.TextColor = System.Drawing.Color.Empty;
            this.altButton.UseVisualStyleBackColor = false;
            // 
            // writeButton
            // 
            this.writeButton.BackColor = System.Drawing.Color.Transparent;
            this.writeButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_write;
            this.writeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.writeButton.BGGradBot = System.Drawing.Color.Empty;
            this.writeButton.BGGradTop = System.Drawing.Color.Empty;
            this.writeButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.writeButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.writeButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.writeButton.FlatAppearance.BorderSize = 0;
            this.writeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.writeButton.Location = new System.Drawing.Point(0, 256);
            this.writeButton.Name = "writeButton";
            this.writeButton.Outline = System.Drawing.Color.Empty;
            this.writeButton.Size = new System.Drawing.Size(95, 54);
            this.writeButton.TabIndex = 13;
            this.writeButton.TextColor = System.Drawing.Color.Empty;
            this.writeButton.UseVisualStyleBackColor = false;
            // 
            // getButton
            // 
            this.getButton.BackColor = System.Drawing.Color.Transparent;
            this.getButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_get;
            this.getButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.getButton.BGGradBot = System.Drawing.Color.Empty;
            this.getButton.BGGradTop = System.Drawing.Color.Empty;
            this.getButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.getButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.getButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.getButton.FlatAppearance.BorderSize = 0;
            this.getButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getButton.Location = new System.Drawing.Point(0, 340);
            this.getButton.MinimumSize = new System.Drawing.Size(95, 54);
            this.getButton.Name = "getButton";
            this.getButton.Outline = System.Drawing.Color.Empty;
            this.getButton.Size = new System.Drawing.Size(95, 54);
            this.getButton.TabIndex = 14;
            this.getButton.TextColor = System.Drawing.Color.Empty;
            this.getButton.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(0, 631);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(95, 21);
            this.progressBar1.TabIndex = 17;
            this.progressBar1.Visible = false;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.label6.Location = new System.Drawing.Point(0, 397);
            this.label6.MinimumSize = new System.Drawing.Size(95, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "Получить";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.label7.Location = new System.Drawing.Point(0, 313);
            this.label7.MinimumSize = new System.Drawing.Size(95, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Записать";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.label8.Location = new System.Drawing.Point(0, 229);
            this.label8.MinimumSize = new System.Drawing.Size(95, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "Высота";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.label9.Location = new System.Drawing.Point(0, 141);
            this.label9.MinimumSize = new System.Drawing.Size(95, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "Сохранить";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.label10.Location = new System.Drawing.Point(0, 57);
            this.label10.MinimumSize = new System.Drawing.Size(95, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 24);
            this.label10.TabIndex = 16;
            this.label10.Text = "Загрузить";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_delete2;
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteButton.BGGradBot = System.Drawing.Color.Empty;
            this.deleteButton.BGGradTop = System.Drawing.Color.Empty;
            this.deleteButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.deleteButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.deleteButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.ForeColor = System.Drawing.Color.Transparent;
            this.deleteButton.Location = new System.Drawing.Point(0, 424);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Outline = System.Drawing.Color.Empty;
            this.deleteButton.Size = new System.Drawing.Size(95, 54);
            this.deleteButton.TabIndex = 15;
            this.deleteButton.TextColor = System.Drawing.Color.Empty;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.label5.Location = new System.Drawing.Point(0, 481);
            this.label5.MinimumSize = new System.Drawing.Size(95, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "Удалить";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "14";
            this.label2.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "/";
            this.label4.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "14";
            this.label1.Visible = false;
            // 
            // WPMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.altButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainButton);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(500, 500);
            this.Name = "WPMenu";
            this.Size = new System.Drawing.Size(95, 652);
            this.Load += new System.EventHandler(this.WPMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyButton mainButton;
        public System.Windows.Forms.Label label3;
        public MyButton loadButton;
        public MyButton saveButton;
        public MyButton altButton;
        public MyButton writeButton;
        public MyButton getButton;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public MyButton deleteButton;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label1;
    }
}
