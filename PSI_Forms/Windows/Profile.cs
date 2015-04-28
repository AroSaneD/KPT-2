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
	public partial class Profile : Form
	{
		public Profile()
		{
			InitializeComponent();
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void editBtn_Click(object sender, EventArgs e)
		{
			textBox1.Enabled = true;
			dateTimePicker1.Enabled = true;
			comboBox1.Enabled = true;
			pictureBox1.Enabled = true;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			openFileDialog.Filter = "Image Files (*.jpg; *.png)|*.jpg; *.png|All Files (*.*)|*.*";
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				pictureBox1.BackgroundImage = System.Drawing.Image.FromFile(openFileDialog.FileName);
			}
		}
	}
}
