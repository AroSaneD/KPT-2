using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Client;
using Client.Controller;
using Client.DataTransferObjects;
using Client.Properties;
using Octokit;
using PSI_Forms.Controller;
using PSI_Forms.MyWindows;
using PSI_Forms.Windows;

namespace PSI_Forms
{
	public partial class MDIMain : Form
	{
		private int childFormNumber = 0;
		public bool logged = false;
		//private string role = "user";
		private string role = "admin";
        DataTable dt = new DataTable();
	    private NotesController notes;

		public MDIMain()
		{
			InitializeComponent();
            Controllers.Initialize();
		    InitProjects();
		    LoadNotes();
            Thread th = new Thread(LoadChat);
            th.Start();
		}

	    private void LoadNotes()
	    {
	        notes = new NotesController();
            notes.LoadNotes();
	        notesBox.Text = notes.notes;
	    }


	    private void InitProjects()
	    {
            try
            {
                initTable();
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:9000/api/Project");
                using (var response = HttpHelper.GetHttpWebResponse(request))
                {
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    var jss = new JavaScriptSerializer();

                    var projects = jss.Deserialize<ProjectDto[]>(responseString);
                    var row = new object[7];
                    foreach (var projectDto in projects)
                    {
                        row = new object[7];
                        row[0] = projectDto.Id;
                        row[1] = projectDto.Name;
                        row[2] = projectDto.CreatedOn;
                        row[3] = projectDto.ProjectManager;
                        row[4] = getStatusName(projectDto.ProjectStatusId);
                        row[5] = getClientName(projectDto.ClientId);
                        row[6] = getTeamName(projectDto.TeamIds);
                        dt.Rows.Add(row);
                    }
                    row = new object[7];
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
	    }

	    private string getTeamName(int teamIds)
	    {
	        var request = (HttpWebRequest)WebRequest.Create("http://localhost:9000/api/" + "Team/"+teamIds);
			try
			{
				using (var response = HttpHelper.GetHttpWebResponse(request))
				{
					var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

					var jss = new JavaScriptSerializer();

					var teams = jss.Deserialize<TeamDto[]>(responseString);

					foreach (var team in teams)
					{
					    if (teamIds == team.Id)
					        return team.Name;
					}
				    return null;
				}
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
	    }

	    private object getClientName(int clientId)
	    {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:9000/api/" + "Client/" + clientId);
            try
            {
                using (var response = HttpHelper.GetHttpWebResponse(request))
                {
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    var jss = new JavaScriptSerializer();

                    var clients = jss.Deserialize<TeamDto[]>(responseString);

                    foreach (var team in clients)
                    {
                        if (clientId == team.Id)
                            return team.Name;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
	    }

	    private object getStatusName(int projectStatusId)
	    {
	        return "vykdomas";
	    }

	    private void initTable()
	    {
	        dt = new DataTable();
	        dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Pavadinimas", typeof(string));
            dt.Columns.Add("Sukūrimo data", typeof(string));
            dt.Columns.Add("Projekto vadovas", typeof(string));
            dt.Columns.Add("Statusas", typeof(string));
            dt.Columns.Add("Klientas", typeof(string));
            dt.Columns.Add("Komanda", typeof(string));
            var row = new object[7];
            row[0] = 4;
            row[1] = "fake";
            row[2] = "fake";
            row[3] = "fake";
            row[4] = "fake";
            row[5] = "fake";
            row[6] = "fake";
            dt.Rows.Add(row);
            dataGridView1.DataSource = dt;
	    }

	    private void profileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Profile profile = new Profile();
			profile.MdiParent = this;
			profile.WindowState = FormWindowState.Maximized;		// kinda looks good maximized; dont let max other wins
			profile.Show();
		}

        private void notesBox_TextChanged(object sender, EventArgs e)
        {
            notes.saveNotes((System.Windows.Forms.TextBox)sender);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if(grid.SelectedRows.Count == 1)
            {
                DataGridViewRow row = grid.SelectedRows[0];
                var id = (int)row.Cells["Id"].Value;
                var preview = new ProjectPreview(id);
                preview.Show();
            }
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var window = new ProjectNewEdit(false);
            window.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox2.Text != "")
            {
                ChatSystem.WriteMessage(Controllers.User, Controllers.teamid, textBox2.Text);
                textBox2.Text = "";
            }
        }

	    private void LoadChat()
	    {
	        try
	        {
	            while (true)
	            {
	                textBox1.Invoke((MethodInvoker) (() =>
	                {
	                    textBox1.Text = "";
	                    textBox1.Text = ChatSystem.GetMessages();
	                }));
	                Thread.Sleep(5000);
	            }
            }
            catch { }
	    }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox3.Text = "";

            var tasks = Tasks.getTasks();
            foreach (var milestoneDto in tasks)
            {
                if (milestoneDto.EndDate.Substring(8,2) == monthCalendar1.SelectionStart.Day.ToString())
                {
                    textBox3.Text += "Užduotis:" + milestoneDto.Name + Environment.NewLine;
                }
            }
        }
	}

     public static class Controllers
        {
            public static GitController tcontroller;
            public static string User;
            public static int CurrentUser;
            public static int teamid;

            public static void Initialize()
            {
                tcontroller = new GitController();
                CurrentUser = 1;
                teamid = 0;
                User = "admin";
            }

         public static string MakeApiCallGet(string controller, int ?id)
         {
             try
             {
                 HttpWebRequest request;
                 if (id != null)
                 {
                     request =
                         (HttpWebRequest) WebRequest.Create("http://localhost:9000/api/" + controller + "/" + id);
                 }
                 else
                 {
                     request =
                         (HttpWebRequest)WebRequest.Create("http://localhost:9000/api/" + controller);
                 }
                 using (var response = HttpHelper.GetHttpWebResponse(request))
                 {
                     var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                     return responseString;
                 }
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
                 return null;
             }
         }

         public static void MakeApiCallPost(string controller, string data)
         {
             try
             {
                 var url = "http://localhost:9000/api/"+controller;
                 var requestTask = (HttpWebRequest)WebRequest.Create(url);

                 requestTask.Method = "POST";
                 requestTask.ContentType = "application/json";

                 using (var streamWriter = new StreamWriter(requestTask.GetRequestStream()))
                 {
                     streamWriter.Write(data);
                     streamWriter.Flush();
                     streamWriter.Close();

                     using (var httpResponse = HttpHelper.GetHttpWebResponse(requestTask))
                     {
                         if (httpResponse.StatusCode.ToString() == "OK")
                         {
                         }
                         else
                         {
                             MessageBox.Show("Kažkas nutiko");
                         }
                     }
                 }
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
             }
         }

         public static void MakeApiCallPut(string controller, string data)
         {
             try
             {
                 var url = "http://localhost:9000/api/"+controller;
                 var requestTask = (HttpWebRequest)WebRequest.Create(url);

                 requestTask.Method = "PUT";
                 requestTask.ContentType = "application/json";

                 using (var streamWriter = new StreamWriter(requestTask.GetRequestStream()))
                 {
                     streamWriter.Write(data);
                     streamWriter.Flush();
                     streamWriter.Close();

                     using (var httpResponse = HttpHelper.GetHttpWebResponse(requestTask))
                     {
                         if (httpResponse.StatusCode.ToString() == "OK")
                         {
                         }
                         else
                         {
                             MessageBox.Show("Kažkas nutiko");
                         }
                     }
                 }
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
             }
         }
        }
}
