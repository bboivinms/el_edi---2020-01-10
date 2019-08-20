namespace vivael.wsforms
{
    partial class wsmaintform4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wsmaintform4));
            this.BtnNote = new System.Windows.Forms.PictureBox();
            this.Wsshape1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.BtnNote)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnNote
            // 
            this.BtnNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnNote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNote.Image = global::vivael.Properties.Resources.Notes;
            this.BtnNote.Location = new System.Drawing.Point(122, 342);
            this.BtnNote.Name = "BtnNote";
            this.BtnNote.Size = new System.Drawing.Size(16, 16);
            this.BtnNote.TabIndex = 13;
            this.BtnNote.TabStop = false;
            this.BtnNote.Visible = false;
            // 
            // Wsshape1
            // 
            this.Wsshape1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Wsshape1.Location = new System.Drawing.Point(5, -1);
            this.Wsshape1.Name = "Wsshape1";
            this.Wsshape1.Padding = new System.Windows.Forms.Padding(0);
            this.Wsshape1.Size = new System.Drawing.Size(511, 331);
            this.Wsshape1.TabIndex = 14;
            this.Wsshape1.TabStop = false;
            // 
            // BtnUndo
            // 
            this.BtnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUndo.Location = new System.Drawing.Point(363, 339);
            this.BtnUndo.Name = "BtnUndo";
            this.BtnUndo.Size = new System.Drawing.Size(75, 23);
            this.BtnUndo.TabIndex = 15;
            this.BtnUndo.Text = "Cancel";
            this.BtnUndo.UseVisualStyleBackColor = true;
            this.BtnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(441, 339);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 16;
            this.BtnSave.Text = "&Ok";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // wsmaintform4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 370);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnUndo);
            this.Controls.Add(this.Wsshape1);
            this.Controls.Add(this.BtnNote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "wsmaintform4";
            this.Text = "Title";
            ((System.ComponentModel.ISupportInitialize)(this.BtnNote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BtnNote;
        private System.Windows.Forms.GroupBox Wsshape1;
    }
}