using System;
using System.Collections.Generic;
using System.IO;
using NewLife.Web;

public partial class Cube_Tag : System.Web.UI.UserControl
{
    private String _Selected;
    /// <summary>当前选择</summary>
    public String Selected
    {
        get { return _Selected ?? Path.GetFileName(Request.Path); }
        set { _Selected = value; }
    }

    public Int32 TableID { get { return WebHelper.RequestInt("ModelTableID"); } }

    protected void Page_Load(object sender, EventArgs e)
    {
        Dictionary<String, String> dic = new Dictionary<string, string>();
        if (TableID > 0) dic.Add("表信息", "ModelTableForm.aspx?ID=" + TableID);
        dic.Add("模型列", "ModelColumn.aspx");
        dic.Add("模型索引", "ModelIndex.aspx");
        dic.Add("模型关系", "ModelRelation.aspx");
        Tag.DataSource = dic;
        Tag.DataBind();
    }

    /// <summary>
    /// 绑定属性
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public String BindAtt(Object dt)
    {
        if (dt == null) return null;

        KeyValuePair<String, String> kv = (KeyValuePair<String, String>)dt;

        if (kv.Value.StartsWith(Selected, StringComparison.OrdinalIgnoreCase))
            return " class=\"current\"";
        else if (TableID > 0)
            return String.Format(" onclick=\"location.href='{0}{1}ModelTableID={2}';\"", kv.Value, kv.Value.Contains("?") ? "&" : "?", TableID);
        else
            return String.Format(" onclick=\"location.href='{0}';\"", kv.Value);
    }
}