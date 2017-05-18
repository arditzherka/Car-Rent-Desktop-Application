using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_RentCar
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 add_user = new Form4();
            this.Visible = false;
            add_user.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 delete_user = new Form5();
            this.Visible = false;
            delete_user.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 update_user = new Form6();
            this.Visible = false;
            update_user.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            this.Visible = false;
            home.Show();
        }
    }
}
