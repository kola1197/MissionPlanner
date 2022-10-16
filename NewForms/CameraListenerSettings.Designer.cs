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
            this.ipConfigLabel = new System.Windows.Forms.Label();
            this.ipConfigTextBox = new System.Windows.Forms.TextBox();
            this.ipConfigButton = new MissionPlanner.Controls.MyButton();
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
            this.activeCameraViewAreaColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CameraOutdatedViewAreaLabel
            // 
            this.CameraOutdatedViewAreaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.CameraOutdatedViewAreaLabel.Location = new System.Drawing.Point(12, 85);
            this.CameraOutdatedViewAreaLabel.Name = "CameraOutdatedViewAreaLabel";
            this.CameraOutdatedViewAreaLabel.Size = new System.Drawing.Size(342, 32);
            this.CameraOutdatedViewAreaLabel.TabIndex = 2;
            this.CameraOutdatedViewAreaLabel.Text = "Цвет области видимости при потере связи с ВСКС:";
            this.CameraOutdatedViewAreaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // drawCameraAreaCheckBox
            // 
            this.drawCameraAreaCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.drawCameraAreaCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.drawCameraAreaCheckBox.Location = new System.Drawing.Point(12, 5);
            this.drawCameraAreaCheckBox.Name = "drawCameraAreaCheckBox";
            this.drawCameraAreaCheckBox.Size = new System.Drawing.Size(422, 24);
            this.drawCameraAreaCheckBox.TabIndex = 3;
            this.drawCameraAreaCheckBox.Text = "Отображать область видимости:";
            this.drawCameraAreaCheckBox.UseVisualStyleBackColor = true;
            this.drawCameraAreaCheckBox.CheckedChanged += new System.EventHandler(this.drawCameraAreaCheckBox_CheckedChanged);
            // 
            // activeCameraViewAreaColorBox
            // 
            this.activeCameraViewAreaColorBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.activeCameraViewAreaColorBox.Location = new System.Drawing.Point(360, 62);
            this.activeCameraViewAreaColorBox.Name = "activeCameraViewAreaColorBox";
            this.activeCameraViewAreaColorBox.Size = new System.Drawing.Size(128, 23);
            this.activeCameraViewAreaColorBox.TabIndex = 4;
            this.activeCameraViewAreaColorBox.BackColorChanged += new System.EventHandler(this.activeCameraViewAreaColorBox_BackColorChanged);
            this.activeCameraViewAreaColorBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.activeCameraViewAreaColorBox_MouseClick);
            // 
            // cameraOutdatedViewAreaColorBox
            // 
            this.cameraOutdatedViewAreaColorBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cameraOutdatedViewAreaColorBox.Location = new System.Drawing.Point(360, 91);
            this.cameraOutdatedViewAreaColorBox.Name = "cameraOutdatedViewAreaColorBox";
            this.cameraOutdatedViewAreaColorBox.Size = new System.Drawing.Size(128, 26);
            this.cameraOutdatedViewAreaColorBox.TabIndex = 5;
            this.cameraOutdatedViewAreaColorBox.BackColorChanged += new System.EventHandler(this.cameraOutdatedViewAreaColorBox_BackColorChanged);
            this.cameraOutdatedViewAreaColorBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CameraOldViewAreaColor_MouseClick);
            // 
            // drawCrossHairCheckBox
            // 
            this.drawCrossHairCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.drawCrossHairCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.drawCrossHairCheckBox.Location = new System.Drawing.Point(12, 32);
            this.drawCrossHairCheckBox.Name = "drawCrossHairCheckBox";
            this.drawCrossHairCheckBox.Size = new System.Drawing.Size(422, 24);
            this.drawCrossHairCheckBox.TabIndex = 6;
            this.drawCrossHairCheckBox.Text = "Отображать точку перекрестия:⠀";
            this.drawCrossHairCheckBox.UseVisualStyleBackColor = true;
            this.drawCrossHairCheckBox.CheckedChanged += new System.EventHandler(this.drawCrossHairCheckBox_CheckedChanged);
            // 
            // ipConfigLabel
            // 
            this.ipConfigLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ipConfigLabel.Location = new System.Drawing.Point(12, 127);
            this.ipConfigLabel.Name = "ipConfigLabel";
            this.ipConfigLabel.Size = new System.Drawing.Size(127, 22);
            this.ipConfigLabel.TabIndex = 7;
            this.ipConfigLabel.Text = "IP адрес камеры:";
            this.ipConfigLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ipConfigTextBox
            // 
            this.ipConfigTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ipConfigTextBox.Location = new System.Drawing.Point(145, 129);
            this.ipConfigTextBox.Name = "ipConfigTextBox";
            this.ipConfigTextBox.Size = new System.Drawing.Size(209, 22);
            this.ipConfigTextBox.TabIndex = 8;
            this.ipConfigTextBox.TextChanged += new System.EventHandler(this.ipConfigTextBox_TextChanged);
            // 
            // ipConfigButton
            // 
            this.ipConfigButton.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.ipConfigButton.BGGradBot = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.ipConfigButton.BGGradTop = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.ipConfigButton.Location = new System.Drawing.Point(360, 125);
            this.ipConfigButton.Name = "ipConfigButton";
            this.ipConfigButton.Outline = System.Drawing.Color.Transparent;
            this.ipConfigButton.Size = new System.Drawing.Size(128, 26);
            this.ipConfigButton.TabIndex = 9;
            this.ipConfigButton.Text = "Задать IP";
            this.ipConfigButton.TextColor = System.Drawing.Color.Black;
            this.ipConfigButton.UseVisualStyleBackColor = false;
            this.ipConfigButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ipConfigButton_MouseUp);
            // 
            // CameraListenerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 183);
            this.Controls.Add(this.ipConfigButton);
            this.Controls.Add(this.ipConfigTextBox);
            this.Controls.Add(this.ipConfigLabel);
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
            this.PerformLayout();
        }

        private MissionPlanner.Controls.MyButton ipConfigButton;

        private System.Windows.Forms.Label ipConfigLabel;
        private System.Windows.Forms.TextBox ipConfigTextBox;

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