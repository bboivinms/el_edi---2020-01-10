namespace vivael.forms
{
    partial class wsprintform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wsprintform));
            this.Wscommandbutton2 = new vivael.wscontrols.Wscommandbutton();
            this.Wscommandbutton1 = new vivael.wscontrols.Wscommandbutton();
            this.BtnExport = new vivael.wscontrols.Wscommandbutton();
            this.BtnEmail = new vivael.wscontrols.Wscommandbutton();
            this.BtnFax = new vivael.wscontrols.Wscommandbutton();
            this.BtnPrint2 = new vivael.wscontrols.Wscommandbutton();
            this.BtnView = new vivael.wscontrols.Wscommandbutton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnBasket = new vivael.wscontrols.Wscommandbutton();
            this.BtnViewBasket = new vivael.wscontrols.Wscommandbutton();
            this.cntprintform21 = new vivael.wscontrols.cntprintform2();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(517, 0);
            this.panel1.Size = new System.Drawing.Size(109, 430);
            // 
            // BtnQuit
            // 
            this.BtnQuit.Location = new System.Drawing.Point(12, 382);
            // 
            // Wscommandbutton2
            // 
            this.Wscommandbutton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Wscommandbutton2.Enabled = false;
            this.Wscommandbutton2.Location = new System.Drawing.Point(409, 210);
            this.Wscommandbutton2.Name = "Wscommandbutton2";
            this.Wscommandbutton2.Size = new System.Drawing.Size(85, 23);
            this.Wscommandbutton2.TabIndex = 16;
            this.Wscommandbutton2.Text = "&Configuration";
            this.Wscommandbutton2.Text_EN = "&Configuration";
            this.Wscommandbutton2.Text_FR = "&Configuration";
            this.Wscommandbutton2.ToolTipText = null;
            this.Wscommandbutton2.UseVisualStyleBackColor = true;
            this.Wscommandbutton2.Visible = false;
            this.Wscommandbutton2.Click += new System.EventHandler(this.Wscommandbutton2_Click);
            // 
            // Wscommandbutton1
            // 
            this.Wscommandbutton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Wscommandbutton1.Location = new System.Drawing.Point(409, 235);
            this.Wscommandbutton1.Name = "Wscommandbutton1";
            this.Wscommandbutton1.Size = new System.Drawing.Size(85, 23);
            this.Wscommandbutton1.TabIndex = 10;
            this.Wscommandbutton1.Text = "&Quit";
            this.Wscommandbutton1.Text_EN = "&Quit";
            this.Wscommandbutton1.Text_FR = "&Terminer";
            this.Wscommandbutton1.ToolTipText = null;
            this.Wscommandbutton1.UseVisualStyleBackColor = true;
            this.Wscommandbutton1.Click += new System.EventHandler(this.Wscommandbutton1_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExport.Enabled = false;
            this.BtnExport.Location = new System.Drawing.Point(409, 167);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(85, 23);
            this.BtnExport.TabIndex = 14;
            this.BtnExport.Text = "&Export";
            this.BtnExport.Text_EN = "&Export";
            this.BtnExport.Text_FR = "&Exporter";
            this.BtnExport.ToolTipText = null;
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // BtnEmail
            // 
            this.BtnEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEmail.Enabled = false;
            this.BtnEmail.Location = new System.Drawing.Point(409, 89);
            this.BtnEmail.Name = "BtnEmail";
            this.BtnEmail.Size = new System.Drawing.Size(85, 23);
            this.BtnEmail.TabIndex = 15;
            this.BtnEmail.Text = "&Email";
            this.BtnEmail.Text_EN = "&Email";
            this.BtnEmail.Text_FR = "&Courriel";
            this.BtnEmail.ToolTipText = null;
            this.BtnEmail.UseVisualStyleBackColor = true;
            this.BtnEmail.Click += new System.EventHandler(this.BtnEmail_Click);
            // 
            // BtnFax
            // 
            this.BtnFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFax.Enabled = false;
            this.BtnFax.Location = new System.Drawing.Point(409, 63);
            this.BtnFax.Name = "BtnFax";
            this.BtnFax.Size = new System.Drawing.Size(85, 23);
            this.BtnFax.TabIndex = 13;
            this.BtnFax.Text = "&Fax";
            this.BtnFax.Text_EN = "&Fax";
            this.BtnFax.Text_FR = "Télécopieur";
            this.BtnFax.ToolTipText = null;
            this.BtnFax.UseVisualStyleBackColor = true;
            this.BtnFax.Click += new System.EventHandler(this.BtnFax_Click);
            // 
            // BtnPrint2
            // 
            this.BtnPrint2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrint2.Location = new System.Drawing.Point(409, 37);
            this.BtnPrint2.Name = "BtnPrint2";
            this.BtnPrint2.Size = new System.Drawing.Size(85, 23);
            this.BtnPrint2.TabIndex = 12;
            this.BtnPrint2.Text = "&Print";
            this.BtnPrint2.Text_EN = "&Print";
            this.BtnPrint2.Text_FR = "&Imprimante";
            this.BtnPrint2.ToolTipText = null;
            this.BtnPrint2.UseVisualStyleBackColor = true;
            this.BtnPrint2.Click += new System.EventHandler(this.BtnPrint2_Click);
            // 
            // BtnView
            // 
            this.BtnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnView.Location = new System.Drawing.Point(409, 11);
            this.BtnView.Name = "BtnView";
            this.BtnView.Size = new System.Drawing.Size(85, 23);
            this.BtnView.TabIndex = 11;
            this.BtnView.Text = "&Screen";
            this.BtnView.Text_EN = "&Screen";
            this.BtnView.Text_FR = "&Écran";
            this.BtnView.ToolTipText = null;
            this.BtnView.UseVisualStyleBackColor = true;
            this.BtnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::vivael.Properties.Resources.rapport_i;
            this.pictureBox1.Location = new System.Drawing.Point(24, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(369, 247);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // BtnBasket
            // 
            this.BtnBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBasket.Enabled = false;
            this.BtnBasket.Location = new System.Drawing.Point(409, 115);
            this.BtnBasket.Name = "BtnBasket";
            this.BtnBasket.Size = new System.Drawing.Size(85, 23);
            this.BtnBasket.TabIndex = 23;
            this.BtnBasket.Text = "&To basket";
            this.BtnBasket.Text_EN = "&To basket";
            this.BtnBasket.Text_FR = "&Au panier";
            this.BtnBasket.ToolTipText = null;
            this.BtnBasket.UseVisualStyleBackColor = true;
            this.BtnBasket.Click += new System.EventHandler(this.BtnBasket_Click);
            // 
            // BtnViewBasket
            // 
            this.BtnViewBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnViewBasket.Enabled = false;
            this.BtnViewBasket.Location = new System.Drawing.Point(409, 141);
            this.BtnViewBasket.Name = "BtnViewBasket";
            this.BtnViewBasket.Size = new System.Drawing.Size(85, 23);
            this.BtnViewBasket.TabIndex = 24;
            this.BtnViewBasket.Text = "&View basket";
            this.BtnViewBasket.Text_EN = "&View basket";
            this.BtnViewBasket.Text_FR = "&Voir panier";
            this.BtnViewBasket.ToolTipText = null;
            this.BtnViewBasket.UseVisualStyleBackColor = true;
            this.BtnViewBasket.Click += new System.EventHandler(this.BtnViewBasket_Click);
            // 
            // cntprintform21
            // 
            this.cntprintform21.BackColor = System.Drawing.Color.Transparent;
            this.cntprintform21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cntprintform21.Location = new System.Drawing.Point(24, 266);
            this.cntprintform21.Name = "cntprintform21";
            this.cntprintform21.Size = new System.Drawing.Size(470, 60);
            this.cntprintform21.TabIndex = 25;
            // 
            // wsprintform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(511, 338);
            this.Controls.Add(this.cntprintform21);
            this.Controls.Add(this.BtnViewBasket);
            this.Controls.Add(this.BtnBasket);
            this.Controls.Add(this.Wscommandbutton2);
            this.Controls.Add(this.Wscommandbutton1);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnEmail);
            this.Controls.Add(this.BtnFax);
            this.Controls.Add(this.BtnPrint2);
            this.Controls.Add(this.BtnView);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(527, 377);
            this.MinimumSize = new System.Drawing.Size(527, 377);
            this.Name = "wsprintform";
            this.Text = "Printout";
            this.Text_EN = "Printout";
            this.Text_FR = "Impression";
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.BtnView, 0);
            this.Controls.SetChildIndex(this.BtnPrint2, 0);
            this.Controls.SetChildIndex(this.BtnFax, 0);
            this.Controls.SetChildIndex(this.BtnEmail, 0);
            this.Controls.SetChildIndex(this.BtnExport, 0);
            this.Controls.SetChildIndex(this.Wscommandbutton1, 0);
            this.Controls.SetChildIndex(this.Wscommandbutton2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.BtnBasket, 0);
            this.Controls.SetChildIndex(this.BtnViewBasket, 0);
            this.Controls.SetChildIndex(this.cntprintform21, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private wscontrols.Wscommandbutton Wscommandbutton2;
        private wscontrols.Wscommandbutton Wscommandbutton1;
        private wscontrols.Wscommandbutton BtnExport;
        private wscontrols.Wscommandbutton BtnEmail;
        private wscontrols.Wscommandbutton BtnFax;
        private wscontrols.Wscommandbutton BtnPrint2;
        private wscontrols.Wscommandbutton BtnView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private wscontrols.Wscommandbutton BtnBasket;
        private wscontrols.Wscommandbutton BtnViewBasket;
        private wscontrols.cntprintform2 cntprintform21;
    }
}
