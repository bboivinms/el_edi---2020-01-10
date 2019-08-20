
namespace vivael.wsforms
{
    partial class wsPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wsPrint));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.wslabel1 = new vivael.wscontrols.wslabel();
            this.ScnCurPrinter = new vivael.wscontrols.wslabel();
            this.BtnView = new vivael.wscontrols.Wscommandbutton();
            this.BtnPrint = new vivael.wscontrols.Wscommandbutton();
            this.BtnFax = new vivael.wscontrols.Wscommandbutton();
            this.BtnEmail = new vivael.wscontrols.Wscommandbutton();
            this.BtnExport = new vivael.wscontrols.Wscommandbutton();
            this.Wscommandbutton1 = new vivael.wscontrols.Wscommandbutton();
            this.Wscommandbutton2 = new vivael.wscontrols.Wscommandbutton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::vivael.Properties.Resources.rapport_i;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(369, 247);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // wslabel1
            // 
            this.wslabel1.Location = new System.Drawing.Point(12, 270);
            this.wslabel1.Name = "wslabel1";
            this.wslabel1.Size = new System.Drawing.Size(120, 16);
            this.wslabel1.TabIndex = 8;
            this.wslabel1.Text = "Current printer:";
            this.wslabel1.Text_EN = "Current printer:";
            this.wslabel1.Text_FR = "Imprimante courante:";
            this.wslabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ScnCurPrinter
            // 
            this.ScnCurPrinter.AutoSize = true;
            this.ScnCurPrinter.Location = new System.Drawing.Point(137, 270);
            this.ScnCurPrinter.Name = "ScnCurPrinter";
            this.ScnCurPrinter.Size = new System.Drawing.Size(16, 13);
            this.ScnCurPrinter.TabIndex = 7;
            this.ScnCurPrinter.Text = "...";
            this.ScnCurPrinter.Text_EN = null;
            this.ScnCurPrinter.Text_FR = null;
            // 
            // BtnView
            // 
            this.BtnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnView.Location = new System.Drawing.Point(395, 10);
            this.BtnView.Name = "BtnView";
            this.BtnView.Size = new System.Drawing.Size(85, 23);
            this.BtnView.TabIndex = 2;
            this.BtnView.Text = "&Screen";
            this.BtnView.ToolTipText = null;
            this.BtnView.UseVisualStyleBackColor = true;
            this.BtnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrint.Location = new System.Drawing.Point(395, 36);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(85, 23);
            this.BtnPrint.TabIndex = 3;
            this.BtnPrint.Text = "&Print";
            this.BtnPrint.ToolTipText = null;
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnFax
            // 
            this.BtnFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFax.Enabled = false;
            this.BtnFax.Location = new System.Drawing.Point(395, 62);
            this.BtnFax.Name = "BtnFax";
            this.BtnFax.Size = new System.Drawing.Size(85, 23);
            this.BtnFax.TabIndex = 4;
            this.BtnFax.Text = "&Fax";
            this.BtnFax.ToolTipText = null;
            this.BtnFax.UseVisualStyleBackColor = true;
            this.BtnFax.Click += new System.EventHandler(this.BtnFax_Click);
            // 
            // BtnEmail
            // 
            this.BtnEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEmail.Enabled = false;
            this.BtnEmail.Location = new System.Drawing.Point(395, 88);
            this.BtnEmail.Name = "BtnEmail";
            this.BtnEmail.Size = new System.Drawing.Size(85, 23);
            this.BtnEmail.TabIndex = 5;
            this.BtnEmail.Text = "&Email";
            this.BtnEmail.ToolTipText = null;
            this.BtnEmail.UseVisualStyleBackColor = true;
            this.BtnEmail.Click += new System.EventHandler(this.BtnEmail_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExport.Enabled = false;
            this.BtnExport.Location = new System.Drawing.Point(395, 114);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(85, 23);
            this.BtnExport.TabIndex = 5;
            this.BtnExport.Text = "&Export";
            this.BtnExport.ToolTipText = null;
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // Wscommandbutton1
            // 
            this.Wscommandbutton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Wscommandbutton1.Location = new System.Drawing.Point(395, 234);
            this.Wscommandbutton1.Name = "Wscommandbutton1";
            this.Wscommandbutton1.Size = new System.Drawing.Size(85, 23);
            this.Wscommandbutton1.TabIndex = 1;
            this.Wscommandbutton1.Text = "&Quit";
            this.Wscommandbutton1.ToolTipText = null;
            this.Wscommandbutton1.UseVisualStyleBackColor = true;
            this.Wscommandbutton1.Click += new System.EventHandler(this.Wscommandbutton1_Click);
            // 
            // Wscommandbutton2
            // 
            this.Wscommandbutton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Wscommandbutton2.Location = new System.Drawing.Point(395, 209);
            this.Wscommandbutton2.Name = "Wscommandbutton2";
            this.Wscommandbutton2.Size = new System.Drawing.Size(85, 23);
            this.Wscommandbutton2.TabIndex = 6;
            this.Wscommandbutton2.Text = "&Configuration";
            this.Wscommandbutton2.ToolTipText = null;
            this.Wscommandbutton2.UseVisualStyleBackColor = true;
            this.Wscommandbutton2.Click += new System.EventHandler(this.Wscommandbutton2_Click);
            // 
            // wsPrint
            // 
            this.AcceptButton = this.Wscommandbutton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 300);
            this.Controls.Add(this.Wscommandbutton2);
            this.Controls.Add(this.Wscommandbutton1);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnEmail);
            this.Controls.Add(this.BtnFax);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.BtnView);
            this.Controls.Add(this.ScnCurPrinter);
            this.Controls.Add(this.wslabel1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wsPrint";
            this.Text = "Reporting";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private wscontrols.wslabel wslabel1;
        private wscontrols.wslabel ScnCurPrinter;
        private wscontrols.Wscommandbutton BtnView;
        private wscontrols.Wscommandbutton BtnPrint;
        private wscontrols.Wscommandbutton BtnFax;
        private wscontrols.Wscommandbutton BtnEmail;
        private wscontrols.Wscommandbutton BtnExport;
        private wscontrols.Wscommandbutton Wscommandbutton1;
        private wscontrols.Wscommandbutton Wscommandbutton2;
    }
}