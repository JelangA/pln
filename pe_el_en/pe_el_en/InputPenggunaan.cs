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
    public partial class InputPenggunaan : Form
    {

        Koneksi koneksi = new Koneksi();

        DataSet ds;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlDataReader rd;
        public InputPenggunaan()
        {
            InitializeComponent();
        }

        private void InputPenggunaan_Load(object sender, EventArgs e)
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
            tampildata();
            autoIncrement();
        }

        void cmb()
        {
            //get data IdOrder from database to combobox1 
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            try

            {
                cmd = new MySqlCommand("SELECT DISTINCT TOP 10 Id,OrderId FROM OrderDetaile ORDER BY OrderId", conn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string sName = rd.GetString(1);
                    comboBox1.Items.Add(sName);
                }
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
            conn.Close();
            rd.Close();

        }

        void tampildata()
        {
            try
            {

                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("select * from penggunaan", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "penggunaan");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "penggunaan";
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
            cmd = new MySqlCommand("select id_penggunaan from penggunaan order by id_penggunaan desc", conn);
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
                cmd = new MySqlCommand("insert into penggunaan values('" +
                           textBox1.Text + "','" +
                           textBox2.Text + "','" +
                           textBox3.Text + "','" +
                           textBox4.Text + "','" +
                           textBox5.Text + "','" +
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("update penggunaan set bulan ='" +
                           textBox2.Text + "',tahun='" +
                           textBox3.Text + "',meter_awal='" +
                           textBox4.Text + "',meter_akhir= '" +
                           textBox5.Text + "'where id_penggunaan= '"  +
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
            comboBox1.Text = row.Cells[5].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("delete from penggunaan where id_penggunaan='"
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

        private void button4_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Teknis().Show();
        }
    }
}
