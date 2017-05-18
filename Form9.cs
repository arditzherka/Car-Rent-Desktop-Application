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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
             if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                string id_no = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                string name = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                string surname = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                string sex = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                string tel = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                string l_no = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                string nationality = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;

                textBox1.Text = id_no;
                textBox2.Text = name;
                textBox3.Text = surname;
                comboBox1.Text = sex;
                textBox4.Text = tel;
                textBox5.Text = l_no;
                comboBox3.Text = nationality;
            }
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");

                SqlCommand InsertCustomer = new SqlCommand();
                InsertCustomer.Connection = connection;
                connection.Open();

                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    InsertCustomer.CommandText = "INSERT INTO customer(name,surname,sex,tel,l_no,nationality) VALUES ('" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox3.Text + "')";
                    InsertCustomer.ExecuteNonQuery();
                    MessageBox.Show("New Customer inserted");
                    string b = "Select *from customer";
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

        private void Form9_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");
            connection.Open();

            SqlDataAdapter adaptor = new SqlDataAdapter("select * from customer", connection);

            DataTable bostablo = new DataTable();

            adaptor.Fill(bostablo);

            dataGridView1.DataSource = bostablo;

            

            SqlCommand adapter = new SqlCommand("select id_no from customer", connection);
            SqlDataReader okuma = adapter.ExecuteReader();
            while (okuma.Read())
            {
                comboBox2.Items.Add(okuma["id_no"].ToString());
            }
            connection.Close();


            

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["id_no"].Value.ToString();
                textBox2.Text = row.Cells["name"].Value.ToString();
                textBox3.Text = row.Cells["surname"].Value.ToString();
                comboBox1.Text = row.Cells["sex"].Value.ToString();
                textBox4.Text = row.Cells["tel"].Value.ToString();
                textBox5.Text = row.Cells["l_no"].Value.ToString();
                comboBox3.Text = row.Cells["nationality"].Value.ToString();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
             if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {

                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");

                connection.Open();

                SqlCommand guncelle = new SqlCommand("update customer set name='" + textBox2.Text.ToString() + "',surname='" + textBox3.Text.ToString() + "',sex='" + comboBox1.Text.ToString() + "',tel='" + textBox4.Text.ToString() + "',l_no='" + textBox5.Text.ToString() + "',nationality='" + comboBox3.Text.ToString() + "' where name='" + textBox2.Text.ToString() + "'", connection);

                int onay = guncelle.ExecuteNonQuery();

                if (onay > 0)
                {

                    MessageBox.Show("The Customer Informatin updated.", "Information of ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SqlDataAdapter ado = new SqlDataAdapter("select * from customer", connection);

                    DataTable bostablo = new DataTable();

                    ado.Fill(bostablo);

                    dataGridView1.DataSource = bostablo;

                    textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; 


                }
                else
                {

                    MessageBox.Show("ERROR");
                }

                connection.Close();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6KIQ8JE\GYLXHANSAITI;Initial Catalog=rentacar;Integrated Security=True");

            connection.Open();
            SqlCommand deleteUser = new SqlCommand("delete from customer where id_no='" + comboBox2.Text + "'", connection);
            int onay = deleteUser.ExecuteNonQuery();
            if (onay > 0)
            {
                MessageBox.Show("Customer deleted");
                comboBox2.Items.Remove(comboBox2.Text);


            }
            connection.Close();
            connection.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("select * from customer", connection);
            DataTable bostablo = new DataTable();
            adaptor.Fill(bostablo);
            dataGridView1.DataSource = bostablo;
            connection.Close();
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 back = new Form8();
            this.Visible = false;
            back.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            this.Visible = false;
           home.Show();
        }
        }
    }

