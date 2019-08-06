using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vivael.forms
{
    public partial class ReportPreview : Form
    {

        public ReportPreview(ReportDocument reportDocuments)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = reportDocuments;
        }
    }
}
