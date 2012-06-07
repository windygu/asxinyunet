/*
 * XCoder v4.5.2011.1108
 * 作者：nnhy/NEWLIFE
 * 时间：2011-11-09 17:07:38
 * 版权：版权所有 (C) 新生命开发团队 2011
*/
﻿using System;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using NewLife.Cube.Entities;
using NewLife.Web;

public partial class Cube_DataModel : MyEntityList
{
    /// <summary>实体类型</summary>
    public override Type EntityType { get { return typeof(DataModel); } set { base.EntityType = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Int32 index = 0;
        if (!Int32.TryParse("" + e.CommandArgument, out index)) index = -1;
        Int32 id = index >= 0 ? (Int32)gv.DataKeys[index][0] : 0;
        DataModel md = DataModel.FindByID(id);

        if (md != null)
        {
            if (e.CommandName == "ExportXml")
            {
                String xml = md.ExportXml();
                if (!String.IsNullOrEmpty(xml))
                {
                    //MemoryStream ms = new MemoryStream();
                    //EntityAccessorFactory.Create(EntityAccessorTypes.Xml)
                    //    .SetConfig(EntityAccessorOptions.Stream, ms)
                    //    .Write(md, null);
                    //ms.Position = 0;
                    WebDownload wd = new WebDownload();
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
                    wd.Stream = ms;
                    wd.FileName = md.Name + ".xml";
                    wd.Mode = WebDownload.DispositionMode.Attachment;
                    wd.Render();
                    Response.End();
                }
            }
            else if (e.CommandName == "ExportZip")
            {
                MemoryStream ms = new MemoryStream();
                md.ExportZip(ms);

                WebDownload wd = new WebDownload();
                wd.Stream = ms;
                wd.FileName = md.Name + ".zip";
                wd.Mode = WebDownload.DispositionMode.Attachment;
                wd.Render();
                Response.End();
            }
        }
    }
}