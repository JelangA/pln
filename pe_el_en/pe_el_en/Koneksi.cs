using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace pe_el_en
{
    class Koneksi
    {
        public MySqlConnection GetKon()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=pln;username=root;password=";
            return conn;
        }


    }
}
