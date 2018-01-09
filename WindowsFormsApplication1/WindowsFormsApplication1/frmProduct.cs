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
    public partial class frmProduct : MetroFramework.Forms.MetroForm
    {
        string categoryID;
        
        Class1 cl = new Class1();
        public frmProduct()
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
            cl.cnn.Open();
            if (Class1.add == true) {
                 addProduct();
            }
            else
            {
                updateProduct();
            }
           

            cl.cnn.Close();
        }

        private void addProduct()
        {
            try
            {

                cl.sql = @"Insert Into tblproduct (itemCode,itemName,itemCategory,itemPriceIn,itemPriceOut,itemStockInDate,itemInStock,itemKetjea,itemReorderLevel,cateID)" +
                      " Values (@itemCode, @itemName, @itemCategory, @itemPriceIn, @itemPriceOut, @itemStockInDate, @itemInStock, @itemKetjea, @itemReorderLevel, @cateID)";
                cl.cmd = new MySqlCommand(cl.sql, cl.cnn);
                cl.cmd.Parameters.AddWithValue("@itemCode" , txtProducCode.Text);
                cl.cmd.Parameters.AddWithValue("@itemName" , txtProductName.Text);
                cl.cmd.Parameters.AddWithValue("@itemCategory" , txtProductCate.Text);
                cl.cmd.Parameters.AddWithValue("@itemPriceIn" , txtPriceIn.Text);
                cl.cmd.Parameters.AddWithValue("@itemPriceOut" , txtPriceSell.Text);
                cl.cmd.Parameters.AddWithValue("@itemStockInDate" , dtpIn.Value);
                cl.cmd.Parameters.AddWithValue("@itemInStock" , txtProductInStock.Text);
                cl.cmd.Parameters.AddWithValue("@itemKetjea" , txtUnit.Text);
                cl.cmd.Parameters.AddWithValue("@itemReorderLevel" , txtReorderLevel.Text);
                cl.cmd.Parameters.AddWithValue("@cateID", categoryID);


                int i = cl.cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    if (System.Windows.Forms.Application.OpenForms["dash"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["dash"] as dash).showProduct();
                    }
                    MessageBox.Show("Product Success Full Added");
                    ClearText();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void updateProduct()
        {
            try
            {
               
                cl.sql = "Update tblproduct SET itemCode = @itemCode ,itemName = @itemName ,itemCategory = @itemCategory ,itemPriceIn = @itemPriceIn ,itemPriceOut = @itemPriceOut ,itemStockInDate = @itemStockInDate ,itemInStock = @itemInStock ,itemKetjea = @itemKetjea ,itemReorderLevel = @itemReorderLevel"+
                    ", cateID = @cateID Where itemCode= @id";
                cl.cmd = new MySqlCommand(cl.sql, cl.cnn);
                cl.cmd.Parameters.AddWithValue("@itemCode", txtProducCode.Text);
                cl.cmd.Parameters.AddWithValue("@itemName", txtProductName.Text);
                cl.cmd.Parameters.AddWithValue("@itemCategory", txtProductCate.Text);
                cl.cmd.Parameters.AddWithValue("@itemPriceIn", txtPriceIn.Text);
                cl.cmd.Parameters.AddWithValue("@itemPriceOut", txtPriceSell.Text);
                cl.cmd.Parameters.AddWithValue("@itemStockInDate", dtpIn.Value);
                cl.cmd.Parameters.AddWithValue("@itemInStock", txtProductInStock.Text);
                cl.cmd.Parameters.AddWithValue("@itemKetjea", txtUnit.Text);
                cl.cmd.Parameters.AddWithValue("@itemReorderLevel", txtReorderLevel.Text);
                cl.cmd.Parameters.AddWithValue("@id", Class1.id);
                cl.cmd.Parameters.AddWithValue("@cateID", categoryID);
                int i = cl.cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    if (System.Windows.Forms.Application.OpenForms["dash"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["dash"] as dash).showProduct();
                    }
                   
                    this.Close();
                    MessageBox.Show("Product Update Success !");
                }
                else
                {
                    MessageBox.Show("Error Wile Update");
                }

               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            cl.cnn.Open();
            if (Class1.add == true)
            {
                lblTitle.Text = "បន្ថែមទំនិញ";
            }
            else
            {
                lblTitle.Text = "កែប្រែទំនិញ";
                loadProductForUpdate();
            }
            cl.cnn.Close();
        }


        private void loadProductForUpdate()
        {
            
            cl.sql = "Select * from tblproduct Where itemCode = @id";
            cl.cmd = new MySqlCommand(cl.sql, cl.cnn);
            cl.cmd.Parameters.AddWithValue("@id", Class1.id);
            Class1.dr = cl.cmd.ExecuteReader();
            while (Class1.dr.Read())
            {

                txtProducCode.Text = Class1.dr.GetString(1);
                txtProductName.Text = Class1.dr.GetString(2);
                txtProductCate.Text = Class1.dr.GetString(3);
                txtPriceIn.Text = Class1.dr.GetString(4);
                txtPriceSell.Text = Class1.dr.GetString(5);
               // dtpIn.Value = Class1.dr.GetValue(6);
                txtProductInStock.Text = Class1.dr.GetString(7);
                txtUnit.Text = Class1.dr.GetString(8);
                txtReorderLevel.Text = Class1.dr.GetString(9);

            }
           

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


        public string Category
        {
            get { return txtProductCate.Text; }
            set { txtProductCate.Text = value; }
        }

        public String CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        //public string caa
        //{
        //    set { txtProductCate.Text = value; }

        //}
    }

   
}
