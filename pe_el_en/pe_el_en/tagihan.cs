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
    public partial class tagihan : Form
    {
        Koneksi koneksi = new Koneksi();

        DataSet ds;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlDataReader rd;
        public tagihan()
        {
            InitializeComponent();
        }

        private void tagihan_Load(object sender, EventArgs e)
        {
            bersih();
        }

        void bersih()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            tampildata();
            autoIncrement();
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
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tagihan";
                conn.Close();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        void autoIncrement()
        {
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            cmd = new MySqlCommand("select id_tagihan from tagihan order by id_tagihan desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                textBox1.Text = (Convert.ToInt32(rd[0].ToString()) + 1).ToString();
            }
            else
            {
                textBox1.Text = "1";
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
                cmd = new MySqlCommand("insert into tagihan values('" +
                           textBox1.Text + "','" +
                           textBox2.Text + "','" +
                           textBox3.Text + "','" +
                           textBox4.Text + "','" +
                           textBox5.Text + "','" +
                           textBox6.Text + "','" +
                           textBox7.Text + "')", conn);
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

        private void button4_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("delete from tagihan where id_tagihan='"
                    + textBox1.Text + "'", conn);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("update penggunaan set id_penggunaan ='" +
                           textBox2.Text + "',id_tarif='" +
                           textBox3.Text + "',id_denda='" +
                           textBox4.Text + "',tanggal_bayar= '" +
                           textBox5.Text + "',jml_daya_terpakai= '" +
                           textBox6.Text + "',status= '" +
                           textBox7.Text + "'where id_tagihan= '" +
                           textBox1.Text + "'", conn);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[5].Value.ToString();
            textBox7.Text = row.Cells[6].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin().Show();
        }
    }
}
