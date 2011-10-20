namespace EntLib.Controls.DataPrinter
{
    using System;
    using System.Drawing.Printing;
    using System.Windows.Forms;

    public class Printer
    {
        private DataPrintSet PrintSetting;

        public Printer(DataGridView dgv, string ProjectName)
        {
            this.PrintSetting = new DataPrintSet("管理员", dgv, 0, new bool[0]);
            this.PrintSetting.InitPrinter();
            if (ProjectName != null) this.LoadProject(ProjectName);
        }

        public void LoadProject(string ProjectName) { this.PrintSetting.LoadProjectXML(ProjectName); }

        public void PageSettings(System.Drawing.Printing.PageSettings Setting) { this.PrintSetting.PageSet = Setting; }

        public void PrintIt() { this.PrintSetting.bt_OK_Click(this, new EventArgs()); }

        public void SetFooter(DefaultOptions Footer) { this.PrintSetting.Footer = Footer; }

        public void SetHeader(DefaultOptions Header) { this.PrintSetting.Header = Header; }

        public void SetLogo(LogoOptions Logo) { this.PrintSetting.Logo = Logo; }

        public void SetMainTitle(DefaultOptions MainTitle) { this.PrintSetting.TitleMain = MainTitle; }

        public void SetOthers(OtherOptions Others) { this.PrintSetting.Others = Others; }

        public void SetPage(DefaultOptions Page) { this.PrintSetting.Page = Page; }

        public void SetSutTitle(DefaultOptions SubTitle) { this.PrintSetting.TitleSub = SubTitle; }
    }
}
