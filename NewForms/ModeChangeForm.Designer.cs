using System;
using System.ComponentModel;

namespace MissionPlanner.NewForms
{
    partial class ModeChangeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModeChangeForm));
            this.BUT_SetAuto = new MissionPlanner.Controls.MyButton();
            this.BUT_SetManual = new MissionPlanner.Controls.MyButton();
            this.BUT_SetRtl = new MissionPlanner.Controls.MyButton();
            this.BUT_SetStab = new MissionPlanner.Controls.MyButton();
            this.SuspendLayout();
            // 
            // BUT_SetAuto
            // 
            this.BUT_SetAuto.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.BUT_SetAuto.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.BUT_SetAuto.ColorMouseDown = System.Drawing.Color.GreenYellow;
            this.BUT_SetAuto.ColorMouseOver = System.Drawing.Color.WhiteSmoke;
            this.BUT_SetAuto.ColorNotEnabled = System.Drawing.Color.Empty;
            this.BUT_SetAuto.DefaultTheme = false;
            this.BUT_SetAuto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_SetAuto.Location = new System.Drawing.Point(12, 8);
            this.BUT_SetAuto.Name = "BUT_SetAuto";
            this.BUT_SetAuto.Outline = System.Drawing.Color.Transparent;
            this.BUT_SetAuto.Size = new System.Drawing.Size(184, 30);
            this.BUT_SetAuto.TabIndex = 72;
            this.BUT_SetAuto.Text = "AUTO";
            this.BUT_SetAuto.TextColor = System.Drawing.Color.Black;
            this.BUT_SetAuto.UseVisualStyleBackColor = true;
            this.BUT_SetAuto.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SetMode_MouseUp);
            // 
            // BUT_SetManual
            // 
            this.BUT_SetManual.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.BUT_SetManual.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.BUT_SetManual.ColorMouseDown = System.Drawing.Color.GreenYellow;
            this.BUT_SetManual.ColorMouseOver = System.Drawing.Color.WhiteSmoke;
            this.BUT_SetManual.ColorNotEnabled = System.Drawing.Color.Empty;
            this.BUT_SetManual.DefaultTheme = false;
            this.BUT_SetManual.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_SetManual.Location = new System.Drawing.Point(12, 44);
            this.BUT_SetManual.Name = "BUT_SetManual";
            this.BUT_SetManual.Outline = System.Drawing.Color.Transparent;
            this.BUT_SetManual.Size = new System.Drawing.Size(184, 30);
            this.BUT_SetManual.TabIndex = 73;
            this.BUT_SetManual.Text = "MANUAL";
            this.BUT_SetManual.TextColor = System.Drawing.Color.Black;
            this.BUT_SetManual.UseVisualStyleBackColor = true;
            this.BUT_SetManual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SetMode_MouseUp);
            // 
            // BUT_SetRtl
            // 
            this.BUT_SetRtl.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.BUT_SetRtl.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.BUT_SetRtl.ColorMouseDown = System.Drawing.Color.GreenYellow;
            this.BUT_SetRtl.ColorMouseOver = System.Drawing.Color.WhiteSmoke;
            this.BUT_SetRtl.ColorNotEnabled = System.Drawing.Color.Empty;
            this.BUT_SetRtl.DefaultTheme = false;
            this.BUT_SetRtl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_SetRtl.Location = new System.Drawing.Point(12, 116);
            this.BUT_SetRtl.Name = "BUT_SetRtl";
            this.BUT_SetRtl.Outline = System.Drawing.Color.Transparent;
            this.BUT_SetRtl.Size = new System.Drawing.Size(184, 30);
            this.BUT_SetRtl.TabIndex = 74;
            this.BUT_SetRtl.Text = "RTL";
            this.BUT_SetRtl.TextColor = System.Drawing.Color.Black;
            this.BUT_SetRtl.UseVisualStyleBackColor = true;
            this.BUT_SetRtl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SetMode_MouseUp);
            // 
            // BUT_SetStab
            // 
            this.BUT_SetStab.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.BUT_SetStab.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.BUT_SetStab.ColorMouseDown = System.Drawing.Color.GreenYellow;
            this.BUT_SetStab.ColorMouseOver = System.Drawing.Color.WhiteSmoke;
            this.BUT_SetStab.ColorNotEnabled = System.Drawing.Color.Empty;
            this.BUT_SetStab.DefaultTheme = false;
            this.BUT_SetStab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_SetStab.Location = new System.Drawing.Point(12, 80);
            this.BUT_SetStab.Name = "BUT_SetStab";
            this.BUT_SetStab.Outline = System.Drawing.Color.Transparent;
            this.BUT_SetStab.Size = new System.Drawing.Size(184, 30);
            this.BUT_SetStab.TabIndex = 75;
            this.BUT_SetStab.Text = "STABILIZE";
            this.BUT_SetStab.TextColor = System.Drawing.Color.Black;
            this.BUT_SetStab.UseVisualStyleBackColor = true;
            this.BUT_SetStab.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SetMode_MouseUp);
            // 
            // ModeChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(208, 156);
            this.Controls.Add(this.BUT_SetStab);
            this.Controls.Add(this.BUT_SetRtl);
            this.Controls.Add(this.BUT_SetManual);
            this.Controls.Add(this.BUT_SetAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModeChangeForm";
            this.Text = "Изменить режим";
            this.Load += new System.EventHandler(this.ModeChangeForm_Load_1);
            this.Shown += new System.EventHandler(this.ModeChangeForm_Shown);
            this.ResumeLayout(false);

        }

        private MissionPlanner.Controls.MyButton BUT_SetAuto;

        #endregion

        private Controls.MyButton BUT_SetManual;
        private Controls.MyButton BUT_SetRtl;
        private Controls.MyButton BUT_SetStab;
    }
}