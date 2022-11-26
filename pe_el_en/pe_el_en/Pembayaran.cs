using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pe_el_en
{
    public partial class Pembayaran : Form
    {
        koneksi1 koneksi = new koneksi1();

        DataSet ds;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlDataReader rd;
        public Pembayaran()
        {
            InitializeComponent();
        }

        void tampildata()
        {
            try
            {

                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("select * from tagihan", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "tagihan");
                dataGridViewTarif.DataSource = ds;
                dataGridViewDenda.DataMember = "tagihan";
                conn.Close();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void Pembayaran_Load(object sender, EventArgs e)
        {

        } 

        private void dataGridViewTarif_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridViewTarif.Rows[e.RowIndex];
            txtIdtagihan.Text = row.Cells[0].Value.ToString();

        }
    }
}
