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
            this.CMB_modes = new System.Windows.Forms.ComboBox();
            this.BUT_setmode = new MissionPlanner.Controls.MyButton();
            this.SuspendLayout();
            // 
            // CMB_modes
            // 
            this.CMB_modes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_modes.FormattingEnabled = true;
            this.CMB_modes.Location = new System.Drawing.Point(12, 21);
            this.CMB_modes.Name = "CMB_modes";
            this.CMB_modes.Size = new System.Drawing.Size(122, 21);
            this.CMB_modes.TabIndex = 71;
            this.CMB_modes.SelectedIndexChanged += new System.EventHandler(this.CMB_modes_SelectedIndexChanged);
            // 
            // BUT_setmode
            // 
            this.BUT_setmode.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.BUT_setmode.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.BUT_setmode.ColorMouseDown = System.Drawing.Color.Empty;
            this.BUT_setmode.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_setmode.ColorNotEnabled = System.Drawing.Color.Empty;
            this.BUT_setmode.DefaultTheme = false;
            this.BUT_setmode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_setmode.Location = new System.Drawing.Point(151, 19);
            this.BUT_setmode.Name = "BUT_setmode";
            this.BUT_setmode.Outline = System.Drawing.Color.Transparent;
            this.BUT_setmode.Size = new System.Drawing.Size(111, 23);
            this.BUT_setmode.TabIndex = 72;
            this.BUT_setmode.Text = "Установить";
            this.BUT_setmode.TextColor = System.Drawing.Color.Black;
            this.BUT_setmode.UseVisualStyleBackColor = true;
            this.BUT_setmode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BUTsetmode_MouseUp);
            // 
            // ModeChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(274, 61);
            this.Controls.Add(this.BUT_setmode);
            this.Controls.Add(this.CMB_modes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModeChangeForm";
            this.Text = "ModeChangeForm";
            this.Load += new System.EventHandler(this.ModeChangeForm_Load_1);
            this.ResumeLayout(false);

        }

        private MissionPlanner.Controls.MyButton BUT_setmode;

        private System.Windows.Forms.ComboBox CMB_modes;

        #endregion
    }
}