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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

       
        private void Form5_Load(object sender, EventArgs e)
        {
            
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();
            SqlCommand adapter = new SqlCommand("select usr_id from usr", baglanti);
            SqlDataReader okuma = adapter.ExecuteReader();
            while (okuma.Read())
            {
                comboBox1.Items.Add(okuma["usr_id"].ToString());
            }
            baglanti.Close();


            baglanti.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("select * from usr", baglanti);
            DataTable bostablo = new DataTable();
            adaptor.Fill(bostablo);
            dataGridView1.DataSource = bostablo;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 usr = new Form3();
            this.Visible = false;
            usr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");

            connection.Open();
            SqlCommand deleteUser = new SqlCommand("delete from usr where usr_id='" + comboBox1.Text + "'", connection);
            int onay = deleteUser.ExecuteNonQuery();
            if (onay > 0)
            {
                MessageBox.Show("User deleted");
                comboBox1.Items.Remove(comboBox1.Text);


            }
            connection.Close();
            connection.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("select * from usr", connection);
            DataTable bostablo = new DataTable();
            adaptor.Fill(bostablo);
            dataGridView1.DataSource = bostablo;
            connection.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form3 back = new Form3();
            this.Visible = false;
            back.Show();
        }

       

       


        }

       

        }
 
