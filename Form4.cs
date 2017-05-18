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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");

                SqlCommand InsertUser = new SqlCommand();
                InsertUser.Connection = connection;
                connection.Open();

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                {
                    InsertUser.CommandText = "INSERT INTO usr(usr_id,usr_name,usr_surname,usr_password,usr_address,contact_no,usr_email) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                    InsertUser.ExecuteNonQuery();
                    MessageBox.Show("New User inserted");
                    string b = "Select *from usr";
                    SqlDataAdapter d = new SqlDataAdapter(b, connection);
                    DataTable t = new DataTable();
                    d.Fill(t);
                    DataSet f = new DataSet();
                    f.Tables.Add(t);
                    bindingSource1.DataSource = f;
                    bindingSource1.DataMember = f.Tables[0].TableName;
                    dataGridView1.DataSource = bindingSource1;
                    connection.Close();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    

                }
                else
                {

                    MessageBox.Show("Please fill all required fields");
                }
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
            connection.Open();

            SqlDataAdapter adaptor = new SqlDataAdapter("select * from usr", connection);

            DataTable bostablo = new DataTable();

            adaptor.Fill(bostablo);

            dataGridView1.DataSource = bostablo;

            connection.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 usr = new Form3();
            this.Visible = false;
            usr.Show();
        }
    }
}
