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

        koneksi1 koneksi = new koneksi1();

        DataSet ds;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlDataReader rd;
        public InputPenggunaan()
        {
            InitializeComponent();
        }
        private string Autoid()
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("select id_penggunaan from penggunaan order by id_penggunaan desc", conn);
                rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    string id = rd[0].ToString();
                    string angka = id.Substring(4, 4);
                    int num = Convert.ToInt32(angka) + 1;
                    string result = num.ToString();
                    if (result.Length == 1)
                    {
                        result = "000" + result;
                    }
                    else if (result.Length == 2)
                    {
                        result = "00" + result;
                    }
                    else if (result.Length == 3)
                    {
                        result = "0" + result;
                    }
                    else if (result.Length == 4)
                    {
                        result = "" + result;
                    }
                    string tanggal = DateTime.Now.ToString("ddMM");
                    string result2 = tanggal + result;
                    return result2;
                }
                else
                {
                    string result = "0001";
                    string tanggal = DateTime.Now.ToString("ddMM");
                    string result2 = tanggal + result;
                    return result2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        } 
        private void InputPenggunaan_Load(object sender, EventArgs e)
        {
            bersih();
        }

        void cmbPelanggan()
        {
            //get data IdOrder from database to combobox1 
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            try

            {
                cmd = new MySqlCommand("select * from pelanggan", conn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string sName = rd.GetString(0);
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

        void cmbPetugas()
        {
            //get data IdOrder from database to combobox1 
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            try

            {
                cmd = new MySqlCommand("select * from petugas", conn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string sName = rd.GetString(0);
                    comboBox2.Items.Add(sName);
                }
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
            conn.Close();
            rd.Close();
        }

        void bersih()
        {
            txtId.Text = Autoid().ToString();
            txtBulan.Text = "";
            txttahun.Text = "";
            txtAwal.Text = "";
            txtAkhir.Text = "";
            comboBox1.Text = string.Empty; 
            comboBox2.Text = string.Empty;
            tampildata();
            cmbPelanggan();
            cmbPetugas();
        }

        //void cmb()
        //{
        //    //get data IdOrder from database to combobox1 
        //    MySqlConnection conn = koneksi.GetKon();
        //    conn.Open();
        //    try

        //    {
        //        cmd = new MySqlCommand("SELECT DISTINCT TOP 10 Id,OrderId FROM OrderDetaile ORDER BY OrderId", conn);
        //        rd = cmd.ExecuteReader();
        //        while (rd.Read())
        //        {
        //            string sName = rd.GetString(1);
        //            comboBox1.Items.Add(sName);
        //        }
        //    }
        //    catch (Exception g)
        //    {
        //        MessageBox.Show(g.Message);
        //    }
        //    conn.Close();
        //    rd.Close();

        //}

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

        //void autoIncrement()
        //{
        //    MySqlConnection conn = koneksi.GetKon();
        //    conn.Open();
        //    cmd = new MySqlCommand("select id_penggunaan from penggunaan order by id_penggunaan desc", conn);
        //    rd = cmd.ExecuteReader();
        //    rd.Read();
        //    if (rd.HasRows)
        //    {
        //        textBox1.Text = (Convert.ToInt32(rd[0].ToString()) + 1).ToString();
        //    }
        //    else
        //    {
        //        textBox1.Text = "1";
        //    }
        //    rd.Close();
        //    conn.Close();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("insert into penggunaan values('" +
                           txtId.Text + "','" +
                           txtBulan.Text + "','" +
                           txttahun.Text + "','" +
                           txtAwal.Text + "','" +
                           txtAkhir.Text + "','" +
                           comboBox1.Text + "','" +
                           comboBox2.Text + "')", conn);
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
                           txtBulan.Text + "',tahun='" +
                           txttahun.Text + "',meter_awal='" +
                           txtAwal.Text + "',meter_akhir= '" +
                           txtAkhir.Text + "',id_pelanggan= '" +
                           comboBox1.Text + "',id_petugas= '" +
                           comboBox2.Text + "'where id_penggunaan= '"  +
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtId.Text = row.Cells["id_penggunaan"].Value.ToString();
            txtBulan.Text = row.Cells["bulan"].Value.ToString();
            txttahun.Text = row.Cells["tahun"].Value.ToString();
            txtAwal.Text = row.Cells["meter_awal"].Value.ToString();
            txtAkhir.Text = row.Cells["meter_akhir"].Value.ToString();
            comboBox1.Text = row.Cells["id_pelanggan"].Value.ToString();
            comboBox2.Text = row.Cells["id_petugas"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("delete from penggunaan where id_penggunaan='"
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
