using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.DataTransferObjects;

namespace PSI_Forms.Windows
{
    public partial class newMilestone : Form
    {
        public delegate void OnMilestone(MilestoneDto mile);

        private int taskid;
        public event OnMilestone MilestoneCreated;
        public newMilestone(int taskid)
        {
            this.taskid = taskid;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dto = new MilestoneDto()
            {
                EndDate = dateTimePicker1.MinDate,
                Name = textBox1.Text,
                TaskId = this.taskid
            };
            MilestoneCreated(dto);
        }
    }
}
