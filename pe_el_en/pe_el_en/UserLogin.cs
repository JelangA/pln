using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pe_el_en
{
    public partial class UserLogin : Form
    {
        private DataSet ds;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        Koneksi koneksi = new Koneksi();
        public UserLogin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            try
            { 
                cmd = new MySqlCommand("select * from petugas where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", conn);
                rd = cmd.ExecuteReader();
                this.Hide();
                new User().Show();
            }
            catch (Exception)
            {
                MessageBox.Show("username atau password salah");
            }
            conn.Close();
        }
    }
}
