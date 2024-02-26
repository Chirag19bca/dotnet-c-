using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace U4P1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\aaa\Documents\mybca2.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int pos;
        Boolean addmode;
        private void Form1_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from tblbca",con);
            adp = new SqlDataAdapter(cmd);
            ds = new DataSet();
            pos = 0;
            adp.Fill(ds);
           // dataGridView1.DataSource = ds.Tables[0];
            textBox1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            textBox2.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            textBox3.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        }

        private void showdata()
        {
            textBox1.Text = ds.Tables[0].Rows[pos].ItemArray[0].ToString();
            textBox2.Text = ds.Tables[0].Rows[pos].ItemArray[1].ToString();
            textBox3.Text = ds.Tables[0].Rows[pos].ItemArray[2].ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pos = 0;
            showdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            {
                pos = pos - 1;
                showdata();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pos < ds.Tables[0].Rows.Count - 1)
            {
                pos = pos + 1;
                showdata();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pos = ds.Tables[0].Rows.Count - 1;
            showdata();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
           // cmd = new SqlCommand("insert into tblbca values"textBox1.Text", "textBox2.Text","textBox3.Text", con);
            cmd.ExecuteNonQuery();
            textBox1.Focus();
            addmode = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (addmode == true)
            {
                DataRow dt = ds.Tables[0].NewRow();
                dt[0] = textBox1.Text;
                dt[1] = textBox2.Text;
                dt[2] = textBox3.Text;
                ds.Tables[0].Rows.Add(dt);
                adp.Update(ds, "tblbca");
                addmode = false;
            }
            else
            {
                DataRow dt = ds.Tables[0].NewRow();
                dt[0] = textBox1.Text;
                dt[1] = textBox2.Text;
                dt[2] = textBox3.Text;
                adp.Update(ds, "tblbca");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dl;
            dl = MessageBox.Show("Are you sure? Do You Want to delete this record?","Confirm!!!",MessageBoxButtons.YesNo);
            if (dl == DialogResult.Yes)
            {
                ds.Tables[0].Rows[pos].Delete();
                adp.Update(ds,"tblbca");
                pos = 0;
                showdata();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
