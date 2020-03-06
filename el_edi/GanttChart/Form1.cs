using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vivael.wscontrols;
using static vivael.Globals;
using vivael;
using static EDI_DB.Data.Base;
//  **************************  
//  lien avec projet vivael
//  using
//
//  tableau sur 3 lignes
//  Base de donnée aempprod Pour Horaire pour la nouvelle ligne 4 employés possibles
//  
//  requete lesrec avec prplanif pour machine job - ligne 1
//  requete lesrec setup ou prod - ligne 2 
//  **************************
namespace vivael
{
    public partial class Form1 : Form
    {
        public object wprno, wcode, wqte;
        private string vnomach, vnomach2, qteprod, vmois;
        private int vidmach, vidmach2, vdeb, vfin, vid;
        private int tothremp, qtrste, v1, vjrs, idfo;
        private int totep, totepn, tot, djour, totjour;
        private decimal Totalhrs, tothrs, totetape, hrstrans;
        private int SW3, tjour, nhrs, tim, jour, nbrj;
        private decimal hrsrestejour, totestime, hrs, tottmp;
        private decimal var1, var2, thrs, tothrst, vjo;
        private DateTime date_estime, vdateest;
        // private data_arclient arclient = new data_arclient();
        private DataSource lesrec = new DataSource();
        private DataSource lesemp = new DataSource();
        private DataSource cur_employe = new DataSource();
        private DataSource cur_mach = new DataSource();
        private DataSource lespla = new DataSource();
        private bool SelectOnEntry;
        private int DataSessionId;
        TextBox txtLog;

        GanttChart ganttChart2;


        public Form1()
        {
            InitializeComponent();
            lesrec.isFoxpro = true;
            lesemp.isFoxpro = true;
            cur_employe.isFoxpro = true;
            cur_mach.isFoxpro = true;
            lespla.isFoxpro = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SaveImageToolStripMenuItem.Click += new EventHandler(SaveImageToolStripMenuItem_Click);

            txtLog = new TextBox();
            txtLog.Dock = DockStyle.Fill;
            txtLog.Multiline = true;
            txtLog.Enabled = false;
            txtLog.ScrollBars = ScrollBars.Horizontal;
            tableLayoutPanel1.Controls.Add(txtLog, 0, 1);

            //Second Gantt Chart
            ganttChart2 = new GanttChart();
            ganttChart2.Dock = DockStyle.Fill;
            ganttChart2.AllowChange = true;
            ganttChart2.AllowManualEditBar = true;
            ganttChart2.FromDate = new DateTime(2020, 02, 17, 4, 0, 0);
            ganttChart2.ToDate = new DateTime(2020, 02, 17, 23, 59, 0);
            tableLayoutPanel1.Controls.Add(ganttChart2, 0, 2);

            ganttChart2.MouseMove += new MouseEventHandler(ganttChart2.GanttChart_MouseMove);
            ganttChart2.MouseMove += new MouseEventHandler(GanttChart2_MouseMove);
            ganttChart2.MouseDragged += new MouseEventHandler(ganttChart2.GanttChart_MouseDragged);
            ganttChart2.MouseLeave += new EventHandler(ganttChart2.GanttChart_MouseLeave);
            ganttChart2.BarChanged += new EventHandler(ganttChart2_BarChanged);
            ganttChart2.ContextMenuStrip = ContextMenuGanttChart1;


            this.GET_DATA("JET", 21, 0);
            this.GET_DATA("102", 1, 3);
            this.GET_DATA("527", 2, 6);
            this.GET_DATA("326", 6, 9);
            this.GET_DATA("HP-1", 10, 12);
            this.GET_DATA("LATEX", 23, 15);

            /*
            List<BarInformation> lst2 = new List<BarInformation>();

            Random rand = new Random();
            int numberOfRowsToAdd = rand.Next(1, 100);

            // for (int i = 0; i <= numberOfRowsToAdd; i++)
            for (int i = 0; i <= 2; i++)
            {
                int startHour = rand.Next(17, 21);
                int endHour = rand.Next(startHour, 21);
                int startMinute = rand.Next(1, 59);
                int endMinute = rand.Next(startMinute, 59);

                if (startHour == 0) startHour = 17;
                if (endHour == 0) endHour = 21;

                if (startHour == endHour)
                {
                    if (startHour == 17)
                    {
                        endHour += 1;
                    }
                    else
                    {
                        startHour -= 1;
                    }
                }

                if (endHour >= 22)
                {
                    endHour = 22;
                    endMinute = rand.Next(1, 59);
                }


                /*
                if (i == 0)
                {
                    lst2.Add(new BarInformation(this.vnomach , new DateTime(2019, 12, 24, startHour, startMinute, 0), new DateTime(2019, 12, 24, endHour, endMinute, 0), Color.Khaki, Color.Khaki, i));
                }
                if (i == 1)
                {
                    lst2.Add(new BarInformation("Setup ", new DateTime(2019, 12, 24, startHour, startMinute, 0), new DateTime(2019, 12, 24, endHour, endMinute, 0), Color.Maroon, Color.Khaki, i));
                }
                if (i == 2)
                {
                    lst2.Add(new BarInformation("EMP " , new DateTime(2019, 12, 24, startHour, startMinute, 0), new DateTime(2019, 12, 24, endHour, endMinute, 0), Color.Maroon, Color.Khaki, i));
                }
            }
            foreach (BarInformation bar in lst2)
            {
                //ganttChart2.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
               // ganttChart2.AddChartBar(bar.RowText, bar, bar.FromTime.AddHours(3), bar.ToTime.AddHours(3), Color.AliceBlue, bar.HoverColor, bar.Index);
            }*/

        }

        private void GET_DATA(string pvnomach = "JET", int pvidmach = 21, int start = 0)
        {
           
            this.vnomach = pvnomach;
            this.vidmach = pvidmach;

            this.CALCUL_CH();

            string q = $@"SELECT  DISTINCT prplanif.*, prprod.prinfographie,prprod.prdate_approb, space(5) as AffInfo, space(5) as AffInv,prprod.idprod,prprod.qtettprod, prprod.qte as qteproduction,
               space(2) as AffEtape, .T.AS Tkit, prdetprod.statut,prdetprod.ordre as ordreEtape,prprod.rush AS RUSH2,prprod.DATEprevu,prprod.papier_recu,prdate_recep,prdate_envoie,
	          .T. as TEtapea0,IIF(prprod.prreq_date < DATE(),.T.,.F.) as Tretard,prdetprod.estime,ivxenprod.fengauche, ivxenprod.fengauche2,ivxenprod.fenbas,
               ivxenprod.fenbas2, ivxenprod.fenhaut, ivxenprod.fenhaut2,ivxenprod.fenlarge,ivxenprod.fenlarge2,ivprod.pms1,ivprod.pms2,ivprod.pms3,ivprod.pms4,
               prdetprod.setup,ivxenprod.construct, ivxenprod.format,fffomach.hrsprod,IIF(prprod.qtettprod > prprod.qte, 0000000, prprod.qte - prprod.qtettprod) as reste,
               ivxenprod.papier,ivxenprod.poids,ivprod.ac_lst_cost AS derniercout, ivprod.dern_ven, 00000000000.00 AS cm, fffomach.cout_moyen,prdetprod.IDENT AS machineid2,
               prdetprod.lastfab, 000 AS JRS, prprod.cr_by, prprod.cr_dtet,.F. as Tdaterr,.F. as Tdategal,.F. as TdateP,.F. as TENV
               FROM prplanif
               LEFT OUTER JOIN prprod
               ON prplanif.prno = prprod.prno
               LEFT OUTER JOIN prdetprod
               ON prplanif.prno = prdetprod.idfab AND {this.vidmach} = prdetprod.idmach
               LEFT OUTER JOIN ivprod ON ivprod.ident = prprod.idprod
               LEFT OUTER JOIN ivxenprod ON ivxenprod.idprod = prprod.idprod
               LEFT OUTER JOIN fffomach ON fffomach.ident = prdetprod.idmach
               WHERE {gQ1(this.vnomach)} = prplanif.nomach AND prplanif.idnomach = {this.vidmach} AND PRDETPROD.statut <> 'T'
               ORDER BY prplanif.ordre ";


            gQuery(q, lesrec, 0, 0, lesrec.isFoxpro);

            List<BarInformation> lst2 = new List<BarInformation>();

            vdeb = 4;
            vfin = 6;

            DateTime dvdeb = new DateTime(2020, 02, 17, vdeb, 0, 0);
            // DateTime dvdeb = DateTime.Today;
            DateTime dvfin;

            foreach (IDataRecord RAPPORT in lesrec.result)
            {
                if (vdeb >= 24) break;
                {
                    qteprod = RAPPORT["qteproduction"].ToString();
                    dvfin = dvdeb.AddHours(GetDouble(RAPPORT["temps"].ToString()));
                    lst2.Add(new BarInformation(32, RAPPORT, this.vnomach, RAPPORT["prno"].ToString() + NL + RAPPORT["item"].ToString(), dvdeb, dvfin, Color.Blue, Color.Yellow, 0 + start));
                    lst2.Add(new BarInformation(16, RAPPORT, "Setup " + this.vnomach, RAPPORT["setup"].ToString(), dvdeb, dvfin, Color.LightGreen, Color.Yellow, 1 + start));
                    dvdeb = dvfin;

                    // vdeb = vdeb + 2;
                    // vfin = vfin + 2;
                }
            }

            // phase 2
            // machine Par defaut, where, relation avec la job pour la durée, pour 4 employés
            // modifier le lst2 pour rapport2, 

            q = $@"SELECT aempha.*, aempprod.no, aempprod.nom, aempprod.luhrsd, aempprod.luhrsf, aempprod.lurepd, aempprod.lurepf,
                          aempprod.mahrsd, aempprod.mahrsf, aempprod.marepd, aempprod.marepf, aempprod.mehrsd, aempprod.mehrsf, aempprod.merepd, aempprod.merepf,
                          aempprod.jehrsd, aempprod.jehrsf, aempprod.jerepd, aempprod.jerepf, aempprod.vehrsd, aempprod.vehrsf, aempprod.verepd, aempprod.verepf, 
                          aempprod.sahrsd, aempprod.sahrsf, aempprod.sarepd, aempprod.sarepf, aempprod.dihrsd, aempprod.dihrsf, aempprod.direpd, aempprod.direpf
                   FROM aempha
                   LEFT OUTER JOIN aempprod ON aempprod.ident = aempha.idemp
                   LEFT OUTER JOIN fffomach ON fffomach.ident = aempprod.machdef1 or fffomach.ident = aempprod.machdef2 or fffomach.ident = aempprod.machdef3
                   where aempprod.machdef1={this.vidmach}
                   order by aempha.ident ";

            gQuery(q, lesemp, 0, 0, lesemp.isFoxpro);

            vdeb = 4;
            vfin = 6;

            dvdeb = new DateTime(2020, 02, 17, vdeb, 0, 0);

            if (lesemp.result != null)
            {
                foreach (IDataRecord RAPPORT2 in lesemp.result)
                {
                    dvfin = dvdeb.AddHours(2);

                    lst2.Add(new BarInformation(16, RAPPORT2, "Employé " + this.vnomach, RAPPORT2["nom"].ToString(), dvdeb, dvfin, Color.Coral, Color.Yellow, 2 + start));
                    dvdeb = dvfin;
                }
            }


            //lst2.Add(new BarInformation(this.vnomach, lesrec.result[0]["prno"].ToString() + NL + lesrec.result[0]["item"].ToString(), new DateTime(2019, 12, 24, 10, 30, 0), new DateTime(2019, 12, 24, 12, 30, 0), Color.Maroon, Color.Maroon, 0));
            //lst2.Add(new BarInformation(this.vnomach, lesrec.result[1]["prno"].ToString() + NL + lesrec.result[1]["item"].ToString(), new DateTime(2019, 12, 24, 10, 30, 0).AddHours(1), new DateTime(2019, 12, 24, 12, 30, 0).AddHours(1), Color.Maroon, Color.Maroon, 0));
            //lst2.Add(new BarInformation("Setup", lesrec.result[0]["setup"].ToString(), new DateTime(2019, 12, 24, 10, 30, 0), new DateTime(2019, 12, 24, 12, 30, 0), Color.Blue, Color.Blue, 1));
            //lst2.Add(new BarInformation("Employé", lesrec.result[0]["cr_by"].ToString(), new DateTime(2019, 12, 24, 10, 30, 0), new DateTime(2019, 12, 24, 12, 30, 0), Color.Khaki, Color.Khaki, 2));

            // lst2.Add(new BarInformation(this.vnomach, lesrec.result[0]["prno"].ToString(), new DateTime(2019, 12, 24, 13, 30, 0), new DateTime(2019, 12, 24, 15, 30, 0), Color.Khaki, Color.Khaki, 0));

            foreach (BarInformation bar in lst2)
            {
                ganttChart2.AddChartBar(bar.RowHeight, bar.RowText, bar.InnerText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
                // ganttChart2.AddChartBar(bar.RowText, bar.InnerText, bar, bar.FromTime.AddHours(1), bar.ToTime.AddHours(1), Color.Red, Color.Red, bar.Index);
                // ganttChart2.AddChartBar(bar.RowText, bar, bar.FromTime.AddHours(3), bar.ToTime.AddHours(3), Color.AliceBlue, bar.HoverColor, bar.Index);
            }

            this.Refresh();
        }
        private void GanttChart1_MouseMove(Object sender, MouseEventArgs e)
        {
            List<string> toolTipText = new List<string>();
        }


        private void CALCUL_CH()
        {
            this.idfo = 0;
            string r = $@"SELECT SUM(aempprod.nbrhrs) as tothrsemp
                         from aempprod
                         WHERE aempprod.AJUSTEUR = .T. AND aempprod.inactif = .F. ";

            gQuery(r, cur_employe, 0, 0, cur_employe.isFoxpro);

            if (lesemp.result != null)
            {
                int tothrsemp = CINT(cur_employe.result[0]["tothrsemp"]) * 10;
            }

            r = $@"SELECT fffomach.idsupp, fffomach.nomach, fffomach.desc,
                          00000 as etapep, 00000 as etapenp, CTOD('') as datee, SPACE(15) AS CADATE,
                          000000 as totetape, 000 as jrsouv, 0000.00 as tothrest,
                          fffomach.hrsprod, fffomach.typemach, fffomach.ident, apsupp.name
                          FROM fffomach
                          LEFT OUTER JOIN apsupp ON apsupp.ident = fffomach.idsupp
                          WHERE {this.idfo} = 0 OR {this.idfo}= fffomach.idsupp
                          ORDER BY fffomach.idsupp DESC ";

            
            gQuery(r, cur_mach, 0, 0, cur_mach.isFoxpro);

            DataTable dt_cur_mach = cur_mach.ds.Tables[0];
            
            qtrste = 0;
            tothrst = 0;
            totep = 0;
            totepn = 0;
            tot = 0;

            foreach (DataRow RAPPORT3 in dt_cur_mach.Rows)
            {
                vid = CINT(RAPPORT3["ident"]);
                r = $@"SELECT DISTINCT prplanif.*, prprod.prinfographie,prprod.prdate_approb,' ' as AffInfo,'  ' as AffInv,prprod.idprod,prprod.qtettprod, prprod.qte as qteproduction,
                        '  ' as AffEtape, .T. AS Tkit, prdetprod.statut,prdetprod.ordre as ordreEtape,
                         prdate_recep,prdate_envoie,.T. as TEtapea0,IIF(prprod.prreq_date < DATE(),.T.,.F.) as Tretard,prdetprod.estime,
                         ivxenprod.fengauche, ivxenprod.fengauche2, ivxenprod.fenbas,ivxenprod.fenbas2, ivxenprod.fenhaut, ivxenprod.fenhaut2,
                         ivxenprod.fenlarge,ivxenprod.fenlarge2,ivprod.pms1,ivprod.pms2,ivprod.pms3,ivprod.pms4,prdetprod.setup,
                         ivxenprod.construct, ivxenprod.format,fffomach.hrsprod,IIF(prprod.qtettprod > prprod.qte, 0000000, prprod.qte - prprod.qtettprod) as reste,
                         ivxenprod.papier,ivxenprod.poids,ivprod.ac_lst_cost AS derniercout, ivprod.dern_ven, 00000000000.00 AS cm, fffomach.cout_moyen,prdetprod.IDENT AS machineid2,prdetprod.lastfab
                         FROM prplanif
                         LEFT OUTER JOIN prprod
                         ON prplanif.prno = prprod.prno
                         LEFT OUTER JOIN prdetprod
                         ON prplanif.prno = prdetprod.idfab AND {vid} = prdetprod.idmach
                         LEFT OUTER JOIN ivprod
                         ON ivprod.ident = prprod.idprod
                         LEFT OUTER JOIN ivxenprod
                         ON ivxenprod.idprod = prprod.idprod
                         LEFT OUTER JOIN fffomach
                         ON fffomach.ident = prdetprod.idmach
                         WHERE prplanif.idnomach = {vid} AND PRDETPROD.statut <> 'T'
                         ORDER BY prplanif.ordre ";


                gQuery(r, lespla, 0, 0, lespla.isFoxpro);


                if (lespla.result == null)
                {
                   // gMsgBox("ERROR, Query empty: lespla.result");
                }
                else
                {
                    DataTable dt_lespla = lespla.ds.Tables[0];
                    totestime = 0;

                    foreach (DataRow RAPPORT4 in dt_lespla.Rows)
                    {
                        if (RAPPORT4["qteproduction"] == null)
                        {
                            RAPPORT4["qteproduction"] = 0;
                        }

                        RAPPORT4["qte"] = RAPPORT4["qteproduction"];
                        qtrste = CINT(RAPPORT4["reste"]);
                        RAPPORT4["qte_restan"] = qtrste;

                        if (CINT(RAPPORT4["qte_restan"]) > 0 && CINT(RAPPORT4["estime"]) > 0)
                        {
                            totestime = (CINT(RAPPORT4["qte_restan"]) / CINT(RAPPORT4["estime"]) * 60) + CINT(RAPPORT4["setup"]) / 60;
                            RAPPORT4["temps"] = totestime;
                        }
                    }

                    //    *** date estimé
                    vjo = 0;

                    this.vidmach2 = CINT(RAPPORT3["ident"]);
                    this.vnomach2 = RAPPORT3["nomach"].ToString();

                    this.DATEEST(RAPPORT3);


                    RAPPORT3["datee"] = vdateest;

                    vjrs= DAY(vdateest);
                    vmois= CMONTH(vdateest); 
                    vmois = STR(vjrs) + " " + vmois;
                    thrs = 0;
                    RAPPORT3["cadate"] = vmois;

                    //    ***** Calcul

                    foreach (DataRow RAPPORT4 in dt_lespla.Rows)
                    {
                       if (CINT(RAPPORT4["idNOmach"]) == CINT(RAPPORT3["ident"]))
                        {
                            thrs += CDEC(RAPPORT4["temps"]);
                        }
                       // SELECT SUM(lespla["temps"]) as tthrs FROM lesrec0 WHERE lesrec0.idNOmach = cur_mach.ident "

                    }
                    //             STORE vhrs.tthrs TO thrs


                    tothrst += thrs;
                    RAPPORT3["tothrest"]=thrs; 
                    RAPPORT3["totetape"]=v1;  
                    if (CDEC(RAPPORT3["hrsprod"]) != 0)
                    {
                        vjo = CDEC(RAPPORT3["tothrest"]) / CDEC(RAPPORT3["hrsprod"]);
                        if (vjo > INT(vjo))
                        {
                            vjo = INT(vjo) + 1;
                        }
                    }
                    RAPPORT3["jrsouv"] = vjo;
                }
            }
        }


        private void DATEEST(DataRow RAPPORT3)
        {
            decimal x = 0;
            int JOURNEE = DOW(DATE());
            djour = 0;

            if (JOURNEE == 2)  // 'Monday'
            {
                djour = 5;
            }
            if (JOURNEE == 3) // 'Tuesday'
            {
                djour = 4;
            }
            if (JOURNEE == 4)  // 'Wednesday'
            {
                djour = 3;
            }
            if (JOURNEE == 5)  // 'Thursday'
            {
                djour = 2;
            }
            if (JOURNEE == 6)  // 'Friday'
            {
                djour = 1;
            }

            totjour = djour;
            date_estime = DATE();

            //* cur_mach.hrsprod = thisform.vhrsprod

            //* **********************************************************************
            this.vnomach2 = RAPPORT3["nomach"].ToString();
            vid = CINT(RAPPORT3["ident"]);
            //string r = $@"SELECT DISTINCT prplanif.*, prprod.prinfographie,prprod.prdate_approb,'  ' as AffInfo,'  ' as AffInv,prprod.idprod,prprod.qtettprod, prprod.qte as qteproduction,
            //      '  ' as AffEtape, .T. AS Tkit, prdetprod.statut,prdetprod.ordre as ordreEtape,
            //      prdate_recep,prdate_envoie,.T. as TEtapea0,IIF(prprod.prreq_date < DATE(),.T.,.F.) as Tretard,prdetprod.estime,
            //      ivxenprod.fengauche, ivxenprod.fengauche2, ivxenprod.fenbas,ivxenprod.fenbas2, ivxenprod.fenhaut, ivxenprod.fenhaut2,
            //      ivxenprod.fenlarge,ivxenprod.fenlarge2,ivprod.pms1,ivprod.pms2,ivprod.pms3,ivprod.pms4,prdetprod.setup,
            //      ivxenprod.construct, ivxenprod.format,fffomach.hrsprod,IIF(prprod.qtettprod > prprod.qte, 0000000, prprod.qte - prprod.qtettprod) as reste,
            //      ivxenprod.papier,ivxenprod.poids,ivprod.ac_lst_cost AS derniercout, ivprod.dern_ven, 00000000000.00 AS cm, fffomach.cout_moyen,prdetprod.IDENT AS machineid2,prdetprod.lastfab
            //      FROM prplanif
            //      LEFT OUTER JOIN prprod
            //      ON prplanif.prno = prprod.prno
            //      LEFT OUTER JOIN prdetprod
            //      ON prplanif.prno = prdetprod.idfab AND {vid} = prdetprod.idmach
            //      LEFT OUTER JOIN ivprod
            //      ON ivprod.ident = prprod.idprod
            //      LEFT OUTER JOIN ivxenprod
            //      ON ivxenprod.idprod = prprod.idprod
            //      LEFT OUTER JOIN fffomach
            //      ON fffomach.ident = prdetprod.idmach
            //      WHERE {this.vnomach2} = prplanif.nomach AND prplanif.idnomach = {vid}
            //      ORDER BY prplanif.ordre";
            
            string r = $@"SELECT DISTINCT prplanif.*, prprod.prinfographie,prprod.prdate_approb,' ' as AffInfo,'  ' as AffInv,prprod.idprod,prprod.qtettprod, prprod.qte as qteproduction,
                        '  ' as AffEtape, .T. AS Tkit, prdetprod.statut,prdetprod.ordre as ordreEtape,
                         prdate_recep,prdate_envoie,.T. as TEtapea0,IIF(prprod.prreq_date < DATE(),.T.,.F.) as Tretard,prdetprod.estime,
                         ivxenprod.fengauche, ivxenprod.fengauche2, ivxenprod.fenbas,ivxenprod.fenbas2, ivxenprod.fenhaut, ivxenprod.fenhaut2,
                         ivxenprod.fenlarge,ivxenprod.fenlarge2,ivprod.pms1,ivprod.pms2,ivprod.pms3,ivprod.pms4,prdetprod.setup,
                         ivxenprod.construct, ivxenprod.format,fffomach.hrsprod,IIF(prprod.qtettprod > prprod.qte, 0000000, prprod.qte - prprod.qtettprod) as reste,
                         ivxenprod.papier,ivxenprod.poids,ivprod.ac_lst_cost AS derniercout, ivprod.dern_ven, 00000000000.00 AS cm, fffomach.cout_moyen,prdetprod.IDENT AS machineid2,prdetprod.lastfab
                         FROM prplanif
                         LEFT OUTER JOIN prprod
                         ON prplanif.prno = prprod.prno
                         LEFT OUTER JOIN prdetprod
                         ON prplanif.prno = prdetprod.idfab AND {vid} = prdetprod.idmach
                         LEFT OUTER JOIN ivprod
                         ON ivprod.ident = prprod.idprod
                         LEFT OUTER JOIN ivxenprod
                         ON ivxenprod.idprod = prprod.idprod
                         LEFT OUTER JOIN fffomach
                         ON fffomach.ident = prdetprod.idmach
                          WHERE prplanif.idnomach = {vid} 
                         ORDER BY prplanif.ordre ";

            gQuery(r, lesrec, 0, 0, lesrec.isFoxpro);

            DataTable dt_lesrec = lesrec.ds.Tables[0];

            Totalhrs = 0;
            tothrs = 0;
            hrsrestejour = 0;
            totetape = 0;
            SW3 = 0;
            tjour = 0;

            hrs = HOUR(DATETIME()) - 7;
            tim = CINT(SUBSTR(TIME(DATETIME()), 4, 2));
            tim /= 60;
            hrs += tim;
            nhrs = 0;
            hrsrestejour = CDEC(RAPPORT3["hrsprod"]) - hrs;

            foreach (DataRow dr_lesrec in dt_lesrec.Rows)
            {

                if (RAPPORT3["hrsprod"] == null)
                {
                    tottmp = 0;
                }
                else
                {
                    tottmp = CDEC(RAPPORT3["hrsprod"]);
                    jour = 0;
                    if (CDEC(RAPPORT3["hrsprod"]) != 0)
                    {
                        if (CDEC(dr_lesrec["temps"]) == 0)
                        {
                            nhrs = 1;
                        }
                        if (CDEC(dr_lesrec["temps"]) + Totalhrs < CDEC(RAPPORT3["hrsprod"]) - hrs)
                        {
                            Totalhrs = Totalhrs + CDEC(dr_lesrec["temps"]);
                            hrstrans = 0;
                            hrsrestejour = CDEC(RAPPORT3["hrsprod"]) - Totalhrs;
                            if (CDEC(dr_lesrec["temps"]) != 0)
                            {
                                dr_lesrec["date_plani"] = date_estime;
                            }
                            jour = 0;
                            nbrj = 0;
                        }
                        else
                            hrs = 0;
                        var1 = 0;
                        var2 = 0;
                        var1 = CDEC(dr_lesrec["temps"]) - hrsrestejour;
                        var2 = INT(var1) / CDEC(RAPPORT3["hrsprod"]);
                        jour = INT(var2) + 1;
                        hrstrans = CDEC(dr_lesrec["temps"]) - ((INT(var2) * CDEC(RAPPORT3["hrsprod"]) + hrsrestejour));
                        Totalhrs = hrstrans;
                        hrsrestejour = CDEC(RAPPORT3["hrsprod"]) - hrstrans;
                        nbrj = jour;
                        JOURNEE = DOW(date_estime);
                        if (JOURNEE == 2)     // 'Monday' OR JOURNEE = 'Lundi'
                        {
                            if (jour > 5)
                            {
                                nbrj = jour + 2;
                            }
                        }
                        if (JOURNEE == 3)   // 'Tuesday' OR JOURNEE = 'Mardi'
                        { 
                           if (jour > 4)
                           {
                              nbrj = jour + 2;
                           }
                        }
                        if (JOURNEE == 4)    // 'Wednesday' OR JOURNEE = 'Mercredi'
                        { 
                            if (jour > 3)
                            {
                               nbrj = jour + 2;
                            }
                        }
                        if (JOURNEE == 5)      // 'Thursday' OR JOURNEE = 'Jeudi'
                        {
                           if (jour > 2)
                           {
                              nbrj = jour + 2;
                           }
                        }
                        if (JOURNEE == 6) // 'Friday' OR JOURNEE = 'Vendredi'
                        { 
                            if (jour > 1)
                            {
                               nbrj = jour + 2;
                            }
                        }
                    }
                    djour = 0;
                    date_estime = date_estime.AddDays(nbrj);
                    if (nhrs == 0)
                    {
                    JOURNEE = DOW(date_estime);

                        if (JOURNEE == 1)   // 'Saturday' OR JOURNEE = 'Samedi'
                        {
                                date_estime = date_estime.AddDays(2); 
                        }
                        if (JOURNEE == 7)   // 'Sunday' OR JOURNEE = 'Dimanche'
                        {
                                date_estime = date_estime.AddDays(2);
                        }
                        dr_lesrec["date_plani"] = date_estime;
                    }
                    else
                    {
                        dr_lesrec["date_plani"] = "";
                    }
                    if (CINT(dr_lesrec["ordre"]) == 9999)
                    {
                        dr_lesrec["date_plani"] = "";
                    }
                }

                x = CDEC(dr_lesrec["temps"]);

            }
           
            tothrs = tothrs + x;
            totetape = totetape + 1;

            vdateest = date_estime;
            
         }

        private void GanttChart2_MouseMove(Object sender, MouseEventArgs e)
        {
            try
            { 
                List<string> toolTipText = new List<string>();

                if (ganttChart2.MouseOverRowText != null && ganttChart2.MouseOverRowText != "" && ganttChart2.MouseOverRowValue != null)
                {
                    object obj = ganttChart2.MouseOverRowValue;
                    string typ = obj.GetType().ToString();
                    if (typ.ToLower().Contains("barinformation"))
                    {
                        BarInformation val = (BarInformation)ganttChart2.MouseOverRowValue;
                        // toolTipText.Add("[b]Time:");
                        toolTipText.Add("No de production: " + val.RowData["prno"].ToString());
                        toolTipText.Add("No produit: " + val.RowData["item"].ToString());
                        toolTipText.Add("From " + val.FromTime.ToString("HH:mm"));
                        toolTipText.Add("To " + val.ToTime.ToString("HH:mm"));
                        toolTipText.Add("Temps estimé: " + val.RowData["temps"].ToString());
                        toolTipText.Add("Quantité a produire: "+val.RowData["qteproduction"].ToString());
                        toolTipText.Add("Quantité total produite: " + val.RowData["qtettprod"].ToString());
                    }
                    else if (typ.ToLower() == "string")
                    {
                        toolTipText.Add(ganttChart2.MouseOverRowValue.ToString());
                    }
                }
                else
                {
                    toolTipText.Add("");
                }

                ganttChart2.ToolTipTextTitle = ganttChart2.MouseOverRowText;
                ganttChart2.ToolTipText = toolTipText;
            }
            catch(Exception Ex)
            {
                string X = Ex.ToString();
            }
        }

        private void ganttChart2_BarChanged(object sender, EventArgs e)
        {
            BarInformation b = sender as BarInformation;
            txtLog.Text += String.Format("\r\n{0} has changed", b.RowText);
        }

        private void SaveImageToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            Control chart = null;
            if (menuItem != null)
            {
                ContextMenuStrip calendarMenu = menuItem.Owner as ContextMenuStrip;

                if (calendarMenu != null)
                {
                    chart = calendarMenu.SourceControl;
                }
            }

            SaveImage(chart);
        }

        private void SaveImage(Control control)
        {
            GanttChart gantt = control as GanttChart;
            string filePath = Interaction.InputBox("Where to save the file?", "Save image", "C:\\Temp\\GanttChartTester.jpg");
            if (filePath.Length == 0)
                return;
            gantt.SaveImage(filePath);
            Interaction.MsgBox("Picture saved", MsgBoxStyle.Information);
        }

    }
}
