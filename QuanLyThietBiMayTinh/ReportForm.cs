using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThietBiMayTinh
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void MatHangReport_Load(object sender, EventArgs e)
        {
        }
        public void showReport(string rpfileName, string rpFilter="", string rptitle="")
        {
            //1.Nạp report
            ReportDocument rpt = new ReportDocument();
            string path = string.Format("{0}\\Reports\\{1}", Application.StartupPath, rpfileName);
            rpt.Load(path);
            //2.cập nhật nguồn dữ liệu
            TableLogOnInfo logOnInfo = new TableLogOnInfo();
            logOnInfo.ConnectionInfo.ServerName = ".\\SQLEXPRESS";
            logOnInfo.ConnectionInfo.DatabaseName = "db_QuanLyHangHoa";

            foreach (Table t in rpt.Database.Tables)
                t.ApplyLogOnInfo(logOnInfo);
            //3.tác vụ
            if (!string.IsNullOrEmpty(rpFilter))
                rpt.RecordSelectionFormula = rpFilter;
            if (!string.IsNullOrEmpty(rptitle))
                rpt.SummaryInfo.ReportTitle = rptitle;
            //4.hiển thị
            crystalReportViewer1.ReportSource = rpt;
            
        }
    }
}
