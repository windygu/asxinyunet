namespace EntLib.Controls.WinForm
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class WinFormHelper
    {
        public static ContextMenuStrip GetContextMenuStrip(string[] names, string[] texts, System.EventHandler[] onclick)
        {
            ContextMenuStrip CellcontextMenuStrip = new ContextMenuStrip();
            for (int i = 0; i < names.Length; i++)
            {
                ToolStripMenuItem toolStripMenu = new ToolStripMenuItem();
                toolStripMenu.Name = names[i];
                toolStripMenu.Size = new Size(180, 70);
                toolStripMenu.Text = texts[i];
                toolStripMenu.Click += new System.EventHandler(onclick[i].Invoke);
                CellcontextMenuStrip.Items.Add(toolStripMenu);
            }
            return CellcontextMenuStrip;
        }
    }
}
