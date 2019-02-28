using Microsoft.VisualBasic;
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
using CrystalDecisions.CrystalReports;


namespace WindowsFormsApplication1
{
   public partial class dash : MetroFramework.Forms.MetroForm
    //public partial class dash : Form
       
    {
        public SQLCON cl = new SQLCON();
      
        public dash()
        {
            //SQLCON.openConn();
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
                
                SQLCON.sql = "Select * from tblproduct Where itemInstock <= itemReorderLevel ";
                SQLCON.da = new MySqlDataAdapter(SQLCON.sql, SQLCON.cnn);
                DataTable dt = new DataTable();
                SQLCON.da.Fill(dt);
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
            
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            SQLCON.add = true;
            SQLCON.update = false;
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
            SQLCON.sql = "Select * From tblproduct";
            SQLCON.da = new MySqlDataAdapter(SQLCON.sql, SQLCON.cnn);
            DataTable dt = new DataTable();
            SQLCON.da.Fill(dt);
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
            SQLCON.da = new MySqlDataAdapter(sql1, SQLCON.cnn);
            DataTable dt = new DataTable();
            SQLCON.da.Fill(dt);
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
           
            SQLCON.add = false;
            SQLCON.update = true;
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
                SQLCON.id = row.Cells[1].Value.ToString();
                //Class1.cateID = row.Cells[10].Value.ToString();

            }
        }

        private void dgvCate_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            //SQLCON.openConn();
            if (dgvCate.SelectedCells.Count > 0)

            {
                DialogResult result = MessageBox.Show("Do you want to Delete Category?", "Warning",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SQLCON.cmd = new MySqlCommand("Delete from tblcate Where cateID = @id",SQLCON.cnn);
                    SQLCON.cmd.Parameters.AddWithValue("@id", SQLCON.id);
                    int i = SQLCON.cmd.ExecuteNonQuery();
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

            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SQLCON.add = true;
            SQLCON.update = false;
            frmProduct pro = new frmProduct();
            pro.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SQLCON.add = false;
            SQLCON.update = true;
            frmProduct pro = new frmProduct();
            pro.ShowDialog();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvProduct.Rows[e.RowIndex];
                SQLCON.id = row.Cells[1].Value.ToString();
                


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SQLCON.openConn();
                 DialogResult result = MessageBox.Show("Do you want to Delete Product?", "Warning",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SQLCON.sql = "Delete From tblproduct Where itemCode = @id";
                    SQLCON.cmd = new MySqlCommand(SQLCON.sql,SQLCON.cnn);
                    SQLCON.cmd.Parameters.AddWithValue("@id", SQLCON.id);
                    int i = SQLCON.cmd.ExecuteNonQuery();
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
            SQLCON.cnn.Close();
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
               SQLCON.openConn();
                int d;
                for (d = 0; d <= 900; d++)
                {
                    SQLCON.cmd = new MySqlCommand("Insert Into tblproduct (itemCode) Values(@d)", SQLCON.cnn);
                    SQLCON.cmd.Parameters.AddWithValue("@d", d);
                    SQLCON.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

     

        private void loadInvoiceNo()
        {
            SQLCON.openConn();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand("Select * from tblsaledetail Order by saleId Desc Limit 1", SQLCON.cnn);
                SQLCON.da = new MySqlDataAdapter(cmd1);
                //cmd1.Parameters.AddWithValue(txtInvoiceNo.Text ,"@invoiceNo");
                DataTable dt = new DataTable();
                SQLCON.da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    txtInvoiceNo.Text = "0001";
                }
                else
                {
                    int inno = Convert.ToInt32(dt.Rows[0]["invoiceNo"]) + 1;
                    txtInvoiceNo.Text = inno.ToString("0000");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }finally   
           
            {
                SQLCON.cnn.Close(); 
            }
           

                    
            

        }

        private void loadSaleitem()
        {
           
           DataTable dt = new DataTable();
            SQLCON.cmd = new MySqlCommand("Select * from tblsaledetail where invoiceNo = @invoiceNo", SQLCON.cnn);
            SQLCON.cmd.Parameters.AddWithValue( "@invoiceNo" , txtInvoiceNo.Text);
            SQLCON.da = new MySqlDataAdapter(SQLCON.cmd);
                      
            SQLCON.da.Fill(dt);
           // if (dt.Rows.Count > 0) {
                dgvSale.DataSource = dt;
            //}
            
            
            
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //SQLCON.cnn.Open();
                loadSaleitem();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally {
                SQLCON.cnn.Close(); 
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmReportCrystal frmCrystal = new frmReportCrystal();
            Form2 frmPrint = new Form2();
           
            frmPrint.Show();
            frmCrystal.Show();


        }

        private void txtProducCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProducCode_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtProducCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // add invoice
                    try
                    {
                        DataTable dt = new DataTable();
                        SQLCON.openConn();
                        //SQLCON.cnn.Open();

                        SQLCON.cmd = new MySqlCommand("Select * from tblproduct where itemCode = @item",SQLCON.cnn);
                        SQLCON.cmd.Parameters.AddWithValue("@item", txtProducCode.Text);
                        SQLCON.da = new MySqlDataAdapter(SQLCON.cmd);
                        

                        SQLCON.da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            
                                txtItemName.Text = Convert.ToString(dt.Rows[0]["itemName"]);
                                txtItemCategory.Text = Convert.ToString(dt.Rows[0]["itemCategory"]);
                                txtItemPrice.Text = Convert.ToString(dt.Rows[0]["itemPriceOut"]);
                                txtQuantity.Focus();

                        }

                        


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    SQLCON.cnn.Close();



            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void saleProducts()
        {
            try
            {
                SQLCON.openConn();
                SQLCON.cmd = new MySqlCommand("Insert Into tblsaledetail (invoiceNo,itemCode,itemName,unitePrice,quantity,price)" +
                    " Values (@invoiceNo,@item,@itemName,@unitePrice,@quantity,@price)", SQLCON.cnn);
                var p = SQLCON.cmd;
                p.Parameters.AddWithValue("@invoiceNo", txtInvoiceNo.Text);
                p.Parameters.AddWithValue("@item", txtProducCode.Text);
                p.Parameters.AddWithValue("@itemName", txtItemName.Text);
                p.Parameters.AddWithValue(@"unitePrice", Convert.ToDouble(txtItemPrice.Text));
                p.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                p.Parameters.AddWithValue("@price", Convert.ToDouble(txtItemPrice.Text) * Convert.ToDouble(txtQuantity.Text));
                p.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                SQLCON.cnn.Close();
                loadSaleitem();
            }
           
            
            SQLCON.cnn.Close();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            try
            {
                
                saleProducts();
                txtProducCode.Focus();
                clearText();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void clearText()
        {
            txtProducCode.Text = "";
            txtItemCategory.Text = "";
            txtCustomerName.Text = "";
            txtQuantity.Text = "";
            txtItemPrice.Text = "";
            txtItemName.Text = "";
            
            foreach (Control  t  in pProductInfo.Controls)
            {
                if (t is TextBox)
                {
                    t.Text = "";
                }
            }

        }

        private void saveInvoice_Print()
        {
            try
            {
                SQLCON.openConn();
                if (txtRecieveDollar.Text != "" && txtRecieveDollar.Text == "")
                {
                    MessageBox.Show("Can't Sale Products when not Recieve money yet !", "Recieve Money Requied");
                    return;
                }

                //when cash reciev is Dollar

                if (txtRecieveDollar.Text != "" && txtRecieveReil.Text == "")
                {
                    SQLCON.cmd = new MySqlCommand("Insert Into tbl_invoice(invoiceNo,saleBy,saleDate,totalDollar,totalRiel,cash_D_R_all,cashRecieveDollar,cashReturnDollar)" +
                    " Values (@invoiceNo,'Sopheak',sysdate(),@totalDollar,@totalRiel,@cash_D_R_all,@cashRecieveDollar,@cashReturnDollar)", SQLCON.cnn);
                    SQLCON.cmd.Parameters.AddWithValue("@invoiceNo", txtInvoiceNo.Text);
                    SQLCON.cmd.Parameters.AddWithValue("@totalDollar", txtGrandTotalDollar.Text);
                    SQLCON.cmd.Parameters.AddWithValue("@totalRiel", txtGrandTotalRiel.Text);
                    SQLCON.cmd.Parameters.AddWithValue("@cash_D_R_all", 0);
                    SQLCON.cmd.Parameters.AddWithValue("@cashRecieveDollar", txtRecieveDollar.Text);
                    SQLCON.cmd.Parameters.AddWithValue("@cashReturnDollar", txtCashReturnDollar.Text);
                    
                    //SQLCON.cmd.Parameters.AddWithValue("@cash", txt.Text);
                }
                else if (txtRecieveReil.Text != "" && txtRecieveDollar.Text == "")
                {
                    // When cash reciev is Riel
                    SQLCON.cmd = new MySqlCommand("Insert Into tbl_invoice (invoiceNo,saleBy,saleDate,totalDollar,totalRiel,cash_D_R_all,cashRecieveRiel,cashReturnRiel)" +
                    " Values (@invoiceNo,'Sopheak', sysdate(),@totalRiel,@cashRecieveRiel,@cash_D_R_all)", SQLCON.cnn);
                    SQLCON.cmd.Parameters.AddWithValue("@totalDollar", txtGrandTotalDollar.Text);
                    SQLCON.cmd.Parameters.AddWithValue("@totalRiel", txtGrandTotalRiel.Text);
                    SQLCON.cmd.Parameters.AddWithValue("@cashRecieveRiel", txtRecieveReil.Text);
                    SQLCON.cmd.Parameters.AddWithValue("@cash_D_R_all", 1);
                }


                //SQLCON.cmd = new MySqlCommand("Insert Into tbl_invoice (invoiceNo,saleBy,saleDate,totalDollar,totalRiel,cash_D_R_all,cashRecieveDollar,cashRecieveRiel,cashReturnDollar,isPay)" +
                // " Values (@invoiceNo,'Sopheak', sysdate(),@totalDollar,@cashRecieveDollar,@cash_D_R_all)", SQLCON.cnn);

                //SQLCON.cmd.Parameters.AddWithValue("@invoiceNo", txtInvoiceNo.Text);
                //SQLCON.cmd.ExecuteNonQuery();
                int p = SQLCON.cmd.ExecuteNonQuery();
                if (p > 0)
                {
                    SQLCON.cmd = new MySqlCommand("Select * from v_invoice where invoiceNo=@invoiceNoPrintINvoice", SQLCON.cnn);
                    
                    SQLCON.cmd.Parameters.AddWithValue("@invoiceNoPrintINvoice", txtInvoiceNo.Text);
                    SQLCON.da = new MySqlDataAdapter(SQLCON.cmd);
                    //DataTable dt = new DataTable();
                    SQLCON.dsa.Clear();
                    SQLCON.da.Fill(SQLCON.dsa, "rptInvoice");              // rpt is the name of ttx File
                    
                    SQLCON.reportName = "cryInvoice";                       // report name
                    frmReportCrystal frmprint = new frmReportCrystal();
                   
                    frmprint.Show();
                    
                   
                }

                SQLCON.cnn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
           
            
        }

        

        private void dgvSale_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                //if (dgvSale.Rows.Count > 0)
                //{
                    DataTable dt = new DataTable();

                    //SQLCON.openConn();

                    SQLCON.cmd = new MySqlCommand("Select sum(price) from tblsaledetail where invoiceNo = @invoiceNo", SQLCON.cnn);
                    SQLCON.cmd.Parameters.AddWithValue("@invoiceNo", txtInvoiceNo.Text);
                    SQLCON.da = new MySqlDataAdapter(SQLCON.cmd);
                    SQLCON.da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtGrandTotalDollar.Text = Convert.ToString(dt.Rows[0][0]);
                    }

                    DataTable dtRate = new DataTable();
                    SQLCON.cmd = new MySqlCommand("Select USD_RIEL from tblrate  order by id DESC Limit 1", SQLCON.cnn);
                    SQLCON.da = new MySqlDataAdapter(SQLCON.cmd);
                    SQLCON.da.Fill(dtRate);

                    if (dtRate.Rows.Count > 0)
                    {
                        if (txtGrandTotalDollar.Text !="")
                        {
                            string riel = Convert.ToString(dtRate.Rows[0][0]);
                            double rielD = Convert.ToDouble(riel) * Convert.ToDouble(txtGrandTotalDollar.Text);
                            txtGrandTotalRiel.Text = rielD.ToString("##,###.00");
                        }
                        else
                        {
                            return;
                        }
                       
                    }
                }
              
            //}
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            SQLCON.cnn.Close();
           
        }



        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtRecieveReil.Text == "" && txtRecieveDollar.Text == "")
                {
                    MessageBox.Show("Please Input Recieved Money", "Input Recieved money");
                    return;
                }

                else if (txtRecieveDollar.Text !="" && Convert.ToDouble(txtRecieveDollar.Text) < Convert.ToDouble(txtGrandTotalDollar.Text))
                {
                    MessageBox.Show("អត់គ្រប់លុយទេ !", "Input Recieved money");
                    txtRecieveDollar.Focus();
                    return;
                }
                else if (txtRecieveReil.Text !="" && Convert.ToDouble(txtRecieveDollar.Text) < Convert.ToDouble(txtGrandTotalDollar.Text))
                {
                    MessageBox.Show("អត់គ្រប់លុយទេ !", "Input Recieved money");
                    txtRecieveReil.Focus();
                    return;
                }
               

                
               

                saveInvoice_Print();
                
                btnNewSale.PerformClick();

                foreach (Control t in pProductCash.Controls)
                {
                    if (t is TextBox)
                    {
                        t.Text = "";
                    }
                }

                //txtGrandTotalDollar.Text = "";
                //txtGrandTotalRiel.Text = "";
                //txtRecieveDollar.Text = "";
                //txtRecieveReil.Text = "";
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            //saveInvoice();
        }



        private void btnNewSale_Click(object sender, EventArgs e)
        {
            try
            {
                loadInvoiceNo();
                txtProducCode.Focus();
            }
            
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                SQLCON.cnn.Close();
            }
        }

        private void txtGrandTotalDollar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtGrandTotalRiel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtRecieveDollar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtRecieveReil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtQuantity.Text != "" && e.KeyCode == Keys.Enter)
            {
                txtCustomerName.Focus();
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSale.Focus();
            }
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            frmReportCrystal frmprint = new frmReportCrystal();

            SQLCON.da = new MySqlDataAdapter("Select * from v_invoice where invoiceNo ='" + txtInvoiceNo.Text + "'", SQLCON.cnn);
            //DataTable dt = new DataTable();
            SQLCON.dsa.Clear();
            SQLCON.da.Fill(SQLCON.dsa, "rptInvoice");              //  name of ttx File
            SQLCON.reportName = "cryInvoice";                       // report name
            frmprint.Show();
            

        }

        private void txtRecieveDollar_TextChanged(object sender, EventArgs e)
        {
            if (txtRecieveReil.Text == "" && txtRecieveDollar.Text !="")
            {
                double returnDollar;
                returnDollar = Convert.ToDouble(txtRecieveDollar.Text) - Convert.ToDouble(txtGrandTotalDollar.Text);
                txtCashReturnDollar.Text = returnDollar.ToString();
            }
            else
            {
                txtCashReturnDollar.Text = "";
            }
        }
    }

    
}
