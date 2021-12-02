
namespace GoNurse
{
    partial class Splash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.logo = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label_loader = new Bunifu.UI.WinForms.BunifuLabel();
            this.label_version = new Bunifu.UI.WinForms.BunifuLabel();
            this.rounded = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.moveDown = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.timer_loading = new System.Windows.Forms.Timer(this.components);
            this.bunifuCircleProgress1 = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.moveUp = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.logo.FillColor = System.Drawing.Color.Transparent;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.ImageRotate = 0F;
            this.logo.Location = new System.Drawing.Point(12, 3);
            this.logo.Name = "logo";
            this.logo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.logo.ShadowDecoration.Parent = this.logo;
            this.logo.Size = new System.Drawing.Size(263, 207);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // label_loader
            // 
            this.label_loader.AllowParentOverrides = false;
            this.label_loader.AutoEllipsis = false;
            this.label_loader.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_loader.CursorType = System.Windows.Forms.Cursors.Default;
            this.label_loader.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label_loader.ForeColor = System.Drawing.Color.White;
            this.label_loader.Location = new System.Drawing.Point(104, 280);
            this.label_loader.Name = "label_loader";
            this.label_loader.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_loader.Size = new System.Drawing.Size(90, 20);
            this.label_loader.TabIndex = 2;
            this.label_loader.Text = "Please wait...";
            this.label_loader.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.label_loader.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // label_version
            // 
            this.label_version.AllowParentOverrides = false;
            this.label_version.AutoEllipsis = false;
            this.label_version.CursorType = null;
            this.label_version.Font = new System.Drawing.Font("Nirmala UI", 11.25F);
            this.label_version.ForeColor = System.Drawing.Color.White;
            this.label_version.Location = new System.Drawing.Point(124, 352);
            this.label_version.Name = "label_version";
            this.label_version.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_version.Size = new System.Drawing.Size(40, 20);
            this.label_version.TabIndex = 3;
            this.label_version.Text = "v.1.1.0";
            this.label_version.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.label_version.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // rounded
            // 
            this.rounded.ElipseRadius = 30;
            this.rounded.TargetControl = this;
            // 
            // moveDown
            // 
            this.moveDown.TargetControl = this;
            // 
            // timer_loading
            // 
            this.timer_loading.Enabled = true;
            this.timer_loading.Tick += new System.EventHandler(this.timer_loading_Tick);
            // 
            // bunifuCircleProgress1
            // 
            this.bunifuCircleProgress1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCircleProgress1.Animated = true;
            this.bunifuCircleProgress1.AnimationInterval = 5;
            this.bunifuCircleProgress1.AnimationSpeed = 1;
            this.bunifuCircleProgress1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgress1.CircleMargin = 10;
            this.bunifuCircleProgress1.Font = new System.Drawing.Font("Nirmala UI", 1F, System.Drawing.FontStyle.Bold);
            this.bunifuCircleProgress1.ForeColor = System.Drawing.Color.LawnGreen;
            this.bunifuCircleProgress1.IsPercentage = true;
            this.bunifuCircleProgress1.LineProgressThickness = 5;
            this.bunifuCircleProgress1.LineThickness = 5;
            this.bunifuCircleProgress1.Location = new System.Drawing.Point(117, 226);
            this.bunifuCircleProgress1.Name = "bunifuCircleProgress1";
            this.bunifuCircleProgress1.ProgressAnimationSpeed = 200;
            this.bunifuCircleProgress1.ProgressBackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgress1.ProgressColor = System.Drawing.Color.White;
            this.bunifuCircleProgress1.ProgressColor2 = System.Drawing.Color.DodgerBlue;
            this.bunifuCircleProgress1.ProgressEndCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.bunifuCircleProgress1.ProgressFillStyle = Bunifu.UI.WinForms.BunifuCircleProgress.FillStyles.Solid;
            this.bunifuCircleProgress1.ProgressStartCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.bunifuCircleProgress1.SecondaryFont = new System.Drawing.Font("Nirmala UI", 1F, System.Drawing.FontStyle.Bold);
            this.bunifuCircleProgress1.Size = new System.Drawing.Size(53, 53);
            this.bunifuCircleProgress1.SubScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgress1.SubScriptMargin = new System.Windows.Forms.Padding(0);
            this.bunifuCircleProgress1.SubScriptText = "";
            this.bunifuCircleProgress1.SuperScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgress1.SuperScriptMargin = new System.Windows.Forms.Padding(4, 15, 0, 0);
            this.bunifuCircleProgress1.SuperScriptText = "";
            this.bunifuCircleProgress1.TabIndex = 16;
            this.bunifuCircleProgress1.Text = "0";
            this.bunifuCircleProgress1.TextMargin = new System.Windows.Forms.Padding(0);
            this.bunifuCircleProgress1.ValueByTransition = 0;
            this.bunifuCircleProgress1.ValueMargin = new System.Windows.Forms.Padding(0);
            // 
            // moveUp
            // 
            this.moveUp.TargetControl = this.logo;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LawnGreen;
            this.ClientSize = new System.Drawing.Size(285, 380);
            this.Controls.Add(this.bunifuCircleProgress1);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.label_loader);
            this.Controls.Add(this.logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox logo;
        private Bunifu.UI.WinForms.BunifuLabel label_loader;
        private Bunifu.UI.WinForms.BunifuLabel label_version;
        private Bunifu.Framework.UI.BunifuElipse rounded;
        private Guna.UI2.WinForms.Guna2DragControl moveDown;
        private System.Windows.Forms.Timer timer_loading;
        private Bunifu.UI.WinForms.BunifuCircleProgress bunifuCircleProgress1;
        private Guna.UI2.WinForms.Guna2DragControl moveUp;
    }
}