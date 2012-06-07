using System;
using System.Collections.Generic;
using System.IO;
using NewLife.Cube;
using XTemplate.Templating;

public partial class Cube_Tag : System.Web.UI.UserControl
{
    private String _Selected;
    /// <summary>当前选择</summary>
    public String Selected
    {
        get { return _Selected ?? Path.GetFileName(Request.Path) + Request.Url.Query; }
        set { _Selected = value; }
    }

    /// <summary>模版名</summary>
    public String Name { get { return Request["Template"]; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        String name = Name;
        if (!String.IsNullOrEmpty(name))
        {
            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("模版管理[" + name + "]", String.Format("Template.aspx?Template={0}", name));

            //Template template = TemplateHelper.GetTemplateEngine(name);
            //if (template != null)
            //{
            //    foreach (TemplateItem item in template.Templates)
            //    {
            //        dic.Add(item.Name, String.Format("TemplateItem.aspx?Template={0}&Item={1}", name, item.Name));
            //    }
            //}

            String path = TemplateHelper.GetFullPath(name);
            if (Directory.Exists(path))
            {
                String[] files = Directory.GetFiles(path);
                foreach (String item in files)
                {
                    String fname = item;
                    if (fname.StartsWith(path)) fname = fname.Substring(path.Length, fname.Length - path.Length);
                    if (fname.StartsWith("/") || fname.StartsWith("\\")) fname = fname.Substring(1);

                    dic.Add(fname, String.Format("TemplateItem.aspx?Template={0}&Item={1}", name, fname));
                }
            }

            Tag.DataSource = dic;
            Tag.DataBind();
        }
    }

    /// <summary>绑定属性</summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public String BindAtt(Object dt)
    {
        if (dt == null) return null;

        KeyValuePair<String, String> kv = (KeyValuePair<String, String>)dt;

        if (Selected.StartsWith(kv.Value, StringComparison.OrdinalIgnoreCase))
            return " class=\"current\"";
        else
            return String.Format(" onclick=\"location.href='{0}';\"", kv.Value);
    }
}