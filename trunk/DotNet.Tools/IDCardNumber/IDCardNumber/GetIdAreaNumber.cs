using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Data;
using DotNet.Tools.IDCardNumber.Model;
using DotNet.Tools.IDCardNumber.BLL;
using System.Collections;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Nodes;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Filters;
using Winista;

namespace DotNet.Tools.IDCardNumber
{
    /// <summary>
    /// 获取行政区域代码数据:从网站http://hm.alai.net/index.php/Idcard/index获取
    /// 编码格式为 UTF8
    /// </summary>
    public class GetIdAreaCodeFromWebSite
    {
        static BLL.areacodetable bll = new DotNet.Tools.IDCardNumber.BLL.areacodetable();
        static Model.areacodetable model = new DotNet.Tools.IDCardNumber.Model.areacodetable();

        /// <summary>
        /// 将字符串和代码分离,并 保存到数据库
        /// </summary>
        /// <param name="codeStr">区域名称与代码,该网站格式固定</param>
        /// <returns>是否保存成功</returns>
        public static bool SaveCodeData(string codeStr)
        {
            //后8为的括号为区域代码
            codeStr = codeStr.Trim();
        //    int length = codeStr.Length;
            model.ShortName = codeStr.Substring(0, codeStr.Length - 8);//获取简称
            model.AreaCode = codeStr.Substring(codeStr.Length - 7, 6);//截取区域代码            
            model.FullName = "";
            //根据获取的区域代码来获取上级区域代码及名称，并组合成全称
        
            if (model.AreaCode.Substring(2, 2) != "00")//中间2位不为0
            {
                //model.FullName = bll.GetModel(model.AreaCode.Substring(0, 2) + "0000").ShortName;//身份
                if (model.AreaCode.Substring(4, 2) != "00") //最后2位不为0
                {
                    if (bll.Exists(model.AreaCode.Substring(0, 4) + "00"))
                    {
                        model.FullName += bll.GetModel(model.AreaCode.Substring(0, 4) + "00").FullName;                        
                    }
                    model.FullName += model.ShortName;
                }
                else //最后2位为0 
                {
                    if (bll.Exists(model.AreaCode.Substring(0, 4) + "00"))
                    {
                        model.FullName = bll.GetModel(model.AreaCode.Substring(0, 4) + "00").FullName;
                    }
                }
            }
            else
            {
                model.FullName = model.ShortName;//省级区域
            }
            if (!bll.Exists (model.AreaCode ))
            {
                bll.Add(model);
                Console.WriteLine(model.FullName +":"+model.AreaCode +" ; 成功!");
            }
            return true;
        }

        /// <summary>
        /// 根据初始网址得到数据,遍历所有网页,直到当前页面不包含下一级行政区域
        /// </summary>
        /// <param name="url">初始网页</param>
        /// <returns>获取数据</returns>
        public static void GetAllDataListFromWebSite(string url)
        {
            Hashtable ht = GetAreaListFromWebSite(url);
            if (ht.Count < 1)
            {
                return;
            }
            else
            {
                foreach (DictionaryEntry item in ht )
                {
                    SaveCodeData(item.Key.ToString().Trim());//保存
                    GetAllDataListFromWebSite(item.Value.ToString());//递归调用
                }
            }
        }

        /// <summary>
        /// 根据当前输入网址检测行政区域列表
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns>区域及下一级区域的网页链接:hashtable,key:区域名称及代码;value:下一级网址</returns>
        public static Hashtable GetAreaListFromWebSite(string url)
        {
            //先判断当前网址是否存在下一级行政区域
            //判断的简单的方法是看网址是否包括:code 字符，分析一下网址特点得出的;通过分析网页代码也可以的.
            Hashtable ht = new Hashtable() ;
            if(!url.Contains ("code"))//不包含则继续获取
            {
                           
            Lexer lexer = new Lexer(CaptureWebSite.GetHtmlEx(url, Encoding.UTF8 ));
            Parser parser = new Parser(lexer);
            //公司列表过滤
            HasAttributeFilter has = new HasAttributeFilter("CLASS", "idsf");
            NodeList htmlNodes = parser.Parse(has);
            //遍历所有节点列表，每个节点都可能是一条信息
            for (int i = 0; i < htmlNodes.Count; i++)
            {
                ITag tag = (ITag)(htmlNodes[i] as ITag);//div节点
                if (tag.Children.Count > 0)
                {
                    NodeList tlist = tag.Children;
                    //根据子节点的信息来判断是不是需要的节点
                    for (int j = 0; j < tlist.Count; j++)
                    {
                        ITag tagTemp = (ITag)(tlist[j] as ITag);//UL节点
                        if (tagTemp != null && tagTemp.TagName=="UL" && tagTemp.Children.Count > 0)
                        {
                            NodeList aearlist = tagTemp.Children;
                            for (int k = 0; k < aearlist.Count; k++)
                            {
                                ITag areaTag = (ITag)(aearlist[k] as ITag);//LI节点
                                if ((areaTag != null) && (areaTag.TagName == "LI") )
                                {
                                    //获取到区域名称与代码信息，以及网址
                                    ITag a = (ITag)(areaTag.Children [0] as ITag) ;
                                    if (a!=null && a.TagName =="A")
                                    {
                                        if (!ht.Contains(a.ToPlainTextString().Trim()))//判断是否存在
                                        {
                                            ht.Add(a.ToPlainTextString().Trim(), "http://hm.alai.net"+a.Attributes["HREF"].ToString().Trim());
                                        }
                                    }
                                   
                                }
                            }
                        }     
                    }
                }
            }
           
            }
            return ht ;
        }

        /// <summary>
        /// 获取行政区域的全名
        /// </summary>
        public static void GetFullName()
        {
            DataTable dt = bll.GetAllList().Tables[0] ;
            model.FullName = "";
            string code = "";
            for (int i = 0; i < dt.Rows.Count ; i++)
            {
                code = dt.Rows[i]["AreaCode"].ToString().Trim();
                model.AreaCode = code;
                if (code.Substring(2, 2) != "00") //中间2位
                {
                    // 不为00 ，可能是直辖市地区，也可能是省级地区
                    if (code.Substring(4, 2) != "00") //末尾2位
                    {
                        //直辖市地区或者省级地区
                        if (bll.Exists(code.Substring(0, 4) + "00"))//查找省级地区
                        {
                            //存在则添加
                            model.FullName = bll.GetModel(code.Substring(0, 2) + "0000").ShortName;
                            model.FullName += bll.GetModel(code.Substring(0, 4) + "00").ShortName;
                            model.FullName += dt.Rows[i]["ShortName"].ToString().Trim();
                        }
                        else  //否则不存在为直辖市
                        {
                            model.FullName = bll.GetModel(code.Substring(0, 2) + "0000").ShortName;
                            model.FullName += dt.Rows[i]["ShortName"].ToString().Trim();
                        }
                    }
                    else
                    {
                        //省级地区：
                           model.FullName = bll.GetModel(code.Substring(0, 2) + "0000").ShortName;
                           model.FullName += dt.Rows[i]["ShortName"].ToString().Trim();                        
                    }
                }
                else
                {
                    //省或直辖市 不用更改
                    model.FullName = dt.Rows[i]["ShortName"].ToString().Trim();
                }               
               
                model.ShortName = dt.Rows[i]["ShortName"].ToString().Trim() ;
                bll.Update (model);
                Console.WriteLine(model.FullName +": 修改完成！");
            }
        }

        public static void SetUpdateTime()
        {
            DataTable dt = bll.GetAllList().Tables[0];
            string code = "" ;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                code = dt.Rows[i]["AreaCode"].ToString().Trim();
                model = bll.GetModel(code);
                model.UpdateTime = DateTime.Now;
                bll.Update(model);
                Console.WriteLine(i.ToString());
            }
        }
    }

    #region 获取网页
    public class CaptureWebSite
    {
        private static CookieContainer cookie = new CookieContainer();
        private static string contentType = "application/x-www-form-urlencoded";
        private static string accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg," +
            " application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, " +
            "application/vnd.ms-powerpoint, application/msword, application/x-ms-application, " +
            "application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
        private static string userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; " +
            ".NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";

        /// <summary>
        /// 获取网址的源代码
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns>该网址的源代码 html格式</returns>
        public static string GetHtmlInfoFromURL(string url)
        {
            System.Net.WebClient aWebClient = new System.Net.WebClient();
            aWebClient.Encoding = System.Text.Encoding.Default;
            return aWebClient.DownloadString(url);
        }

        /// <summary>
        /// 根据网址和编码获取源代码，源代码来自 http://www.cnblogs.com/nuke/archive/2010/08/22/1805626.html,感谢！
        /// </summary>
        /// <param name="url">网址</param>
        /// <param name="encoding">编码</param>
        /// <returns>源文件</returns>
        public static string GetHtmlEx(string url, Encoding encoding)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = userAgent;
            request.ContentType = contentType;
            request.CookieContainer = cookie;
            request.Accept = accept;
            request.Method = "get";

            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, encoding);
            String html = reader.ReadToEnd();
            response.Close();
            return html;
        }
    }
    #endregion
}