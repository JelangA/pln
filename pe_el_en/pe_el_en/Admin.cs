using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pe_el_en
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ManagePelanggans().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new tagihan().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new ManagePetugas().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new TarifDenda().Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Pembayaran().Show();
            this.Hide();
        }
    }
}
