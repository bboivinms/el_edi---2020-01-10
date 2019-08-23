using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using vivael.wscontrols;
using static vivael.Globals;

namespace vivael.forms
{
    public partial class wsLogin : Form
    {
        private WsSession Session;
        private data_wsuser WsUser;
        //private string scnciecode;
        //private bool User_Validated; //The user is validated yes/no
        private string ValidPasswd;    //Used to store valid password when userid is correctly entered (Used by password field)

        public wsLogin(WsSession oSession)
        {
            InitializeComponent();
            WsUser = new data_wsuser();

            Session = oSession;

            TranslateForm(this);

            CenterToScreen();
        }

        public void CheckUser()
        {
            ValidPasswd = "";
            //User_Validated = false;

            if(ScnLogin.Text != "")
            {
                string code = ScnLogin.Text;

                gQuery("SELECT * FROM WsUser WHERE UPPER(code) ~= "+ Q2(Upper(code)), WsUser, 0, 0, WsUser.isFoxpro);
                WsUser.LoadRow();

                if (WsUser.RECCOUNT() > 0)
                {
                    if(bool.Parse(WsUser.Active.ToString()) == false)
                    {
                        MessageBox.Show(IIF(m0frch, "Utilisateur inactif!", "User inactive!"), IIF(m0frch, "Accès interdit", "Access denied"));
                        ScnLogin.Focus();
                        ScnLogin.SelectAll();
                        return;
                    }
                    else
                    {
                        ValidPasswd = WsUser.Passwd.ToString();
                        ScnLoginName.Text = WsUser.Name.ToString();
                    }
                }
                else
                {
                    MessageBox.Show(IIF(m0frch, "Utilisateur inexistant!", "User not found!"), IIF(m0frch, "Accès interdit", "Access denied"));
                    ScnLogin.Focus();
                    ScnLogin.SelectAll();
                    return;
                }
            }
        }

        private void ScnLogin_Leave(object sender, EventArgs e)
        {
            CheckUser();
        }

        public void CheckPassword()
        {
            if (!EMPTY(ScnPasswd.Text))
            {
                if(EMPTY(ScnLogin.Text))
                {
                    MessageBox.Show(IIF(m0frch, "Utilisateur inexistant!", "User not found!"), IIF(m0frch, "Accès interdit", "Access denied"));
                    ScnPasswd.Focus();
                    ScnPasswd.SelectAll();
                    BtnLogin.Enabled = false;
                    return;
                }

                if (Upper(ScnPasswd.Text) != Upper(ValidPasswd))
                {
                    MessageBox.Show(IIF(m0frch, "Mot de passe invalide", "Invalid password"), IIF(m0frch, "Accès interdit", "Access denied"));
                    ScnPasswd.Focus();
                    ScnPasswd.SelectAll();
                    BtnLogin.Enabled = false;
                    return;
                }
                //User_Validated = true;
                BtnLogin.Enabled = true;
            }
            else
            {
                BtnLogin.Enabled = false;
            }
        }

        private void ScnPasswd_Leave(object sender, EventArgs e)
        {
            CheckPassword();
            if(BtnLogin.Enabled == true)
            {
                BtnLogin.Focus();
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Session.UserCode = ScnLogin.Text;

            Session.UserName =              WsUser.Name.ToString();                       
            Session.UserGroup =             WsUser.Group.ToString();                      
            Session.UserTimer =             Convert.ToInt32(WsUser.Usertimer);            
            Session.language  =             WsUser.Language.ToString();
            Session.zart =                  WsUser.Zart;                
            Session.UserCanModclientaccntg = Convert.ToBoolean(WsUser.Canmodclientaccntg);  
            Session.UserType  =             WsUser.Type.ToString();                       
            Session.administrator =         Convert.ToBoolean(WsUser.Administrator);        
            Session.UserEmail =             WsUser.Email.ToString();              
            Session.email_bcc_self =        Convert.ToBoolean(WsUser.Email_Bcc_Self); 
            Session.accountant =            Convert.ToBoolean(WsUser.Accountant);        
            Session.UserEmailSignature =    WsUser.Email_Signature.ToString();         
            Session.UserArrep =             Convert.ToInt32(WsUser.Arrep);

            if(Session.language.ToLower() == "fr")
            {
                m0frch = true;
            }
            else
            {
                m0frch = false;
            }

            if (Convert.ToInt32(WsUser.Date_Format) == 2)
            {
                Session.date_format = "DMY";
            }
            else
            {
                Session.date_format = "MDY";
            }

            //Initialisation par defaut des couleurs de champs
            if (Session.fBackColor != IntToColor(0) || Session.fForeColor != IntToColor(0))
            {
                Session.fBackColor =            IntToColor(Convert.ToInt32(WsUser.Fbackcolor));
                Session.fForeColor =            IntToColor(Convert.ToInt32(WsUser.Fforecolor));
                Session.fdisabledBackColor =    IntToColor(Convert.ToInt32(WsUser.Fdisabledbackcolor));
                Session.fdisabledForeColor =    IntToColor(Convert.ToInt32(WsUser.Fdisabledforecolor));

                // Pour les captions
                Session.LBackColor =            IntToColor(Convert.ToInt32(WsUser.Lbackcolor));        
                Session.LForeColor =            IntToColor(Convert.ToInt32(WsUser.Lforecolor));        
                Session.LdisabledBackColor =    IntToColor(Convert.ToInt32(WsUser.Ldisabledbackcolor));
                Session.LdisabledForeColor =    IntToColor(Convert.ToInt32(WsUser.Ldisabledforecolor));

                // Pour les formes
                Session.WBackColor =            IntToColor(Convert.ToInt32(WsUser.Wbackcolor));
                Session.WForeColor =            IntToColor(Convert.ToInt32(WsUser.Wforecolor));
                Session.WPicture =              WsUser.Wpicture; 

                // Pour les boutons
                Session.BForeColor =            IntToColor(Convert.ToInt32(WsUser.Bforecolor)); 
                Session.BdisabledForeColor =    IntToColor(Convert.ToInt32(WsUser.Bdisabledforecolor)); 

                // Pour le reste
                Session.sPicture =              WsUser.Spicture;
            }

            Hide();
            Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void ScnPasswd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
    }
}
