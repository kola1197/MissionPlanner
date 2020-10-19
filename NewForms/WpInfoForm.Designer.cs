namespace MissionPlanner.NewForms
{
    partial class WpInfoForm
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
            this.wpInfoControl = new MissionPlanner.NewForms.WaypointInfoControl();
            this.SuspendLayout();
            // 
            // wpInfoControl
            // 
            this.wpInfoControl.Location = new System.Drawing.Point(10, 7);
            this.wpInfoControl.Name = "wpInfoControl";
            this.wpInfoControl.Size = new System.Drawing.Size(159, 113);
            this.wpInfoControl.TabIndex = 0;
            // 
            // WpInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(177, 130);
            this.Controls.Add(this.wpInfoControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WpInfoForm";
            this.Text = "WpInfoForm";
            this.ResumeLayout(false);

        }

        #endregion

        private WaypointInfoControl wpInfoControl;
    }
}