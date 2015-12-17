namespace FormaProces
{
    partial class PrikazOptuznice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrikazOptuznice));
            this.dialog = new System.Windows.Forms.PrintDialog();
            this.rtbOptuznica = new System.Windows.Forms.RichTextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.document = new System.Drawing.Printing.PrintDocument();
            this.preview = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // dialog
            // 
            this.dialog.AllowSelection = true;
            this.dialog.AllowSomePages = true;
            this.dialog.UseEXDialog = true;
            // 
            // rtbOptuznica
            // 
            this.rtbOptuznica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbOptuznica.Location = new System.Drawing.Point(12, 37);
            this.rtbOptuznica.Name = "rtbOptuznica";
            this.rtbOptuznica.ReadOnly = true;
            this.rtbOptuznica.Size = new System.Drawing.Size(766, 499);
            this.rtbOptuznica.TabIndex = 2;
            this.rtbOptuznica.Text = "[Nema optužnice]";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // preview
            // 
            this.preview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.preview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.preview.ClientSize = new System.Drawing.Size(400, 300);
            this.preview.Enabled = true;
            this.preview.Icon = ((System.Drawing.Icon)(resources.GetObject("preview.Icon")));
            this.preview.Name = "preview";
            this.preview.Visible = false;
            // 
            // PrikazOptuznice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 548);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.rtbOptuznica);
            this.Name = "PrikazOptuznice";
            this.Text = "PrikazOptuznice";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintDialog dialog;
        private System.Windows.Forms.RichTextBox rtbOptuznica;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument document;
        private System.Windows.Forms.PrintPreviewDialog preview;
    }
}