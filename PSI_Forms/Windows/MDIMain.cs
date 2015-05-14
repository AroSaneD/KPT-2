using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSI_Forms.Windows;

namespace PSI_Forms
{
	public partial class MDIMain : Form
	{
		private int childFormNumber = 0;
		public bool logged = false;
		//private string role = "user";
		private string role = "admin";

		public MDIMain()
		{
			InitializeComponent();
			timer.Start();

			Login loginCForm = new Login();
			loginCForm.MdiParent = this;
			loginCForm.StartPosition = FormStartPosition.CenterScreen;
			//loginCForm.Show();
		}

		#region Default MenuStrip functions
		private void ShowNewForm(object sender, EventArgs e)
		{
			Form childForm = new Form();
			childForm.MdiParent = this;
			childForm.Text = "Window " + childFormNumber++;
			childForm.Show();
		}

		private void OpenFile(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string FileName = openFileDialog.FileName;
			}
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string FileName = saveFileDialog.FileName;
			}
		}
		private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PrintDialog PrintDialog1 = new PrintDialog();
			PrintDialog1.Document = printDocument1;

			if (PrintDialog1.ShowDialog(this) == DialogResult.OK)
			{
				printDocument1.DocumentName = "Print Document";
				printDocument1.Print();
			}
		}

		private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			/*InputBoxResult result = InputBox.Show("Select items for printing", "Input");
			
			if (input == DialogResult.OK)
			{
			}*/

			// Open the print preview dialog
			PrintPreviewDialog printDlg = new PrintPreviewDialog();
			printDlg.Document = printDocument1;
			((Form)printDlg).WindowState = FormWindowState.Maximized;

			printDlg.ShowDialog();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			try
			{
				Font drawFont = new Font("Arial", 12);
				PointF drawPoint = new PointF(100F, 100F);
				bool bMorePagesToPrint = false;			// Whether more pages have to print or not
				
				// smth to print

				//e.Graphics.DrawString("ID\tName\n", drawFont, Brushes.Black, drawPoint);
				//drawPoint.Y += int.Parse(drawFont.Height.ToString());

				e.HasMorePages = bMorePagesToPrint;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}


		private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			statusStrip.Visible = statusBarToolStripMenuItem.Checked;
		}

		private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.ArrangeIcons);
		}

		private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Form childForm in MdiChildren)
			{
				childForm.Close();
			}
		}

		private void MDIForm_MdiChildActivate(object sender, EventArgs e)
		{
			toolStripStatusLabelBrowse.Text = "Browsing: ";
			if (this.ActiveMdiChild == null)
				return;
			toolStripStatusLabelBrowse.Text += ActiveMdiChild.Name;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			toolStripStatusLabelTimer.Text = DateTime.Now.ToString();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox about = new AboutBox();
			about.MdiParent = this;
			about.Show();
		}
		#endregion

		# region View (Project, Task, Team, User)
		private void taskListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (role == "user") 
			{
				ViewsList taskViewCForm = new ViewsList("Task", role);
				taskViewCForm.MdiParent = this;
				taskViewCForm.Show();
			}
			else
			{
				ViewList taskViewCForm = new ViewList("Task", role);
				taskViewCForm.MdiParent = this;
				taskViewCForm.Show();
			}
		}
		private void userListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (role == "user")
			{
				ViewsList userViewCForm = new ViewsList("User", role);
				userViewCForm.MdiParent = this;
				userViewCForm.Show();
			}
			else
			{
				ViewList userViewCForm = new ViewList("User", role);
				userViewCForm.MdiParent = this;
				userViewCForm.Show();
			}
		}

		private void teamListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (role == "user")
			{
				ViewsList teamViewCForm = new ViewsList("Team", role);
				teamViewCForm.MdiParent = this;
				teamViewCForm.Show();
			}
			else
			{
				ViewList teamViewCForm = new ViewList("Team", role);
				teamViewCForm.MdiParent = this;
				teamViewCForm.Show();
			}
		}
		private void projectListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (role == "user")
			{
				ViewsList projectViewCForm = new ViewsList("Project", role);
				projectViewCForm.MdiParent = this;
				projectViewCForm.Show();
			}
			else
			{
				ViewList projectViewCForm = new ViewList("Project", role);
				projectViewCForm.MdiParent = this;
				projectViewCForm.Show();
			}
		}

		#endregion

		private void profileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Profile profile = new Profile();
			profile.MdiParent = this;
			profile.WindowState = FormWindowState.Maximized;		// kinda looks good maximized; dont let max other wins
			profile.Show();
		}

	}
}
