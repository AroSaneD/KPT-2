using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace PSI_Forms.Controller
{
    class NotesController
    {
        public string notes;

        public void LoadNotes()
        {
            notes = "";
            using (var reader = new StreamReader(new FileStream("notes.txt",FileMode.OpenOrCreate)))
            {
                while (!reader.EndOfStream)
                {
                    notes += reader.ReadLine();
                }
            }
        }

        public void saveNotes(System.Windows.Forms.TextBox sender)
        {
            using (var writer = new StreamWriter(new FileStream("notes.txt", FileMode.Create)))
            {
                writer.WriteLine(sender.Text);
            }
        }
    }
}
