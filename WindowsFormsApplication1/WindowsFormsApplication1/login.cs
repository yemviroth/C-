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
    public partial class login : MetroFramework.Forms.MetroForm
    {
        Class1 cl = new Class1();
       // public MySqlConnection cnn = new MySqlConnection("Server=192.168.0.8;Database=cc;Uid=root;Pwd=123;Encrypt=true;");
        public login()
        {
           
            InitializeComponent();
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //MySqlCommand cmd = new MySqlCommand("Select * from tbluser Where userName='"+txtUser.Text+"','"+txtPwd.Text+"'",cnn);
           
         }
             

        private void login_Load(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
            this.Activate();
            this.TopMost = true;


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("Select * from tbluser Where userName=@user And pwd=@pwd", cl.cnn);
                cmd.Parameters.AddWithValue("@user", txtUser.Text);
                cmd.Parameters.AddWithValue("@pwd", txtPwd.Text);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dtlogin = new DataTable();
                da.Fill(dtlogin);
                if (dtlogin.Rows.Count > 0)
                {
                    //this.Hide();
                    dash frmMain = new dash();

                   // login ln = new login();
                    this.Hide();
                    frmMain.Show();
                    //ln.Close();
                }
                else
                {
                    MessageBox.Show("Invalid");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
    }
}
