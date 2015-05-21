using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Client.Controller;
using Client.DataTransferObjects;
using PSI_Forms.MyWindows;

namespace PSI_Forms.Windows
{
    public partial class ProjectPreview : Form
    {
        private DataTable dt;
        private int id;

        public ProjectPreview(int id)
        {
            this.id = id;
            InitializeComponent();
            GetProjectDetails(id);
            if (Controllers.User != "admin")
                EditButton.Hide();
            GetTasks(id);
        }

        private void GetTasks(int id)
        {
            try
            {
                    initTable();
                    var tasks = Tasks.getTasks();
                    foreach (var task in tasks)
                    {
                        if (task.ProjectId != this.id)
                            continue;
                        var row = new object[5];
                        row[0] = task.Id;
                        row[1] = task.Name;
                        row[2] = task.CreatedOn;
                        row[3] = task.EndDate;
                        row[4] = GetResponsiblePersonsNames(task.Id);
                        dt.Rows.Add(row);
                    }
                    taskGrid.DataSource = dt;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private string GetResponsiblePersonsNames(int id)
        {
            try
            {
                var pers = Users.getUsers();
                string result = "";
                foreach (var userDto in pers)
                {
                    if (userDto.TaskId != null && userDto.TaskId == id)
                        result += userDto.Firstname + ";";

                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private int getTeam(int id)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:9000/api/" + "Team");
                using (var response = HttpHelper.GetHttpWebResponse(request))
                {
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    var jss = new JavaScriptSerializer();

                    var teams = jss.Deserialize<TeamDto[]>(responseString);
                    foreach (var team in teams)
                    {
                        if (team.Id == id)
                            return team.Id;
                    }
                    return -1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        private void GetProjectDetails(int id)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:9000/api/Project/"+id);
                using (var response = HttpHelper.GetHttpWebResponse(request))
                {
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    var jss = new JavaScriptSerializer();

                    var projects = jss.Deserialize<ProjectDto>(responseString);
                    ProjectName.Text = projects.Name;
                    label1.Text = projects.Description;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void initTable()
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Pavadinimas", typeof(string));
            dt.Columns.Add("Sukūrimo data", typeof(string));
            dt.Columns.Add("Pabaigos data", typeof(string));
            dt.Columns.Add("Atsakingi asmenys", typeof(string));
            var row = new object[5];
            row[0] = 4;
            row[1] = "fake";
            row[2] = "fake";
            row[3] = "fake";
            row[4] = "fake";
            dt.Rows.Add(row);
            taskGrid.DataSource = dt;
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void taskGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (grid.SelectedRows.Count == 1)
            {
                DataGridViewRow row = grid.SelectedRows[0];
                var id = (int)row.Cells["Id"].Value;
                var persons = (string)row.Cells["Atsakingi asmenys"].Value;
                var preview = new TaskPreview(id, persons);
                preview.Closed += preview_Closed;
                preview.Show();
            }
        }

        void preview_Closed(object sender, EventArgs e)
        {
            GetProjectDetails(id);
            if (Controllers.User != "admin")
                EditButton.Hide();
            GetTasks(id);
        }

        private void newTask_Click(object sender, EventArgs e)
        {
            var window = new TaskNewEdit(id);
            window.Show();
        }
    }
}
