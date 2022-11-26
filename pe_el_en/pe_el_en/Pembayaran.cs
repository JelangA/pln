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
        public Pembayaran()
        {
            InitializeComponent();
        }

        void tampildataTagihan()
        {
            try
            {

                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("select * from tagihan", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "tagihan");
                dataGridViewTagihan.DataSource = ds;
                dataGridViewTagihan.DataMember = "tagihan";
                conn.Close();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        void tampildataPembayaran()
        {
            try
            {

                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("select * from pembayaran", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "pembayaran");
                dataGridViewPembayaran.DataSource = ds;
                dataGridViewPembayaran.DataMember = "pembayaran";
                conn.Close();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        void bersih()
        {
            txtBiayaAdmin.Text = "";
            txtIdDenda.Text = "";
            txtIdTagihan.Text = "";
            txtTotalBayar.Text = "";
            tampildataTagihan();
            tampildataPembayaran();
        }

        private void Pembayaran_Load(object sender, EventArgs e)
        {
            bersih();
        } 

        private void dataGridViewTarif_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridViewTagihan.Rows[e.RowIndex];
            txtIdTagihan.Text = row.Cells[0].Value.ToString();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("insert into pembayaran values('" +
                           dateTimePicker1.Text + "','" +
                           txtIdTagihan.Text + "','" +
                           dateTimePicker1.Text + "','" +
                           txtBiayaAdmin.Text + "','" +
                           txtTotalBayar.Text + "','" +
                           comboBox1.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("berhasil di simpan");
                conn.Close();
                bersih();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("delete from tarif where id_tarif='"
                    + txtTDD.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("berhasil di delete");
                conn.Close();
                bersih();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }
    }
}
