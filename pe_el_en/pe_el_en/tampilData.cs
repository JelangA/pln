using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace pe_el_en
{
    public partial class tampilData : Form
    {
        public tampilData()
        {
            InitializeComponent();
        }

        DataSet ds;
        MySqlDataAdapter da;
        MySqlCommand cmd;

        Koneksi koneksi = new Koneksi();
        void tamplData()
        {
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            cmd = new MySqlCommand("select * from pelanggan", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds, "pelanggan");
            tabel.DataSource = ds;
            tabel.DataMember = "pelanggan";
            conn.Close();
        }

        private void tampilData_Load(object sender, EventArgs e)
        {
            tamplData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
