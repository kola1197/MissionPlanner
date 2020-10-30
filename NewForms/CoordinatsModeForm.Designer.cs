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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoordinatsModeForm));
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
            this.wgs_gButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.wgs_gButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.wgs_gButton.ForeColor = System.Drawing.Color.Black;
            this.wgs_gButton.Location = new System.Drawing.Point(12, 12);
            this.wgs_gButton.Name = "wgs_gButton";
            this.wgs_gButton.Size = new System.Drawing.Size(123, 23);
            this.wgs_gButton.TabIndex = 0;
            this.wgs_gButton.Tag = "0";
            this.wgs_gButton.Text = "Г (WGS84)";
            this.wgs_gButton.UseVisualStyleBackColor = false;
            this.wgs_gButton.BackColorChanged += new System.EventHandler(this.wgs_gButton_BackColorChanged);
            this.wgs_gButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // wgs_gmButton
            // 
            this.wgs_gmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.wgs_gmButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.wgs_gmButton.ForeColor = System.Drawing.Color.Black;
            this.wgs_gmButton.Location = new System.Drawing.Point(12, 41);
            this.wgs_gmButton.Name = "wgs_gmButton";
            this.wgs_gmButton.Size = new System.Drawing.Size(123, 23);
            this.wgs_gmButton.TabIndex = 1;
            this.wgs_gmButton.Tag = "1";
            this.wgs_gmButton.Text = "ГМ (WGS84)";
            this.wgs_gmButton.UseVisualStyleBackColor = false;
            this.wgs_gmButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // wgs_gmsButton
            // 
            this.wgs_gmsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.wgs_gmsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.wgs_gmsButton.ForeColor = System.Drawing.Color.Black;
            this.wgs_gmsButton.Location = new System.Drawing.Point(12, 70);
            this.wgs_gmsButton.Name = "wgs_gmsButton";
            this.wgs_gmsButton.Size = new System.Drawing.Size(123, 23);
            this.wgs_gmsButton.TabIndex = 2;
            this.wgs_gmsButton.Tag = "2";
            this.wgs_gmsButton.Text = "ГМС (WGS84)";
            this.wgs_gmsButton.UseVisualStyleBackColor = false;
            this.wgs_gmsButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // sk_gButton
            // 
            this.sk_gButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.sk_gButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sk_gButton.ForeColor = System.Drawing.Color.Black;
            this.sk_gButton.Location = new System.Drawing.Point(12, 99);
            this.sk_gButton.Name = "sk_gButton";
            this.sk_gButton.Size = new System.Drawing.Size(123, 23);
            this.sk_gButton.TabIndex = 3;
            this.sk_gButton.Tag = "3";
            this.sk_gButton.Text = "Г (СК42)";
            this.sk_gButton.UseVisualStyleBackColor = false;
            this.sk_gButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // sk_gmButton
            // 
            this.sk_gmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.sk_gmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sk_gmButton.ForeColor = System.Drawing.Color.Black;
            this.sk_gmButton.Location = new System.Drawing.Point(12, 128);
            this.sk_gmButton.Name = "sk_gmButton";
            this.sk_gmButton.Size = new System.Drawing.Size(123, 23);
            this.sk_gmButton.TabIndex = 4;
            this.sk_gmButton.Tag = "4";
            this.sk_gmButton.Text = "ГМ (WGS84)";
            this.sk_gmButton.UseVisualStyleBackColor = false;
            this.sk_gmButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // sk_gmsButton
            // 
            this.sk_gmsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.sk_gmsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sk_gmsButton.ForeColor = System.Drawing.Color.Black;
            this.sk_gmsButton.Location = new System.Drawing.Point(12, 157);
            this.sk_gmsButton.Name = "sk_gmsButton";
            this.sk_gmsButton.Size = new System.Drawing.Size(123, 23);
            this.sk_gmsButton.TabIndex = 5;
            this.sk_gmsButton.Tag = "5";
            this.sk_gmsButton.Text = "ГМС (WGS84)";
            this.sk_gmsButton.UseVisualStyleBackColor = false;
            this.sk_gmsButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // orthogonalСoordinatesButton
            // 
            this.orthogonalСoordinatesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.orthogonalСoordinatesButton.ForeColor = System.Drawing.Color.Black;
            this.orthogonalСoordinatesButton.Location = new System.Drawing.Point(11, 186);
            this.orthogonalСoordinatesButton.Name = "orthogonalСoordinatesButton";
            this.orthogonalСoordinatesButton.Size = new System.Drawing.Size(123, 48);
            this.orthogonalСoordinatesButton.TabIndex = 6;
            this.orthogonalСoordinatesButton.Tag = "6";
            this.orthogonalСoordinatesButton.Text = "Прямоугольные координаты";
            this.orthogonalСoordinatesButton.UseVisualStyleBackColor = false;
            this.orthogonalСoordinatesButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // CoordinatsModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(147, 244);
            this.Controls.Add(this.orthogonalСoordinatesButton);
            this.Controls.Add(this.sk_gmsButton);
            this.Controls.Add(this.sk_gmButton);
            this.Controls.Add(this.sk_gButton);
            this.Controls.Add(this.wgs_gmsButton);
            this.Controls.Add(this.wgs_gmButton);
            this.Controls.Add(this.wgs_gButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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