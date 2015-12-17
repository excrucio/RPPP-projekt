using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaGlavna
{
    class StatusBusy:IDisposable
	{
		private Cursor c;
		public StatusBusy()
		{
			this.c = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
		}
		void IDisposable.Dispose()
		{
			Cursor.Current = this.c;
		}

    }
}
