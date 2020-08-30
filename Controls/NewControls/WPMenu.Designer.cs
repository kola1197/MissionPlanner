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
            this.loadButton = new MissionPlanner.Controls.MyButton();
            this.saveButton = new MissionPlanner.Controls.MyButton();
            this.altButton = new MissionPlanner.Controls.MyButton();
            this.writeButton = new MissionPlanner.Controls.MyButton();
            this.getButton = new MissionPlanner.Controls.MyButton();
            this.deleteButton = new MissionPlanner.Controls.MyButton();
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
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(6, 93);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(86, 23);
            this.loadButton.TabIndex = 10;
            this.loadButton.Text = "Загрузить";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(6, 131);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(86, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // altButton
            // 
            this.altButton.Location = new System.Drawing.Point(6, 169);
            this.altButton.Name = "altButton";
            this.altButton.Size = new System.Drawing.Size(86, 23);
            this.altButton.TabIndex = 12;
            this.altButton.Text = "Высота";
            this.altButton.UseVisualStyleBackColor = true;
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(6, 207);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(86, 23);
            this.writeButton.TabIndex = 13;
            this.writeButton.Text = "Записать";
            this.writeButton.UseVisualStyleBackColor = true;
            // 
            // getButton
            // 
            this.getButton.Location = new System.Drawing.Point(6, 247);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(86, 23);
            this.getButton.TabIndex = 14;
            this.getButton.Text = "Получить";
            this.getButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(6, 285);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(86, 23);
            this.deleteButton.TabIndex = 15;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // WPMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.altButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
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
        public MyButton loadButton;
        public MyButton saveButton;
        public MyButton altButton;
        public MyButton writeButton;
        public MyButton getButton;
        public MyButton deleteButton;
    }
}
