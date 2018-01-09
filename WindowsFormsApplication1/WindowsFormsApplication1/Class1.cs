using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public class Class1
    {
        //public MySqlConnection cnn = new MySqlConnection("Server=192.168.0.8;Database=cc;Uid=root;Pwd=123;Encrypt=true;");
        public MySqlConnection cnn = new MySqlConnection("Server=192.168.0.8;Database=cc;Uid=root;Pwd=123;Encrypt=true;Character Set=utf8");
        
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataAdapter da = new MySqlDataAdapter();
        public  string sql="";
        public static bool add;
        public static bool update;
        public static MySqlDataReader dr;
        public static string id;
        public static string cateName;



    }
}
