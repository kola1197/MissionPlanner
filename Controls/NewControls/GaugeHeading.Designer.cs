using System.ComponentModel;

namespace MissionPlanner.Controls
{
    partial class GaugeHeading
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GaugeHeading));
            this.Gheading = new MissionPlanner.Controls.HSI();
            this.bindingSourceGaugeHeading = new System.Windows.Forms.BindingSource(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.headingDegrees_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.bindingSourceGaugeHeading)).BeginInit();
            this.SuspendLayout();
            // 
            // Gheading
            // 
            this.Gheading.BackColor = System.Drawing.Color.Transparent;
            this.Gheading.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("Gheading.BackgroundImage")));
            this.Gheading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Gheading.DataBindings.Add(new System.Windows.Forms.Binding("Heading", this.bindingSourceGaugeHeading, "yaw", true));
            this.Gheading.DataBindings.Add(new System.Windows.Forms.Binding("NavHeading", this.bindingSourceGaugeHeading, "nav_bearing", true));
            this.Gheading.Heading = 0;
            this.Gheading.Location = new System.Drawing.Point(0, 0);
            this.Gheading.Margin = new System.Windows.Forms.Padding(0);
            this.Gheading.Name = "Gheading";
            this.Gheading.NavHeading = 0;
            this.Gheading.Size = new System.Drawing.Size(123, 123);
            this.Gheading.TabIndex = 84;
            // 
            // bindingSourceGaugeHeading
            // 
            this.bindingSourceGaugeHeading.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // headingDegrees_Label
            // 
            this.headingDegrees_Label.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.headingDegrees_Label.Location = new System.Drawing.Point(48, 35);
            this.headingDegrees_Label.Name = "headingDegrees_Label";
            this.headingDegrees_Label.Size = new System.Drawing.Size(29, 14);
            this.headingDegrees_Label.TabIndex = 85;
            this.headingDegrees_Label.Text = "365°";
            this.headingDegrees_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GaugeHeading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headingDegrees_Label);
            this.Controls.Add(this.Gheading);
            this.MinimumSize = new System.Drawing.Size(123, 123);
            this.Name = "GaugeHeading";
            this.Size = new System.Drawing.Size(123, 123);
            ((System.ComponentModel.ISupportInitialize) (this.bindingSourceGaugeHeading)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.BindingSource bindingSourceGaugeHeading;

        private MissionPlanner.Controls.HSI Gheading;

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label headingDegrees_Label;
    }
}