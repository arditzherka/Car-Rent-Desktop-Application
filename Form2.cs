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


namespace new_RentCar
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
            con.Open();
            string id = textBox1.Text;
            string pass = textBox2.Text;
            SqlCommand cmd = new SqlCommand("select id,pass from adm where id='" + textBox1.Text + "'and pass='" + textBox2.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("Login sucess Welcome");
                Form3 usr = new Form3();
                this.Visible = false;
                usr.Show();

            }
            else
            {

                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 back = new Form1();
            this.Visible = false;
            back.Show();
        }

        
    }
}
