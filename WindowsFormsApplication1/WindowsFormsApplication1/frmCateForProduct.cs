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

namespace WindowsFormsApplication1
{
    public partial class frmCateForProduct : MetroFramework.Forms.MetroForm
    {
        Class1 cl = new Class1();
        private frmProduct frmAddpro = null;
        public frmCateForProduct(Form callingForm)
        {
            InitializeComponent();
            frmAddpro = callingForm as frmProduct;
        }

        private void frmCateForProduct_Load(object sender, EventArgs e)
        {
            showCate();
        }

        public void showCate()
        {

            string sql1 = "Select * from tblcate";
            cl.da = new MySqlDataAdapter(sql1, cl.cnn);
            DataTable dt = new DataTable();
            cl.da.Fill(dt);
            dgvCate.DataSource = dt;
            dgvCate.Columns[1].HeaderText = "កូដប្រភេទ";
            dgvCate.Columns[2].HeaderText = "ឈ្មោះប្រផេទទំនិញ";
            dgvCate.Columns[3].HeaderText = "បរិយាយប្រភេទទំនិញ";
            dgvCate.Columns[0].Visible = false;
            this.dgvCate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dgvCate_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgvCate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ////gets a collection that contains all the rows
                //frmProduct pro = new frmProduct();
                DataGridViewRow row = this.dgvCate.Rows[e.RowIndex];


                //Class1.cateName = row.Cells[2].Value.ToString();
                ////pro.caa = cateName;

                //pro.txtProductCate.Text = Class1.cateName;
                //// this.Close();
                //MessageBox.Show(Class1.cateName);
                string id = row.Cells[1].Value.ToString();
                this.frmAddpro.CategoryID = id;
                this.frmAddpro.Category = row.Cells[2].Value.ToString();
                this.Close();




            }

            //frmProduct pro = new frmProduct();
            //string dg = this.dgvCate.SelectedRows[1].Cells[0].Value.ToString();
            //pro.txtProductCate.Text = this.dgvCate.SelectedRows[1].Cells[0].Value.ToString();
            //MessageBox.Show(dg);


            
        }
    }
}
