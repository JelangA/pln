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
    public partial class TarifDenda : Form
    {
        koneksi1 koneksi = new koneksi1();

        DataSet ds;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlDataReader rd;

        public TarifDenda()
        {
            InitializeComponent();
        }

        void bersih1()
        {
            txtIdTarif.Text = "";
            txtTarif.Text = "";
            txtDaya.Text="";

            tampildataTarif();
            autoIncrement1();

        }

        void bersih2()
        {
            txtIdDenda.Text = "";
            txtDenda.Text = "";

            tampildataDenda();
            autoIncrement2();
        }

        void tampildataTarif()
        {
            try
            {

                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("select * from tarif", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "tarif");
                dataGridViewTarif.DataSource = ds;
                dataGridViewTarif.DataMember = "tarif";
                conn.Close();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        void tampildataDenda()
        {
            try
            {

                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("select * from denda", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "denda");
                dataGridViewDenda.DataSource = ds;
                dataGridViewDenda.DataMember = "denda";
                conn.Close();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        void autoIncrement1()
        {
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            cmd = new MySqlCommand("select id_tarif from tarif order by id_tarif desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                txtIdTarif.Text = (Convert.ToInt32(rd[0].ToString()) + 1).ToString();
            }
            else
            {
                txtIdTarif.Text = "8001";
            }
            rd.Close();
            conn.Close();
        }
        void autoIncrement2()
        {
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            cmd = new MySqlCommand("select id_denda from denda order by id_denda desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                txtIdDenda.Text = (Convert.ToInt32(rd[0].ToString()) + 1).ToString();
            }
            else
            {
                txtIdDenda.Text = "9001";
            }
            rd.Close();
            conn.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("insert into tarif values('" +
                           txtIdTarif.Text + "','" +
                           txtDaya.Text + "','" +
                           txtTarif.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("berhasil di simpan");
                conn.Close();
                bersih1();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("update tarif set daya='" +
                           txtDaya.Text + "',tarifperkwh='" +
                           txtTarif.Text + "'where id_tarif='" +
                           txtIdTarif.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("berhasil di edit");
                conn.Close();
                bersih1();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("delete from tarif where id_tarif='"
                    + txtIdTarif.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("berhasil di delete");
                conn.Close();
                bersih1();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bersih1();
        }

        private void TarifDenda_Load(object sender, EventArgs e)
        {
            bersih2();
            bersih1();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("insert into denda values('" +
                           txtIdDenda.Text + "','" +
                           txtDenda.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("berhasil di simpan");
                conn.Close();
                bersih2();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("update denda set jumlah_denda='" +
                           txtDenda.Text + "'where id_denda='" +
                           txtIdDenda.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("berhasil di edit");
                conn.Close();
                bersih2();
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
                cmd = new MySqlCommand("delete from denda where id_denda='"
                    + txtIdDenda.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("berhasil di delete");
                conn.Close();
                bersih2();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bersih2();
        }

        private void dataGridViewTarif_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridViewTarif.Rows[e.RowIndex];
            txtIdTarif.Text = row.Cells[0].Value.ToString();
            txtDaya.Text = row.Cells[1].Value.ToString();
            txtTarif.Text = row.Cells[2].Value.ToString();
        }

        private void dataGridViewDenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridViewDenda.Rows[e.RowIndex];
            txtIdDenda.Text = row.Cells[0].Value.ToString();
            txtDenda.Text = row.Cells[1].Value.ToString();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Admin().Show();
            this.Hide();
        }
    }
}
