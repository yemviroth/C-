using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
   public partial class dash : MetroFramework.Forms.MetroForm
    //public partial class dash : Form
    {
        public Class1 cl = new Class1();
        public dash()
        {
            InitializeComponent();

        }

        private void metroTabPage3_Leave(object sender, EventArgs e)
        {
           
        }

        private void dash_Load(object sender, EventArgs e)
        {
            //showCate();
            //showProduct();
            //reOrderProduct();
            
        }

        private void reOrderProduct()
        {
            try
            {
                cl.cnn.Open();
                cl.sql = "Select * from tblproduct Where itemInstock <= itemReorderLevel ";
                cl.da = new MySqlDataAdapter(cl.sql, cl.cnn);
                DataTable dt = new DataTable();
                cl.da.Fill(dt);
                dgvReOrder.DataSource = dt;
                dgvReOrder.Columns[0].Visible = false;
                this.dgvReOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                var dgv = dgvReOrder;
                {
                    dgv.Columns[1].HeaderText = "កូដទំនិញ";
                    dgv.Columns[2].HeaderText = "ឈ្មោះទំនិញ";
                    dgv.Columns[3].HeaderText = "ឈ្មោះប្រភេទទំនិញ";
                    dgv.Columns[4].HeaderText = "តំលៃទិញចូល";
                    dgv.Columns[5].HeaderText = "តំលៃលក់";
                    dgv.Columns[6].HeaderText = "ថ្ងៃទិញចូល";
                    dgv.Columns[7].HeaderText = "ចំនួនក្នុងស្តុក";
                    dgv.Columns[8].HeaderText = "ទំនិញគិតជា";
                    dgv.Columns[9].HeaderText = "Reorder level";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            cl.cnn.Close();
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Class1.add = true;
            Class1.update = false;
            frmCategory frmCate = new frmCategory();
            frmCate.ShowDialog();
        }

        private void dash_Leave(object sender, EventArgs e)
        {
            //if (Interaction.MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNo, "Exit System") == MsgBoxResult.Yes)
            //{
            //    Application.Exit();
            //}
            
        }

        private void dash_FormClosed(object sender, FormClosedEventArgs e)
        {
          
          

        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        public void showProduct()
        {
            cl.sql = "Select * From tblproduct";
            cl.da = new MySqlDataAdapter(cl.sql, cl.cnn);
            DataTable dt = new DataTable();
            cl.da.Fill(dt);
            dgvProduct.DataSource = dt;
            dgvProduct.Columns[0].Visible = false;
            this.dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var dgv = dgvProduct;
            {
                dgv.Columns[1].HeaderText = "កូដទំនិញ";
                dgv.Columns[2].HeaderText = "ឈ្មោះទំនិញ";
                dgv.Columns[3].HeaderText = "ឈ្មោះប្រភេទទំនិញ";
                dgv.Columns[4].HeaderText = "តំលៃទិញចូល";
                dgv.Columns[5].HeaderText = "តំលៃលក់";
                dgv.Columns[6].HeaderText = "ថ្ងៃទិញចូល";
                dgv.Columns[7].HeaderText = "ចំនួនក្នុងស្តុក";
                dgv.Columns[8].HeaderText = "ទំនិញគិតជា";
                dgv.Columns[9].HeaderText = "Reorder level";
            }

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
            dgvCate.Columns[0].Visible = false ;
            this.dgvCate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dash_FormClosing(object sender, FormClosingEventArgs e)
        {
          
            DialogResult result = MessageBox.Show("Do you wanna do something?", "Warning",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
               login ln = new login();
               ln.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
           
            Class1.add = false;
            Class1.update = true;
            frmCategory frmCate = new frmCategory();
            frmCate.ShowDialog();
        }

        private void dgvCate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgvCate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvCate.Rows[e.RowIndex];
                Class1.id = row.Cells[1].Value.ToString();
                //Class1.cateID = row.Cells[10].Value.ToString();

            }
        }

        private void dgvCate_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            cl.cnn.Open();
            if (dgvCate.SelectedCells.Count > 0)

            {
                DialogResult result = MessageBox.Show("Do you want to Delete Category?", "Warning",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    cl.cmd = new MySqlCommand("Delete from tblcate Where cateID = @id",cl.cnn);
                    cl.cmd.Parameters.AddWithValue("@id", Class1.id);
                    int i = cl.cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Category Delete Success!");
                        showCate();
                    }
                    else
                    {
                        MessageBox.Show("No Data Deleted");
                    }
                }

            }
            else
            {
                MessageBox.Show("Please Select data to Delete");
            }

            cl.cmd.Dispose();
            cl.cnn.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Class1.add = true;
            Class1.update = false;
            frmProduct pro = new frmProduct();
            pro.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Class1.add = false;
            Class1.update = true;
            frmProduct pro = new frmProduct();
            pro.ShowDialog();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvProduct.Rows[e.RowIndex];
                Class1.id = row.Cells[1].Value.ToString();
                


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cl.cnn.Open();
                 DialogResult result = MessageBox.Show("Do you want to Delete Product?", "Warning",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    cl.sql = "Delete From tblproduct Where itemCode = @id";
                    cl.cmd = new MySqlCommand(cl.sql,cl.cnn);
                    cl.cmd.Parameters.AddWithValue("@id", Class1.id);
                    int i = cl.cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Product Delete Success!");
                        showProduct();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            cl.cnn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmStockIn stockIn = new frmStockIn();
            stockIn.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    reOrderProduct();
                    break;
                case 1:
                    showCate();
                    break;
                case 2:
                    showProduct();
                    this.dgvProduct.Columns[4].DefaultCellStyle.Format = "c";
                    this.dgvProduct.Columns[5].DefaultCellStyle.Format = "c";
                    break;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cl.cnn.Open();
                int d;
                for (d = 0; d <= 900; d++)
                {
                    cl.cmd = new MySqlCommand("Insert Into tblproduct (itemCode) Values(@d)", cl.cnn);
                    cl.cmd.Parameters.AddWithValue("@d", d);
                    cl.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            cl.cnn.Close();
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

    }
}
