using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;

namespace DotNet.Tools
{
    /// <summary>
    /// 生活服务
    /// </summary>
    public class LivingService
    {
        #region 静态字段
        /// <summary>
        /// 默认的手机号码提取信息网站前缀
        /// </summary>
        static string DefaultMobileWebSite = @"http://vip.showji.com/locating/?m=";
        #endregion

        #region 查询手机号码归属地
         /// <summary>
        /// 查询手机号码归属地
        /// </summary>
        /// <param name="mobileNo">手机号码</param>
        public static MobileLocating QueryMobileLocating(string mobileNo)
        {
            string htmlCode = GetStringByUrl(DefaultMobileWebSite +mobileNo );//获取网页代码
            MobileLocating model = new MobileLocating ();
            //创建Xml实例
            XmlDocument xmldoc = new XmlDocument();
            //加载Xml文档
            xmldoc.LoadXml(htmlCode);
            //获取Xml文档的根元素
            XmlElement root = xmldoc.DocumentElement;
            //获取Xml文档的根元素下的所有子节点
            XmlNodeList topNode = xmldoc.DocumentElement.ChildNodes;
            //子节点集合
            XmlNodeList elemList;
            //遍历根元素下所有子节点
            foreach (XmlElement element in topNode)
            {
                //根据节点名称获取节点元素值
                elemList = root.GetElementsByTagName(element.Name);
                switch (element.Name)
                {
                    //判断手机号码格式是否正确
                    case "QueryResult":
                        if (elemList[0].InnerText.ToString() == "False")
                            MessageBox.Show("您输入的手机号码格式有误，请重新输入！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;                    
                    case "Mobile"://手机号码
                        model.Mobile = elemList[0].InnerText;
                        break;                    
                    case "Province"://所属省份
                        model.Province = elemList[0].InnerText;
                        break;                    
                    case "City"://所属城市
                        model.City = elemList[0].InnerText;
                        break;                    
                    case "AreaCode"://区号
                        model.AreaCode = elemList[0].InnerText;
                        break;                    
                    case "PostCode": //邮编
                        model.PostCode = elemList[0].InnerText;
                        break;                    
                    case "Corp":
                        model.Corp = elemList[0].InnerText;//运营商
                        break;
                    //卡类型
                    case "Card":                                                
                        model.Card = model.Corp + elemList[0].InnerText;//拼接字符串（运营商+卡类型）
                        break;
                }
            }
            return model ;
        }
        #endregion

        #region 其他辅助方法
        /// <summary>
        /// 抓取网页html代码
        /// </summary>
        /// <param name="strUrl">URL</param>
        /// <returns></returns>
        private static string GetStringByUrl(string strUrl)
        {
            //与指定URL创建HTTP请求
            WebRequest wrt = WebRequest.Create(strUrl);
            //获取对应HTTP请求的响应
            WebResponse wrse = wrt.GetResponse();
            //获取响应流
            Stream strM = wrse.GetResponseStream();
            //对接响应流(以"GBK"字符集)
            StreamReader SR = new StreamReader(strM, Encoding.GetEncoding("UTF-8"));
            //获取响应流的全部字符串
            string strallstrm = SR.ReadToEnd();
            //关闭读取流
            SR.Close();

            //返回网页html代码
            return strallstrm;
        }
        #endregion
    }
    
    #region 手机号码实体类
    /// <summary>
    /// 手机号码归属地
    /// </summary>
    public class MobileLocating
    {
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区号
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// 运营商
        /// </summary>
        public string Corp { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public string Card { get; set; }
    }    
    #endregion
}
