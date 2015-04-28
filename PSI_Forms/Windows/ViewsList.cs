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
	public partial class ViewsList : Form
	{
		public ViewsList(string menuChoice, string role)
		{
			InitializeComponent();

			switch (menuChoice)
			{
				case "User":

					winName(menuChoice);
					break;
				case "Team":

					winName(menuChoice);
					break;
				case "Project":

					winName(menuChoice);
					break;
				case "Task":

					winName(menuChoice);
					break;
			}
		}

		private void winName(string name)
		{
			this.Text = "View " + name;
			this.Name = "View " + name;
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
