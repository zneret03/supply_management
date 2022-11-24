using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace supply_management.Model
{
    class ConnectionSql
    {

        public String connection()
        {
            String constring = "datasource=localhost;port=3306;username=root;password=;database=supply;SslMode=None";
            return constring;
        }

    }
}
