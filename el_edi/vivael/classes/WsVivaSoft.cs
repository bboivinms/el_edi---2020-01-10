using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static vivael.Globals;

namespace vivael.classes
{
    class WsVivaSoft
    {
        int? IdPrice = 0;
        int verif_crlimit_lastid = 0;
        string Signature;
        object pocode = false;
        object pono = false;
        object limpression = false;
        int? IdProdInfo = null;
        decimal? co_pctg;
        decimal? eq_pctg;
        decimal? fa_pctg;
        decimal? en_pctg;
        decimal? ca_pctg;
        decimal? pl_pctg;
        decimal? co_min;
        decimal? eq_min;
        decimal? fa_min;
        decimal? en_min;
        decimal? ca_min;
        decimal? pl_min;
        string Imagesproduitsfolder;

        public WsVivaSoft()
        {

        }

        public void Init()
        {
            this.refresh_param();

            if (DIRECTORY(@"D:\VIVAEL\ImagesProduits"))
            {
                this.Imagesproduitsfolder = @"D:\VIVAEL\ImagesProduits\";
            }
            else if (DIRECTORY(@"V:\VIVAEL\ImagesProduits"))
            {
                this.Imagesproduitsfolder = @"V:\VIVAEL\ImagesProduits\";
            }
            else if (DIRECTORY(@"V:\ImagesProduits"))
            {
                this.Imagesproduitsfolder = @"V:\ImagesProduits\";
            }
            else if (DIRECTORY(@"c:\VivaEL\ImagesProduits"))
            {
                this.Imagesproduitsfolder = @"c:\VivaEL\ImagesProduits\";
            }
            else
            {
                this.Imagesproduitsfolder = "";
            }
        }

        public void refresh_param()
        {
            //*Refresh oVivaSoft.(company parameters) from wscie
            //*To be called before using them to have them uptodate

            data_wscie WsCie = new data_wscie();

            gQuery("SELECT * FROM wscie order by cie_id asc", WsCie, 0, 0, WsCie.isFoxpro);
            WsCie.LoadRow();

            if (WsCie.RECCOUNT() <= 0)
            {
                MESSAGEBOX("Undefined company parameters!", 0 + 16, "Major problem");
                return;
            }

            Signature = WsCie.Posignature;
            IdPrice = WsCie.Idprice;
            IdProdInfo = WsCie.Idprodinfo;
            co_pctg = WsCie.Co_Pctg;
            eq_pctg = WsCie.Eq_Pctg;
            fa_pctg = WsCie.Fa_Pctg;
            en_pctg = WsCie.En_Pctg;
            ca_pctg = WsCie.Ca_Pctg;
            pl_pctg = WsCie.Pl_Pctg;

            co_min = WsCie.Co_Min;
            eq_min = WsCie.Eq_Min;
            fa_min = WsCie.Fa_Min;
            en_min = WsCie.En_Min;
            ca_min = WsCie.Ca_Min;
            pl_min = WsCie.Pl_Min;
        }
    }
}
