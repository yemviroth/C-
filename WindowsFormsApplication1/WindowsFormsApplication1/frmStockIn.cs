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
    public partial class frmStockIn : MetroFramework.Forms.MetroForm
    {
        string categoryID;
        
        SQLCON cl = new SQLCON();
        public frmStockIn()
        {
            InitializeComponent();
           
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearText();
        }


        private void ClearText()
        {
            foreach (var txt in this.Controls)
            {
                if (txt is TextBox)
                {
                    (txt as TextBox).Clear();

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            addProduct();
            SQLCON.cnn.Close();
        }

        private void addProduct()
        {
            try
            {

                SQLCON.sql = @"Insert Into tblstockin (itemCode,itemName,Quantity,Datein)" +
                      " Values (@itemCode,@itemName,@quantity,DATE_FORMAT(sysdate(),'%d-%b-%Y'))";
                SQLCON.cmd = new MySqlCommand(SQLCON.sql, SQLCON.cnn);
                SQLCON.cmd.Parameters.AddWithValue("@itemCode" , txtProducCode.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemName" , txtProductName.Text);
                
                SQLCON.cmd.Parameters.AddWithValue("@quantity" , txtQuantity.Text);
               //SQLCON.cmd.Parameters.AddWithValue("@Datein", Now());
               


                int i = SQLCON.cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    updateProductStock();
                    if (System.Windows.Forms.Application.OpenForms["dash"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["dash"] as dash).showProduct();
                    }
                    MessageBox.Show("Product Stocked In");
                    //ClearText();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void updateProductStock()
        {
            try
            {
               
                SQLCON.sql = "Update tblproduct SET itemInstock=@itemInstock Where itemCode= @id";
                SQLCON.cmd = new MySqlCommand(SQLCON.sql, SQLCON.cnn);
               
               
                SQLCON.cmd.Parameters.AddWithValue("@itemInStock", txtAfterAdd.Text);
              
               
                SQLCON.cmd.Parameters.AddWithValue("@id", SQLCON.id);
               // SQLCON.cmd.Parameters.AddWithValue("@cateID", categoryID);
                SQLCON.cmd.ExecuteNonQuery();
              

               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {

            SQLCON.cnn.Open();
           
   
                lblTitle.Text = "កែប្រែតុកស្ទំនិញ";
                loadProductForUpdate();
          
        }


        private void loadProductForUpdate()
        {
            if (SQLCON.id !="")
            {
                SQLCON.sql = "Select * from tblproduct Where itemCode = @id";
                SQLCON.cmd = new MySqlCommand(SQLCON.sql, SQLCON.cnn);
                SQLCON.cmd.Parameters.AddWithValue("@id", SQLCON.id);
                SQLCON.dr = SQLCON.cmd.ExecuteReader();
                while (SQLCON.dr.Read())
                {

                    txtProducCode.Text = SQLCON.dr.GetString(1);
                    txtProductName.Text = SQLCON.dr.GetString(2);

                    txtPriceSell.Text = SQLCON.dr.GetString(5);
                    // dtpIn.Value = Class1.dr.GetValue(6);
                    txtProductInStock.Text = SQLCON.dr.GetString(7);
                    //txtAfterAdd.Text = Class1.dr.GetString(8);


                }
            }
            else
            {
                MessageBox.Show("Please Select Product to Update");
            }

            SQLCON.dr.Dispose();
           

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCateForProduct cate = new frmCateForProduct(this);
            cate.ShowDialog();
        }


        //public string Category
        //{
        //    get { return txtProductCate.Text; }
        //    set { txtProductCate.Text = value; }
        //}

        public String CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        public string proCode
        {
            get { return txtProducCode.Text; }
            set { txtProducCode.Text = value; }
        }

        private void txtAddInStock_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuantity.Text) && !string.IsNullOrEmpty(txtProductInStock.Text))
            {
                txtAfterAdd.Text = (Convert.ToInt32(txtQuantity.Text) + Convert.ToInt32(txtProductInStock.Text)).ToString();
            }
            else
            {
                txtAfterAdd.Text = txtProductInStock.Text;
            }
           

        }

        //public string caa
        //{
        //    set { txtProductCate.Text = value; }

        //}
    }

   
}
