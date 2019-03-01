using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace WindowsFormsApplication1
    
{
    public class SQLCON
    {
      // public MySqlConnection cnn = new MySqlConnection("Server=192.168.0.8;Database=cc;Uid=root;Pwd=123;Encrypt=true;");
        public static MySqlConnection cnn = new MySqlConnection();
        public static MySqlCommand cmd = new MySqlCommand();
        public static MySqlDataAdapter da = new MySqlDataAdapter();
        public static DataSet dsa = new DataSet();

        public static string rielExchange;
        
        public static string sql="";
        public static bool add;
        public static bool update;
        public static MySqlDataReader dr;
        public static string id;
        public static string cateID;
        public static string codeItem;
        public static string reportName;
        public static string reportPath = @"\Reports\";
        ReportDocument crystalReport = new ReportDocument();
        CrystalReportViewer cryViewer = new CrystalReportViewer();

        public static void openConn()
        {
            
            try 
	            {
                    //cnn.Close();
                    

                    cnn.ConnectionString = @"Server=192.168.0.8;Database=cc;Uid=root;Pwd=123;Encrypt=true;charset=utf8;";
                    //cnn.Open();

                    if (cnn.State == ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                    
                        cnn.Open();
                   
	            }
	            catch (Exception)
	            {
		
		           MessageBox.Show("The system failed to establish a connection", "Database Settings");
	            }
            


           
        }

        public void crysReportView(string reportName,  DataSet dsCrystal, CrystalReportViewer crystalReportViewer)
        {
            
            crystalReport.Load(Application.StartupPath + reportPath + reportName +".rpt");
            crystalReport.SetDataSource(dsCrystal);
            crystalReportViewer.ReportSource = crystalReport;
            //crystalReport.PrintToPrinter(1, true, 0, 0);            // auto print
            crystalReportViewer.RefreshReport();
        }

    }
}
