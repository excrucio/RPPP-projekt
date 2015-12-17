using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Printing;

namespace FormaProces
{
    public partial class PrikazOptuznice : Form
    {
        public PrikazOptuznice()
        {
            InitializeComponent();
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
        }

        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtbOptuznica.Text, rtbOptuznica.Font, Brushes.Black, 80, 80);
        }

        public PrikazOptuznice(string p)
        {
            InitializeComponent();
            if (p != "" && p != null) 
            {
                rtbOptuznica.Text=p;
            }
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dialog.Document = document;
            preview.Document = document;
            preview.Height = this.Height;
            preview.Width = this.Width; 

            //ukinuti print button na pregledu
            ((ToolStripButton)((ToolStrip)preview.Controls[1]).Items[0]).Enabled = false;
            if (preview.ShowDialog() == DialogResult.Cancel)
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    document.Print();
                }
            }
         }
    }
}
