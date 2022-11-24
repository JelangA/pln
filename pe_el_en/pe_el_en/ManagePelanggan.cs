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
    public partial class ManagePelanggan : Form
    {

        private DataSet ds;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        Koneksi koneksi = new Koneksi();

        public ManagePelanggan()
        {
            InitializeComponent();
        }

        private void ManagePelanggan_Load(object sender, EventArgs e)
        {
            bersih();
        }

        void autoIncrement()
        {
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            cmd = new MySqlCommand("select id_pelanggan from pelanggan order by id_pelanggan desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                txtId.Text = (Convert.ToInt32(rd[0].ToString()) + 1).ToString();
                textBox1.Text = (Convert.ToInt32(rd[0].ToString()) + 1).ToString();
            }
            else
            {
                txtId.Text = "1";
                textBox1.Text = "1";
            }
            rd.Close();
            conn.Close();
        }

        void tampildata()
        {
            try
            {

                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("select * from pelanggan", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "pelanggan");
                dataGridViewPelanggan.DataSource = ds;
                dataGridViewPelanggan.DataMember = "pelanggan";
                conn.Close();

            }catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        void bersih()
        {
            txtId.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
            txtNoKwh.Text = "";
            textBox1.Text = "";
            tampildata();
            autoIncrement();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("insert into pelanggan values('" +
                           txtId.Text + "','" +
                           txtNama.Text + "','" +
                           txtAlamat.Text + "','" +
                           txtNoKwh.Text + "','" +
                           textBox1.Text + "')", conn);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("update pelanggan set nama_pelanggan='" +
                           txtNama.Text + "',alamat='" +
                           txtAlamat.Text + "',nomor_kwh='" +
                           txtNoKwh.Text + "'where id_pelanggan= '" +
                           txtId.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("berhasil di edit");
                conn.Close();
                bersih();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("delete from pelanggan where id_pelanggan='"
                    + txtId.Text + "'", conn);
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

        private void btnBatal_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void dataGridViewPelanggan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridViewPelanggan.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtNama.Text = row.Cells[1].Value.ToString();
            txtAlamat.Text = row.Cells[2].Value.ToString();
            txtNoKwh.Text = row.Cells[3].Value.ToString();
            textBox1.Text = row.Cells[4].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Admin().Show();
            this.Close();
        }
    }
}
