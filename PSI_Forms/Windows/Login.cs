﻿using System;
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
	public partial class Login : Form
	{
		private int failCounter = 0;

		public Login()
		{
			InitializeComponent();
		}

		private void loginBtn_Click(object sender, EventArgs e)
		{
			// check correct login
			if (textBoxName.Text == "a" && textBoxPass.Text == "a") {
				MessageBox.Show("Succes", "Logging in...");
				this.Dispose();
			}
			else {
				failCounter++;
				if (failCounter > 4)
					MessageBox.Show("STOP IT!!!", "Logging in...");

					// do smth more

				else
					MessageBox.Show("Fail", "Logging in...");
			}

			return; //role
		}

	}
}
