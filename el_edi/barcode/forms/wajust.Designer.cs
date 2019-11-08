namespace barcode.forms
{
    partial class wajust
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wajust));
            this.wstextbox1 = new vivael.wscontrols.wstextbox();
            this.wstextbox2 = new vivael.wscontrols.wstextbox();
            this.wslabel1 = new vivael.wscontrols.wslabel();
            this.commandbutton1 = new vivael.wscontrols.Commandbutton();
            this.wsbtnsearch1 = new vivael.wscontrols.Wsbtnsearch();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wstextbox1
            // 
            this.wstextbox1.apControlSource = null;
            this.wstextbox1.apType = null;
            this.wstextbox1.Location = new System.Drawing.Point(58, 34);
            this.wstextbox1.Name = "wstextbox1";
            this.wstextbox1.Size = new System.Drawing.Size(100, 20);
            this.wstextbox1.State = null;
            this.wstextbox1.TabIndex = 4;
            this.wstextbox1.Click += new System.EventHandler(this.wstextbox1_Click);
            // 
            // wstextbox2
            // 
            this.wstextbox2.apControlSource = null;
            this.wstextbox2.apType = null;
            this.wstextbox2.Location = new System.Drawing.Point(258, 32);
            this.wstextbox2.Name = "wstextbox2";
            this.wstextbox2.ReadOnly = true;
            this.wstextbox2.Size = new System.Drawing.Size(236, 20);
            this.wstextbox2.State = null;
            this.wstextbox2.TabIndex = 5;
            // 
            // wslabel1
            // 
            this.wslabel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.wslabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wslabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.wslabel1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.wslabel1.Location = new System.Drawing.Point(108, 8);
            this.wslabel1.Name = "wslabel1";
            this.wslabel1.Size = new System.Drawing.Size(386, 21);
            this.wslabel1.TabIndex = 6;
            this.wslabel1.Text = "Produit à ajuster\r\n\r\n                      ";
            this.wslabel1.Text_EN = null;
            this.wslabel1.Text_FR = null;
            this.wslabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // commandbutton1
            // 
            this.commandbutton1.Location = new System.Drawing.Point(91, 108);
            this.commandbutton1.Name = "commandbutton1";
            this.commandbutton1.Size = new System.Drawing.Size(103, 26);
            this.commandbutton1.TabIndex = 8;
            this.commandbutton1.Text = "commandbutton1";
            this.commandbutton1.Text_EN = null;
            this.commandbutton1.Text_FR = null;
            this.commandbutton1.ToolTipText = null;
            this.commandbutton1.UseVisualStyleBackColor = true;
            // 
            // wsbtnsearch1
            // 
            this.wsbtnsearch1.Image = ((System.Drawing.Image)(resources.GetObject("wsbtnsearch1.Image")));
            this.wsbtnsearch1.Location = new System.Drawing.Point(172, 33);
            this.wsbtnsearch1.Name = "wsbtnsearch1";
            this.wsbtnsearch1.Size = new System.Drawing.Size(22, 22);
            this.wsbtnsearch1.TabIndex = 9;
            this.wsbtnsearch1.Text = "wsbtnsearch1";
            this.wsbtnsearch1.Text_EN = null;
            this.wsbtnsearch1.Text_FR = null;
            this.wsbtnsearch1.ToolTipText = "Search";
            this.wsbtnsearch1.UseVisualStyleBackColor = true;
            // 
            // wajust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(559, 320);
            this.Controls.Add(this.wsbtnsearch1);
            this.Controls.Add(this.commandbutton1);
            this.Controls.Add(this.wslabel1);
            this.Controls.Add(this.wstextbox2);
            this.Controls.Add(this.wstextbox1);
            this.Name = "wajust";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.wstextbox1, 0);
            this.Controls.SetChildIndex(this.wstextbox2, 0);
            this.Controls.SetChildIndex(this.wslabel1, 0);
            this.Controls.SetChildIndex(this.commandbutton1, 0);
            this.Controls.SetChildIndex(this.wsbtnsearch1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vivael.wscontrols.wstextbox wstextbox1;
        private vivael.wscontrols.wstextbox wstextbox2;
        private vivael.wscontrols.wslabel wslabel1;
        private vivael.wscontrols.Commandbutton commandbutton1;
        private vivael.wscontrols.Wsbtnsearch wsbtnsearch1;
    }
}
