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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
       


        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update car set state_car='" + 1 + "' where plate='" + comboBox1.Text + "'", baglanti);
            int onay = komut.ExecuteNonQuery();
            if (onay > 0)
            {
                MessageBox.Show("Car is delivered");
                comboBox1.Items.Remove(comboBox1.Text);


                SqlConnection baglanti1 = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
                baglanti1.Open();
                SqlDataAdapter ado = new SqlDataAdapter("select * from car where state_car='" + 0 + "'", baglanti1);
                DataTable bos = new DataTable();
                ado.Fill(bos);
                dataGridView1.DataSource = bos;
                baglanti1.Close();



                SqlConnection baglanti2 = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
                baglanti2.Open();
                SqlCommand komut2 = new SqlCommand("select plate from car where durumu='" + 0 + "'", baglanti2);
                SqlDataReader okuma2 = komut.ExecuteReader();
                while (okuma2.Read())
                {
                    comboBox1.Items.Add(okuma2["plate"].ToString());
                }
                baglanti2.Close();
            }

        }

        private void Form11_Load(object sender, EventArgs e)
        {

            {
                SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select plate from car where state_car='" + 0 + "'", baglanti);
                SqlDataReader okuma = komut.ExecuteReader();
                while (okuma.Read())
                {
                    comboBox1.Items.Add(okuma["plate"].ToString());
                }
                baglanti.Close();


                SqlConnection baglanti1 = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
                baglanti1.Open();
                SqlDataAdapter ado = new SqlDataAdapter("select * from car where state_car='" + 0 + "'", baglanti1);
                DataTable bos = new DataTable();
                ado.Fill(bos);
                dataGridView1.DataSource = bos;
                baglanti1.Close();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            this.Visible = false;
            home.Show();
        }
    }
}
