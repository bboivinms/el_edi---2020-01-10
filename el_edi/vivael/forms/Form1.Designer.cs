namespace vivael.forms
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.wsComboBox1 = new vivael.wscontrols.wsComboBox();
            this.wstextbox3 = new vivael.wscontrols.wstextbox();
            this.wstextbox2 = new vivael.wscontrols.wstextbox();
            this.wstextbox1 = new vivael.wscontrols.wstextbox();
            this.wstextbox4 = new vivael.wscontrols.wstextbox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // wsComboBox1
            // 
            this.wsComboBox1.apControlSource = "wsuser.type";
            this.wsComboBox1.apType = "string";
            this.wsComboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.wsComboBox1.BoundTo = true;
            this.wsComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wsComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wsComboBox1.FormattingEnabled = true;
            this.wsComboBox1.Items.AddRange(new object[] {
            "Management",
            "Operation",
            "Accounting",
            "Sales"});
            this.wsComboBox1.lenabledisable = true;
            this.wsComboBox1.Location = new System.Drawing.Point(419, 123);
            this.wsComboBox1.Name = "wsComboBox1";
            this.wsComboBox1.Size = new System.Drawing.Size(125, 21);
            this.wsComboBox1.TabIndex = 10;
            // 
            // wstextbox3
            // 
            this.wstextbox3.apControlSource = "wsuser.name";
            this.wstextbox3.apType = "string";
            this.wstextbox3.Location = new System.Drawing.Point(419, 70);
            this.wstextbox3.Name = "wstextbox3";
            this.wstextbox3.Size = new System.Drawing.Size(125, 20);
            this.wstextbox3.State = null;
            this.wstextbox3.TabIndex = 9;
            // 
            // wstextbox2
            // 
            this.wstextbox2.apControlSource = "wsuser.code";
            this.wstextbox2.apType = "string";
            this.wstextbox2.Location = new System.Drawing.Point(419, 44);
            this.wstextbox2.Name = "wstextbox2";
            this.wstextbox2.Size = new System.Drawing.Size(125, 20);
            this.wstextbox2.State = null;
            this.wstextbox2.TabIndex = 8;
            // 
            // wstextbox1
            // 
            this.wstextbox1.apControlSource = "wsuser.ident";
            this.wstextbox1.apType = "int";
            this.wstextbox1.Location = new System.Drawing.Point(419, 15);
            this.wstextbox1.Name = "wstextbox1";
            this.wstextbox1.Size = new System.Drawing.Size(125, 20);
            this.wstextbox1.State = null;
            this.wstextbox1.TabIndex = 7;
            this.wstextbox1.Tag = "";
            // 
            // wstextbox4
            // 
            this.wstextbox4.apControlSource = "wsuser.idnum";
            this.wstextbox4.apType = "string";
            this.wstextbox4.Location = new System.Drawing.Point(419, 96);
            this.wstextbox4.Name = "wstextbox4";
            this.wstextbox4.Size = new System.Drawing.Size(125, 20);
            this.wstextbox4.State = null;
            this.wstextbox4.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(669, 408);
            this.Controls.Add(this.wstextbox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wsComboBox1);
            this.Controls.Add(this.wstextbox3);
            this.Controls.Add(this.wstextbox2);
            this.Controls.Add(this.wstextbox1);
            this.Name = "Form1";
            this.Text = "TestWsMaintForm2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.wstextbox1, 0);
            this.Controls.SetChildIndex(this.wstextbox2, 0);
            this.Controls.SetChildIndex(this.wstextbox3, 0);
            this.Controls.SetChildIndex(this.wsComboBox1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.wstextbox4, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private wscontrols.wsComboBox wsComboBox1;
        private wscontrols.wstextbox wstextbox3;
        private wscontrols.wstextbox wstextbox2;
        private wscontrols.wstextbox wstextbox1;
        private wscontrols.wstextbox wstextbox4;
    }
}
