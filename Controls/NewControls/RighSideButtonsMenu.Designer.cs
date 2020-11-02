namespace MissionPlanner.Controls.NewControls
{
    partial class RighSideButtonsMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RighSideButtonsMenu));
            this.ppkButton = new System.Windows.Forms.Button();
            this.regButton = new System.Windows.Forms.Button();
            this.gskButton = new System.Windows.Forms.Button();
            this.antButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ppkButton
            // 
            this.ppkButton.BackColor = System.Drawing.Color.Transparent;
            this.ppkButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ppkButton.BackgroundImage")));
            this.ppkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ppkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ppkButton.Location = new System.Drawing.Point(0, 0);
            this.ppkButton.Name = "ppkButton";
            this.ppkButton.Size = new System.Drawing.Size(35, 75);
            this.ppkButton.TabIndex = 0;
            this.ppkButton.UseVisualStyleBackColor = false;
            // 
            // regButton
            // 
            this.regButton.BackColor = System.Drawing.Color.Transparent;
            this.regButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("regButton.BackgroundImage")));
            this.regButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.regButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regButton.Location = new System.Drawing.Point(0, 70);
            this.regButton.Name = "regButton";
            this.regButton.Size = new System.Drawing.Size(35, 75);
            this.regButton.TabIndex = 1;
            this.regButton.UseVisualStyleBackColor = false;
            // 
            // gskButton
            // 
            this.gskButton.BackColor = System.Drawing.Color.Transparent;
            this.gskButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gskButton.BackgroundImage")));
            this.gskButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gskButton.Location = new System.Drawing.Point(0, 141);
            this.gskButton.Name = "gskButton";
            this.gskButton.Size = new System.Drawing.Size(35, 75);
            this.gskButton.TabIndex = 2;
            this.gskButton.UseVisualStyleBackColor = false;
            // 
            // antButton
            // 
            this.antButton.BackColor = System.Drawing.Color.Transparent;
            this.antButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("antButton.BackgroundImage")));
            this.antButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.antButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.antButton.Location = new System.Drawing.Point(0, 213);
            this.antButton.Name = "antButton";
            this.antButton.Size = new System.Drawing.Size(35, 75);
            this.antButton.TabIndex = 3;
            this.antButton.UseVisualStyleBackColor = false;
            // 
            // RighSideButtonsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.antButton);
            this.Controls.Add(this.gskButton);
            this.Controls.Add(this.regButton);
            this.Controls.Add(this.ppkButton);
            this.Name = "RighSideButtonsMenu";
            this.Size = new System.Drawing.Size(35, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ppkButton;
        private System.Windows.Forms.Button regButton;
        private System.Windows.Forms.Button gskButton;
        private System.Windows.Forms.Button antButton;
    }
}
