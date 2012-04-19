using System;
using System.IO;
using System.Web;

using DotNet.Utilities;
using DotNet.Business;

public partial class OfficeTemplateUpload : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        // ID为文档的主键，如果ID不为空，则更新数据，否则新建一条记录
        string templateId = Request.Params["ID"];
        string title = Server.UrlDecode(Request.Params["DocTitle"]);
        string code = Server.UrlDecode(Request.Params["DocCode"]);
        string category = Server.UrlDecode(Request.Params["DocCategory"]);
        string introduction = Server.UrlDecode(Request.Params["DocIntroduction"]);

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
            WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.WorkFlowDbHelper, this.UserInfo);
            if (string.IsNullOrEmpty(templateId))
            {
                newsEntity = new BaseNewsEntity();
                newsEntity.Id = BaseBusinessLogic.NewGuid();
            }
            else
            {
                newsEntity = templateManager.GetEntity(templateId);
            }
            newsEntity.FileSize = postedFileLength;
            newsEntity.Source = "xls";
            newsEntity.Title = title;
            newsEntity.Code = code;
            newsEntity.CategoryCode = category;
            newsEntity.Introduction = introduction;
            newsEntity.Contents = null;
            if (string.IsNullOrEmpty(templateId))
            {
                templateManager.AddEntity(newsEntity);
            }
            else
            {
                templateManager.UpdateEntity(newsEntity);
            }
            string fileName = newsEntity.Id + ".xls";
            string loadDirectory = string.Empty;
            Utilities.UpLoadFile("OfficeTemplate", newsEntity.Id, httpPostedFile, ref loadDirectory, true, fileName);
            Response.Write("succeed");
            Response.End();
        }
        else
        {
            Response.Write("No File Upload!");
        }
    }
}