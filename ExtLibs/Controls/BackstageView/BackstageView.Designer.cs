namespace MissionPlanner.Controls.BackstageView
{
    partial class BackstageView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPages = new System.Windows.Forms.Panel();
            this.pnlMenu = new MissionPlanner.Controls.BackstageView.BackStageViewMenuPanel();
            this.myButton1 = new MissionPlanner.Controls.MyButton();
            this.SuspendLayout();
            // 
            // pnlPages
            // 
            this.pnlPages.AutoScroll = true;
            this.pnlPages.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPages.Location = new System.Drawing.Point(200, 0);
            this.pnlPages.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPages.Name = "pnlPages";
            this.pnlPages.Size = new System.Drawing.Size(436, 360);
            this.pnlPages.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.Location = new System.Drawing.Point(0, 26);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 334);
            this.pnlMenu.TabIndex = 1;
            // 
            // myButton1
            // 
            this.myButton1.BGGradBot = System.Drawing.Color.Empty;
            this.myButton1.BGGradTop = System.Drawing.Color.Empty;
            this.myButton1.Location = new System.Drawing.Point(0, 0);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(170, 26);
            this.myButton1.TabIndex = 0;
            this.myButton1.Text = "Возврат к карте";
            this.myButton1.UseVisualStyleBackColor = true;
            // 
            // BackstageView
            // 
            this.Controls.Add(this.myButton1);
            this.Controls.Add(this.pnlPages);
            this.Controls.Add(this.pnlMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BackstageView";
            this.Size = new System.Drawing.Size(636, 360);
            this.Load += new System.EventHandler(this.BackstageView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPages;
        private BackStageViewMenuPanel pnlMenu;
        public MyButton myButton1;
    }
}
