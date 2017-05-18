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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                string usr_id = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                string usr_name = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                string usr_surname = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                string usr_password = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                string usr_address = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                string contact_no = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                string usr_email = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;

                textBox1.Text = usr_id;
                textBox2.Text = usr_name;
                textBox3.Text = usr_surname;
                textBox4.Text = usr_password;
                textBox5.Text = usr_address;
                textBox6.Text = contact_no;
                textBox7.Text = usr_email;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["usr_id"].Value.ToString();
                textBox2.Text = row.Cells["usr_name"].Value.ToString();
                textBox3.Text = row.Cells["usr_surname"].Value.ToString();
                textBox4.Text = row.Cells["usr_password"].Value.ToString();
                textBox5.Text = row.Cells["usr_address"].Value.ToString();
                textBox6.Text = row.Cells["contact_no"].Value.ToString();
                textBox7.Text = row.Cells["usr_email"].Value.ToString();
                

            }
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            
            textBox1.Enabled = false;

            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");

            connection.Open();

            SqlDataAdapter ado = new SqlDataAdapter("select * from usr", connection);

            DataTable bostablo = new DataTable();

            ado.Fill(bostablo);

            dataGridView1.DataSource = bostablo;

            connection.Close();

            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = "";

            textBox7.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {

                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");

                connection.Open();

                SqlCommand guncelle = new SqlCommand("update usr set usr_id='" + textBox1.Text.ToString() + "', usr_name='" + textBox2.Text.ToString() + "',usr_surname='" + textBox3.Text.ToString() + "',usr_password='" + textBox4.Text.ToString() + "',usr_address='" + textBox5.Text.ToString() + "',contact_no='" + textBox6.Text.ToString() + "',usr_email='" + textBox7.Text.ToString() + "' where usr_id='" + textBox1.Text.ToString() + "'", connection);

                int onay = guncelle.ExecuteNonQuery();

                if (onay > 0)
                {

                    MessageBox.Show("The User Informatin updated.", "Information of ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SqlDataAdapter ado = new SqlDataAdapter("select * from usr", connection);

                    DataTable bostablo = new DataTable();

                    ado.Fill(bostablo);

                    dataGridView1.DataSource = bostablo;

                    textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = "";

                    textBox7.Text = "";

                }
                else
                {

                    MessageBox.Show("ERROR");
                }

                connection.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 back = new Form3();
            this.Visible = false;
            back.Show();
        }

      
    }
}

