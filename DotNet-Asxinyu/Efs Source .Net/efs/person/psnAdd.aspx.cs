using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System;
using System.Xml;
using System.Data;
using Efsframe.cn.db;
using Efsframe.cn.declare;
using Efsframe.cn.func;
using Efsframe.cn.baseCls;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Efsframe.cn.person;
using Efsframe.cn.baseManage;
using XCode;
using XCode.DataAccessLayer;
using ResourceEnties;

public partial class person_psnAdd : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        string strXml = Request["txtXML"];
        //Response.Write(PageCommon.showMsg(strXml, "back"));
        if (!General.empty(strXml))
        {
            try
            {
                //UserSession userSession = ((UserSession)Session["RoleUser"]);
                //strXml = PageCommon.setOpDocXML(strXml, userSession);
                string strRetXml = person.addNew(strXml);
                //if (PageCommon.IsSucceed(strRetXml))
                //{
                //    Response.Write(PageCommon.showMsg("添加成功!", "../task.aspx"));
                //    Response.End();
                //}
                //else
                //{
                //    Response.Write(PageCommon.showMsg("添加失败,错误原因是：" + PageCommon.getErrInfo(strRetXml), "back"));
                //    Response.End();
                //} PERSON/NAME
                UserSession userSession = ((UserSession)Session["RoleUser"]);
                strXml = PageCommon.setOpDocXML(strXml, userSession);
                //string strRetXml = person.addNew(strXml);
                XmlDocument obj_Doc = XmlFun.CreateNewDoc(strXml);
                XmlNodeList nodeLst = obj_Doc.SelectNodes("//*[@operation][@operation!='']");
                IEntityOperate io = EntityFactory.CreateOperate(typeof(PERSON));
                for (int i = 0; i < nodeLst.Count; i++)
                {
                    XmlElement ele_Temp = (XmlElement)nodeLst.Item(i);
                    // 分配学生编码
                    string strpersonid = NumAssign.assignID_B("100001", "1007");
                    XmlFun.setNodeValue(ele_Temp.SelectSingleNode("//PERSONID"), strpersonid);
                    string stT = ele_Temp.InnerXml;

                    XmlNodeList it_Temp = ele_Temp.ChildNodes;
                    IEntity CurrentEntity = io.Create();
                    //DAL.Create("StudentConn").CreateOperate("PERSON").Create();
                    for (int k = 0; k < it_Temp.Count; k++)
                    {
                        XmlNode ele_Field = it_Temp[k];
                        String str_State = XmlFun.getAttributValue(ele_Field, Common.XML_PROP_STATE);
                        String str_FieldName = ele_Field.Name;
                        String str_FieldValue = ele_Field.InnerText;
                        if (General.empty(str_State)) continue;

                        if (str_State.Equals(Common.ST_NORMAL))
                        {
                            string str_DataType = XmlFun.getAttributValue(ele_Field, Common.XML_PROP_DATATYPE);
                            if (General.empty(str_DataType)) continue;
                            int int_DataType = Convert.ToInt32(str_DataType);
                            CurrentEntity.SetItem(str_FieldName, str_FieldValue);                            
                        }                        
                    }
                    CurrentEntity.Insert();
                }
                Response.Write(PageCommon.showMsg("添加成功!", "../task.aspx"));
            }
            catch (Exception ep)
            {
                string strRet = ep.Message;
                Response.Write(PageCommon.showMsg("异常错误：" + strRet, "back"));
                Response.End();
            }
        }
    }
}
