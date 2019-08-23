namespace vivael.wsforms
{
    partial class wsSearchForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wsSearchForm2));
            this.wsGrid1 = new vivael.wscontrols.wsGrid();
            this.Btn_Ok = new vivael.wscontrols.Commandbutton();
            this.Btn_cancel = new vivael.wscontrols.Commandbutton();
            ((System.ComponentModel.ISupportInitialize)(this.wsGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // wsGrid1
            // 
            this.wsGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.wsGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wsGrid1.Location = new System.Drawing.Point(13, 13);
            this.wsGrid1.MultiSelect = false;
            this.wsGrid1.Name = "wsGrid1";
            this.wsGrid1.ReadOnly = true;
            this.wsGrid1.Size = new System.Drawing.Size(288, 216);
            this.wsGrid1.TabIndex = 1;
            this.wsGrid1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WsGrid1_CellContentDoubleClick);
            this.wsGrid1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.WsGrid1_RowHeaderMouseDoubleClick);
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Btn_Ok.Location = new System.Drawing.Point(324, 12);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(73, 25);
            this.Btn_Ok.TabIndex = 2;
            this.Btn_Ok.Text = "&Ok";
            this.Btn_Ok.Text_EN = null;
            this.Btn_Ok.Text_FR = null;
            this.Btn_Ok.ToolTipText = "Get the entry";
            this.Btn_Ok.UseVisualStyleBackColor = true;
            this.Btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // Btn_cancel
            // 
            this.Btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_cancel.Location = new System.Drawing.Point(324, 43);
            this.Btn_cancel.Name = "Btn_cancel";
            this.Btn_cancel.Size = new System.Drawing.Size(73, 25);
            this.Btn_cancel.TabIndex = 3;
            this.Btn_cancel.Text = "&Cancel";
            this.Btn_cancel.Text_EN = null;
            this.Btn_cancel.Text_FR = null;
            this.Btn_cancel.ToolTipText = "Return to previous entry";
            this.Btn_cancel.UseVisualStyleBackColor = true;
            this.Btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
            // 
            // wsSearchForm2
            // 
            this.AcceptButton = this.Btn_cancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 241);
            this.Controls.Add(this.Btn_cancel);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.wsGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "wsSearchForm2";
            this.Text = "Recherche...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WsSearchForm2_FormClosing);
            this.Click += new System.EventHandler(this.WsSearchForm2_Click);
            ((System.ComponentModel.ISupportInitialize)(this.wsGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected wscontrols.wsGrid wsGrid1;
        protected wscontrols.Commandbutton Btn_Ok;
        protected wscontrols.Commandbutton Btn_cancel;
    }
}