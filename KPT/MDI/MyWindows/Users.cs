using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.DataTransferObjects;
using Npgsql;

namespace PSI_Forms.MyWindows
{
    static class Users
    {
        public static UserDto[] getUsers()
        {
            var conn = new NpgsqlConnection(Properties.Resources.connString);
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT id,firstname, taskid, teamid FROM users",conn);
            var reader = cmd.ExecuteReader();
            List<UserDto> returnas = new List<UserDto>();
            while (reader.Read())
            {
                var user = new UserDto();
                user.Firstname = reader[1].ToString();
                user.Id = Int32.Parse(reader[0].ToString());
                if (!(reader[2] is DBNull))
                    user.TaskId = Int32.Parse(reader[2].ToString());
                if (!(reader[3] is DBNull))
                    user.TeamId = Int32.Parse(reader[3].ToString());
                returnas.Add(user);
            }
            conn.Close();
            return returnas.ToArray();
        }

        public static void SetTask(int userid, int taskid)
        {
            var conn = new NpgsqlConnection(Properties.Resources.connString);
            conn.Open();
            var cmd = new NpgsqlCommand("UPDATE users SET taskid=@id where id=@userid",conn);
            cmd.Parameters.AddWithValue("@id", taskid);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
