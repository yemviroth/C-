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
        SQLCON cl = new SQLCON();
        
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
            SQLCON.cnn.Open();
            

            if (SQLCON.add == true)
            {
                //check if not exist then add cate;
                checkCate("tblcate");
            }
            else
            {
                updateCate();
                
            }
            SQLCON.cnn.Close();

           
           
        }
        private void addCate()
        {
            //SQLCON.cnn.Open();
            //checkCate("tblcate");

            string sql = "Insert Into tblcate (cateID,cateName) Values(@cateCode,@cateName)";
            //SQLCON.cmd = new MySql.Data.MySqlClient.MySqlCommand(SQLCON.sql, SQLCON.cnn);
            //SQLCON.cmd.ExecuteNonQuery();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, SQLCON.cnn);
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
          
            SQLCON.sql = "Update tblcate Set cateID=@cateCode,cateName=@cateName Where cateID = @id";
            SQLCON.cmd = new MySqlCommand(SQLCON.sql, SQLCON.cnn);
            SQLCON.cmd.Parameters.AddWithValue("@cateCode", txtCateCode.Text);
            SQLCON.cmd.Parameters.AddWithValue("@cateName", txtCateName.Text);
            SQLCON.cmd.Parameters.AddWithValue("@id", SQLCON.id);
            int i = SQLCON.cmd.ExecuteNonQuery();
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
            
            SQLCON.sql = "Select * From "+tbl+" Where cateID = @cateCode";
            SQLCON.cmd = new MySqlCommand(SQLCON.sql,SQLCON.cnn);
            SQLCON.cmd.Parameters.AddWithValue("@cateCode", txtCateCode.Text);
            
            SQLCON.dr = SQLCON.cmd.ExecuteReader();
            if (SQLCON.dr.Read() == true)
            {
                MessageBox.Show("Category Code Already Exist.");
                
            }
               
            else
            {
                SQLCON.dr.Close();
                addCate();
            }
           
            
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
           
            try
            {
                SQLCON.cnn.Open();
                if (SQLCON.update == true)
                {
                    SQLCON.sql = "Select * from tblcate Where cateID = @id";
                    SQLCON.cmd = new MySqlCommand(SQLCON.sql, SQLCON.cnn);
                    SQLCON.cmd.Parameters.AddWithValue("@id", SQLCON.id);
                    SQLCON.dr = SQLCON.cmd.ExecuteReader();
                    if (SQLCON.dr.Read() == true)
                    {
                        txtCateCode.Text = SQLCON.dr["cateID"].ToString();
                        txtCateName.Text = SQLCON.dr["cateName"].ToString();
                        
                    }
                    SQLCON.dr.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
            SQLCON.cmd.Dispose();
            SQLCON.cnn.Close();

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
