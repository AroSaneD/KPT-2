using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSI_Forms.Windows
{
	public partial class AddNew : Form
	{
		public AddNew(string menuChoice)
		{
			InitializeComponent();

			switch (menuChoice) {
				case "User":
					label1.Text = "Name";
					label2.Text = "Surname";
					label3.Text = "E-mail";
					label4.Text = "DOB";
					label5.Text = "Position";
					addWorkersBtn.Visible = false;

					winName(menuChoice);
					break;
				case "Team":
					label1.Text = "Name";
					label2.Text = "Workers";
					textBox2.Multiline = true;
					textBox2.ScrollBars = ScrollBars.Vertical;
					textBox2.Height = 55;
					label3.Visible = false;
					label4.Visible = false;
					textBox3.Visible = false;
					dateTimePicker1.Visible = false;
					label5.Visible = false;
					comboBox1.Visible = false;

					winName(menuChoice);
					break;
				case "Project":
					label1.Text = "Name";
					label2.Text = "Description";
					textBox2.Multiline = true;
					textBox2.ScrollBars = ScrollBars.Vertical;
					textBox2.Height = 55;
					label3.Visible = false;
					textBox3.Visible = false;
					label4.Text = "Deadline";
					label5.Text = "Team";

					winName(menuChoice);
					break;
				case "Task" :
					label1.Text = "Name";
					label2.Text = "Description";
					textBox2.Multiline = true;
					textBox2.ScrollBars = ScrollBars.Vertical;
					textBox2.Height = 55;
					label3.Visible = false;
					textBox3.Visible = false;
					label4.Text = "Milestone";
					label5.Visible = false;
					comboBox1.Visible = false;

					winName(menuChoice);
					break;
			}
		}

		private void winName(string name)
		{
			this.Text = "New " + name;
			this.Name = "New " + name;
		}

		private void addWorkersBtn_Click(object sender, EventArgs e)
		{
			AddWorkers newWorkers = new AddWorkers();
			newWorkers.MdiParent = MdiParent;
			newWorkers.Show();

		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void saveBtn_Click(object sender, EventArgs e)
		{
			// save data from textbox, datetimepicker...
			this.Dispose();
		}
	}
}
