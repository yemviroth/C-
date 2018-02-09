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
        
        Class1 cl = new Class1();
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
            cl.cnn.Close();
        }

        private void addProduct()
        {
            try
            {

                cl.sql = @"Insert Into tblstockin (itemCode,itemName,Quantity,Datein)" +
                      " Values (@itemCode,@itemName,@quantity,DATE_FORMAT(sysdate(),'%d-%b-%Y'))";
                cl.cmd = new MySqlCommand(cl.sql, cl.cnn);
                cl.cmd.Parameters.AddWithValue("@itemCode" , txtProducCode.Text);
                cl.cmd.Parameters.AddWithValue("@itemName" , txtProductName.Text);
                
                cl.cmd.Parameters.AddWithValue("@quantity" , txtQuantity.Text);
               //cl.cmd.Parameters.AddWithValue("@Datein", Now());
               


                int i = cl.cmd.ExecuteNonQuery();
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
               
                cl.sql = "Update tblproduct SET itemInstock=@itemInstock Where itemCode= @id";
                cl.cmd = new MySqlCommand(cl.sql, cl.cnn);
               
               
                cl.cmd.Parameters.AddWithValue("@itemInStock", txtAfterAdd.Text);
              
               
                cl.cmd.Parameters.AddWithValue("@id", Class1.id);
               // cl.cmd.Parameters.AddWithValue("@cateID", categoryID);
                cl.cmd.ExecuteNonQuery();
              

               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {

            cl.cnn.Open();
           
   
                lblTitle.Text = "កែប្រែតុកស្ទំនិញ";
                loadProductForUpdate();
          
        }


        private void loadProductForUpdate()
        {
            if (Class1.id !="")
            {
                cl.sql = "Select * from tblproduct Where itemCode = @id";
                cl.cmd = new MySqlCommand(cl.sql, cl.cnn);
                cl.cmd.Parameters.AddWithValue("@id", Class1.id);
                Class1.dr = cl.cmd.ExecuteReader();
                while (Class1.dr.Read())
                {

                    txtProducCode.Text = Class1.dr.GetString(1);
                    txtProductName.Text = Class1.dr.GetString(2);

                    txtPriceSell.Text = Class1.dr.GetString(5);
                    // dtpIn.Value = Class1.dr.GetValue(6);
                    txtProductInStock.Text = Class1.dr.GetString(7);
                    //txtAfterAdd.Text = Class1.dr.GetString(8);


                }
            }
            else
            {
                MessageBox.Show("Please Select Product to Update");
            }

            Class1.dr.Dispose();
           

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
