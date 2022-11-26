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
        koneksi1 koneksi = new koneksi1();

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
        private string Autoid()
        {
            try
            {
                MySqlConnection conn = koneksi.GetKon();
                conn.Open();
                cmd = new MySqlCommand("select id_tagihan from tagihan order by id_tagihan desc", conn);
                rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    string id = rd["id_tagihan"].ToString();
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
        void bersih()
        {
            textBox1.Text = Autoid().ToString();
            comboBox2.Text = string.Empty;
            comboBox3.Text = string.Empty;
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            tampildata();
            cmbPenggunaan();
            cmbDenda();
            cmbTarif();
            //autoIncrement();
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

        void cmbPenggunaan()
        {
            //get data IdOrder from database to combobox1 
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            try

            {
                cmd = new MySqlCommand("select * from penggunaan", conn);
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

        void cmbDenda()
        {
            //get data IdOrder from database to combobox1 
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            try

            {
                cmd = new MySqlCommand("select * from denda", conn);
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
        void cmbTarif()
        {
            //get data IdOrder from database to combobox1 
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            try

            {
                cmd = new MySqlCommand("select * from tarif", conn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string sName = rd.GetString(0);
                    comboBox3.Items.Add(sName);
                }
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
            conn.Close();
            rd.Close();

        }

        //void autoIncrement()
        //{
        //    MySqlConnection conn = koneksi.GetKon();
        //    conn.Open();
        //    cmd = new MySqlCommand("select id_tagihan from tagihan order by id_tagihan desc", conn);
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
                cmd = new MySqlCommand("insert into tagihan values('" +
                           textBox1.Text + "','" +
                           comboBox1.Text + "','" +
                           comboBox2.Text + "','" +
                           comboBox3.Text + "','" +
                           textBox4.Text + "','" +
                           textBox5.Text + "','" +
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
            //try
            //{
            //    MySqlConnection conn = koneksi.GetKon();
            //    conn.Open();
            //    cmd = new MySqlCommand("update tagihan set id_tagihan ='" +
            //               comboBox1.Text + "',id_penggunaan='" +
            //               comboBox1.Text + "',id_tarif='" +
            //               textBox2.Text + "',id_denda='" +
            //               textBox3.Text + "',tanggal_bayar= '" +
            //               textBox4.Text + "',jml_daya_terpakai= '" +
            //               textBox5.Text + "',status= '" +
            //               textBox7.Text + "'where id_tagihan= '" +
            //               textBox1.Text + "'", conn);
            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("berhasil di edit");
            //    conn.Close();
            //    bersih();
            //}
            //catch (Exception x)
            //{
            //    MessageBox.Show(x.ToString());
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();
            comboBox2.Text = row.Cells[1].Value.ToString();
            comboBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            comboBox1.Text = row.Cells[5].Value.ToString();
            textBox7.Text = row.Cells[6].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin().Show();
        }
    }
}
