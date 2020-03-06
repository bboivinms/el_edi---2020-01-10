using vivael.wscontrols;

namespace vivael.forms
{
    partial class wsmuser2
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
            this.wsComboBox1 = new vivael.wscontrols.wsComboBox();
            this.txtName = new vivael.wscontrols.wstextbox();
            this.txtCode = new vivael.wscontrols.wstextbox();
            this.txtPasswd = new vivael.wscontrols.wstextbox();
            this.txtUsertimer = new vivael.wscontrols.wsnumbox();
            this.chkReceive = new vivael.wscontrols.wsCheckBox();
            this.wsoptiongroup1 = new vivael.wscontrols.wsoptiongroup();
            this.selOption2 = new OpGroup.SelOption();
            this.selOption1 = new OpGroup.SelOption();
            this.lblDateFormat = new vivael.wscontrols.wslabel();
            this.lblMinutes = new vivael.wscontrols.wslabel();
            this.lblVerifyMess = new vivael.wscontrols.wslabel();
            this.lblEmailSignature = new vivael.wscontrols.wslabel();
            this.edtEmail_signature = new vivael.wscontrols.wstextbox();
            this.lblTitle = new vivael.wscontrols.wslabel();
            this.wstextbox1 = new vivael.wscontrols.wstextbox();
            this.lblPhone = new vivael.wscontrols.wslabel();
            this.txtTel = new vivael.wscontrols.wstextbox();
            this.lblMsnAddress = new vivael.wscontrols.wslabel();
            this.txtMsn = new vivael.wscontrols.wstextbox();
            this.chkEmail_bcc_self = new vivael.wscontrols.wsCheckBox();
            this.lblEmail = new vivael.wscontrols.wslabel();
            this.txtEmail = new vivael.wscontrols.wstextbox();
            this.wsCheckBox2 = new vivael.wscontrols.wsCheckBox();
            this.wsCheckBox1 = new vivael.wscontrols.wsCheckBox();
            this.chkActive = new vivael.wscontrols.wsCheckBox();
            this.lblLanguage = new vivael.wscontrols.wslabel();
            this.lblType = new vivael.wscontrols.wslabel();
            this.lblGroup = new vivael.wscontrols.wslabel();
            this.lblPassword = new vivael.wscontrols.wslabel();
            this.lblName = new vivael.wscontrols.wslabel();
            this.lblCode = new vivael.wscontrols.wslabel();
            this.wsComboBox3 = new vivael.wscontrols.wsComboBox();
            this.wsComboBox2 = new vivael.wscontrols.wsComboBox();
            this.groupBox2 = new vivael.wscontrols.wsgroupbox();
            this.lblAccess = new vivael.wscontrols.wslabel();
            this.chkTa_limited = new vivael.wscontrols.wsCheckBox();
            this.lblAccountRep = new vivael.wscontrols.wslabel();
            this.wsComboBox4 = new vivael.wscontrols.wsComboBox();
            this.groupBox1 = new vivael.wscontrols.wsgroupbox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsertimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wsoptiongroup1)).BeginInit();
            this.wsoptiongroup1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(560, 0);
            this.panel1.Size = new System.Drawing.Size(109, 532);
            // 
            // BtnPrint
            // 
            this.BtnPrint.Visible = false;
            // 
            // BtnQuit
            // 
            this.BtnQuit.Location = new System.Drawing.Point(12, 500);
            // 
            // wsComboBox1
            // 
            this.wsComboBox1.apControlSource = "wsuser.group";
            this.wsComboBox1.apType = "string";
            this.wsComboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.wsComboBox1.BoundTo = true;
            this.wsComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wsComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wsComboBox1.FormattingEnabled = true;
            this.wsComboBox1.lenabledisable = true;
            this.wsComboBox1.Location = new System.Drawing.Point(109, 103);
            this.wsComboBox1.Name = "wsComboBox1";
            this.wsComboBox1.Size = new System.Drawing.Size(160, 21);
            this.wsComboBox1.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.apControlSource = "wsuser.name";
            this.txtName.apType = "string";
            this.txtName.Location = new System.Drawing.Point(109, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 20);
            this.txtName.State = null;
            this.txtName.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.apControlSource = "wsuser.code";
            this.txtCode.apType = "string";
            this.txtCode.Location = new System.Drawing.Point(109, 19);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(81, 20);
            this.txtCode.State = null;
            this.txtCode.TabIndex = 1;
           // this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // txtPasswd
            // 
            this.txtPasswd.apControlSource = "wsuser.passwd";
            this.txtPasswd.apType = "string";
            this.txtPasswd.Location = new System.Drawing.Point(109, 79);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.Size = new System.Drawing.Size(81, 20);
            this.txtPasswd.State = null;
            this.txtPasswd.TabIndex = 3;
            // 
            // txtUsertimer
            // 
            this.txtUsertimer.apControlSource = "wsuser.usertimer";
            this.txtUsertimer.apType = "int";
            this.txtUsertimer.Location = new System.Drawing.Point(180, 392);
            this.txtUsertimer.Name = "txtUsertimer";
            this.txtUsertimer.Size = new System.Drawing.Size(40, 20);
            this.txtUsertimer.State = null;
            this.txtUsertimer.TabIndex = 41;
            // 
            // chkReceive
            // 
            this.chkReceive.apControlSource = "wsuser.msg_recep";
            this.chkReceive.apType = "bool";
            this.chkReceive.AutoSize = true;
            this.chkReceive.Location = new System.Drawing.Point(107, 416);
            this.chkReceive.Name = "chkReceive";
            this.chkReceive.Size = new System.Drawing.Size(147, 17);
            this.chkReceive.TabIndex = 40;
            this.chkReceive.Text = "Receive receptions notes";
            this.chkReceive.Text_EN = "Receive receptions notes";
            this.chkReceive.Text_FR = "Recevoir les notes des réceptions";
            this.chkReceive.UseVisualStyleBackColor = true;
            // 
            // wsoptiongroup1
            // 
            this.wsoptiongroup1.apControlSource = "wsuser.date_format";
            this.wsoptiongroup1.apType = "int";
            this.wsoptiongroup1.Controls.Add(this.selOption2);
            this.wsoptiongroup1.Controls.Add(this.selOption1);
            this.wsoptiongroup1.Location = new System.Drawing.Point(366, 151);
            this.wsoptiongroup1.Name = "wsoptiongroup1";
            this.wsoptiongroup1.Size = new System.Drawing.Size(147, 24);
            this.wsoptiongroup1.State = null;
            this.wsoptiongroup1.TabIndex = 39;
            this.wsoptiongroup1.Value = 1;
            // 
            // selOption2
            // 
            this.selOption2.Location = new System.Drawing.Point(54, 1);
            this.selOption2.Name = "selOption2";
            this.selOption2.Size = new System.Drawing.Size(54, 24);
            this.selOption2.TabIndex = 1;
            this.selOption2.Text = "DMY";
            this.selOption2.Value = 2;
            // 
            // selOption1
            // 
            this.selOption1.Checked = true;
            this.selOption1.Location = new System.Drawing.Point(1, 1);
            this.selOption1.Name = "selOption1";
            this.selOption1.Size = new System.Drawing.Size(57, 24);
            this.selOption1.TabIndex = 0;
            this.selOption1.TabStop = true;
            this.selOption1.Text = "MDY";
            this.selOption1.Value = 1;
            // 
            // lblDateFormat
            // 
            this.lblDateFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFormat.Location = new System.Drawing.Point(275, 155);
            this.lblDateFormat.Name = "lblDateFormat";
            this.lblDateFormat.Size = new System.Drawing.Size(90, 15);
            this.lblDateFormat.TabIndex = 37;
            this.lblDateFormat.Text = "Date format";
            this.lblDateFormat.Text_EN = null;
            this.lblDateFormat.Text_FR = null;
            this.lblDateFormat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(219, 393);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(51, 15);
            this.lblMinutes.TabIndex = 35;
            this.lblMinutes.Text = "minutes";
            this.lblMinutes.Text_EN = null;
            this.lblMinutes.Text_FR = null;
            // 
            // lblVerifyMess
            // 
            this.lblVerifyMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerifyMess.Location = new System.Drawing.Point(39, 392);
            this.lblVerifyMess.Name = "lblVerifyMess";
            this.lblVerifyMess.Size = new System.Drawing.Size(144, 15);
            this.lblVerifyMess.TabIndex = 33;
            this.lblVerifyMess.Text = "Verify message every ";
            this.lblVerifyMess.Text_EN = "Verify message every";
            this.lblVerifyMess.Text_FR = "Vérifier les messages aux";
            this.lblVerifyMess.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEmailSignature
            // 
            this.lblEmailSignature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailSignature.Location = new System.Drawing.Point(2, 330);
            this.lblEmailSignature.Name = "lblEmailSignature";
            this.lblEmailSignature.Size = new System.Drawing.Size(104, 15);
            this.lblEmailSignature.TabIndex = 32;
            this.lblEmailSignature.Text = "Email signature";
            this.lblEmailSignature.Text_EN = "Email signature";
            this.lblEmailSignature.Text_FR = "Signature courriel";
            this.lblEmailSignature.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // edtEmail_signature
            // 
            this.edtEmail_signature.apControlSource = "wsuser.email_signature";
            this.edtEmail_signature.apType = "string";
            this.edtEmail_signature.Location = new System.Drawing.Point(109, 327);
            this.edtEmail_signature.Multiline = true;
            this.edtEmail_signature.Name = "edtEmail_signature";
            this.edtEmail_signature.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edtEmail_signature.Size = new System.Drawing.Size(391, 55);
            this.edtEmail_signature.State = null;
            this.edtEmail_signature.TabIndex = 31;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(58, 308);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(48, 15);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "Title";
            this.lblTitle.Text_EN = "Title";
            this.lblTitle.Text_FR = "Titre";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // wstextbox1
            // 
            this.wstextbox1.apControlSource = "wsuser.title";
            this.wstextbox1.apType = "string";
            this.wstextbox1.Location = new System.Drawing.Point(109, 306);
            this.wstextbox1.Name = "wstextbox1";
            this.wstextbox1.Size = new System.Drawing.Size(391, 20);
            this.wstextbox1.State = null;
            this.wstextbox1.TabIndex = 29;
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(30, 287);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(76, 15);
            this.lblPhone.TabIndex = 28;
            this.lblPhone.Text = "Phone";
            this.lblPhone.Text_EN = "Phone";
            this.lblPhone.Text_FR = "Téléphone";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTel
            // 
            this.txtTel.apControlSource = "wsuser.tel";
            this.txtTel.apType = "string";
            this.txtTel.Location = new System.Drawing.Point(109, 285);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(203, 20);
            this.txtTel.State = null;
            this.txtTel.TabIndex = 27;
            // 
            // lblMsnAddress
            // 
            this.lblMsnAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsnAddress.Location = new System.Drawing.Point(8, 266);
            this.lblMsnAddress.Name = "lblMsnAddress";
            this.lblMsnAddress.Size = new System.Drawing.Size(98, 15);
            this.lblMsnAddress.TabIndex = 26;
            this.lblMsnAddress.Text = "MSN address";
            this.lblMsnAddress.Text_EN = "MSN address";
            this.lblMsnAddress.Text_FR = "Adresse MSN";
            this.lblMsnAddress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMsn
            // 
            this.txtMsn.apControlSource = "wsuser.msn";
            this.txtMsn.apType = "string";
            this.txtMsn.Location = new System.Drawing.Point(109, 264);
            this.txtMsn.Name = "txtMsn";
            this.txtMsn.Size = new System.Drawing.Size(391, 20);
            this.txtMsn.State = null;
            this.txtMsn.TabIndex = 25;
            // 
            // chkEmail_bcc_self
            // 
            this.chkEmail_bcc_self.apControlSource = "wsuser.email_bcc_self";
            this.chkEmail_bcc_self.apType = "bool";
            this.chkEmail_bcc_self.AutoSize = true;
            this.chkEmail_bcc_self.Location = new System.Drawing.Point(109, 244);
            this.chkEmail_bcc_self.Name = "chkEmail_bcc_self";
            this.chkEmail_bcc_self.Size = new System.Drawing.Size(256, 17);
            this.chkEmail_bcc_self.TabIndex = 11;
            this.chkEmail_bcc_self.Text = "When sending an email bcc to this email address";
            this.chkEmail_bcc_self.Text_EN = "When sending an email, bcc to this email address";
            this.chkEmail_bcc_self.Text_FR = "Mettre dans le bcc lors de l\'envoie d\'un courriel";
            this.chkEmail_bcc_self.UseVisualStyleBackColor = true;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(36, 222);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(68, 15);
            this.lblEmail.TabIndex = 24;
            this.lblEmail.Text = "Email";
            this.lblEmail.Text_EN = "Email";
            this.lblEmail.Text_FR = "Courriel";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtEmail
            // 
            this.txtEmail.apControlSource = "wsuser.email";
            this.txtEmail.apType = "string";
            this.txtEmail.Location = new System.Drawing.Point(109, 220);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(391, 20);
            this.txtEmail.State = null;
            this.txtEmail.TabIndex = 10;
            // 
            // wsCheckBox2
            // 
            this.wsCheckBox2.apControlSource = "wsuser.administrator";
            this.wsCheckBox2.apType = "bool";
            this.wsCheckBox2.AutoSize = true;
            this.wsCheckBox2.Location = new System.Drawing.Point(109, 198);
            this.wsCheckBox2.Name = "wsCheckBox2";
            this.wsCheckBox2.Size = new System.Drawing.Size(140, 17);
            this.wsCheckBox2.TabIndex = 9;
            this.wsCheckBox2.Text = "Is a system administrator";
            this.wsCheckBox2.Text_EN = "Is a system administrator";
            this.wsCheckBox2.Text_FR = "Est un administrateur de systeme";
            this.wsCheckBox2.UseVisualStyleBackColor = true;
            // 
            // wsCheckBox1
            // 
            this.wsCheckBox1.apControlSource = "wsuser.canmodclientaccntg";
            this.wsCheckBox1.apType = "bool";
            this.wsCheckBox1.AutoSize = true;
            this.wsCheckBox1.Location = new System.Drawing.Point(109, 179);
            this.wsCheckBox1.Name = "wsCheckBox1";
            this.wsCheckBox1.Size = new System.Drawing.Size(282, 17);
            this.wsCheckBox1.TabIndex = 8;
            this.wsCheckBox1.Text = "Allowed to modify client accounting && bank information";
            this.wsCheckBox1.Text_EN = "Allowed to modify client accounting & bank information";
            this.wsCheckBox1.Text_FR = "Peut modifier les information comptables dans les clients";
            this.wsCheckBox1.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.apControlSource = "wsuser.active";
            this.chkActive.apType = "bool";
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(457, 22);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 19;
            this.chkActive.Text = "Active";
            this.chkActive.Text_EN = "Active";
            this.chkActive.Text_FR = "Actif";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // lblLanguage
            // 
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.Location = new System.Drawing.Point(27, 156);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(78, 15);
            this.lblLanguage.TabIndex = 20;
            this.lblLanguage.Text = "Language";
            this.lblLanguage.Text_EN = "Language";
            this.lblLanguage.Text_FR = "Langue";
            this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblType
            // 
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(55, 131);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(50, 15);
            this.lblType.TabIndex = 19;
            this.lblType.Text = "Type";
            this.lblType.Text_EN = null;
            this.lblType.Text_FR = null;
            this.lblType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGroup
            // 
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.Location = new System.Drawing.Point(27, 106);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(79, 18);
            this.lblGroup.TabIndex = 18;
            this.lblGroup.Text = "Group";
            this.lblGroup.Text_EN = "Group";
            this.lblGroup.Text_FR = "Groupe";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(16, 81);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(90, 15);
            this.lblPassword.TabIndex = 17;
            this.lblPassword.Text = "Password";
            this.lblPassword.Text_EN = "Password";
            this.lblPassword.Text_FR = "Mot de passe";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(65, 58);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 15);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Name";
            this.lblName.Text_EN = "Name";
            this.lblName.Text_FR = "Nom";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCode
            // 
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(70, 21);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(36, 15);
            this.lblCode.TabIndex = 15;
            this.lblCode.Text = "Code";
            this.lblCode.Text_EN = null;
            this.lblCode.Text_FR = null;
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // wsComboBox3
            // 
            this.wsComboBox3.apControlSource = "wsuser.language";
            this.wsComboBox3.apType = "string";
            this.wsComboBox3.BackColor = System.Drawing.SystemColors.Window;
            this.wsComboBox3.BoundTo = true;
            this.wsComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wsComboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wsComboBox3.FormattingEnabled = true;
            this.wsComboBox3.lenabledisable = true;
            this.wsComboBox3.Location = new System.Drawing.Point(109, 153);
            this.wsComboBox3.Name = "wsComboBox3";
            this.wsComboBox3.Size = new System.Drawing.Size(160, 21);
            this.wsComboBox3.TabIndex = 6;
            // 
            // wsComboBox2
            // 
            this.wsComboBox2.apControlSource = "wsuser.type";
            this.wsComboBox2.apType = "string";
            this.wsComboBox2.BackColor = System.Drawing.SystemColors.Window;
            this.wsComboBox2.BoundTo = true;
            this.wsComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wsComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wsComboBox2.FormattingEnabled = true;
            this.wsComboBox2.lenabledisable = true;
            this.wsComboBox2.Location = new System.Drawing.Point(109, 128);
            this.wsComboBox2.Name = "wsComboBox2";
            this.wsComboBox2.Size = new System.Drawing.Size(160, 21);
            this.wsComboBox2.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.lblAccess);
            this.groupBox2.Controls.Add(this.chkTa_limited);
            this.groupBox2.Controls.Add(this.lblAccountRep);
            this.groupBox2.Controls.Add(this.wsComboBox4);
            this.groupBox2.Location = new System.Drawing.Point(6, 447);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(542, 78);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Follow-up";
            this.groupBox2.Text_EN = "Follow-up";
            this.groupBox2.Text_FR = "Suivis";
            // 
            // lblAccess
            // 
            this.lblAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccess.Location = new System.Drawing.Point(42, 46);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(62, 15);
            this.lblAccess.TabIndex = 38;
            this.lblAccess.Text = "Access";
            this.lblAccess.Text_EN = "Access";
            this.lblAccess.Text_FR = "Accès";
            this.lblAccess.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkTa_limited
            // 
            this.chkTa_limited.apControlSource = "wsuser.limited";
            this.chkTa_limited.apType = "bool";
            this.chkTa_limited.AutoSize = true;
            this.chkTa_limited.Location = new System.Drawing.Point(107, 47);
            this.chkTa_limited.Name = "chkTa_limited";
            this.chkTa_limited.Size = new System.Drawing.Size(179, 17);
            this.chkTa_limited.TabIndex = 37;
            this.chkTa_limited.Text = "Limited to his own accounts only";
            this.chkTa_limited.Text_EN = "Limited to his own accounts only";
            this.chkTa_limited.Text_FR = "Limité à ses comptes seulement";
            this.chkTa_limited.UseVisualStyleBackColor = true;
            // 
            // lblAccountRep
            // 
            this.lblAccountRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountRep.Location = new System.Drawing.Point(19, 23);
            this.lblAccountRep.Name = "lblAccountRep";
            this.lblAccountRep.Size = new System.Drawing.Size(86, 15);
            this.lblAccountRep.TabIndex = 22;
            this.lblAccountRep.Text = "Account rep.";
            this.lblAccountRep.Text_EN = "Account rep.";
            this.lblAccountRep.Text_FR = "Représentant";
            this.lblAccountRep.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // wsComboBox4
            // 
            this.wsComboBox4.apControlSource = "wsuser.arrep";
            this.wsComboBox4.apType = "string";
            this.wsComboBox4.BackColor = System.Drawing.SystemColors.Window;
            this.wsComboBox4.BoundTo = true;
            this.wsComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wsComboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wsComboBox4.FormattingEnabled = true;
            this.wsComboBox4.lenabledisable = true;
            this.wsComboBox4.Location = new System.Drawing.Point(109, 20);
            this.wsComboBox4.Name = "wsComboBox4";
            this.wsComboBox4.Size = new System.Drawing.Size(160, 21);
            this.wsComboBox4.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUsertimer);
            this.groupBox1.Controls.Add(this.chkReceive);
            this.groupBox1.Controls.Add(this.wsoptiongroup1);
            this.groupBox1.Controls.Add(this.lblDateFormat);
            this.groupBox1.Controls.Add(this.lblMinutes);
            this.groupBox1.Controls.Add(this.lblVerifyMess);
            this.groupBox1.Controls.Add(this.lblEmailSignature);
            this.groupBox1.Controls.Add(this.edtEmail_signature);
            this.groupBox1.Controls.Add(this.lblTitle);
            this.groupBox1.Controls.Add(this.wstextbox1);
            this.groupBox1.Controls.Add(this.lblPhone);
            this.groupBox1.Controls.Add(this.txtTel);
            this.groupBox1.Controls.Add(this.lblMsnAddress);
            this.groupBox1.Controls.Add(this.txtMsn);
            this.groupBox1.Controls.Add(this.chkEmail_bcc_self);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.wsCheckBox2);
            this.groupBox1.Controls.Add(this.wsCheckBox1);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.lblLanguage);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.lblGroup);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblCode);
            this.groupBox1.Controls.Add(this.wsComboBox3);
            this.groupBox1.Controls.Add(this.wsComboBox2);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.txtPasswd);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.wsComboBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 441);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text_EN = null;
            this.groupBox1.Text_FR = null;
            // 
            // wsmuser2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(669, 531);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "wsmuser2";
            this.Text = "Users";
            this.Text_EN = "Users";
            this.Text_FR = "Utilisateurs";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsertimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wsoptiongroup1)).EndInit();
            this.wsoptiongroup1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private wscontrols.wsComboBox wsComboBox1;
        private wscontrols.wstextbox txtName;
        private wscontrols.wstextbox txtCode;
        private wscontrols.wstextbox txtPasswd;
        private wslabel lblLanguage;
        private wslabel lblType;
        private wslabel lblGroup;
        private wslabel lblPassword;
        private wslabel lblName;
        private wslabel lblCode;
        private wscontrols.wsComboBox wsComboBox3;
        private wscontrols.wsComboBox wsComboBox2;
        private wscontrols.wsCheckBox chkActive;
        private wscontrols.wsCheckBox wsCheckBox2;
        private wscontrols.wsCheckBox wsCheckBox1;
        private wscontrols.wsCheckBox chkEmail_bcc_self;
        private wslabel lblEmail;
        private wscontrols.wstextbox txtEmail;
        private wslabel lblMinutes;
        private wslabel lblVerifyMess;
        private wslabel lblEmailSignature;
        private wscontrols.wstextbox edtEmail_signature;
        private wslabel lblTitle;
        private wscontrols.wstextbox wstextbox1;
        private wslabel lblPhone;
        private wscontrols.wstextbox txtTel;
        private wslabel lblMsnAddress;
        private wscontrols.wstextbox txtMsn;
        private wsgroupbox groupBox2;
        private wslabel lblAccess;
        private wscontrols.wsCheckBox chkTa_limited;
        private wslabel lblAccountRep;
        private wscontrols.wsComboBox wsComboBox4;
        private wslabel lblDateFormat;
        private wscontrols.wsoptiongroup wsoptiongroup1;
        private OpGroup.SelOption selOption2;
        private OpGroup.SelOption selOption1;
        private wscontrols.wsCheckBox chkReceive;
        private wscontrols.wsnumbox txtUsertimer;
        private wsgroupbox groupBox1;
    }
}
