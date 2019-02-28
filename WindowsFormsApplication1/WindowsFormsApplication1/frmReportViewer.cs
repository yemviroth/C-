using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices;
using CrystalDecisions;
namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public SQLCON cl = new SQLCON();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

           

         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //dsRpt ds = new dsRpt();
            //rpt cry = new rpt();
            //SQLCON.openConn();
            //SQLCON.sql = "Select * from tblcate";
            //SQLCON.cmd = new MySqlCommand(SQLCON.sql, SQLCON.cnn);
            //SQLCON.da = new MySqlDataAdapter(SQLCON.cmd);
            ////SQLCON.cmd.Parameters.AddWithValue(txtInvoiceNo.Text, "@invoiceNo");
            //DataTable dt = new DataTable();
            //SQLCON.da.Fill(ds.Tables[0]);
            //dt = ds.Tables[0];


            //cry.SetDataSource(ds.Tables[0]);
            //crystalReportViewer1.ReportSource = cry;
            //crystalReportViewer1.Refresh();
            //this.reportViewer1.RefreshReport();
            DataSet1 dsa = new DataSet1();

            //SQLCON.openConn();

            //SQLCON.sql = "Select * from tblcate";
            // SQLCON.cmd = new MySqlCommand("Select * from tblcate", SQLCON.cnn);
            SQLCON.da = new MySqlDataAdapter("Select * from tblcate", SQLCON.cnn);

            DataTable dt = new DataTable();
            SQLCON.da.Fill(dsa, "DataTable1");

            //dataGridView1.DataSource = dt;


            ReportDataSource rds = new ReportDataSource("DataSet1", dsa.Tables[0]);
            // this.reportViewer2.ProcessingMode = ProcessingMode.Local;
            this.reportViewer2.LocalReport.DataSources.Clear();
            this.reportViewer2.LocalReport.DataSources.Add(rds);
            this.reportViewer2.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer2.RefreshReport();


            ///////////// crystal
            //crystal cry = new crystal();
            //cry.SetDataSource(dsa.Tables[0]);
            //crystalReportViewer1.ReportSource = cry;
            //this.crystalReportViewer1.RefreshReport();

            

            //   Try
            //    Dim DS As New DataSet_cate
            //    Dim cnn As New MySqlConnection("Server=192.168.0.8;Database=pos;Uid=root;Pwd=12345678;")
            //    cnn.Open()
            //    Dim da As New MySqlDataAdapter("Select * From tbl_cate", cnn)
            //    da.Fill(DS.Tables(0))

            //    ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
            //    'ReportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\ReportName.rdp"
            //    ReportViewer1.LocalReport.ReportPath = "D:\My Document\Project\POS 03012017\POS\main\Form\_01_System\Report\rptCate.rdlc"
            //    ReportViewer1.LocalReport.DataSources.Clear()
            //    ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet_cate", DS.Tables(0)))
            //    ReportViewer1.DocumentMapCollapsed = True

            //    'parameter
            //    Dim printBy As New ReportParameter("printBy", fMain.stUser.Text)
            //    ReportViewer1.LocalReport.SetParameters(printBy)

            //    ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
            //    Me.ReportViewer1.RefreshReport()


            //Catch ex As Exception
            //    cnn.Close()
            //    MsgBox(ex.Message)
            //End Try
        }
  
    }
}
