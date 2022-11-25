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

        koneksi1 koneksi = new koneksi1();

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
            cmd = new MySqlCommand("select * from type_user where username='" + txtEmail.Text + "' and password='" + txtPassword.Text + "'", conn);
            rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                rd.Read();
                if (rd[1].ToString() == "admin")
                {
                    Admin formAdmin = new Admin();
                    formAdmin.Show();
                    this.Hide();
                }
                else if (rd[1].ToString() == "teknisi")
                {
                    Teknis formMenu = new Teknis();
                    formMenu.Show();
                    this.Hide();
                }
                else if (rd[1].ToString() == "pelanggan")
                {
                    User formMenu = new User();
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

    }
}
