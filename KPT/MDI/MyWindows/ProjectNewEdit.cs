using System;
using System.CodeDom.Compiler;
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
using Client.Properties;
using Octokit;

namespace PSI_Forms.MyWindows
{
    public partial class ProjectNewEdit : Form
    {
        public ProjectNewEdit(bool edit)
        {
            InitializeComponent();
            if (!edit)
            {
                comboBox1.DataSource = getFreeTeams(null);
            }
            else
            {
                button2.Text = "Patvirtinti";
            }
        }

        private List<string> getFreeTeams(int? id)
        {
            try
            {
                HttpWebRequest request;
                if (id != null)
                {
                    request = (HttpWebRequest) WebRequest.Create("http://localhost:9000/api/" + "Team/" + id);
                }
                else
                {
                    request = (HttpWebRequest) WebRequest.Create("http://localhost:9000/api/" + "Team");
                }
                using (var response = HttpHelper.GetHttpWebResponse(request))
                {
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    var jss = new JavaScriptSerializer();

                    var teams = jss.Deserialize<TeamDto[]>(responseString);
                    List<string> list = new List<string>();
                    foreach (var team in teams)
                    {
                        var z = "";
                        z += team.Id + ". ";
                        z += team.Name;
                        list.Add(z);
                    }
                    return list;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (button2.Text == "Sukurti")
                {
                    var json = new JavaScriptSerializer().Serialize(new ProjectDto
                    {
                        Name = textBox1.Text,
                        Description = textBox2.Text,
                        CreatedOn = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                        ProjectManager = Controllers.User,
                        TeamIds = Convert.ToInt32(comboBox1.SelectedItem.ToString().Split('.')[0]),
                        ClientId = 1
                    });
                    var url = "http://localhost:9000/api/Project";
                    var requestTask = (HttpWebRequest) WebRequest.Create(url);

                    requestTask.Method = "POST";
                    requestTask.ContentType = "application/json";

                    using (var streamWriter = new StreamWriter(requestTask.GetRequestStream()))
                    {
                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();

                        using (var httpResponse = HttpHelper.GetHttpWebResponse(requestTask))
                        {
                            if (httpResponse.StatusCode.ToString() == "OK")
                            {
                                MessageBox.Show("Projektas sukurtas");
                                Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Kažkas nutiko");
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
