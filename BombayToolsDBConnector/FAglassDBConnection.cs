using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BombayToolsDBConnector
{
    public class FAglassDBConnection
    {
        private SqlConnection SqlConn = null;
        public SqlConnection GetConnection
        {
            get { return SqlConn; }
            set { SqlConn = value; }
        }

        //start: defines connection to the sql server, add this connection to the webconfig file
        public FAglassDBConnection()
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["ConString_FAglass"].ConnectionString;
            SqlConn = new SqlConnection(ConnectionString);
        }
        //End: defines connection to the sql server

    }
}
