using System.ComponentModel;

namespace MissionPlanner.NewForms
{
    partial class CameraListenerSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraListenerSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.activeCameraViewAreaColorLabel = new System.Windows.Forms.Label();
            this.CameraOutdatedViewAreaLabel = new System.Windows.Forms.Label();
            this.drawCameraAreaCheckBox = new System.Windows.Forms.CheckBox();
            this.activeCameraViewAreaColorBox = new System.Windows.Forms.Panel();
            this.cameraOutdatedViewAreaColorBox = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.drawCrossHairCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 23);
            this.label1.TabIndex = 0;
            // 
            // activeCameraViewAreaColorLabel
            // 
            this.activeCameraViewAreaColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.activeCameraViewAreaColorLabel.Location = new System.Drawing.Point(12, 62);
            this.activeCameraViewAreaColorLabel.Name = "activeCameraViewAreaColorLabel";
            this.activeCameraViewAreaColorLabel.Size = new System.Drawing.Size(259, 23);
            this.activeCameraViewAreaColorLabel.TabIndex = 1;
            this.activeCameraViewAreaColorLabel.Text = "Цвет области видимости ВСКС:";
            // 
            // CameraOutdatedViewAreaLabel
            // 
            this.CameraOutdatedViewAreaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.CameraOutdatedViewAreaLabel.Location = new System.Drawing.Point(12, 85);
            this.CameraOutdatedViewAreaLabel.Name = "CameraOutdatedViewAreaLabel";
            this.CameraOutdatedViewAreaLabel.Size = new System.Drawing.Size(259, 32);
            this.CameraOutdatedViewAreaLabel.TabIndex = 2;
            this.CameraOutdatedViewAreaLabel.Text = "Цвет последней области видимости ВСКС при потере соеднения:";
            // 
            // drawCameraAreaCheckBox
            // 
            this.drawCameraAreaCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.drawCameraAreaCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.drawCameraAreaCheckBox.Location = new System.Drawing.Point(12, 5);
            this.drawCameraAreaCheckBox.Name = "drawCameraAreaCheckBox";
            this.drawCameraAreaCheckBox.Size = new System.Drawing.Size(375, 24);
            this.drawCameraAreaCheckBox.TabIndex = 3;
            this.drawCameraAreaCheckBox.Text = "Отображать область видимости:";
            this.drawCameraAreaCheckBox.UseVisualStyleBackColor = true;
            this.drawCameraAreaCheckBox.CheckedChanged += new System.EventHandler(this.drawCameraAreaCheckBox_CheckedChanged);
            // 
            // activeCameraViewAreaColorBox
            // 
            this.activeCameraViewAreaColorBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.activeCameraViewAreaColorBox.Location = new System.Drawing.Point(312, 62);
            this.activeCameraViewAreaColorBox.Name = "activeCameraViewAreaColorBox";
            this.activeCameraViewAreaColorBox.Size = new System.Drawing.Size(128, 23);
            this.activeCameraViewAreaColorBox.TabIndex = 4;
            this.activeCameraViewAreaColorBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.activeCameraViewAreaColorBox_MouseClick);
            // 
            // cameraOutdatedViewAreaColorBox
            // 
            this.cameraOutdatedViewAreaColorBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cameraOutdatedViewAreaColorBox.Enabled = false;
            this.cameraOutdatedViewAreaColorBox.Location = new System.Drawing.Point(312, 91);
            this.cameraOutdatedViewAreaColorBox.Name = "cameraOutdatedViewAreaColorBox";
            this.cameraOutdatedViewAreaColorBox.Size = new System.Drawing.Size(128, 26);
            this.cameraOutdatedViewAreaColorBox.TabIndex = 5;
            this.cameraOutdatedViewAreaColorBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CameraOldViewAreaColor_MouseClick);
            // 
            // drawCrossHairCheckBox
            // 
            this.drawCrossHairCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.drawCrossHairCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.drawCrossHairCheckBox.Location = new System.Drawing.Point(12, 35);
            this.drawCrossHairCheckBox.Name = "drawCrossHairCheckBox";
            this.drawCrossHairCheckBox.Size = new System.Drawing.Size(375, 24);
            this.drawCrossHairCheckBox.TabIndex = 6;
            this.drawCrossHairCheckBox.Text = "Отображать точку перекрестия:⠀";
            this.drawCrossHairCheckBox.UseVisualStyleBackColor = true;
            this.drawCrossHairCheckBox.CheckedChanged += new System.EventHandler(this.drawCrossHairCheckBox_CheckedChanged);
            // 
            // CameraListenerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 151);
            this.Controls.Add(this.drawCrossHairCheckBox);
            this.Controls.Add(this.cameraOutdatedViewAreaColorBox);
            this.Controls.Add(this.activeCameraViewAreaColorBox);
            this.Controls.Add(this.drawCameraAreaCheckBox);
            this.Controls.Add(this.CameraOutdatedViewAreaLabel);
            this.Controls.Add(this.activeCameraViewAreaColorLabel);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CameraListenerSettings";
            this.Text = "Настройки отображения ВСКС";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.CameraListenerSettings_Shown);
            this.LocationChanged += new System.EventHandler(this.CameraListenerSettings_LocationChanged);
            this.VisibleChanged += new System.EventHandler(this.CameraListenerSettings_VisibleChanged);
            this.Leave += new System.EventHandler(this.CameraListenerSettings_Leave);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.CheckBox drawCrossHairCheckBox;

        private System.Windows.Forms.ColorDialog colorDialog1;

        private System.Windows.Forms.Panel cameraOutdatedViewAreaColorBox;

        private System.Windows.Forms.Panel activeCameraViewAreaColorBox;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label activeCameraViewAreaColorLabel;
        private System.Windows.Forms.Label CameraOutdatedViewAreaLabel;
        private System.Windows.Forms.CheckBox drawCameraAreaCheckBox;

        #endregion
    }
}