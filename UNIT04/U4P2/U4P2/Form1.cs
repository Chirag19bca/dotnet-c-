using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace U4P2
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\aaa\Documents\mybca.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        SqlDataReader dr;
        //SqlCommandBuilder cb = new SqlCommandBuilder();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            
            cmd=new SqlCommand("select * from tblbca where username = "+textBox1.Text+"and password = "+textBox2.Text+"",con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("successfully login");
            }
            else
            {
                MessageBox.Show("Invaild username and password");
            }
            con.Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\aaa\Documents\mybca.mdf;Integrated Security=True;Connect Timeout=30");

        }
    }
}
