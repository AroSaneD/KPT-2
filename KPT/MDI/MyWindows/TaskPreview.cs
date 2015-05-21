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

namespace PSI_Forms.MyWindows
{
    public partial class TaskPreview : Form
    {
        private DataTable dt;

        public TaskPreview(int id, string persons)
        {
            InitializeComponent();
            GetTaskDetails(id, persons);
            GetMilestones(id);
        }

        private void GetTaskDetails(int id, string persons)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:9000/api/Task/" + id);
                using (var response = HttpHelper.GetHttpWebResponse(request))
                {
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    var jss = new JavaScriptSerializer();

                    var projects = jss.Deserialize<TaskDto[]>(responseString);
                    foreach (var projectDto in projects)
                    {
                        label1.Text = projectDto.Name;
                        textBox1.Text = projectDto.Description;
                        resPersons.Text = persons;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void GetMilestones(int id)
        {
            try
            {
                initTable();
                var request =
                    (HttpWebRequest)
                        WebRequest.Create("http://localhost:9000/api/Milestones/" +
                                          id);
                using (var response = HttpHelper.GetHttpWebResponse(request))
                {
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    var jss = new JavaScriptSerializer();

                    var milestones = jss.Deserialize<MilestoneDto[]>(responseString);
                    foreach (var milestone in milestones)
                    {
                        var row = new object[6];
                        row[0] = milestone.Id;
                        row[1] = milestone.Name;
                        row[2] = milestone.EndDate;
                        dt.Rows.Add(row);
                    }
                    milestoneGrid.DataSource = dt;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void initTable 
            ()
            {
                dt = new DataTable();
                dt.Columns.Add("Id", typeof (int));
                dt.Columns.Add("Pavadinimas", typeof (string));
                dt.Columns.Add("Pabaigos data", typeof (string));
                var row = new object[6];
                row[0] = 4;
                row[1] = "fake";
                row[2] = "fake";
                dt.Rows.Add(row);
                milestoneGrid.DataSource = dt;
            }
        
    }
}
