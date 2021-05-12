using CR.DB_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.BS_Layer
{
    public class BLScore
    {
        private DLMain database;

        public DLMain Database { get => database; set => database = value; }

        public BLScore()
        {
            Database = new DLMain();
        }

        public DataSet getPlayerScore()
        {
            string sqlString = "SELECT TOP(10) PlayerName, Coins, TimeInText " +
                "FROM PlayerScore " +
                "ORDER BY Coins DESC, TimeInNumber ASC";
            return Database.executeQueryDataSet(sqlString, CommandType.Text);
        }

        public bool getPlayerName(string playerName, out int n)
        {
            string sqlString = "SELECT COUNT(*) " +
                "FROM PlayerScore " +
                "WHERE PlayerName = N'" + playerName + "'";
            return Database.myExecuteScalar(sqlString, CommandType.Text, out n);
        }

        public bool getTopOnePlayer(out string name)
        {
            string sqlString = "SELECT TOP(1) PlayerName " +
                "FROM PlayerScore " +
                "ORDER BY Coins DESC, TimeInNumber ASC";            
            return Database.myOtherExecuteScalar(sqlString, CommandType.Text, out name);            
        }

        public bool insertPlayerScore(string playerName, int coins, string timeInText, int timeInNumber)
        {
            string sqlString = "INSERT INTO PlayerScore VALUES (N'" + playerName
                + "', " + coins
                + ", '" + timeInText
                + "', " + timeInNumber + ")";
            return Database.myExecuteNonQuery(sqlString, CommandType.Text);
        }

        public bool updatePlayerScore(string playerName, int coins, string timeInText, int timeInNumber)
        {
            string sqlString = "UPDATE PlayerScore " +
                "SET Coins = " + coins + ", TimeInText = '" + timeInText + "', TimeInNumber = " + timeInNumber +
                " WHERE PlayerName = N'" + playerName + "'";
            return Database.myExecuteNonQuery(sqlString, CommandType.Text);
        }
    }
}
