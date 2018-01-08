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
    public partial class frmCategory : MetroFramework.Forms.MetroForm
    {
        Class1 cl = new Class1();
        
        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cl.cnn.Open();
            

            if (Class1.add == true)
            {
                //check if not exist then add cate;
                checkCate("tblcate");
            }
            else
            {
                updateCate();
                
            }
            cl.cnn.Close();

           
           
        }
        private void addCate()
        {
            //cl.cnn.Open();
            //checkCate("tblcate");

            string sql = "Insert Into tblcate (cateID,cateName) Values(@cateCode,@cateName)";
            //cl.cmd = new MySql.Data.MySqlClient.MySqlCommand(cl.sql, cl.cnn);
            //cl.cmd.ExecuteNonQuery();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, cl.cnn);
                cmd.Parameters.AddWithValue("@cateCode", txtCateCode.Text);
                cmd.Parameters.AddWithValue("@cateName", txtCateName.Text);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    if (System.Windows.Forms.Application.OpenForms["dash"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["dash"] as dash).showCate();
                    }

                    MessageBox.Show("Success Added");
                    cleartext();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
           
        }

        private void updateCate()
        {
          
            cl.sql = "Update tblcate Set cateID=@cateCode,cateName=@cateName Where cateID = @id";
            cl.cmd = new MySqlCommand(cl.sql, cl.cnn);
            cl.cmd.Parameters.AddWithValue("@cateCode", txtCateCode.Text);
            cl.cmd.Parameters.AddWithValue("@cateName", txtCateName.Text);
            cl.cmd.Parameters.AddWithValue("@id", Class1.id);
            int i = cl.cmd.ExecuteNonQuery();
            if (i > 0)
            {
                if (System.Windows.Forms.Application.OpenForms["dash"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["dash"] as dash).showCate();
                }

                MessageBox.Show("Success Update");
                cleartext();
            }
            
            this.Close();
        }

        private void checkCate(string tbl)
        {

            cl.sql = "Select * From "+tbl+" Where cateID = @cateCode";
            cl.cmd = new MySqlCommand(cl.sql,cl.cnn);
            cl.cmd.Parameters.AddWithValue("@cateCode", txtCateCode.Text);
            
            Class1.dr = cl.cmd.ExecuteReader();
            if (Class1.dr.Read() == true)
            {
                MessageBox.Show("Category Code Already Exist.");

            }
            else
            {
                addCate();
            }

            
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            btnSave.Font = new System.Drawing.Font(this.Font, btnSave.Font.Style);
            try
            {
                cl.cnn.Open();
                if (Class1.update == true)
                {
                    cl.sql = "Select * from tblcate Where cateID = @id";
                    cl.cmd = new MySqlCommand(cl.sql, cl.cnn);
                    cl.cmd.Parameters.AddWithValue("@id", Class1.id);
                    Class1.dr = cl.cmd.ExecuteReader();
                    if (Class1.dr.Read() == true)
                    {
                        txtCateCode.Text = Class1.dr["cateID"].ToString();
                        txtCateName.Text = Class1.dr["cateName"].ToString();
                        
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
            cl.cmd.Dispose();
            cl.cnn.Close();

        }
        private void cleartext()
        {
            txtCateCode.Text = "";
            txtCateName.Text = "";
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
