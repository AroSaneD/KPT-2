using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Client.DataTransferObjects;

namespace PSI_Forms.Windows
{
	public partial class Stages : Form
	{
	    private List<MilestoneDto> miles;
	    private int taskid;

	    public Stages(List<MilestoneDto> milestones)
	    {
	        label1.Visible = false;
			InitializeComponent();
		    this.taskid = taskid;
		    miles = milestones;
		    fillMilestones();
		}

	    private void fillMilestones()
	    {
	        var result = Controllers.MakeApiCallGet("Milestones", null);
	        var milestones = new JavaScriptSerializer().Deserialize<MilestoneDto[]>(result);
            listView1.Items.Clear();
	        foreach (var milestoneDto in milestones)
	        {
	            if (milestoneDto.TaskId == taskid)
	            {
	                var item =
	                    new ListViewItem(new [] {milestoneDto.Name, milestoneDto.EndDate.ToString("yyyy-MM-dd")});
	                listView1.Items.Add(item);
	            }
	        }
	    }

	    private void okBtn_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            var window = new newMilestone(taskid);
            window.MilestoneCreated += window_MilestoneCreated;
            window.Show();
        }

        void window_MilestoneCreated(MilestoneDto mile)
        {
            Controllers.MakeApiCallPost("Milestone", new JavaScriptSerializer().Serialize(mile));
            fillMilestones();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView z = (ListView) sender;
            var value = z.SelectedItems[0].Text;
            PrintToPrinter(value);
        }

	    private void PrintToPrinter(string value)
	    {
            label1.Visible = true;
	        Thread.Sleep(1000);
            label1.Visible = false;
	    }
	}
}
