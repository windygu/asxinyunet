﻿/*
 * Created by SharpDevelop.
 * User: asxinyu
 * Date: 2011-9-1
 * Time: 21:23
 * 
 * Verycd.com资源网
 */
using System;
using System.Web;
using System.Text;
using HtmlAgilityPack;
using ResouceEntity;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using NewLife.Log;
using System.Threading.Tasks;

namespace ResourceManage
{
    /// <summary>
    /// Verycd.com 资源网工具类
    /// 1.根据资源列表页面URL-->得到资源列表页面，采集页面及URL（一级资源大类列表） 
    ///                      -->根据资源页面，采集资源页面链接URL，（资源列表）
    ///                      -->循环资源列表，采集每个资源页面的ed2k链接
    /// 2.根据资源页面，直接获取资源页面链接，然后采集每个页面的ed2k链接
    /// 
    /// tb_typelist表存储2种数据，都是URL，一种是大类资源的列表页面入口，一种是浏览资源页面的入口
    /// 任务调度，是从这个表开始，进行处理，根据URL关键字来区分处理的类型
    /// 首页内容区更新1-2页的都要全部扫描，防止更新：规则，若重复率大于85%则停止采集 
    /// 只有从首页内容区更新的页面，如果有重复才允许重新采集，列表采集只是一个备用手段，防止漏采
    /// </summary>
    public class VeryCdResouce
    {
        #region 静态变量
        public static string xPath_TypePageList = @"/html[1]/body[1]/div[4]/div[2]/div[3]/div[2]/dl[1]/dd";
        public static string xPath_ResouceList = @"/html[1]/body[1]/div[4]/div[2]/div[3]/div[2]/div[2]/ol[1]/li";
        public static string xPath_ResouceInfo = @"/html[1]/body[1]/div[4]/div[2]/div[3]/div[1]/div[6]/div[1]/div[2]/table[1]/tr";
        public static string verycdWebSite = @"http://www.verycd.com";
        public static Encoding VerycdEncoding = Encoding.UTF8;
        public static string pagePatten = @"/topics/\d{1,12}/";//匹配资源页面链接的正则表达式
        #endregion

        #region 扫描常规资源列表区
        /// <summary>
        /// 扫描常规资源列表区,一般定期一周才扫描一次
        /// </summary>
        public static void ScanPageList()
        {
            //从tb_typelist类型列表中取出所有的列表地址数据
            var typeListUrl = tb_typelist.FindAll().FindAll(n => n.URL.Contains("archives"));
            Parallel.For(0, typeListUrl.Count, (i) => {
                GetTypePageList(typeListUrl[i].URL, typeListUrl[i].TypeName, typeListUrl[i].SubClassName,
                    (ResouceType)Enum.Parse(typeof(ResouceType), typeListUrl[i].ResType, true));            
            });           
        }
        #endregion

        #region 扫描常规资源首页
        /// <summary>
        /// 扫描常规资源首页,扫描频率可以频繁点,比如1-2天一次,默认更新前10页
        /// </summary>
        public static void ScanPageContent()
        {
            //从tb_typelist类型列表中取出所有的列表地址数据
            //每个子类更新的页面数，给tb_typelist表增加一个默认更新页数的字段
            var typeListUrl = tb_typelist.FindAll();
            int count = 0;
            try
            {
                foreach (var item in typeListUrl)
                {
                    AnalyNormalPage(item);
                    count++;
                }
            }
            catch (Exception err) { XTrace.WriteException(err); }
            finally { XTrace.WriteLine("扫描{0}个常规资源子类的页面完成", count); }
        }
        //分析常规页面
        private static void AnalyNormalPage(tb_typelist item)
        {
            //循环进行
            if (item.URL.Contains("sto"))//只扫描子类首页内容更新的页面
            {
                //TODO:处理逻辑，只匹配固定模式的,正则匹配 \d{1,10} 
                for (int i = 1; i <= 10; i++)
                {
                    if (GetPageContentHerf(item, item.URL + "page" + i.ToString()) > 0.85)
                    {
                        return;
                    }
                }
            }
        }
        //获取当前页面的链接,返回成功率
        private static double GetPageContentHerf(tb_typelist item, string curUrl)
        {
            HtmlDocument doc = CaptureWebSite.GetHtmlDocument(curUrl, VerycdEncoding);
            HtmlNodeCollection hc = doc.DocumentNode.SelectNodes("//@herf");
            int count = 0;
            try
            {
                foreach (var s in hc)
                {
                    string urls = s.Attributes["href"].Value.ToString();
                    string url = verycdWebSite + urls;
                    if (Regex.IsMatch(urls, pagePatten))
                    {
                        #region 数据库操作
                        //不包括“全文”字样
                        string name = s.InnerText.Replace("\r\n", "").Trim();
                        if (name != "" && !name.Contains("全文"))
                        {
                            //写入加入到页面数据库，如果页面已经存在，则检查更新时间，如更新时间>10天，则更新状态                            
                            if (tb_resoucepageslist.FindCount(tb_resoucepageslist._.PageURL, url) < 1)
                            {
                                //直接插入
                                tb_resoucepageslist model = new tb_resoucepageslist();
                                model.PageURL = url;
                                model.ClassName = item.TypeName;
                                model.CollectionMark = 0;
                                model.InfoOrigin = item.URL;
                                model.PageTitle = name;
                                model.ResouceType = item.ResType;
                                model.SubClassName = item.SubClassName;
                                model.UpdateTime = DateTime.Now;
                                count++;
                            }
                            else
                            {
                                //更新状态
                                tb_resoucepageslist model = tb_resoucepageslist.FindByPageURL(url);
                                if ((DateTime.Now - model.UpdateTime).TotalDays > 5)
                                {
                                    model.ClassName = item.TypeName;
                                    model.CollectionMark = 0;
                                    model.InfoOrigin = item.URL;
                                    model.PageTitle = name;
                                    model.ResouceType = item.ResType;
                                    model.SubClassName = item.SubClassName;
                                    model.UpdateTime = DateTime.Now;
                                    model.Update();
                                    count++;
                                }
                            }
                        }
                        #endregion
                    }
                }
                return ((double)count) / ((double)hc.Count);
            }
            catch (Exception err) { XTrace.WriteException(err); return ((double)count) / ((double)hc.Count); }
            finally { XTrace.WriteLine("通过网页:{0},获取到更新记录页面{1}条", curUrl, count); }
        }
        #endregion

        #region 开始逐一对资源集合进行分析,提取单独资源页面
        //对资源集合数据库中的资源逐一获取下载链接
        public static void StartCollectResoucePages()
        {
            while (tb_fistclasslist.FindCount(tb_fistclasslist._.CollectionMark, 0) > 0)//还有未采集的
            {
                try
                {
                    tb_fistclasslist pageModel = tb_fistclasslist.Find(tb_fistclasslist._.CollectionMark, 0);
                    GetPageResouceList(pageModel);//采集此列表                    
                }
                catch (Exception err)
                {
                    XTrace.WriteException(err);
                    continue;
                }
            }
        }
        #endregion

        #region 开始采集每个页面的链接信息
        public static void StartCollectResouceDownLoadLink()
        {
            while (tb_resoucepageslist.FindCount(tb_resoucepageslist._.CollectionMark, 0) > 0)//还有未采集的
            {
                try
                {
                    tb_resoucepageslist pageModel = tb_resoucepageslist.Find(tb_resoucepageslist._.CollectionMark, 0);
                    GetResoucePageInfo(pageModel);//采集此列表
                }
                catch (Exception err)
                {
                    XTrace.WriteException(err);
                    continue;
                }
            }
        }
        #endregion

        protected static void Test()
        {
            string url = @"http://www.verycd.com/sto/book/eco/";
            HtmlDocument doc = CaptureWebSite.GetHtmlDocument(url, VerycdEncoding);
            HtmlNodeCollection hc = doc.DocumentNode.SelectNodes("//@href");

            foreach (var s in hc)
            {
                string urls = s.Attributes["href"].Value.ToString();
                if (Regex.IsMatch(urls, pagePatten))
                { //不包括“全文”字样
                    string name = s.InnerText.Replace("\r\n", "").Trim();
                    if (name != "" && !name.Contains("全文"))
                        Console.WriteLine(name + ":" + urls);//Attributes["href"].Value.ToString ()
                }
            }
        }

        //以下为基本采集功能方法
        #region 根据大类资源网址获取资源集合列表网址
        //根据大类资源网址获取资源集合列表网址
        public static void GetTypePageList(string URL, string FirName, string SubClassName, ResouceType resType)
        {
            HtmlDocument doc = CaptureWebSite.GetHtmlDocument(URL, VerycdEncoding);
            HtmlNodeCollection hc = doc.DocumentNode.SelectNodes(xPath_TypePageList);
            int count = 0;//计数器
            for (int i = 0; i < hc.Count; i++)
            {
                try
                {
                    string url = (verycdWebSite + hc[i].SelectSingleNode(@"a[1]").Attributes["href"].Value.Trim());
                    if (tb_fistclasslist.FindCount(tb_fistclasslist._.WebURL, url) < 1)
                    {
                        tb_fistclasslist model = new tb_fistclasslist();
                        model.WebURL = url;
                        model.ClassName = FirName;
                        model.SubClassName = SubClassName;
                        model.CollectionMark = 0;
                        model.InfoOrigin = "VeryCd";
                        model.Remark = string.Empty;
                        model.ResouceType = resType.ToString();
                        model.UpdateTime = DateTime.Now;
                        model.Insert();
                        count++;
                    }
                }
                catch (Exception err)
                {
                    XTrace.WriteException(err);
                    continue;
                }
                finally
                {
                    XTrace.WriteLine("通过大类资源列表{0},获取到更新记录{1}条", URL, count);
                }
            }
        }
        #endregion

        #region 根据资源集合列表网址获取单独资源的列表
        //根据资源集合列表网址获取单独资源的列表
        public static void GetPageResouceList(tb_fistclasslist firClassListModel)
        {
            //传入进来的都是可以操作的
            if (firClassListModel.CollectionMark == 2) return;//采集过的不再重复进行
            HtmlDocument doc = CaptureWebSite.GetHtmlDocument(firClassListModel.WebURL, VerycdEncoding);
            HtmlNodeCollection hc = doc.DocumentNode.SelectNodes(xPath_ResouceList);
            firClassListModel.CollectionMark = 1;
            firClassListModel.Update();
            int count = 0;
            try
            {
                for (int i = 0; i < hc.Count; i++)
                {
                    string url = (verycdWebSite + hc[i].SelectSingleNode(@"a[1]").Attributes["href"].Value.Trim());
                    if (tb_resoucepageslist.FindCount(tb_resoucepageslist._.PageURL, url) < 1)
                    {
                        tb_resoucepageslist model = new tb_resoucepageslist();
                        model.PageURL = url;
                        model.PageTitle = hc[i].InnerText.Trim();
                        model.ClassName = firClassListModel.ClassName;
                        model.SubClassName = firClassListModel.SubClassName;
                        model.CollectionMark = 0;
                        model.InfoOrigin = "VeryCd";
                        model.Remark = string.Empty;
                        model.ResouceType = firClassListModel.ResouceType;
                        model.UpdateTime = DateTime.Now;
                        model.Insert();
                        count++;
                    }
                }
            }
            catch (Exception err) { XTrace.WriteException(err); }
            finally
            {
                firClassListModel.CollectionMark = 2; firClassListModel.Update();
                XTrace.WriteLine("通过大类资源列表页面:{0},获取到更新记录{1}条", firClassListModel.WebURL, count);
            }
        }
        #endregion

        #region 根据页面链接获取页面所有的ed2k资源并分析入库
        //根据页面链接获取页面的资源下的信息 详细信息，即名称和下载链接,介绍等
        public static void GetResoucePageInfo(tb_resoucepageslist respageListModel)
        {
            if (respageListModel.CollectionMark == 2) return;
            HtmlDocument doc = CaptureWebSite.GetHtmlDocument(respageListModel.PageURL, VerycdEncoding);
            HtmlNodeCollection hc = doc.DocumentNode.SelectNodes("//@ed2k");
            respageListModel.CollectionMark = 1;
            respageListModel.Update();
            int count = 0;
            try
            {
                for (int i = 0; i < hc.Count; i++)
                {

                    string name = hc[i].Attributes["ed2k"].Value.Trim();
                    string urlLink = HttpUtility.UrlDecode(name, Encoding.UTF8);
                    string[] linkFields = urlLink.Split('|');
                    if (tb_resoucelink.FindCount(tb_resoucelink._.ResouceMD5, linkFields[4]) < 1)
                    {
                        tb_resoucelink model = new tb_resoucelink();
                        model.ResouceMD5 = linkFields[4];
                        model.ResouceName = linkFields[2];
                        model.ResouceLink = urlLink;
                        model.FromURL = respageListModel.PageURL;
                        model.ClassName = respageListModel.ClassName;
                        model.SubClassName = respageListModel.SubClassName;
                        model.InfoOrigin = "VeryCd";
                        model.Remark = string.Empty;
                        model.ResouceType = respageListModel.ResouceType;
                        model.UpdateTime = DateTime.Now;
                        model.Insert();
                        count++;
                    }
                }
            }
            catch (Exception err) { XTrace.WriteException(err); }
            finally
            {
                respageListModel.CollectionMark = 2;
                respageListModel.Update();
                XTrace.WriteLine("从资源页面{0}获取到{1}条新的资源链接", respageListModel.PageURL, count);
            }
        }
        #endregion

        #region 初始化获取资源页面
        //根据大类资源集合网址来提取资源页面集合
        protected static void StartCollectResouceList()
        {
            string firClassName = "图书";
            ResouceType resType = ResouceType.EBook;
            Hashtable ht = new Hashtable();
            ht.Add("http://www.verycd.com/sto/book/novels/", "小说");
            ht.Add("http://www.verycd.com/sto/book/literature/", "文学");
            ht.Add("http://www.verycd.com/sto/book/social/", "人文社科");
            ht.Add("http://www.verycd.com/sto/book/eco/", "经济管理");
            ht.Add("http://www.verycd.com/sto/book/computer/", "计算机与网络");
            ht.Add("http://www.verycd.com/sto/book/life/", "生活");
            ht.Add("http://www.verycd.com/sto/book/edu/", "教育科技");
            ht.Add("http://www.verycd.com/sto/book/children/", "少儿");
            ht.Add("http://www.verycd.com/sto/book/others/", "其它图书");
            //ht.Add("http://www.verycd.com/archives/book/novels/", "小说");
            //ht.Add("http://www.verycd.com/archives/book/literature/", "文学");
            //ht.Add("http://www.verycd.com/archives/book/social/", "人文社科");
            //ht.Add("http://www.verycd.com/archives/book/eco/", "经济管理");
            //ht.Add("http://www.verycd.com/archives/book/computer/", "计算机与网络");
            //ht.Add("http://www.verycd.com/archives/book/life/", "生活");
            //ht.Add("http://www.verycd.com/archives/book/edu/", "教育科技");
            //ht.Add("http://www.verycd.com/archives/book/children/", "少儿");
            //ht.Add("http://www.verycd.com/archives/book/others/", "其它图书");
            foreach (DictionaryEntry element in ht)
            {
                if (tb_typelist.FindCount(tb_typelist._.URL, element.Key.ToString()) < 1)
                {
                    tb_typelist model = new tb_typelist();
                    model.URL = element.Key.ToString().Trim();
                    model.Remark = string.Empty;
                    model.SubClassName = element.Value.ToString().Trim();
                    model.TypeName = firClassName;
                    model.UpdateTime = DateTime.Now;
                    model.ResType = resType.ToString();
                    model.Insert();
                }
            }
        }
        #endregion
    }
}