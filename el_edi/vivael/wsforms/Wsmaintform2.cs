using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vivael.wscontrols;
using vivael.wsforms;
using static vivael.Globals;

namespace vivael
{
    public partial class wsmaintform2 : DataMenu, WsControl
    {
        [
        Category("Translation"),
        TypeConverter(typeof(WsControl)),
        Editor(typeof(WsControl), typeof(string)),
        Description("The english text of the title form.  You can enter an english text here.")
        ]
        public string Text_EN { get; set; }

        [
        Category("Translation"),
        TypeConverter(typeof(WsControl)),
        Editor(typeof(WsControl), typeof(string)),
        Description("The french text of the title form.  You can enter an french text here.")
        ]
        public string Text_FR { get; set; }

        public wsmaintform2()
        {
            InitializeComponent();
        }

        private void Wsmaintform2_Load(object sender, EventArgs e)
        {
        }

        public override void doAfter_nav()
        {
        }
    }
}
