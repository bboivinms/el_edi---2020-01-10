﻿

namespace barcode.forms
{
    partial class ffpapiercli
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ffpapiercli));
            this.btnQuit2 = new vivael.wscontrols.Wscommandbutton();
            this.btnApply = new vivael.wscontrols.Wscommandbutton();
            this.ScnCode = new vivael.wscontrols.wstextbox();
            this.txtclient_code = new vivael.wscontrols.wstextbox();
            this.txtClient_name = new vivael.wscontrols.wstextbox();
            this.btn_raf = new vivael.wscontrols.Wscommandbutton();
            this.wsGrid1 = new vivael.wscontrols.wsGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wslabel1 = new vivael.wscontrols.wslabel();
            this.wslabel2 = new vivael.wscontrols.wslabel();
            this.btnSearchCli = new vivael.wscontrols.Wsbtnsearch();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wsGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1138, 0);
            this.panel1.Size = new System.Drawing.Size(109, 563);
            // 
            // BtnQuit
            // 
            this.BtnQuit.Location = new System.Drawing.Point(12, 530);
            // 
            // btnQuit2
            // 
            this.btnQuit2.Location = new System.Drawing.Point(839, 428);
            this.btnQuit2.Name = "btnQuit2";
            this.btnQuit2.Size = new System.Drawing.Size(75, 23);
            this.btnQuit2.TabIndex = 4;
            this.btnQuit2.Text = "Quitter";
            this.btnQuit2.Text_EN = null;
            this.btnQuit2.Text_FR = null;
            this.btnQuit2.ToolTipText = null;
            this.btnQuit2.UseVisualStyleBackColor = true;
            this.btnQuit2.Click += new System.EventHandler(this.btnQuit2_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(753, 428);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Confirmer";
            this.btnApply.Text_EN = null;
            this.btnApply.Text_FR = null;
            this.btnApply.ToolTipText = null;
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // ScnCode
            // 
            this.ScnCode.apControlSource = null;
            this.ScnCode.apType = null;
            this.ScnCode.Location = new System.Drawing.Point(119, 11);
            this.ScnCode.Name = "ScnCode";
            this.ScnCode.Size = new System.Drawing.Size(100, 20);
            this.ScnCode.State = null;
            this.ScnCode.TabIndex = 6;
            this.ScnCode.TextChanged += new System.EventHandler(this.ScnCode_TextChanged);
            this.ScnCode.Leave += new System.EventHandler(this.ScnCode_Leave);
            // 
            // txtclient_code
            // 
            this.txtclient_code.apControlSource = null;
            this.txtclient_code.apType = null;
            this.txtclient_code.Location = new System.Drawing.Point(331, 11);
            this.txtclient_code.Name = "txtclient_code";
            this.txtclient_code.Size = new System.Drawing.Size(100, 20);
            this.txtclient_code.State = null;
            this.txtclient_code.TabIndex = 7;
            // 
            // txtClient_name
            // 
            this.txtClient_name.apControlSource = null;
            this.txtClient_name.apType = null;
            this.txtClient_name.Location = new System.Drawing.Point(477, 11);
            this.txtClient_name.Name = "txtClient_name";
            this.txtClient_name.ReadOnly = true;
            this.txtClient_name.Size = new System.Drawing.Size(200, 20);
            this.txtClient_name.State = null;
            this.txtClient_name.TabIndex = 8;
            // 
            // btn_raf
            // 
            this.btn_raf.Location = new System.Drawing.Point(692, 9);
            this.btn_raf.Name = "btn_raf";
            this.btn_raf.Size = new System.Drawing.Size(75, 23);
            this.btn_raf.TabIndex = 9;
            this.btn_raf.Text = "Rafraichir";
            this.btn_raf.Text_EN = null;
            this.btn_raf.Text_FR = null;
            this.btn_raf.ToolTipText = null;
            this.btn_raf.UseVisualStyleBackColor = true;
            this.btn_raf.Click += new System.EventHandler(this.btn_raf_Click);
            // 
            // wsGrid1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.wsGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.wsGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.wsGrid1.Location = new System.Drawing.Point(12, 47);
            this.wsGrid1.Name = "wsGrid1";
            this.wsGrid1.Size = new System.Drawing.Size(1098, 375);
            this.wsGrid1.TabIndex = 10;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "No prod";
            this.Column1.Name = "Column1";
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Code produit";
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Description";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Qte à produire";
            this.Column4.Name = "Column4";
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Code client";
            this.Column5.Name = "Column5";
            this.Column5.Width = 75;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Nom du client";
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.NullValue = false;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column7.HeaderText = "Recept";
            this.Column7.Name = "Column7";
            this.Column7.Width = 40;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "PO client";
            this.Column8.Name = "Column8";
            this.Column8.Width = 75;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Notes";
            this.Column9.Name = "Column9";
            this.Column9.Width = 250;
            // 
            // wslabel1
            // 
            this.wslabel1.AutoSize = true;
            this.wslabel1.Location = new System.Drawing.Point(292, 16);
            this.wslabel1.Name = "wslabel1";
            this.wslabel1.Size = new System.Drawing.Size(33, 13);
            this.wslabel1.TabIndex = 11;
            this.wslabel1.Text = "Client";
            this.wslabel1.Text_EN = null;
            this.wslabel1.Text_FR = null;
            // 
            // wslabel2
            // 
            this.wslabel2.AutoSize = true;
            this.wslabel2.Location = new System.Drawing.Point(36, 16);
            this.wslabel2.Name = "wslabel2";
            this.wslabel2.Size = new System.Drawing.Size(75, 13);
            this.wslabel2.TabIndex = 12;
            this.wslabel2.Text = "No Production";
            this.wslabel2.Text_EN = null;
            this.wslabel2.Text_FR = null;
            // 
            // btnSearchCli
            // 
            this.btnSearchCli.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchCli.Image")));
            this.btnSearchCli.Location = new System.Drawing.Point(431, 10);
            this.btnSearchCli.Name = "btnSearchCli";
            this.btnSearchCli.Size = new System.Drawing.Size(22, 22);
            this.btnSearchCli.TabIndex = 13;
            this.btnSearchCli.Text = "wsbtnsearch1";
            this.btnSearchCli.Text_EN = null;
            this.btnSearchCli.Text_FR = null;
            this.btnSearchCli.ToolTipText = "Search";
            this.btnSearchCli.UseVisualStyleBackColor = true;
            this.btnSearchCli.Click += new System.EventHandler(this.btnSearchCli_Click);
            // 
            // ffpapiercli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1136, 475);
            this.Controls.Add(this.btnSearchCli);
            this.Controls.Add(this.wslabel2);
            this.Controls.Add(this.wslabel1);
            this.Controls.Add(this.wsGrid1);
            this.Controls.Add(this.btn_raf);
            this.Controls.Add(this.txtClient_name);
            this.Controls.Add(this.txtclient_code);
            this.Controls.Add(this.ScnCode);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnQuit2);
            this.Name = "ffpapiercli";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnQuit2, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.Controls.SetChildIndex(this.ScnCode, 0);
            this.Controls.SetChildIndex(this.txtclient_code, 0);
            this.Controls.SetChildIndex(this.txtClient_name, 0);
            this.Controls.SetChildIndex(this.btn_raf, 0);
            this.Controls.SetChildIndex(this.wsGrid1, 0);
            this.Controls.SetChildIndex(this.wslabel1, 0);
            this.Controls.SetChildIndex(this.wslabel2, 0);
            this.Controls.SetChildIndex(this.btnSearchCli, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wsGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vivael.wscontrols.Wscommandbutton btnQuit2;
        private vivael.wscontrols.Wscommandbutton btnApply;
        private vivael.wscontrols.wstextbox ScnCode;
        private vivael.wscontrols.wstextbox txtclient_code;
        private vivael.wscontrols.wstextbox txtClient_name;
        private vivael.wscontrols.Wscommandbutton btn_raf;
        private vivael.wscontrols.wsGrid wsGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private vivael.wscontrols.wslabel wslabel1;
        private vivael.wscontrols.wslabel wslabel2;
        private vivael.wscontrols.Wsbtnsearch btnSearchCli;
    }
}
