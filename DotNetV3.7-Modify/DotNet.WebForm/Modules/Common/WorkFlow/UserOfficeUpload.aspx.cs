using System;
using System.IO;
using System.Web;

using DotNet.Utilities;
using DotNet.Business;

public partial class UserOfficeUpload : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        // ID为文档的主键，如果ID不为空，则更新数据，否则新建一条记录
        string billId = Request.Params["ID"];
        string title = Server.UrlDecode(Request.Params["DocTitle"]);
        string templateId = Server.UrlDecode(Request.Params["DocTemplateId"]);
        string docSubmit = Request.Params["DocSubmit"];

        if (Request.Files.Count > 0)
        {
            HttpPostedFile httpPostedFile = Request.Files[0];
            int postedFileLength = httpPostedFile.ContentLength;
            /*
            byte[] postedFile = new Byte[postedFileLength];
            Stream stream = httpPostedFile.InputStream;
            stream.Read(postedFile, 0, postedFileLength);
            */

            BaseNewsEntity newsEntity = null;
            UserBillManager templateManager = new UserBillManager(this.WorkFlowDbHelper, this.UserInfo);
            if (string.IsNullOrEmpty(billId))
            {
                newsEntity = new BaseNewsEntity();
                newsEntity.Id = BaseBusinessLogic.NewGuid();
                newsEntity.CategoryCode = templateId;
            }
            else
            {
                newsEntity = templateManager.GetEntity(billId);
                // 下面表明是没能获得数据
                if (newsEntity == null || string.IsNullOrEmpty(newsEntity.Id))
                {
                    newsEntity.Id = billId;
                    newsEntity.CategoryCode = templateId;
                }
            }
            newsEntity.FileSize = postedFileLength;
            newsEntity.Source = "xls";
            newsEntity.Title = title;
            newsEntity.Contents = null;
            if (string.IsNullOrEmpty(billId))
            {
                templateManager.AddEntity(newsEntity);
            }
            else
            {
                int rowCont = 0;
                rowCont = templateManager.UpdateEntity(newsEntity);
                if (rowCont == 0)
                {
                    templateManager.AddEntity(newsEntity);
                }
            }
            string fileName = newsEntity.Id + ".xls";
            string loadDirectory = string.Empty;
            Utilities.UpLoadFile("User_" + newsEntity.CreateUserId, newsEntity.Id, httpPostedFile, ref loadDirectory, true, fileName);
            if (string.IsNullOrEmpty(docSubmit) || docSubmit == "false")
            {
                Response.Write("succeed");
                Response.End();
            }
            else
            {
                Response.Redirect("SubmitBill.aspx?Id=" + newsEntity.Id);
            }
        }
        else
        {
            Response.Write("No File Upload!");
        }
    }
}