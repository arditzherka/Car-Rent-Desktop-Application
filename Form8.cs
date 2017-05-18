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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }


        
        private void button1_Click(object sender, EventArgs e)
        {

           

        }

        private void Form8_Load(object sender, EventArgs e)
        {
           


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form9 customer = new Form9();
            this.Visible = false;
            customer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 booking = new Form10();
            this.Visible = false;
            booking.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form11 delivery = new Form11();
            this.Visible = false;
            delivery.Show();
        }
    }
}
