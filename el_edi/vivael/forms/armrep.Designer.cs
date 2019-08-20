namespace vivael.forms
{
    partial class armrep
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.wstextbox1 = new vivael.wscontrols.wstextbox();
            this.lblCode = new vivael.wscontrols.wslabel();
            this.lblName = new vivael.wscontrols.wslabel();
            this.txtName = new vivael.wscontrols.wstextbox();
            this.lblUsercode = new vivael.wscontrols.wslabel();
            this.txtUsercode = new vivael.wscontrols.wstextbox();
            this.wslabel1 = new vivael.wscontrols.wslabel();
            this.txtTitle = new vivael.wscontrols.wstextbox();
            this.lblEmail = new vivael.wscontrols.wslabel();
            this.txtEmail = new vivael.wscontrols.wstextbox();
            this.chkInactif = new vivael.wscontrols.wsCheckBox();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wsshape1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wsGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Wsshape1
            // 
            this.Wsshape1.Controls.Add(this.chkInactif);
            this.Wsshape1.Controls.Add(this.lblEmail);
            this.Wsshape1.Controls.Add(this.txtEmail);
            this.Wsshape1.Controls.Add(this.wslabel1);
            this.Wsshape1.Controls.Add(this.txtTitle);
            this.Wsshape1.Controls.Add(this.lblUsercode);
            this.Wsshape1.Controls.Add(this.txtUsercode);
            this.Wsshape1.Controls.Add(this.lblName);
            this.Wsshape1.Controls.Add(this.txtName);
            this.Wsshape1.Controls.Add(this.lblCode);
            this.Wsshape1.Controls.Add(this.wstextbox1);
            this.Wsshape1.Size = new System.Drawing.Size(454, 153);
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
            this.wsGrid1.ColumnHeadersHeight = 20;
            this.wsGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NAME});
            this.wsGrid1.RowHeadersWidth = 20;
            this.wsGrid1.RowTemplate.Height = 15;
            this.wsGrid1.Size = new System.Drawing.Size(454, 231);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(466, 0);
            // 
            // wstextbox1
            // 
            this.wstextbox1.apControlSource = "arrep.code";
            this.wstextbox1.apType = "string";
            this.wstextbox1.Location = new System.Drawing.Point(100, 31);
            this.wstextbox1.Name = "wstextbox1";
            this.wstextbox1.Size = new System.Drawing.Size(48, 20);
            this.wstextbox1.State = null;
            this.wstextbox1.TabIndex = 0;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(61, 33);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(37, 15);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Code";
            this.lblCode.Text_EN = null;
            this.lblCode.Text_FR = null;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(57, 54);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 15);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            this.lblName.Text_EN = null;
            this.lblName.Text_FR = null;
            // 
            // txtName
            // 
            this.txtName.apControlSource = "arrep.name";
            this.txtName.apType = "string";
            this.txtName.Location = new System.Drawing.Point(100, 52);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(288, 20);
            this.txtName.State = null;
            this.txtName.TabIndex = 2;
            // 
            // lblUsercode
            // 
            this.lblUsercode.AutoSize = true;
            this.lblUsercode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsercode.Location = new System.Drawing.Point(34, 75);
            this.lblUsercode.Name = "lblUsercode";
            this.lblUsercode.Size = new System.Drawing.Size(64, 15);
            this.lblUsercode.TabIndex = 5;
            this.lblUsercode.Text = "User code";
            this.lblUsercode.Text_EN = null;
            this.lblUsercode.Text_FR = null;
            // 
            // txtUsercode
            // 
            this.txtUsercode.apControlSource = "arrep.usercode";
            this.txtUsercode.apType = "string";
            this.txtUsercode.Location = new System.Drawing.Point(100, 73);
            this.txtUsercode.Name = "txtUsercode";
            this.txtUsercode.Size = new System.Drawing.Size(81, 20);
            this.txtUsercode.State = null;
            this.txtUsercode.TabIndex = 4;
            // 
            // wslabel1
            // 
            this.wslabel1.AutoSize = true;
            this.wslabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wslabel1.Location = new System.Drawing.Point(68, 96);
            this.wslabel1.Name = "wslabel1";
            this.wslabel1.Size = new System.Drawing.Size(30, 15);
            this.wslabel1.TabIndex = 7;
            this.wslabel1.Text = "Title";
            this.wslabel1.Text_EN = null;
            this.wslabel1.Text_FR = null;
            this.wslabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTitle
            // 
            this.txtTitle.apControlSource = "arrep.title";
            this.txtTitle.apType = "string";
            this.txtTitle.Location = new System.Drawing.Point(100, 94);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(288, 20);
            this.txtTitle.State = null;
            this.txtTitle.TabIndex = 6;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(59, 117);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email";
            this.lblEmail.Text_EN = null;
            this.lblEmail.Text_FR = null;
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtEmail
            // 
            this.txtEmail.apControlSource = "arrep.email";
            this.txtEmail.apType = "string";
            this.txtEmail.Location = new System.Drawing.Point(100, 115);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(288, 20);
            this.txtEmail.State = null;
            this.txtEmail.TabIndex = 8;
            // 
            // chkInactif
            // 
            this.chkInactif.apControlSource = "arrep.inactif";
            this.chkInactif.apType = "bool";
            this.chkInactif.AutoSize = true;
            this.chkInactif.Location = new System.Drawing.Point(279, 32);
            this.chkInactif.Name = "chkInactif";
            this.chkInactif.Size = new System.Drawing.Size(55, 17);
            this.chkInactif.TabIndex = 10;
            this.chkInactif.Text = "Inactif";
            this.chkInactif.Text_EN = null;
            this.chkInactif.Text_FR = null;
            this.chkInactif.UseVisualStyleBackColor = true;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "Name";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NAME.Width = 420;
            // 
            // armrep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(575, 408);
            this.Name = "armrep";
            this.Text = "Représentants";
            this.Wsshape1.ResumeLayout(false);
            this.Wsshape1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wsGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private wscontrols.wslabel lblCode;
        private wscontrols.wstextbox wstextbox1;
        private wscontrols.wslabel lblEmail;
        private wscontrols.wstextbox txtEmail;
        private wscontrols.wslabel wslabel1;
        private wscontrols.wstextbox txtTitle;
        private wscontrols.wslabel lblUsercode;
        private wscontrols.wstextbox txtUsercode;
        private wscontrols.wslabel lblName;
        private wscontrols.wstextbox txtName;
        private wscontrols.wsCheckBox chkInactif;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
    }
}
