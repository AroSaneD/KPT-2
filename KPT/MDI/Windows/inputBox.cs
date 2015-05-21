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
	public partial class InputBox : Form
	{
		private static InputBoxResult _outputResponse = new InputBoxResult();

		public class InputBoxResult
		{
			public DialogResult ReturnCode;
			public string Text;		// mab change
		}

		public InputBox()
		{
			InitializeComponent();
		}

		static private InputBoxResult OutputResponse
		{
			get { return _outputResponse; }
			set { _outputResponse = value; }
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			OutputResponse.ReturnCode = DialogResult.OK;
			//OutputResponse.Text = txtInput.Text;	//save selected ckeck boxes
			this.Dispose();
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
