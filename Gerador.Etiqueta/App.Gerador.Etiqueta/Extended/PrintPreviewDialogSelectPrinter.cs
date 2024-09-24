using System;
using System.Windows.Forms;

namespace Extended
{
    public class PrintPreviewDialogSelectPrinter : PrintPreviewDialog
    {
        public PrintPreviewDialogSelectPrinter()
        {
            ToolStripButton b = new ToolStripButton
            {
                Image = ((ToolStrip)(Controls[1])).ImageList.Images[0],
                DisplayStyle = ToolStripItemDisplayStyle.Image
            };
            b.Click += new EventHandler(Preview_PrintClick);
            ((ToolStrip)(Controls[1])).Items.RemoveAt(0);
            ((ToolStrip)(Controls[1])).Items.Insert(0, b);
        }

        private void Preview_PrintClick(object sender, EventArgs e)
        {
            try
            {
                PrintDialog pg = new PrintDialog();
                if (pg.ShowDialog() == DialogResult.OK)
                    Document.Print();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
