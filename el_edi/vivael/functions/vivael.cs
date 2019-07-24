using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vivael
{
    public partial class Globals
    {
        // Foxpro notes: 
        // - Please note that in foxpro, all variables are automatically boolean and set to false, until explicitly set
        // - The height of a form needs to be 30px bigger than foxpro form height since it includes the header portion that includes min/max/close buttons
        //
        // WinDev resserved Name = replacement Name
        // currency = rn_currency
        // Visible = rn_Visible

        static Globals() { }
        public Globals() { }

        public static int NULL_INT = -987654321;
        public static string CR = "\r\n";
        public static string Active = "Active";
        public static string Grayed = "Grayed";

        public static string gsUserName;
        public static DataSource gsdWsUser;
        public static string gsDatabase = "vivadata4";

        public static object no_version;
        public static bool m0frch;
        public static object m0flat;
        public static object m0xp;
        public static object m0xpxcheme;
        public static bool m0xpscheme; //ADDED_VARIABLE_KJ_2018_06_05 // KJ: 2018-10-03: Foxpro + GoFish: Never set to true
        public static object m07to8;
        public static object m0checkdb;

        public static WsSession oSession; // oSession = new wssession // automatically creates new

        public static object oReindexer;
        public static object oVivaSoft;
        public static object MySQL_lnHandle;
        public static object gidclient;
        public static object gmd5;
        public static object tv;
        public static object trfval;
        public static object loc;
        public static object idproduit;

        public static object wMyLog;
        public static object wMyErrorLog;
        public static object MySQLError;
        public static object MySQLExpectedCount;
        public static object mySQLActualCount;

        public static object wMyLog2;
        public static object wMyErrorLog2;
        public static object MySQLError2;
        public static object MySQLExpectedCount2;
        public static object mySQLActualCount2;
        public static object MySQL_lnHandle2;
        public static object glastattempt;
        public static object MYSQL_LNHANDLE_IS_BOOL2;
        public static object pArRep;
        public static object pArLimited;
        public static object lcDatabase;
        public static object iswebemail;
        public static object lcimp;
        public static object blcouriel;

        // gwsfield is array<growth=1> of wsfield // Should no longer be needed, was added in order to add properties to textbox in windev

        public static int gIPType = 0;

    }
}
