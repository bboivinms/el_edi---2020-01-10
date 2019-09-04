using vivael.wscontrols;

namespace vivael.forms
{
    partial class wsLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wsLogin));
            this.Wslabel3 = new vivael.wscontrols.wslabel();
            this.Wslabel1 = new vivael.wscontrols.wslabel();
            this.ScnPasswd = new System.Windows.Forms.TextBox();
            this.ScnLoginName = new System.Windows.Forms.TextBox();
            this.BtnLogin = new vivael.wscontrols.wsbutton();
            this.Wslink1 = new vivael.wscontrols.wslink();
            this.Wsimage1 = new System.Windows.Forms.PictureBox();
            this.ScnLogin = new System.Windows.Forms.TextBox();
            this.Wslabel2 = new vivael.wscontrols.wslabel();
            ((System.ComponentModel.ISupportInitialize)(this.Wsimage1)).BeginInit();
            this.SuspendLayout();
            // 
            // Wslabel3
            // 
            this.Wslabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Wslabel3.AutoSize = true;
            this.Wslabel3.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wslabel3.Location = new System.Drawing.Point(81, 108);
            this.Wslabel3.Name = "Wslabel3";
            this.Wslabel3.Size = new System.Drawing.Size(383, 34);
            this.Wslabel3.TabIndex = 10;
            this.Wslabel3.Text = "ENVELOPPE LAURENTIDE";
            this.Wslabel3.Text_EN = null;
            this.Wslabel3.Text_FR = null;
            // 
            // Wslabel1
            // 
            this.Wslabel1.AutoSize = true;
            this.Wslabel1.Location = new System.Drawing.Point(129, 181);
            this.Wslabel1.Name = "Wslabel1";
            this.Wslabel1.Size = new System.Drawing.Size(29, 13);
            this.Wslabel1.TabIndex = 2;
            this.Wslabel1.Text = "User";
            this.Wslabel1.Text_EN = "User";
            this.Wslabel1.Text_FR = "Utilisateur";
            // 
            // ScnPasswd
            // 
            this.ScnPasswd.Location = new System.Drawing.Point(129, 237);
            this.ScnPasswd.Name = "ScnPasswd";
            this.ScnPasswd.Size = new System.Drawing.Size(92, 20);
            this.ScnPasswd.TabIndex = 2;
            this.ScnPasswd.UseSystemPasswordChar = true;
            this.ScnPasswd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScnPasswd_KeyDown);
            this.ScnPasswd.Leave += new System.EventHandler(this.ScnPasswd_Leave);
            // 
            // ScnLoginName
            // 
            this.ScnLoginName.Enabled = false;
            this.ScnLoginName.Location = new System.Drawing.Point(234, 196);
            this.ScnLoginName.Name = "ScnLoginName";
            this.ScnLoginName.ReadOnly = true;
            this.ScnLoginName.Size = new System.Drawing.Size(190, 20);
            this.ScnLoginName.TabIndex = 6;
            // 
            // BtnLogin
            // 
            this.BtnLogin.Enabled = false;
            this.BtnLogin.Location = new System.Drawing.Point(328, 233);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(96, 24);
            this.BtnLogin.TabIndex = 3;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.Text_EN = "Access";
            this.BtnLogin.Text_FR = "Accéder";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // Wslink1
            // 
            this.Wslink1.AutoSize = true;
            this.Wslink1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wslink1.LinkColor = System.Drawing.Color.Black;
            this.Wslink1.Location = new System.Drawing.Point(490, 281);
            this.Wslink1.Name = "Wslink1";
            this.Wslink1.Size = new System.Drawing.Size(39, 16);
            this.Wslink1.TabIndex = 11;
            this.Wslink1.TabStop = true;
            this.Wslink1.Text = "Sortir";
            this.Wslink1.Text_EN = "Exit";
            this.Wslink1.Text_FR = "Sortir";
            this.Wslink1.VisitedLinkColor = System.Drawing.Color.Black;
            this.Wslink1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // Wsimage1
            // 
            this.Wsimage1.Image = ((System.Drawing.Image)(resources.GetObject("Wsimage1.Image")));
            this.Wsimage1.Location = new System.Drawing.Point(0, 0);
            this.Wsimage1.Name = "Wsimage1";
            this.Wsimage1.Size = new System.Drawing.Size(540, 72);
            this.Wsimage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Wsimage1.TabIndex = 0;
            this.Wsimage1.TabStop = false;
            // 
            // ScnLogin
            // 
            this.ScnLogin.Location = new System.Drawing.Point(129, 196);
            this.ScnLogin.Name = "ScnLogin";
            this.ScnLogin.Size = new System.Drawing.Size(92, 20);
            this.ScnLogin.TabIndex = 1;
            this.ScnLogin.Leave += new System.EventHandler(this.ScnLogin_Leave);
            // 
            // Wslabel2
            // 
            this.Wslabel2.AutoSize = true;
            this.Wslabel2.Location = new System.Drawing.Point(129, 222);
            this.Wslabel2.Name = "Wslabel2";
            this.Wslabel2.Size = new System.Drawing.Size(53, 13);
            this.Wslabel2.TabIndex = 9;
            this.Wslabel2.Text = "Password";
            this.Wslabel2.Text_EN = "Password";
            this.Wslabel2.Text_FR = "Mot de passe";
            // 
            // wsLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 306);
            this.Controls.Add(this.Wslabel2);
            this.Controls.Add(this.ScnLogin);
            this.Controls.Add(this.Wslink1);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.ScnLoginName);
            this.Controls.Add(this.Wslabel1);
            this.Controls.Add(this.Wslabel3);
            this.Controls.Add(this.Wsimage1);
            this.Controls.Add(this.ScnPasswd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "wsLogin";
            this.Text = "Winsys access";
            ((System.ComponentModel.ISupportInitialize)(this.Wsimage1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Wsimage1;
        private wslabel Wslabel3;
        private wslabel Wslabel1;
        private System.Windows.Forms.TextBox ScnPasswd;
        private System.Windows.Forms.TextBox ScnLoginName;
        private vivael.wscontrols.wsbutton BtnLogin;
        private wslink Wslink1;
        private System.Windows.Forms.TextBox ScnLogin;
        private wslabel Wslabel2;
    }
}