﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static vivael.Globals;

namespace vivael.forms
{
    public partial class wsemailinfo : Form
    {
        private int MesgIdent = 0;
        private data_wsemail wsemail = new data_wsemail();
        public int action = 0;

        public wsemailinfo()
        {
            InitializeComponent();

            Text = (IIF(m0frch, "Couriel", "Email"));
            btnSearchEmail.ToolTipText = (IIF(m0frch, "Recherche", "Search"));
            wsbtnsearch1.ToolTipText = (IIF(m0frch, "Recherche", "Search"));
            wsbtnsearch2.ToolTipText = (IIF(m0frch, "Recherche", "Search"));
        }

        public void Init(int pIdent)
        {
            if (!ISNULL(oSession))
            {
                this.MesgIdent = pIdent; 
            }
            else {
                this.MesgIdent = 1; 
            }

            string query = $"SELECT dest_adr, subject, notes, attached, cc, bcc " +
                $"FROM wsemail " +
                $"WHERE wsemail.ident = {this.MesgIdent}";

            gQuery(query, wsemail, 0, 0, wsemail.isFoxpro);
            wsemail.LoadRow();

            if (wsemail.RECCOUNT() <= 0) {
                MESSAGEBOX("Message introuvable!", 0 + 16, "Envoi impossible");
                this.action = -1;
                this.Close();
                return;
            }

            this.ScnMailTo.Text = wsemail.Dest_Adr;     
            this.ScnSubject.Text = wsemail.Subject;     
            this.ScnNotes.Text = wsemail.Notes;         
            this.ScnAttachments.Text = wsemail.Attached;
            this.ScnMailCc.Text = wsemail.Cc;           
            this.ScnMailBcc.Text = wsemail.Bcc;         

            this.ScnMailTo.Focus();

            this.ShowDialog();
        }

        private void ScnAttachments_DoubleClick(object sender, EventArgs e)
        {
            Attachment_Click();
        }

        private void BtnViewAttachment_Click(object sender, EventArgs e)
        {
            Attachment_Click();
        }

        private void Attachment_Click()
        {
            oSession.Shellexec(this.ScnAttachments.Text);
        }

        private void Wsbtnsearch2_Click(object sender, EventArgs e)
        {
            string lEmail = "";
            //DO FORM ffscontactemail NAME Fsearch TO lEmail
            this.ScnMailBcc.Text = lEmail;
        }

        private void Wsbtnsearch1_Click(object sender, EventArgs e)
        {
            string lEmail = "";
            //DO FORM ffscontactemail NAME Fsearch TO lEmail
            this.ScnMailCc.Text = lEmail;
        }

        private void BtnSearchEmail_Click(object sender, EventArgs e)
        {
            string lEmail = "";
            //DO FORM ffscontactemail NAME Fsearch TO lEmail
            this.ScnMailTo.Text = lEmail;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            object lMailTo, lSubject, lNotes, lAttachments, lCc, lBcc;

            if(LEN(ALLTRIM(this.ScnMailTo.Text)) == 0)
            {
                MESSAGEBOX("La destination doit être indiquée!", 0 + 16, "Envoi impossible");
                this.ScnMailTo.Focus();
            }
            else
            {
                lMailTo = this.ScnMailTo.Text;
                lSubject = this.ScnSubject.Text;
                lNotes = this.ScnNotes.Text;
                lAttachments = this.ScnAttachments.Text;
                lCc = this.ScnMailCc.Text;
                lBcc = this.ScnMailBcc.Text;
                if (!EMPTY(this.ScnAttachment1.Text))
                {
                    string vattach = ALLTRIM(this.ScnAttachment1.Text);
                    lAttachments = ALLTRIM(lAttachments.ToString()) + ";" + vattach;
                }
                if (!EMPTY(this.ScnAttachment2.Text))
                {
                    string vattach = ALLTRIM(this.ScnAttachment2.Text);
                    lAttachments = ALLTRIM(lAttachments.ToString()) + ";" + vattach;
                }
                if (!EMPTY(this.ScnAttachment3.Text))
                {
                    string vattach = ALLTRIM(this.ScnAttachment3.Text);
                    lAttachments = ALLTRIM(lAttachments.ToString()) + ";" + vattach;
                }

                //UPDATE wsemail SET dest_adr = lMailTo,;
                //subject = lSubject,;
                //notes = lNotes,;
                //attached = lAttachments,;
                //cc = lCc,;
                //bcc = lBcc;
                //WHERE wsemail.ident = THISFORM.MesgIdent

                //SELECT wsemail
                //= TABLEUPDATE(2,.T.)

                this.action = 1;

                ScnMailTo.Text = "";
                ScnSubject.Text = "";
                ScnNotes.Text = "";
                ScnAttachments.Text = "";
                ScnMailCc.Text = "";
                ScnMailBcc.Text = "";
                lMailTo = "";
                lSubject = "";
                lNotes = "";
                lAttachments = "";
                lCc = "";
                lBcc = "";

                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            int lconfirm;

            lconfirm = MESSAGEBOX(IIF(m0frch, "Annuler ce couriel ?", "Cancel this email ?"), 4 + 32 + 256, IIF(m0frch, "SVP, Confirmer", "Please confirm"));

            if(lconfirm == 6)
            {
                string DelQuery = $"DELETE FROM wsemail WHERE wsemail.ident = {this.MesgIdent}";

                //SELECT wsemail
                //= TABLEUPDATE(2,.T.)

                this.action = 3;
                this.Close();
            }
        }

        private bool Valid_TextBox(wscontrols.wstextbox textbox)
        {
            if (!EMPTY(textbox.Text))
            {
                if (!FILE(textbox.Text))
                {
                    MESSAGEBOX(IIF(m0frch, "Fichier non trouvé", "File not found"), 0 + 16, "");
                    return false;
                }
            }
            return true;
        }

        private void ScnAttachment1_Leave(object sender, EventArgs e)
        {
            Valid_TextBox(this.ScnAttachment1);
        }

        private void Wscommandbutton4_Click(object sender, EventArgs e)
        {

        }

        private void ScnAttachment2_Leave(object sender, EventArgs e)
        {
            Valid_TextBox(this.ScnAttachment2);
        }

        private void Wscommandbutton1_Click(object sender, EventArgs e)
        {

        }

        private void ScnAttachment3_Leave(object sender, EventArgs e)
        {
            Valid_TextBox(this.ScnAttachment3);
        }

        private void Wscommandbutton2_Click(object sender, EventArgs e)
        {

        }
    }
}