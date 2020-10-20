namespace MissionPlanner.NewForms
{
    partial class CoordinatsModeForm
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
            this.wgs_gButton = new System.Windows.Forms.Button();
            this.wgs_gmButton = new System.Windows.Forms.Button();
            this.wgs_gmsButton = new System.Windows.Forms.Button();
            this.sk_gButton = new System.Windows.Forms.Button();
            this.sk_gmButton = new System.Windows.Forms.Button();
            this.sk_gmsButton = new System.Windows.Forms.Button();
            this.orthogonalСoordinatesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wgs_gButton
            // 
            this.wgs_gButton.Location = new System.Drawing.Point(12, 12);
            this.wgs_gButton.Name = "wgs_gButton";
            this.wgs_gButton.Size = new System.Drawing.Size(123, 23);
            this.wgs_gButton.TabIndex = 0;
            this.wgs_gButton.Tag = "0";
            this.wgs_gButton.Text = "Г (WGS84)";
            this.wgs_gButton.UseVisualStyleBackColor = true;
            this.wgs_gButton.BackColorChanged += new System.EventHandler(this.wgs_gButton_BackColorChanged);
            this.wgs_gButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // wgs_gmButton
            // 
            this.wgs_gmButton.Location = new System.Drawing.Point(12, 41);
            this.wgs_gmButton.Name = "wgs_gmButton";
            this.wgs_gmButton.Size = new System.Drawing.Size(123, 23);
            this.wgs_gmButton.TabIndex = 1;
            this.wgs_gmButton.Tag = "1";
            this.wgs_gmButton.Text = "ГМ (WGS84)";
            this.wgs_gmButton.UseVisualStyleBackColor = true;
            this.wgs_gmButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // wgs_gmsButton
            // 
            this.wgs_gmsButton.Location = new System.Drawing.Point(12, 70);
            this.wgs_gmsButton.Name = "wgs_gmsButton";
            this.wgs_gmsButton.Size = new System.Drawing.Size(123, 23);
            this.wgs_gmsButton.TabIndex = 2;
            this.wgs_gmsButton.Tag = "2";
            this.wgs_gmsButton.Text = "ГМС (WGS84)";
            this.wgs_gmsButton.UseVisualStyleBackColor = true;
            this.wgs_gmsButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // sk_gButton
            // 
            this.sk_gButton.Location = new System.Drawing.Point(12, 99);
            this.sk_gButton.Name = "sk_gButton";
            this.sk_gButton.Size = new System.Drawing.Size(123, 23);
            this.sk_gButton.TabIndex = 3;
            this.sk_gButton.Tag = "3";
            this.sk_gButton.Text = "Г (СК42)";
            this.sk_gButton.UseVisualStyleBackColor = true;
            this.sk_gButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // sk_gmButton
            // 
            this.sk_gmButton.Location = new System.Drawing.Point(12, 128);
            this.sk_gmButton.Name = "sk_gmButton";
            this.sk_gmButton.Size = new System.Drawing.Size(123, 23);
            this.sk_gmButton.TabIndex = 4;
            this.sk_gmButton.Tag = "4";
            this.sk_gmButton.Text = "ГМ (WGS84)";
            this.sk_gmButton.UseVisualStyleBackColor = true;
            this.sk_gmButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // sk_gmsButton
            // 
            this.sk_gmsButton.Location = new System.Drawing.Point(12, 157);
            this.sk_gmsButton.Name = "sk_gmsButton";
            this.sk_gmsButton.Size = new System.Drawing.Size(123, 23);
            this.sk_gmsButton.TabIndex = 5;
            this.sk_gmsButton.Tag = "5";
            this.sk_gmsButton.Text = "ГМС (WGS84)";
            this.sk_gmsButton.UseVisualStyleBackColor = true;
            this.sk_gmsButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // orthogonalСoordinatesButton
            // 
            this.orthogonalСoordinatesButton.Location = new System.Drawing.Point(11, 186);
            this.orthogonalСoordinatesButton.Name = "orthogonalСoordinatesButton";
            this.orthogonalСoordinatesButton.Size = new System.Drawing.Size(123, 48);
            this.orthogonalСoordinatesButton.TabIndex = 6;
            this.orthogonalСoordinatesButton.Tag = "6";
            this.orthogonalСoordinatesButton.Text = "Прямоугольные координаты";
            this.orthogonalСoordinatesButton.UseVisualStyleBackColor = true;
            this.orthogonalСoordinatesButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // CoordinatsModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(147, 244);
            this.Controls.Add(this.orthogonalСoordinatesButton);
            this.Controls.Add(this.sk_gmsButton);
            this.Controls.Add(this.sk_gmButton);
            this.Controls.Add(this.sk_gButton);
            this.Controls.Add(this.wgs_gmsButton);
            this.Controls.Add(this.wgs_gmButton);
            this.Controls.Add(this.wgs_gButton);
            this.Name = "CoordinatsModeForm";
            this.Text = "CoordinatsModeForm";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button wgs_gButton;
        public System.Windows.Forms.Button wgs_gmButton;
        public System.Windows.Forms.Button wgs_gmsButton;
        public System.Windows.Forms.Button sk_gButton;
        public System.Windows.Forms.Button sk_gmButton;
        public System.Windows.Forms.Button sk_gmsButton;
        public System.Windows.Forms.Button orthogonalСoordinatesButton;
    }
}