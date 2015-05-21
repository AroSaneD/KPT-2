using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using Client.DataTransferObjects;
using PSI_Forms.Windows;

namespace PSI_Forms.MyWindows
{
    public partial class TaskNewEdit : Form
    {
        private int projectId;
        private List<MilestoneDto> milestones; 

        public TaskNewEdit(int id)
        {
            InitializeComponent();
            LoadResponsiblePersons();
            projectId = id;
        }

        private void LoadResponsiblePersons()
        {
            try
            {
                checkedListBox1.Items.Clear();
                var list = Users.getUsers();
                foreach (var userDto in list)
                {
                    if (userDto.TaskId == null && userDto.TeamId == Controllers.teamid)
                    {
                        checkedListBox1.Items.Add(userDto.Id + ". " + userDto.Firstname);
                    }
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                var ent = new TaskDto()
                {
                    Name = textBox1.Text,
                    CreatedOn =  time,
                    Description = textBox2.Text,
                    EndDate = dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                    ProjectId = this.projectId,
                    Slug = textBox1.Text.ToLower().Replace(' ','_'),
                    TaskPriorityId = 4,
                    TaskStatusId = 1,
                };
                int ids = Tasks.SetTask(ent);
                foreach (string item in checkedListBox1.CheckedItems)
                {
                    var id = Int32.Parse(item.Split('.')[0]);
                    Users.SetTask(id, ids);
                }
                MessageBox.Show("Uzduotis sukurta");
                this.Dispose();
            }
            catch (Exception)
            {
                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var window = new Stages(milestones);
            window.Show();
        }

    }
}
