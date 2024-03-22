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
        public SqlConnection con;
        //SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=bca;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        //SqlCommandBuilder cb = new SqlCommandBuilder();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "select password from tblbca where user='" + textBox1.Text+"'";
            cmd.Connection = con;
            string op;
            op = Convert.ToString(cmd.ExecuteScalar());
            if (op!="")
            {
                if(op==textBox2.Text)
                {
                    MessageBox.Show("Successfully login completed");
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invaild username and password");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Invaild username and password");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=bca;Integrated Security=True;Encrypt=False");
           // con.ConnectionString= "Data Source = localhost\\SQLEXPRESS01; Initial Catalog = bca; Integrated Security = True; Encrypt = False";
            con.Open();
            MessageBox.Show(con.State.ToString());
          //  SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=bca;Integrated Security=True;Encrypt=False");

        }
    }
}
