using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

namespace cn.buddy
{
    /// <summary>
    /// Original 的摘要说明
    /// </summary>
    public class Original
    {
        public Original()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
    }

    public class Categories
    {
        public string tableWidth;
        public byte folderDeepth;

        public Categories()
        {

        }

        public string showCategories(long c)
        {
            return showCategories(c, 1);
        }

        public string showCategories(long c,int deepth)
        {
            string html = "";
            OleDbConnection conn = DatabaseCommon.CreateConnection(folderDeepth);
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from category where parent_id=@parent_id order by cate_order asc";
            cmd.Parameters.AddWithValue("@parent_id", c);
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (hasSubCategory(long.Parse(dr["cate_id"].ToString())))
                {
                    html += "<div>";
                    for (int i = 1; i < deepth; i++)
                    {
                        html += "&nbsp;&nbsp;";
                    }
                    html += "• <a href=\"javascript:changeDisplayStyle('childOf" + dr["cate_id"].ToString() + "')\">";
                    html += dr["cate_name"].ToString();
                    html += "</a> <font style='color:#234c6c;font-size:9pt;'>&gt; </font>";
                    html += "</div>";
                    html += "<div id='childOf" + dr["cate_id"].ToString() + "' style='display:block;'>";
                    html += showCategories(long.Parse(dr["cate_id"].ToString()), deepth + 1);
                    html += "</div>";
                }
                else
                {
                    for (int i = 1; i < deepth; i++)
                    {
                        html += "&nbsp;&nbsp;";
                    }
                    html += "&nbsp;&nbsp;• <a href='n.aspx?cid=" + dr["cate_id"].ToString() + "'>";
                    html += dr["cate_name"].ToString();
                    html += "</a>";
                    html += "<br />";
                }
            }
            dr.Close();
            conn.Close();

            return html;
        }

        private bool hasSubCategory(long c)
        {
            bool s;
            OleDbConnection conn = DatabaseCommon.CreateConnection(folderDeepth);
            OleDbCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select * from category where parent_id=@parent_id order by cate_order asc";
            cmd.Parameters.AddWithValue("@parent_id", c);

            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                s = true;
            }
            else
            {
                s = false;
            }
            dr.Close();
            conn.Close();
            return s;
        }
    }

    public class Article
    {
        public static string getCateId(string arti_id, int folderDeepth)
        {
            if (arti_id == null)
                return null;
            OleDbConnection conn = DatabaseCommon.CreateConnection(folderDeepth);
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select cate_id from article where arti_id=@arti_id";
            cmd.Parameters.AddWithValue("@arti_id", arti_id);
            conn.Open();
            object o = cmd.ExecuteScalar();
            conn.Close();
            if (o == null)
                return null;
            else
                return o.ToString();
        }

        public static string changeMediaPlayerToReal(string source)
        {
            int currPos = 0;
            string mediaStr = source;
            while (mediaStr.IndexOf("<EMBED") != -1)
            {
                currPos = source.IndexOf("</EMBED>") + 8;
                int start;
                int end;
                start = mediaStr.IndexOf("<EMBED");
                if (start != -1)
                {
                    mediaStr = mediaStr.Substring(start);
                    end = mediaStr.IndexOf("</EMBED>");
                    mediaStr = mediaStr.Substring(0, end + 8);
                }
                string oldStr = mediaStr;
                /* 
                 * <EMBED name=MediaPlayer1 pluginspage=http://www.microsoft.com/Windows/MediaPlayer 
                 * src=/CuteSoft_Client/UploadFiles/Media/余军/00.rm 
                 * width=200 height=200 type=application/x-mplayer2 showcontrols="1" autostart="1">
                 * </EMBED>
                 */
                //取src
                mediaStr = mediaStr.Replace("\"", "");
                string src, width, height, fileExt;
                start = mediaStr.IndexOf("src=");
                mediaStr = mediaStr.Substring(start + 4);
                end = mediaStr.IndexOf(" ");
                src = mediaStr.Substring(0, end);
                mediaStr = mediaStr.Substring(end + 1);
                //取width
                start = mediaStr.IndexOf("width=");
                mediaStr = mediaStr.Substring(start + 6);
                end = mediaStr.IndexOf(" ");
                width = mediaStr.Substring(0, end);
                mediaStr = mediaStr.Substring(end + 1);
                //取height
                start = mediaStr.IndexOf("height=");
                mediaStr = mediaStr.Substring(start + 7);
                end = mediaStr.IndexOf(" ");
                height = mediaStr.Substring(0, end);
                mediaStr = mediaStr.Substring(end + 1);
                //取fileExt
                start = src.LastIndexOf(".");
                fileExt = src.Substring(start + 1).ToUpper();

                string newStr = "";
                newStr += "<OBJECT classid=\"clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA\" id=\"video1\" height=\"" + height + "\" width=\"" + width + "\" VIEWASTEXT>";
                newStr += "<param name=\"SRC\" value=\"" + src + "\">";
                newStr += "<param name=\"_ExtentX\" value=\"5503\">";
                newStr += "<param name=\"_ExtentY\" value=\"1588\">";
                newStr += "<param name=\"AUTOSTART\" value=\"0\">";
                newStr += "<param name=\"SHUFFLE\" value=\"0\">";
                newStr += "<param name=\"PREFETCH\" value=\"0\">";
                newStr += "<param name=\"NOLABELS\" value=\"0\">";
                newStr += "<param name=\"CONTROLS\" value=\"Imagewindow,StatusBar,ControlPanel\">";
                newStr += "<param name=\"CONSOLE\" value=\"RAPLAYER\">";
                newStr += "<param name=\"LOOP\" value=\"0\">";
                newStr += "<param name=\"NUMLOOP\" value=\"0\">";
                newStr += "<param name=\"CENTER\" value=\"0\">";
                newStr += "<param name=\"MAINTAINASPECT\" value=\"0\">";
                newStr += "<param name=\"BACKGROUNDCOLOR\" value=\"#000000\">";
                newStr += "</OBJECT>";

                if (fileExt == "RM" || fileExt == "RMVB" || fileExt == "WMV")
                {
                    source = source.Replace(oldStr, newStr);
                }
                mediaStr = source.Substring(currPos);
            }

            return source;
        }
    }

    public class Picture
    {
        public static string getCateId(string pic_id, int folderDeepth)
        {
            if (pic_id == null)
                return null;
            OleDbConnection conn = DatabaseCommon.CreateConnection(folderDeepth);
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select cate_id from picture where pic_id=@pic_id";
            cmd.Parameters.AddWithValue("@pic_id", pic_id);
            conn.Open();
            object o = cmd.ExecuteScalar();
            conn.Close();
            if (o == null)
                return null;
            else
                return o.ToString();
        }
    }

    public class LinkList
    {
        public static DataTable GetLinks(string cate_id,int folderDeepth)
        {
            string sql = "select lnk_name,lnk_url from link where cate_id="+cate_id+" order by lnk_order asc";
            return DatabaseCommon.Fill(sql, folderDeepth);
        }
    }
}
