using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace pe_el_en
{
    class koneksi1
    {
        public MySqlConnection GetKon()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;database=pln;username=root;password=";
            return conn;
        }
    }
}
