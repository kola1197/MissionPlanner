namespace MissionPlanner.Controls
{
    partial class MainMenuWidget
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainButton = new MissionPlanner.Controls.MyButton();
            this.MapChoiseButton = new MissionPlanner.Controls.MyButton();
            this.EKFButton = new MissionPlanner.Controls.MyButton();
            this.ParamsButton = new MissionPlanner.Controls.MyButton();
            this.RulerButton = new MissionPlanner.Controls.MyButton();
            this.centeringButton = new MissionPlanner.Controls.MyButton();
            this.homeButton = new MissionPlanner.Controls.MyButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // MainButton
            // 
            this.MainButton.BackColor = System.Drawing.Color.Transparent;
            this.MainButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_MainButton;
            this.MainButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MainButton.BGGradBot = System.Drawing.Color.Empty;
            this.MainButton.BGGradTop = System.Drawing.Color.Empty;
            this.MainButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.MainButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.MainButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.MainButton.FlatAppearance.BorderSize = 0;
            this.MainButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.MainButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.MainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainButton.Location = new System.Drawing.Point(10, 10);
            this.MainButton.Name = "MainButton";
            this.MainButton.Outline = System.Drawing.Color.Empty;
            this.MainButton.Size = new System.Drawing.Size(48, 48);
            this.MainButton.TabIndex = 0;
            this.MainButton.TextColor = System.Drawing.Color.Empty;
            this.MainButton.UseVisualStyleBackColor = false;
            this.MainButton.Click += new System.EventHandler(this.MainButton_Click);
            this.MainButton.MouseEnter += new System.EventHandler(this.MainMenuWidget_MouseEnter);
            // 
            // MapChoiseButton
            // 
            this.MapChoiseButton.BackColor = System.Drawing.Color.Transparent;
            this.MapChoiseButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_MapChoiseButton;
            this.MapChoiseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MapChoiseButton.BGGradBot = System.Drawing.Color.Empty;
            this.MapChoiseButton.BGGradTop = System.Drawing.Color.Empty;
            this.MapChoiseButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.MapChoiseButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.MapChoiseButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.MapChoiseButton.FlatAppearance.BorderSize = 0;
            this.MapChoiseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.MapChoiseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.MapChoiseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MapChoiseButton.Location = new System.Drawing.Point(71, 10);
            this.MapChoiseButton.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.MapChoiseButton.Name = "MapChoiseButton";
            this.MapChoiseButton.Outline = System.Drawing.Color.Empty;
            this.MapChoiseButton.Size = new System.Drawing.Size(48, 48);
            this.MapChoiseButton.TabIndex = 1;
            this.MapChoiseButton.Tag = "Сменить карту";
            this.MapChoiseButton.TextColor = System.Drawing.Color.Empty;
            this.MapChoiseButton.UseVisualStyleBackColor = false;
            this.MapChoiseButton.Click += new System.EventHandler(this.MapChoiseButton_Click);
            this.MapChoiseButton.MouseEnter += new System.EventHandler(this.MainMenuWidget_MouseEnter);
            // 
            // EKFButton
            // 
            this.EKFButton.BackColor = System.Drawing.Color.Transparent;
            this.EKFButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_EKFButton;
            this.EKFButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EKFButton.BGGradBot = System.Drawing.Color.Empty;
            this.EKFButton.BGGradTop = System.Drawing.Color.Empty;
            this.EKFButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.EKFButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.EKFButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.EKFButton.FlatAppearance.BorderSize = 0;
            this.EKFButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.EKFButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.EKFButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EKFButton.Location = new System.Drawing.Point(132, 10);
            this.EKFButton.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.EKFButton.Name = "EKFButton";
            this.EKFButton.Outline = System.Drawing.Color.Empty;
            this.EKFButton.Size = new System.Drawing.Size(45, 45);
            this.EKFButton.TabIndex = 2;
            this.EKFButton.Tag = "Статус ЕКФ";
            this.EKFButton.TextColor = System.Drawing.Color.Empty;
            this.EKFButton.UseVisualStyleBackColor = false;
            this.EKFButton.MouseEnter += new System.EventHandler(this.MainMenuWidget_MouseEnter);
            // 
            // ParamsButton
            // 
            this.ParamsButton.BackColor = System.Drawing.Color.Transparent;
            this.ParamsButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_ParamsButton;
            this.ParamsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ParamsButton.BGGradBot = System.Drawing.Color.Empty;
            this.ParamsButton.BGGradTop = System.Drawing.Color.Empty;
            this.ParamsButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.ParamsButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.ParamsButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.ParamsButton.FlatAppearance.BorderSize = 0;
            this.ParamsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ParamsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ParamsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ParamsButton.Location = new System.Drawing.Point(187, 10);
            this.ParamsButton.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.ParamsButton.Name = "ParamsButton";
            this.ParamsButton.Outline = System.Drawing.Color.Empty;
            this.ParamsButton.Size = new System.Drawing.Size(48, 48);
            this.ParamsButton.TabIndex = 3;
            this.ParamsButton.Tag = "Параметры";
            this.ParamsButton.TextColor = System.Drawing.Color.Empty;
            this.ParamsButton.UseVisualStyleBackColor = false;
            this.ParamsButton.MouseEnter += new System.EventHandler(this.MainMenuWidget_MouseEnter);
            // 
            // RulerButton
            // 
            this.RulerButton.BackColor = System.Drawing.Color.Transparent;
            this.RulerButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_RulerButton;
            this.RulerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RulerButton.BGGradBot = System.Drawing.Color.Empty;
            this.RulerButton.BGGradTop = System.Drawing.Color.Empty;
            this.RulerButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.RulerButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.RulerButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.RulerButton.FlatAppearance.BorderSize = 0;
            this.RulerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RulerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RulerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RulerButton.Location = new System.Drawing.Point(245, 10);
            this.RulerButton.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.RulerButton.Name = "RulerButton";
            this.RulerButton.Outline = System.Drawing.Color.Empty;
            this.RulerButton.Size = new System.Drawing.Size(48, 48);
            this.RulerButton.TabIndex = 4;
            this.RulerButton.Tag = "Линейка";
            this.RulerButton.TextColor = System.Drawing.Color.Empty;
            this.RulerButton.UseVisualStyleBackColor = false;
            this.RulerButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RulerButton_MouseDown);
            this.RulerButton.MouseEnter += new System.EventHandler(this.MainMenuWidget_MouseEnter);
            // 
            // centeringButton
            // 
            this.centeringButton.BackColor = System.Drawing.Color.Transparent;
            this.centeringButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_cenButton;
            this.centeringButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.centeringButton.BGGradBot = System.Drawing.Color.Empty;
            this.centeringButton.BGGradTop = System.Drawing.Color.Empty;
            this.centeringButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.centeringButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.centeringButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.centeringButton.FlatAppearance.BorderSize = 0;
            this.centeringButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.centeringButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.centeringButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.centeringButton.Location = new System.Drawing.Point(303, 10);
            this.centeringButton.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.centeringButton.Name = "centeringButton";
            this.centeringButton.Outline = System.Drawing.Color.Empty;
            this.centeringButton.Size = new System.Drawing.Size(48, 48);
            this.centeringButton.TabIndex = 5;
            this.centeringButton.Tag = "Следить за бортом";
            this.centeringButton.TextColor = System.Drawing.Color.Empty;
            this.centeringButton.UseVisualStyleBackColor = false;
            this.centeringButton.MouseEnter += new System.EventHandler(this.MainMenuWidget_MouseEnter);
            // 
            // homeButton
            // 
            this.homeButton.BackColor = System.Drawing.Color.Transparent;
            this.homeButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_homeButton;
            this.homeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.homeButton.BGGradBot = System.Drawing.Color.Empty;
            this.homeButton.BGGradTop = System.Drawing.Color.Empty;
            this.homeButton.ColorMouseDown = System.Drawing.Color.Transparent;
            this.homeButton.ColorMouseOver = System.Drawing.Color.Transparent;
            this.homeButton.ColorNotEnabled = System.Drawing.Color.Transparent;
            this.homeButton.FlatAppearance.BorderSize = 0;
            this.homeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.homeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Location = new System.Drawing.Point(361, 10);
            this.homeButton.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.homeButton.Name = "homeButton";
            this.homeButton.Outline = System.Drawing.Color.Empty;
            this.homeButton.Size = new System.Drawing.Size(48, 48);
            this.homeButton.TabIndex = 7;
            this.homeButton.Tag = "Лететь домой";
            this.homeButton.TextColor = System.Drawing.Color.Empty;
            this.homeButton.UseVisualStyleBackColor = false;
            this.homeButton.MouseEnter += new System.EventHandler(this.MainMenuWidget_MouseEnter);
            // 
            // MainMenuWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.MapChoiseButton);
            this.Controls.Add(this.centeringButton);
            this.Controls.Add(this.RulerButton);
            this.Controls.Add(this.ParamsButton);
            this.Controls.Add(this.EKFButton);
            this.Controls.Add(this.MainButton);
            this.DoubleBuffered = true;
            this.Name = "MainMenuWidget";
            this.Size = new System.Drawing.Size(420, 70);
            this.MouseEnter += new System.EventHandler(this.MainMenuWidget_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MainMenuWidget_MouseLeave);
            this.ResumeLayout(false);

        }

        public MissionPlanner.Controls.MyButton centeringButton;
        public MissionPlanner.Controls.MyButton EKFButton;
        public MissionPlanner.Controls.MyButton homeButton;
        public MissionPlanner.Controls.MyButton MapChoiseButton;
        public MissionPlanner.Controls.MyButton ParamsButton;
        public MissionPlanner.Controls.MyButton RulerButton;

        #endregion

        public MyButton MainButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
