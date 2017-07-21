namespace NPRClient
{
    partial class FrmShell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShell));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.picImg = new System.Windows.Forms.PictureBox();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbCrop = new System.Windows.Forms.ToolStripButton();
            this.tsbStretch = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbUpload = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.toolStripSeparator3,
            this.tsbCrop,
            this.tsbStretch,
            this.toolStripSeparator4,
            this.tsbSave,
            this.tsbUpload});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(676, 55);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 386);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(676, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // picImg
            // 
            this.picImg.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImg.Location = new System.Drawing.Point(0, 55);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(676, 331);
            this.picImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picImg.TabIndex = 2;
            this.picImg.TabStop = false;
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = global::NPRClient.Properties.Resources.open_48x48;
            this.tsbOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(52, 52);
            this.tsbOpen.Text = "toolStripButton4";
            this.tsbOpen.Click += new System.EventHandler(this.DoOpen_Click);
            // 
            // tsbCrop
            // 
            this.tsbCrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCrop.Image = global::NPRClient.Properties.Resources.crop_48x48;
            this.tsbCrop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCrop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCrop.Name = "tsbCrop";
            this.tsbCrop.Size = new System.Drawing.Size(52, 52);
            this.tsbCrop.Text = "toolStripButton5";
            this.tsbCrop.Click += new System.EventHandler(this.DoCrop_Click);
            // 
            // tsbStretch
            // 
            this.tsbStretch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStretch.Image = global::NPRClient.Properties.Resources.stretch_48x48;
            this.tsbStretch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbStretch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStretch.Name = "tsbStretch";
            this.tsbStretch.Size = new System.Drawing.Size(52, 52);
            this.tsbStretch.Text = "toolStripButton6";
            this.tsbStretch.Click += new System.EventHandler(this.DoStretch_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::NPRClient.Properties.Resources.save_48x48;
            this.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(52, 52);
            this.tsbSave.Text = "toolStripButton7";
            this.tsbSave.Click += new System.EventHandler(this.DoSave_Click);
            // 
            // tsbUpload
            // 
            this.tsbUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpload.Image = global::NPRClient.Properties.Resources.upload_48x48;
            this.tsbUpload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpload.Name = "tsbUpload";
            this.tsbUpload.Size = new System.Drawing.Size(52, 52);
            this.tsbUpload.Text = "toolStripButton1";
            this.tsbUpload.Click += new System.EventHandler(this.tsbUpload_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 52);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // FrmShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 408);
            this.Controls.Add(this.picImg);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmShell";
            this.Text = "Image to iPhone Wallpaper";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbCrop;
        private System.Windows.Forms.ToolStripButton tsbStretch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbUpload;
    }
}

