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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
           
           string sql = "Select * from usr where usr_id=@adi AND usr_password=@sifresi ";
            SqlParameter prm1 = new SqlParameter("adi", textBox1.Text.Trim());
            SqlParameter prm2 = new SqlParameter("sifresi", textBox2.Text.Trim());
            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.Add(prm1);
            komut.Parameters.Add(prm2);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Form8 user = new Form8();
                user.Show();
            }
            else {

                MessageBox.Show("Invalid Login please check username and password");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 hompage = new Form1();
            this.Visible = false;
            hompage.Show();
        }

    }
}