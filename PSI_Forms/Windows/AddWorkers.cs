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
	public partial class AddWorkers : Form
	{
		public AddWorkers()
		{
			InitializeComponent();
			this.Name = "Add Workers";
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void saveBtn_Click(object sender, EventArgs e)
		{
			// save
			this.Dispose();
		}
	}
}
