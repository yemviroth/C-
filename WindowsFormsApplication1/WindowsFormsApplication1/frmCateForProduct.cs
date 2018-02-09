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

        public void dgvCate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ////gets a collection that contains all the rows
                //frmProduct pro = new frmProduct();
                DataGridViewRow row = this.dgvCate.Rows[e.RowIndex];

                string id = row.Cells[1].Value.ToString();
                this.frmAddpro.CategoryID = id;
                this.frmAddpro.Category = row.Cells[2].Value.ToString();

                //MessageBox.Show(id + "," + this.frmAddpro.Category);

                try
                {
                    cl.cnn.Open();
                    MySqlCommand cmd = new MySqlCommand("Select * From tblproduct Where cateID = @cateID Order By itemCode DESC Limit 1", cl.cnn);

                    cmd.Parameters.AddWithValue("@cateID", id);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dtch = new DataTable();
                    da.Fill(dtch);
                    if (dtch.Rows.Count == 0)
                    {
                        this.frmAddpro.proCode = id + "-0001";
                    }
                    else
                    {
                        Class1.dr = cmd.ExecuteReader();
                        while (Class1.dr.Read())
                        {
                            string itemCode = Class1.dr.GetString(1);
                            //this.frmAddpro.proCode = itemCode;
                            if (Class1.update == true)
                            {
                                if  (itemCode != Class1.id )
                                {
                                    String cut = itemCode.Substring(itemCode.Length - 3);
                                    int cutPlus = Convert.ToInt32(cut) + 1;
                                    this.frmAddpro.proCode = id + "-" + cutPlus.ToString("0000");
                                }
                                else
                                {
                                    this.frmAddpro.proCode = Class1.id;
                                }
                                
                            }
                            else
                            {
                                String cut = itemCode.Substring(itemCode.Length - 3);
                                int cutPlus = Convert.ToInt32(cut) + 1;
                                this.frmAddpro.proCode = id + "-" + cutPlus.ToString("0000");
                            }

                            
                        }
                       
                        
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                cl.cnn.Close();
                this.Close();
            }
        }
      
    }
}
