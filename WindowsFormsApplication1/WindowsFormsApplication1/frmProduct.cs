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
        
        SQLCON cl = new SQLCON();
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
            SQLCON.cnn.Open();
            if (SQLCON.add == true) {
                 addProduct();
            }
            else
            {
                updateProduct();
            }
           

            SQLCON.cnn.Close();
        }

        private void addProduct()
        {
            try
            {
                
                SQLCON.sql = @"Insert Into tblproduct (itemCode,itemName,itemCategory,itemPriceIn,itemPriceOut,itemStockInDate,itemInStock,itemKetjea,itemReorderLevel,cateID)" +
                      " Values (@itemCode, @itemName, @itemCategory, @itemPriceIn, @itemPriceOut, @itemStockInDate, @itemInStock, @itemKetjea, @itemReorderLevel, @cateID)";
                SQLCON.cmd = new MySqlCommand(SQLCON.sql, SQLCON.cnn);
                SQLCON.cmd.Parameters.AddWithValue("@itemCode" , txtProducCode.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemName" , txtProductName.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemCategory" , txtProductCate.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemPriceIn" , txtPriceIn.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemPriceOut" , txtPriceSell.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemStockInDate", dtpIn.Value.ToString("dd-MMM-yyyy"));
                SQLCON.cmd.Parameters.AddWithValue("@itemInStock" , txtProductInStock.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemKetjea" , txtUnit.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemReorderLevel" , txtReorderLevel.Text);
                SQLCON.cmd.Parameters.AddWithValue("@cateID", txtCateID.Text);


                int i = SQLCON.cmd.ExecuteNonQuery();
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
               
                SQLCON.sql = "Update tblproduct SET itemCode = @itemCode ,itemName = @itemName ,itemCategory = @itemCategory ,itemPriceIn = @itemPriceIn ,itemPriceOut = @itemPriceOut ,itemStockInDate = @itemStockInDate ,itemInStock = @itemInStock ,itemKetjea = @itemKetjea ,itemReorderLevel = @itemReorderLevel"+
                    ", cateID = @cateID Where itemCode= @id";
                SQLCON.cmd = new MySqlCommand(SQLCON.sql, SQLCON.cnn);
                SQLCON.cmd.Parameters.AddWithValue("@itemCode", txtProducCode.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemName", txtProductName.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemCategory", txtProductCate.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemPriceIn", txtPriceIn.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemPriceOut", txtPriceSell.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemStockInDate", dtpIn.Value.ToString("dd-MMM-yyyy"));
                SQLCON.cmd.Parameters.AddWithValue("@itemInStock", txtProductInStock.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemKetjea", txtUnit.Text);
                SQLCON.cmd.Parameters.AddWithValue("@itemReorderLevel", txtReorderLevel.Text);
                SQLCON.cmd.Parameters.AddWithValue("@id", SQLCON.id);
                SQLCON.cmd.Parameters.AddWithValue("@cateID", txtCateID.Text);
                int i = SQLCON.cmd.ExecuteNonQuery();
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

            dtpIn.Format = DateTimePickerFormat.Custom;
            dtpIn.CustomFormat = "dd-MMM-yyyy";
            SQLCON.cnn.Open();
            if (SQLCON.add == true)
            {
                btnNew.Visible = true;
                lblTitle.Text = "បន្ថែមទំនិញ";
            }
            else
            {
                
                btnNew.Visible = false;
                lblTitle.Text = "កែប្រែទំនិញ";
                loadProductForUpdate();
            }
            SQLCON.cnn.Close();
        }


        private void loadProductForUpdate()
        {
            try
            {
                SQLCON.sql = "Select * from tblproduct Where itemCode = @id";
                SQLCON.cmd = new MySqlCommand(SQLCON.sql, SQLCON.cnn);
                SQLCON.cmd.Parameters.AddWithValue("@id", SQLCON.id);
                SQLCON.dr = SQLCON.cmd.ExecuteReader();
                while (SQLCON.dr.Read())
                {

                    txtProducCode.Text = SQLCON.dr.GetString(1);
                    txtProductName.Text = SQLCON.dr.GetString(2);
                    txtProductCate.Text = SQLCON.dr.GetString(3);
                    txtPriceIn.Text = SQLCON.dr.GetString(4);
                    txtPriceSell.Text = SQLCON.dr.GetString(5);
                    // dtpIn.Value = Class1.dr.GetValue(6);
                    txtProductInStock.Text = SQLCON.dr.GetString(7);
                    txtUnit.Text = SQLCON.dr.GetString(8);
                    txtReorderLevel.Text = SQLCON.dr.GetString(9);
                    txtCateID.Text = SQLCON.dr.GetString(10);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
            get { return txtCateID.Text; }
            set { txtCateID.Text = value; }
        }

        public string proCode
        {
            get { return txtProducCode.Text; }
            set { txtProducCode.Text = value; }
        }

        //public string caa
        //{
        //    set { txtProductCate.Text = value; }

        //}
    }

   
}
