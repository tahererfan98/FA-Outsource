using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace BombayToolsDBConnector
{
    public class OpusProDBConnection
    {
        private SqlConnection SqlConn = null;
        public SqlConnection GetConnection
        {
            get { return SqlConn; }
            set { SqlConn = value; }
        }

        //start: defines connection to the sql server, add this connection to the webconfig file
        public OpusProDBConnection()
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["opusPRON"].ConnectionString;
            SqlConn = new SqlConnection(ConnectionString);
        }
        //End: defines connection to the sql server
    }
}
