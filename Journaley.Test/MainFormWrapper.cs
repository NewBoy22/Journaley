using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Journaley.Forms;

namespace Journaley.Test
{
    class MainFormWrapper : MainForm
    {
        public void ProgrammaticLoad()
        {
            base.OnLoad(new EventArgs());
        }

        public int EntryListCount()
        {
            return this.Entries.Count;
        }
    }
}
