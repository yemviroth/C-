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
    public partial class Form1 : Form
    {
        
        //public MySqlConnection cl.cnn = new MySqlConnection("Server=192.168.0.8;Database=cc;Uid=root;Pwd=123;Encrypt=true;Character Set=utf8");

        public Form1()

        {
            InitializeComponent();

        }
        public Class1 cl = new Class1();
        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
               
                cl.cnn.Open();
                loaddata();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void loaddata()
        {
            //dataGridView1.Columns[1].Visible = false;
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from tblTest", cl.cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string sql = "Insert Into tblTest (stName,age) Values(@name,@age)" ;
            MySqlCommand cmd = new MySqlCommand(sql, cl.cnn);
            cmd.Parameters.AddWithValue("@name",txtName.Text );
            cmd.Parameters.AddWithValue("@age", txtAge.Text);
            cmd.ExecuteNonQuery();
            loaddata();
            button4.PerformClick();
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

          
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtName.Text = row.Cells[1].Value.ToString();
                txtAge.Text = row.Cells[2].Value.ToString();
                label1.Text = row.Cells[0].Value.ToString();
            }



        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //int i;
            //i = dataGridView1.SelectedCells[0].RowIndex;
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            txtName.Text = selectedRow.Cells[2].Value.ToString();
            txtAge.Text = selectedRow.Cells[3].Value.ToString();
            label1.Text = selectedRow.Cells[1].Value.ToString();




        }



        private void button2_Click(object sender, EventArgs e)
        {
            
            MySqlCommand cmd = new MySqlCommand("Update tblTest Set stName='"+txtName.Text+"',age='"+txtAge.Text+"' where ID='"+label1.Text+"'",cl.cnn);
            cmd.ExecuteNonQuery();
            loaddata();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count>0 & label1.Text !="")
                if(MessageBox.Show("You Sure to delete ?","Delete",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    {
                        try
                        {
                            MySqlCommand cmd = new MySqlCommand("Delete From tblTest where ID='" + label1.Text + "'", cl.cnn);
                            cmd.ExecuteNonQuery();
                            loaddata();
                            MessageBox.Show("Delete Success !", "Delete");
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            
           

           

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
             MySqlDataAdapter da1 = new MySqlDataAdapter("Select * from tblTest Where stName Like'" + txtSearch.Text + "%'", cl.cnn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtName.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dash frm = new dash();
            frm.Show();
        }
    }
}
