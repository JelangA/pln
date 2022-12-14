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
    public partial class ManagePetugas : Form
    {
        private DataSet ds;
        private MySqlCommand cmd, cmd2;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        koneksi1 koneksi = new koneksi1();
        public ManagePetugas()
        {
            InitializeComponent();
        }

        void autoIncrementpetugas()
        {
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            cmd = new MySqlCommand("select id_petugas from petugas order by id_petugas desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                txtId.Text = (Convert.ToInt32(rd[0].ToString()) + 1).ToString();      
            }
            else
            {
                txtId.Text = "2001";
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
                    "select * from petugas,type_user where petugas.id_user = type_user.id_user", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "petugas");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "petugas";
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
            txtIdUser.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            comboBox1.Text = String.Empty;
            tampildata();
            autoIncrementIduser();
            autoIncrementpetugas();

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("insert into type_user values('" +
                           txtIdUser.Text + "','" +
                           comboBox1.Text + "','" +
                           txtUsername.Text + "','" +
                           txtPassword.Text + "')", conn);
                cmd.ExecuteNonQuery();
                cmd2 = new MySqlCommand("insert into petugas values('" +
                           txtId.Text + "','" +
                           txtNama.Text + "','" +
                           txtNotelpon.Text + "','" +
                           comboBox1.Text + "','" +
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtId.Text = row.Cells["id_petugas"].Value.ToString();
            txtNama.Text = row.Cells["nama"].Value.ToString();
            txtNotelpon.Text = row.Cells["no_telpon"].Value.ToString();
            txtIdUser.Text = row.Cells["id_user"].Value.ToString();
            txtUsername.Text = row.Cells["username"].Value.ToString();
            txtPassword.Text = row.Cells["password"].Value.ToString();
            comboBox1.Text = row.Cells["type_user"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd2 = new MySqlCommand("delete from petugas where id_petugas='"
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("UPDATE type_user SET type_user='" +
                    comboBox1.Text + "',username='" +
                    txtUsername.Text + "',password='" +
                    txtPassword.Text + "'WHERE id_user='" +
                    txtIdUser.Text + "'", conn);
                cmd.ExecuteNonQuery();
                cmd2 = new MySqlCommand("update petugas set nama='" +
                           txtNama.Text + "',no_telpon='" +
                           txtNotelpon.Text + "',jabatan='" +
                           comboBox1.Text + "'where id_petugas='" +
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

        private void button1_Click(object sender, EventArgs e)
        {
            new Admin().Show();
            this.Hide();
        }

        private void ManagePetugas_Load(object sender, EventArgs e)
        {
            bersih();
        }
    }
}
