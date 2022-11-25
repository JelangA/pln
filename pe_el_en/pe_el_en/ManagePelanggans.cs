using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pe_el_en
{
    public partial class ManagePelanggans : Form
    {
        private DataSet ds;
        private MySqlCommand cmd, cmd2;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        koneksi1 koneksi = new koneksi1();
        public ManagePelanggans()
        {
            InitializeComponent();
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
            }
            else
            {
                txtId.Text = "3001";
            }
            rd.Close();
            conn.Close();
        }

        void autoIncrementIduser()
        {
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            cmd = new MySqlCommand("select id_user from type_user order by id_user desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                txtIdUser.Text = (Convert.ToInt32(rd[0].ToString()) + 1).ToString();
            }
            else
            {
                txtIdUser.Text = "1001";
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
                cmd = new MySqlCommand(
                    "select * from pelanggan,type_user where pelanggan.id_user = type_user.id_user", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "pelanggan");
                dataGridViewPelanggan.DataSource = ds;
                dataGridViewPelanggan.DataMember = "pelanggan";
                conn.Close();

            }
            catch (Exception x)
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
            txtIdUser.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            tampildata();
            autoIncrement();
            autoIncrementIduser();

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("insert into type_user values('" +
                           txtIdUser.Text + "','pelanggan','" +
                           txtUsername.Text + "','" +
                           txtPassword.Text + "')", conn);
                cmd.ExecuteNonQuery();
                cmd2 = new MySqlCommand("insert into pelanggan values('" +
                           txtId.Text + "','" +
                           txtNama.Text + "','" +
                           txtAlamat.Text + "','" +
                           txtNoKwh.Text + "','" +
                           txtIdUser.Text + "')", conn);
                cmd2.ExecuteNonQuery();
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
                cmd = new MySqlCommand("UPDATE type_user SET username='" +
                    txtUsername.Text +"',password='" + 
                    txtPassword.Text + "'WHERE id_user='" + 
                    txtIdUser.Text + "'", conn);
                cmd.ExecuteNonQuery();
                cmd2 = new MySqlCommand("update pelanggan set nama_pelanggan='" +
                           txtNama.Text + "',alamat='" +
                           txtAlamat.Text + "',nomor_kwh='" +
                           txtNoKwh.Text + "'where id_pelanggan='" +
                           txtId.Text + "'", conn);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("berhasil di simpan");
                conn.Close();
                bersih();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void dataGridViewPelanggan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridViewPelanggan.Rows[e.RowIndex];
            txtId.Text = row.Cells["id_pelanggan"].Value.ToString();
            txtNama.Text = row.Cells["nama_pelanggan"].Value.ToString();
            txtAlamat.Text = row.Cells["alamat"].Value.ToString();
            txtNoKwh.Text = row.Cells["nomor_kwh"].Value.ToString();
            txtIdUser.Text = row.Cells["id_user"].Value.ToString();
            txtUsername.Text = row.Cells["username"].Value.ToString();
            txtPassword.Text = row.Cells["password"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd2 = new MySqlCommand("delete from pelanggan where id_pelanggan='"
                   + txtId.Text + "'", conn);
                cmd2.ExecuteNonQuery();
                cmd = new MySqlCommand("delete from type_user where id_user='"
                    + txtIdUser.Text + "'", conn);
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

        private void button1_Click(object sender, EventArgs e)
        {
            new Admin().Show();
            this.Hide();
        }

        private void ManagePelanggans_Load(object sender, EventArgs e)
        {
            bersih();
        }
    }
}
