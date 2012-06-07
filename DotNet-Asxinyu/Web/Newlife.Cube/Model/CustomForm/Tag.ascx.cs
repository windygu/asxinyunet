using System;
using System.Collections.Generic;
using System.IO;
using NewLife.Web;
using NewLife.Cube.Entities;

public partial class Cube_CustomForm_Tag : System.Web.UI.UserControl
{
    private String _Selected;
    /// <summary>当前选择</summary>
    public String Selected { get { return _Selected; } set { _Selected = value; } }

    private Dictionary<String, String> _Data;
    /// <summary>数据</summary>
    public Dictionary<String, String> Data { get { return _Data ?? (_Data = new Dictionary<String, String>()); } set { _Data = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 id = WebHelper.RequestInt("ID");
        if (id <= 0) id = WebHelper.RequestInt("ModelTableID");

        if (id > 0) Data.Add("表单数据", "ModelData.aspx?ID=" + id);
        Data.Add("表单设置", "ModelTableForm.aspx?ID=" + id);
        if (id > 0)
        {
            Data.Add("字段设置", "ModelColumn.aspx?ModelTableID=" + id);
            Data.Add("模版管理", "ModelTemplate.aspx?ID=" + id);
            Data.Add("表单预览", "Preview.aspx?ID=" + id);
        }

        if (id > 0)
        {
            ModelTable mt = ModelTable.FindByID(id);
            if (mt != null)
            {
                lbName.Text = mt.DataModel.DisplayName + "\\" + mt.DisplayName;
            }
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        String path = Path.GetFileName(Request.Path);
        // 如果没有选择项，开始找
        if (String.IsNullOrEmpty(Selected))
        {
            foreach (KeyValuePair<String, String> kv in Data)
            {
                if (kv.Value.StartsWith(path, StringComparison.OrdinalIgnoreCase))
                {
                    Selected = kv.Key;
                    break;
                }
            }
        }
        // 还是没有选择项，则使用第一个
        if (String.IsNullOrEmpty(Selected))
        {
            foreach (KeyValuePair<String, String> kv in Data)
            {
                Selected = kv.Key;
                break;
            }
        }

        Tag.DataSource = Data;
        Tag.DataBind();
    }
}