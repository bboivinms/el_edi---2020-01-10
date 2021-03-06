﻿namespace vivael.wsforms
{
    partial class DataMenu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnPrint = new vivael.wscontrols.wsbutton();
            this.BtnFirst = new vivael.wscontrols.Commandbutton();
            this.BtnPrev = new vivael.wscontrols.Commandbutton();
            this.BtnSearch = new vivael.wscontrols.wsbutton();
            this.BtnModify = new vivael.wscontrols.wsbutton();
            this.BtnDelete = new vivael.wscontrols.wsbutton();
            this.BtnNew = new vivael.wscontrols.wsbutton();
            this.BtnLast = new vivael.wscontrols.Commandbutton();
            this.BtnNext = new vivael.wscontrols.Commandbutton();
            this.BtnQuit = new vivael.wscontrols.wsbutton();
            this.BtnSave = new vivael.wscontrols.wsbutton();
            this.BtnUndo = new vivael.wscontrols.wsbutton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.BtnPrint);
            this.panel1.Controls.Add(this.BtnFirst);
            this.panel1.Controls.Add(this.BtnPrev);
            this.panel1.Controls.Add(this.BtnSearch);
            this.panel1.Controls.Add(this.BtnModify);
            this.panel1.Controls.Add(this.BtnDelete);
            this.panel1.Controls.Add(this.BtnNew);
            this.panel1.Controls.Add(this.BtnLast);
            this.panel1.Controls.Add(this.BtnNext);
            this.panel1.Controls.Add(this.BtnQuit);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Controls.Add(this.BtnUndo);
            this.panel1.Location = new System.Drawing.Point(493, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(109, 408);
            this.panel1.TabIndex = 3;
            // 
            // BtnPrint
            // 
            this.BtnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrint.AutoSize = true;
            this.BtnPrint.Location = new System.Drawing.Point(12, 136);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(85, 23);
            this.BtnPrint.TabIndex = 12;
            this.BtnPrint.Text = "Imprimer";
            this.BtnPrint.Text_EN = null;
            this.BtnPrint.Text_FR = null;
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnFirst
            // 
            this.BtnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFirst.AutoSize = true;
            this.BtnFirst.Image = global::vivael.Properties.Resources.Navfirst;
            this.BtnFirst.Location = new System.Drawing.Point(12, 110);
            this.BtnFirst.Name = "BtnFirst";
            this.BtnFirst.Size = new System.Drawing.Size(22, 23);
            this.BtnFirst.TabIndex = 11;
            this.BtnFirst.ToolTipText = null;
            this.BtnFirst.UseVisualStyleBackColor = true;
            this.BtnFirst.Click += new System.EventHandler(this.BtnFirst_Click);
            // 
            // BtnPrev
            // 
            this.BtnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrev.AutoSize = true;
            this.BtnPrev.Image = global::vivael.Properties.Resources.Navback;
            this.BtnPrev.Location = new System.Drawing.Point(33, 110);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(22, 23);
            this.BtnPrev.TabIndex = 10;
            this.BtnPrev.ToolTipText = null;
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearch.AutoSize = true;
            this.BtnSearch.Location = new System.Drawing.Point(12, 84);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(85, 23);
            this.BtnSearch.TabIndex = 7;
            this.BtnSearch.Text = "&Rechercher";
            this.BtnSearch.Text_EN = null;
            this.BtnSearch.Text_FR = null;
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnModify.AutoSize = true;
            this.BtnModify.Location = new System.Drawing.Point(12, 32);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(85, 23);
            this.BtnModify.TabIndex = 6;
            this.BtnModify.Text = "&Modifier";
            this.BtnModify.Text_EN = null;
            this.BtnModify.Text_FR = null;
            this.BtnModify.UseVisualStyleBackColor = true;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDelete.AutoSize = true;
            this.BtnDelete.Location = new System.Drawing.Point(12, 58);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(85, 23);
            this.BtnDelete.TabIndex = 5;
            this.BtnDelete.Text = "&Supprimer";
            this.BtnDelete.Text_EN = null;
            this.BtnDelete.Text_FR = null;
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNew.AutoSize = true;
            this.BtnNew.Location = new System.Drawing.Point(12, 6);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(85, 23);
            this.BtnNew.TabIndex = 4;
            this.BtnNew.Text = "&Nouveau";
            this.BtnNew.Text_EN = null;
            this.BtnNew.Text_FR = null;
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnLast
            // 
            this.BtnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLast.AutoSize = true;
            this.BtnLast.Image = global::vivael.Properties.Resources.Navlast;
            this.BtnLast.Location = new System.Drawing.Point(75, 110);
            this.BtnLast.Name = "BtnLast";
            this.BtnLast.Size = new System.Drawing.Size(22, 23);
            this.BtnLast.TabIndex = 3;
            this.BtnLast.ToolTipText = null;
            this.BtnLast.UseVisualStyleBackColor = true;
            this.BtnLast.Click += new System.EventHandler(this.BtnLast_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNext.AutoSize = true;
            this.BtnNext.Image = global::vivael.Properties.Resources.Navnext;
            this.BtnNext.Location = new System.Drawing.Point(54, 110);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(22, 23);
            this.BtnNext.TabIndex = 2;
            this.BtnNext.ToolTipText = null;
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnQuit
            // 
            this.BtnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnQuit.AutoSize = true;
            this.BtnQuit.Location = new System.Drawing.Point(12, 375);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(85, 23);
            this.BtnQuit.TabIndex = 0;
            this.BtnQuit.Text = "&Fermer";
            this.BtnQuit.Text_EN = null;
            this.BtnQuit.Text_FR = null;
            this.BtnQuit.UseVisualStyleBackColor = true;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.AutoSize = true;
            this.BtnSave.Location = new System.Drawing.Point(12, 6);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(85, 23);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "&Sauvegarder";
            this.BtnSave.Text_EN = null;
            this.BtnSave.Text_FR = null;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnUndo
            // 
            this.BtnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUndo.AutoSize = true;
            this.BtnUndo.Location = new System.Drawing.Point(12, 32);
            this.BtnUndo.Name = "BtnUndo";
            this.BtnUndo.Size = new System.Drawing.Size(85, 23);
            this.BtnUndo.TabIndex = 9;
            this.BtnUndo.Text = "&Annuler";
            this.BtnUndo.Text_EN = null;
            this.BtnUndo.Text_FR = null;
            this.BtnUndo.UseVisualStyleBackColor = true;
            this.BtnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // DataMenu
            // 
            this.ClientSize = new System.Drawing.Size(602, 408);
            this.Controls.Add(this.panel1);
            this.Name = "DataMenu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        protected wscontrols.wsbutton BtnPrint;
        protected wscontrols.Commandbutton BtnFirst;
        protected wscontrols.Commandbutton BtnPrev;
        protected wscontrols.wsbutton BtnSearch;
        protected wscontrols.wsbutton BtnModify;
        protected wscontrols.wsbutton BtnDelete;
        protected wscontrols.wsbutton BtnNew;
        protected wscontrols.Commandbutton BtnLast;
        protected wscontrols.Commandbutton BtnNext;
        protected wscontrols.wsbutton BtnQuit;
        protected wscontrols.wsbutton BtnSave;
        protected wscontrols.wsbutton BtnUndo;
    }
}