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
			checkedListBox_Load();
			this.Name = "Add Workers";
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			// save
			this.Dispose();
		}

		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Get selected index, and then make sure it is valid.
			int selected = checkedListBox1.SelectedIndex;
			if (selected != -1)
			{
				this.Text = checkedListBox1.Items[selected].ToString();
			}
		}

		private void checkedListBox_Load()
		{
			/*for ()
			{
				var items = checkedListBox1.Items;
				items.Add();
			}*/
		}
	}
}
