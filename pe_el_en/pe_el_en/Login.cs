using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace pe_el_en
{
    public partial class Login : Form
    {
        private MySqlCommand cmd;
        private MySqlDataReader rd;

        Koneksi koneksi = new Koneksi();

        public Login()
        {
            InitializeComponent();
        }

        void batal()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MySqlConnection conn = koneksi.GetKon();
            conn.Open();
            cmd = new MySqlCommand("select * from petugas where username='" + txtEmail.Text + "' and password='" + txtPassword.Text + "'", conn);
            rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                rd.Read();
                if (rd[6].ToString() == "admin")
                {
                    Admin formAdmin = new Admin();
                    formAdmin.Show();
                    this.Hide();
                }
                else if (rd[6].ToString() == "teknisi")
                {
                    Teknis formMenu = new Teknis();
                    formMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("username atau password salah");
                }
                 
            }else
            {
                MessageBox.Show("username atau password salah");
            }
            rd.Close();
            conn.Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            batal();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new UserLogin().Show();
            this.Hide();
        }
    }
}
