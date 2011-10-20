namespace EntLib.Controls.WinForm
{
    using System;
    using System.Windows.Forms;

    public class LoadGUI
    {
        private int _MainFormDock;
        public Panel panMap;
        public SetDockStyle setDockStyle;
        public libNavigate 召测导航;

        public void ShowForm(object sender, EventArgs e)
        {
            RightTreeNode rightTreeNode = null;
            if (sender is ToolStripMenuItem)
            {
                if (sender is ToolStripMenuItem) rightTreeNode = (RightTreeNode) (sender as ToolStripMenuItem).Tag;
            }
            else
                rightTreeNode = (RightTreeNode) (sender as Control).Tag;
            this.MainFormDock = (rightTreeNode == null) ? 0 : rightTreeNode.DockStyle;
            if (rightTreeNode != null && rightTreeNode.PointType > 0 || rightTreeNode.PointType == -1 && !rightTreeNode.notClear && this._MainFormDock != 1)
            {
                if (this.召测导航 == null)
                {
                    this.召测导航 = new libNavigate();
                    this.召测导航.Dock = DockStyle.Fill;
                    this.panMap.Controls.Add(this.召测导航);
                }
                this.召测导航.loadgui = this;
                this.召测导航.RightID = rightTreeNode.RightID;
                this.召测导航.PointType = rightTreeNode.PointType;
                this.召测导航.lb_Hint.Text = rightTreeNode.ShowText;
                this.召测导航.BringToFront();
            }
        }

        public int MainFormDock
        {
            get { return this._MainFormDock; }
            set
            {
                this._MainFormDock = value;
                if (this.setDockStyle != null) this.setDockStyle(value);
            }
        }

        public enum LoadStyle
        {
            toolbar,
            menubar
        }
    }
}
