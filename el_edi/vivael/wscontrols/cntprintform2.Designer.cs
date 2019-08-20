namespace vivael.wscontrols
{
    partial class cntprintform2
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
            this.cmbPrintForm = new vivael.wscontrols.wsComboBox();
            this.wslink1 = new vivael.wscontrols.wslink();
            this.lblCurPrint = new vivael.wscontrols.wslabel();
            this.wslabel2 = new vivael.wscontrols.wslabel();
            this.SuspendLayout();
            // 
            // cmbPrintForm
            // 
            this.cmbPrintForm.apControlSource = null;
            this.cmbPrintForm.apType = null;
            this.cmbPrintForm.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPrintForm.BoundTo = true;
            this.cmbPrintForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrintForm.FormattingEnabled = true;
            this.cmbPrintForm.lenabledisable = true;
            this.cmbPrintForm.Location = new System.Drawing.Point(58, 6);
            this.cmbPrintForm.Name = "cmbPrintForm";
            this.cmbPrintForm.Size = new System.Drawing.Size(305, 21);
            this.cmbPrintForm.TabIndex = 24;
            this.cmbPrintForm.SelectedIndexChanged += new System.EventHandler(this.CmbPrintForm_SelectedIndexChanged);
            // 
            // wslink1
            // 
            this.wslink1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wslink1.LinkColor = System.Drawing.Color.Black;
            this.wslink1.Location = new System.Drawing.Point(364, 10);
            this.wslink1.Name = "wslink1";
            this.wslink1.Size = new System.Drawing.Size(81, 15);
            this.wslink1.TabIndex = 26;
            this.wslink1.TabStop = true;
            this.wslink1.Text = "Configuration";
            this.wslink1.Text_EN = null;
            this.wslink1.Text_FR = null;
            this.wslink1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Wslink1_LinkClicked);
            // 
            // lblCurPrint
            // 
            this.lblCurPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurPrint.Location = new System.Drawing.Point(3, 33);
            this.lblCurPrint.Name = "lblCurPrint";
            this.lblCurPrint.Size = new System.Drawing.Size(438, 13);
            this.lblCurPrint.TabIndex = 23;
            this.lblCurPrint.Text = "Current printer:";
            this.lblCurPrint.Text_EN = "Current printer:";
            this.lblCurPrint.Text_FR = "Imprimante courante:";
            // 
            // wslabel2
            // 
            this.wslabel2.AutoSize = true;
            this.wslabel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wslabel2.Location = new System.Drawing.Point(3, 8);
            this.wslabel2.Name = "wslabel2";
            this.wslabel2.Size = new System.Drawing.Size(46, 15);
            this.wslabel2.TabIndex = 25;
            this.wslabel2.Text = "Format";
            this.wslabel2.Text_EN = null;
            this.wslabel2.Text_FR = null;
            // 
            // cntprintform2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.cmbPrintForm);
            this.Controls.Add(this.wslink1);
            this.Controls.Add(this.lblCurPrint);
            this.Controls.Add(this.wslabel2);
            this.Name = "cntprintform2";
            this.Size = new System.Drawing.Size(453, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private wsComboBox cmbPrintForm;
        private wslink wslink1;
        private wslabel wslabel2;
        public wslabel lblCurPrint;
    }
}
