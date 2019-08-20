using System.Windows.Forms;

namespace vivael.wsforms
{
    partial class wsmaintform5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wsmaintform5));
            this.Wsshape1 = new vivael.wscontrols.wsgroupbox();
            this.wsGrid1 = new vivael.wscontrols.wsGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wsGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(515, 0);
            // 
            // BtnFirst
            // 
            this.BtnFirst.Visible = false;
            // 
            // BtnPrev
            // 
            this.BtnPrev.Visible = false;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Visible = false;
            // 
            // BtnLast
            // 
            this.BtnLast.Visible = false;
            // 
            // BtnNext
            // 
            this.BtnNext.Visible = false;
            // 
            // Wsshape1
            // 
            this.Wsshape1.Location = new System.Drawing.Point(5, 243);
            this.Wsshape1.Name = "Wsshape1";
            this.Wsshape1.Size = new System.Drawing.Size(499, 153);
            this.Wsshape1.TabIndex = 0;
            this.Wsshape1.TabStop = false;
            this.Wsshape1.Text_EN = null;
            this.Wsshape1.Text_FR = null;
            // 
            // wsGrid1
            // 
            this.wsGrid1.Location = new System.Drawing.Point(5, 6);
            this.wsGrid1.MultiSelect = false;
            this.wsGrid1.Name = "wsGrid1";
            this.wsGrid1.ReadOnly = true;
            this.wsGrid1.RowTemplate.Height = 15;
            this.wsGrid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wsGrid1.Size = new System.Drawing.Size(499, 231);
            this.wsGrid1.TabIndex = 0;
            this.wsGrid1.SelectionChanged += new System.EventHandler(this.SelectionChange);
            // 
            // wsmaintform5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 408);
            this.Controls.Add(this.wsGrid1);
            this.Controls.Add(this.Wsshape1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "wsmaintform5";
            this.Text = "Title";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Controls.SetChildIndex(this.Wsshape1, 0);
            this.Controls.SetChildIndex(this.wsGrid1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wsGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public wscontrols.wsgroupbox Wsshape1;
        protected wscontrols.wsGrid wsGrid1;
    }
}