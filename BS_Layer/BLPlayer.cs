using CR.DB_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.BS_Layer
{
    public class BLPlayer
    {
        private DLMain database;

        public DLMain Database { get => database; set => database = value; }

        public BLPlayer()
        {
            Database = new DLMain();
        }

        public bool getPlayer(string playerName, string password, out int n)
        {
            string sqlString = "SELECT COUNT(*) FROM PlayerList WHERE PlayerName = N'" + playerName
                + "' AND Password = '" + password + "'";
            return Database.myExecuteScalar(sqlString, CommandType.Text, out n);
        }

        public bool getPlayerName(string playerName, out int n)
        {
            string sqlString = "SELECT COUNT(*) FROM PlayerList WHERE PlayerName = N'" + playerName + "'";
            return Database.myExecuteScalar(sqlString, CommandType.Text, out n);
        }

        public bool insertPlayer(string playerName, string password)
        {            
            string sqlString = "INSERT INTO PlayerList VALUES (N'" + playerName
                + "', '" + password + "')";
            return Database.myExecuteNonQuery(sqlString, CommandType.Text);
        }
    }
}
