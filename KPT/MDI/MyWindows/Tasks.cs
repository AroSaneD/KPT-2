using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.DataTransferObjects;
using Npgsql;

namespace PSI_Forms.MyWindows
{
    class Tasks
    {
        public static TaskDto[] getTasks()
        {
            var conn = new NpgsqlConnection(Properties.Resources.connString);
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT Id,Slug,Name,Description,CreatedOn,EndDate,Project_Id FROM tasks",conn);
            var reader = cmd.ExecuteReader();
            List<TaskDto> returnas = new List<TaskDto>();
            while (reader.Read())
            {
                var task = new TaskDto();
                task.Id = Int32.Parse(reader[0].ToString());
                task.Slug = reader[1].ToString();
                task.Name = reader[2].ToString();
                task.Description = reader[3].ToString();
                task.CreatedOn = reader[4].ToString();
                task.EndDate = reader[5].ToString();
                task.ProjectId = Int32.Parse(reader[6].ToString());
                returnas.Add(task);
            }
            conn.Close();
            return returnas.ToArray();
        }

        public static int SetTask(TaskDto task)
        {
            var conn = new NpgsqlConnection(Properties.Resources.connString);
            conn.Open();
            var cmd = new NpgsqlCommand("INSERT INTO tasks(Slug,Name,Description,CreatedOn,EndDate,Project_Id) VALUES" +
                                        "(@slug,@name,@description,@createdon,@enddate,@projectid)", conn);
            cmd.Parameters.AddWithValue("@slug", task.Slug);
            cmd.Parameters.AddWithValue("@name", task.Name);
            cmd.Parameters.AddWithValue("@description", task.Description);
            cmd.Parameters.AddWithValue("@createdon", task.CreatedOn);
            cmd.Parameters.AddWithValue("@enddate", task.EndDate);
            cmd.Parameters.AddWithValue("@projectid", task.ProjectId);
            cmd.ExecuteNonQuery();
            cmd = new NpgsqlCommand("SELECT id FROM tasks WHERE enddate=@enddate", conn);
            cmd.Parameters.AddWithValue("@enddate", task.EndDate);
            var i = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return i;
        }
    }
}
