using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace PSI_Forms.Windows
{
    static class ChatSystem
    {
        public static void WriteMessage(string name, int teamid, string message)
        {
            var conn = new NpgsqlConnection(Properties.Resources.connString);
            conn.Open();
            var cmd = new NpgsqlCommand("INSERT INTO messages(name, message, teamid) VALUES(@name, @message,@teamid)",
                conn);
            cmd.Parameters.Add("@name", name);
            cmd.Parameters.Add("@message", message);
            cmd.Parameters.Add("@teamid", teamid);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static string GetMessages()
        {
            var conn = new NpgsqlConnection(Properties.Resources.connString);
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT name, message FROM messages WHERE teamid="+Controllers.teamid+" ORDER BY datecreated DESC",
                conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            string toreturn = "";
            while (reader.Read())
            {
                toreturn += (reader[0] + Environment.NewLine + reader[1] + Environment.NewLine + Environment.NewLine);
            }
            conn.Close();
            return toreturn;
        }
    }
}
