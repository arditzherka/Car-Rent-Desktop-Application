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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value + "";
          

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {

                SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
                baglanti.Open();
                SqlCommand ekleme = new SqlCommand("insert into booking1 (plate,id_no,usr_id,r_date,d_date,price) values(@plate,@id_no,@usr_id,@r_date,@d_date,@price)", baglanti);

                ekleme.Parameters.AddWithValue("@plate", comboBox1.Text);
                ekleme.Parameters.AddWithValue("@id_no", comboBox2.Text);
                ekleme.Parameters.AddWithValue("@usr_id", comboBox3.Text);
                ekleme.Parameters.AddWithValue("@r_date", dateTimePicker1.Text);
                ekleme.Parameters.AddWithValue("@d_date", dateTimePicker2.Text);
                ekleme.Parameters.AddWithValue("@price", textBox1.Text);
               
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                ekleme.ExecuteNonQuery();
                int onay = ekleme.ExecuteNonQuery();
                if (onay > 0)
                {
                    baglanti.Close();
                    SqlConnection baglanti1 = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
                    baglanti1.Open();
                    SqlCommand guncelle = new SqlCommand("update car set state_car='" + 0 + "' where plate='" + comboBox1.Text + "'", baglanti1);
                    guncelle.ExecuteNonQuery();

                    MessageBox.Show("Car is rented");
                    textBox1.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    

                    SqlDataAdapter dtgr = new SqlDataAdapter("select * from car where state_car='" + 0 + "'", baglanti1);
                    DataTable bostablom = new DataTable();
                    dtgr.Fill(bostablom);
                    dataGridView1.DataSource = bostablom;
                    baglanti1.Close();

                }
                baglanti.Close();
            }

            else
            {
                MessageBox.Show("ERROR,Please try once again", "ERROR Message");
            }

        }

        private void Form10_Load(object sender, EventArgs e)
        {
           
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
            baglanti.Open();

            SqlCommand adapter = new SqlCommand("select plate from car", baglanti);
            SqlDataReader okuma = adapter.ExecuteReader();
            while (okuma.Read())
            {
                comboBox1.Items.Add(okuma["plate"].ToString());
            }
            baglanti.Close();
            dateTimePicker1.MinDate = DateTime.Now;

            //comboBox1.Enabled = false;
            baglanti.Open();

            SqlCommand adapter1 = new SqlCommand("select id_no from customer", baglanti);
            SqlDataReader okuma1 = adapter1.ExecuteReader();
            while (okuma1.Read())
            {
                comboBox2.Items.Add(okuma1["id_no"].ToString());
            }
            baglanti.Close();
            baglanti.Open();

            SqlCommand adapter2 = new SqlCommand("select usr_id from usr", baglanti);
            SqlDataReader okuma2 = adapter2.ExecuteReader();
            while (okuma2.Read())
            {
                comboBox3.Items.Add(okuma2["usr_id"].ToString());
            }
            baglanti.Close();
            
            baglanti.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("select * from car where state_car='" + 1 + "'", baglanti);
            DataTable bostablo = new DataTable();
            adaptor.Fill(bostablo);
            dataGridView1.DataSource = bostablo;
            baglanti.Close();

           
           
        }

      

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DateTime d2 = dateTimePicker1.Value;
            DateTime d1 = dateTimePicker2.Value;

           

            double time1 = (d1 - d2).TotalDays;

            int days = Convert.ToInt32(time1);

           
            SqlConnection baglanti1 = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
             int total,price;
            
            string query  =@"select price from car where plate = '" + comboBox1.SelectedItem + "'";
           
            SqlCommand cmd = new SqlCommand(query, baglanti1);
            
            baglanti1.Open();
            price = Convert.ToInt32(cmd.ExecuteScalar());
            total = price * days;
       
          SqlDataReader  dr = cmd.ExecuteReader();
         
          
            while (dr.Read())
            {
              
                textBox1.Text = total.ToString();

            }
            
            baglanti1.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 back = new Form8();
            this.Visible = false;
            back.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            this.Visible = false;
            home.Show();
        }

       

    }
}
