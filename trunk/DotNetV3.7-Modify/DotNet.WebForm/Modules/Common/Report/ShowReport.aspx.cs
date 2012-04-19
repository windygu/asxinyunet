//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.UI;

using DotNet.Business;
using DotNet.Utilities;

public partial class ShowReport : BasePage
{
    private bool allowPrint = false;
    /// <summary>
    /// 允许打印
    /// </summary>
    public bool AllowPrint
    {
        get
        {
            return this.allowPrint;
        }
        set
        {
            this.allowPrint = value;
        }
    }

    private string categoryCode = string.Empty;
    /// <summary>
    /// 单据类别
    /// </summary>
    public string CategoryCode
    {
        get
        {
            return this.categoryCode;
        }
        set
        {
            this.categoryCode = value;
        }
    }

    private string objectId = string.Empty;
    /// <summary>
    /// 单据主键
    /// </summary>
    public string ObjectId
    {
        get
        {
            return this.objectId;
        }
        set
        {
            this.objectId = value;
        }
    }

    private string currentId = String.Empty;
    public string CurrentId
    {
        get
        {
            return this.currentId;
        }
        set
        {
            this.currentId = value;
        }
    }

    private string reportParamters = String.Empty;
    /// <summary>
    /// 表表参数
    /// </summary>
    public string ReportParamters
    {
        get
        {
            return this.reportParamters;
        }
        set
        {
            this.reportParamters = value;
        }
    }

    private string reportSignature = String.Empty;
    /// <summary>
    /// 表表签名
    /// </summary>
    public string ReportSignature
    {
        get
        {
            return this.reportSignature;
        }
        set
        {
            this.reportSignature = value;
        }
    }

    private string printBegin = String.Empty;
    /// <summary>
    /// 表表控制
    /// </summary>
    public string PrintBegin
    {
        get
        {
            return this.printBegin;
        }
        set
        {
            this.printBegin = value;
        }
    }    

    #region private void GetParamters() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamters()
    {
        if (Page.Request["CategoryCode"] != null)
        {
            this.CategoryCode = Page.Request["CategoryCode"].ToString();
        }
        if (Page.Request["ObjectId"] != null)
        {
            this.ObjectId = Page.Request["ObjectId"].ToString();
        }
        if (Page.Request["Id"] != null)
        {
            this.CurrentId = Page.Request["Id"].ToString();
        }
    }
    #endregion

    /// <summary>
    /// 获取报表参数
    /// </summary>
    private void GetReportParamters()
    {
        if (string.IsNullOrEmpty(this.CategoryCode) || string.IsNullOrEmpty(this.ObjectId))
        {
            return;
        }
        // Report.ParameterByName("Year").AsInteger = YearMonthDay[0];
        // Report.ParameterByName("Amount").AsFloat = document.getElementById("txtAmount").value;
        // Report.ParameterByName("Usage").AsString = document.getElementById("txtUsage").value;

        IDbHelper sqlHelper = new SqlHelper(BaseSystemInfo.BusinessDbConnection);
        string commandText = "SELECT 参数名称,参数值,参数类型 " 
                            + " FROM OA网页报表参数 " 
                           + " WHERE 报表类型 = '" + this.CategoryCode + "' AND 单据号码 = '" + this.ObjectId + "'";
        IDataReader dataReader = sqlHelper.ExecuteReader(commandText);
        string paramterType = string.Empty;
        while (dataReader.Read())
        {
            paramterType = dataReader["参数类型"].ToString();
            if (paramterType.Equals("System.String"))
            {
                this.ReportParamters += "Report.ParameterByName(\"" + dataReader["参数名称"].ToString() + "\").AsString = '" + dataReader["参数值"].ToString() + "';" + System.Environment.NewLine;
            }
            else if (paramterType.Equals("System.Int16") || paramterType.Equals("System.Int32") || paramterType.Equals("System.Int64"))
            {
                this.ReportParamters += "Report.ParameterByName(\"" + dataReader["参数名称"].ToString() + "\").AsInteger = " + dataReader["参数值"].ToString() + ";" + System.Environment.NewLine;
            }
            else if (paramterType.Equals("System.Double") || paramterType.Equals("System.Decimal") || paramterType.Equals("System.float"))
            {
                this.ReportParamters += "Report.ParameterByName(\"" + dataReader["参数名称"].ToString() + "\").AsFloat = " + dataReader["参数值"].ToString() + ";" + System.Environment.NewLine;
            }
        }
    }

    private DataTable GetReportSignatureDate(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
    {
        DataTable signatureDateDT = null;
        if (!string.IsNullOrEmpty(workFlowCurrentEntity.Id))
        {
            BaseWorkFlowHistoryManager workFlowHistoryManager = new BaseWorkFlowHistoryManager(this.UserInfo);
            signatureDateDT = workFlowHistoryManager.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowHistoryTable.FieldCurrentFlowId, workFlowCurrentEntity.Id), BaseWorkFlowHistoryTable.FieldCreateOn + " DESC");
            // 去掉退回的
            // BaseBusinessLogic.SetFilter(signatureDateDT, BaseWorkFlowHistoryTable.FieldAuditStatus, "AuditReject", true);
            // 去掉撤销的
            // BaseBusinessLogic.SetFilter(signatureDateDT, BaseWorkFlowHistoryTable.FieldAuditStatus, "AuditQuash", true);
        }
        return signatureDateDT;
    }

    private string GetReportSignatureDate(DataTable signatureDateDT, string activityId, out string userId)
    {
        userId = string.Empty;
        string returnValue = string.Empty;
        if (signatureDateDT != null)
        {
            foreach (DataRow dataRow in signatureDateDT.Rows)
            {
                // if (dataRow[BaseWorkFlowHistoryTable.FieldAuditUserId].ToString().Equals(userId))
                if (dataRow[BaseWorkFlowHistoryTable.FieldActivityId].ToString().Equals(activityId))
                {
                    if (dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus].ToString().Equals(AuditStatus.AuditPass.ToString())
                        || dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus].ToString().Equals(AuditStatus.AuditComplete.ToString())
                        || dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus].ToString().Equals(AuditStatus.WaitForAudit.ToString())
                        )
                    {
                        userId = dataRow[BaseWorkFlowHistoryTable.FieldAuditUserId].ToString();
                        returnValue = dataRow[BaseWorkFlowHistoryTable.FieldAuditDate].ToString();
                        break;
                    }
                }
            }
        }
        return returnValue;
    }

    /// <summary>
    /// 获取报表签名
    /// </summary>
    private void GetReportSignature()
    {
        BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
        BaseWorkFlowCurrentEntity workFlowCurrentEntity = workFlowCurrentManager.GetEntity(this.CurrentId);
        // 通过当前的工作流主键,获得当前的审批流程主键
        BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.UserInfo);
        // 通过审批步骤,获取当前的用户
        // 再看当前用户,有审批通过否?再能确认是否审核通过
        // 当前是审核到了第几步了.是否有被退回情况等,需要确认.
        DataTable dt = null;
        string userId = string.Empty;
        if (workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.AuditPass.ToString())
            || workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.WaitForAudit.ToString()))
        {
            dt = workFlowActivityManager.GetBackToDT(workFlowCurrentEntity);
        }
        else if (workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.AuditComplete.ToString()))
        {
            dt = workFlowActivityManager.GetBackToDT(workFlowCurrentEntity.Id, workFlowCurrentEntity.WorkFlowId.ToString());
        }
        if (dt != null)
        {
            dt.Columns.Remove("Id");
            dt.Columns["ActivityId"].ColumnName = "Id";
            BaseBusinessLogic.SetFilter(dt, "Id", null, true);
        }
        if (dt != null)
        {
            DataTable signatureDateDT = GetReportSignatureDate(workFlowCurrentEntity);
            int userSignature = 0;
            string activityId = string.Empty;
            string userSignatureDate = string.Empty;
            userSignature = 1;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userId))
                {
                    this.ReportSignature += "Report.ControlByName(\"UserSignature1\").AsPictureBox.LoadFromFile(\"ReportData/UserSignature.aspx?UserId=" + userId + "\");" + System.Environment.NewLine;
                    this.ReportSignature += "Report.ParameterByName(\"UserSignatureDate1\").AsString = (\"" + userSignatureDate + "\");" + System.Environment.NewLine;
                }
            }
            userSignature = 2;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userId))
                {
                    this.ReportSignature += "Report.ControlByName(\"UserSignature2\").AsPictureBox.LoadFromFile(\"ReportData/UserSignature.aspx?UserId=" + userId + "\");" + System.Environment.NewLine;
                    this.ReportSignature += "Report.ParameterByName(\"UserSignatureDate2\").AsString = (\"" + userSignatureDate + "\");" + System.Environment.NewLine;
                }
            }
            userSignature = 3;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userId))
                {

                    this.ReportSignature += "Report.ControlByName(\"UserSignature3\").AsPictureBox.LoadFromFile(\"ReportData/UserSignature.aspx?UserId=" + userId + "\");" + System.Environment.NewLine;
                    this.ReportSignature += "Report.ParameterByName(\"UserSignatureDate3\").AsString = (\"" + userSignatureDate + "\");" + System.Environment.NewLine;

                }
            }
            userSignature = 4;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userId))
                {
                    this.ReportSignature += "Report.ControlByName(\"UserSignature4\").AsPictureBox.LoadFromFile(\"ReportData/UserSignature.aspx?UserId=" + userId + "\");" + System.Environment.NewLine;
                    this.ReportSignature += "Report.ParameterByName(\"UserSignatureDate4\").AsString = (\"" + userSignatureDate + "\");" + System.Environment.NewLine;
                }
            }
            userSignature = 5;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userId))
                {
                    this.ReportSignature += "Report.ControlByName(\"UserSignature5\").AsPictureBox.LoadFromFile(\"ReportData/UserSignature.aspx?UserId=" + userId + "\");" + System.Environment.NewLine;
                    this.ReportSignature += "Report.ParameterByName(\"UserSignatureDate5\").AsString = (\"" + userSignatureDate + "\");" + System.Environment.NewLine;
                }
            }
            userSignature = 6;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userId))
                {
                    this.ReportSignature += "Report.ControlByName(\"UserSignature6\").AsPictureBox.LoadFromFile(\"ReportData/UserSignature.aspx?UserId=" + userId + "\");" + System.Environment.NewLine;
                    this.ReportSignature += "Report.ParameterByName(\"UserSignatureDate6\").AsString = (\"" + userSignatureDate + "\");" + System.Environment.NewLine;
                }
            }
            userSignature = 7;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userId))
                {
                    this.ReportSignature += "Report.ControlByName(\"UserSignature7\").AsPictureBox.LoadFromFile(\"ReportData/UserSignature.aspx?UserId=" + userId + "\");" + System.Environment.NewLine;
                    this.ReportSignature += "Report.ParameterByName(\"UserSignatureDate7\").AsString = (\"" + userSignatureDate + "\");" + System.Environment.NewLine;
                }
            }
            userSignature = 8;
            if (dt.Rows.Count >= userSignature)
            {
                activityId = dt.Rows[userSignature - 1][BaseWorkFlowActivityEntity.FieldId].ToString();
                userSignatureDate = GetReportSignatureDate(signatureDateDT, activityId, out userId);
                if (!string.IsNullOrEmpty(userId))
                {
                    this.ReportSignature += "Report.ControlByName(\"UserSignature8\").AsPictureBox.LoadFromFile(\"ReportData/UserSignature.aspx?UserId=" + userId + "\");" + System.Environment.NewLine;
                    this.ReportSignature += "Report.ParameterByName(\"UserSignatureDate8\").AsString = (\"" + userSignatureDate + "\");" + System.Environment.NewLine;
                }
            }
        }
    }

    /// <summary>
    /// 将数据库中报表保存到文件中
    /// </summary>
    private void SaveReport()
    {
        if (string.IsNullOrEmpty(this.CategoryCode))
        {
            return;
        }
        // 从配置文件读取报表存放路径
        string reportPath = string.Empty;
        reportPath = ConfigurationManager.AppSettings["ReportPath"];
        if (string.IsNullOrEmpty(reportPath))
        {
            reportPath = "E:/DotNet.CommonV3.6/DotNet.WebForm/Modules/Common/WorkFlow/Report/";
        }

        IDbHelper sqlHelper = new SqlHelper(BaseSystemInfo.BusinessDbConnection);
        string commandText = "SELECT 报表附件 FROM OA报表文件 WHERE LEN(ReportName) > 0 AND ReportName = '" + this.CategoryCode + "'";
        IDataReader dataReader = sqlHelper.ExecuteReader(commandText);
        string fileName = string.Empty;
        byte[] file = null;
        while (dataReader.Read())
        {
            file = (byte[])dataReader["报表附件"];
            fileName = reportPath + this.CategoryCode + ".grf";
            FileUtil.SaveFile(file, fileName);
        }
    }

    /// <summary>
    /// 显示单据内容
    /// </summary>
    private void ShowDetails()
    {
        if (!string.IsNullOrEmpty(this.CurrentId))
        {
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.WorkFlowDbHelper, this.UserInfo);
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = workFlowCurrentManager.GetEntity(this.CurrentId);
            // 显示友善的标题
            this.Title = workFlowCurrentEntity.ObjectFullName;
            // 从模板表里有效状态区分,是否模板还是报表
            this.CategoryCode = workFlowCurrentEntity.CategoryCode;
            this.ObjectId = workFlowCurrentEntity.ObjectId;
            // 计算是否有打印权限，审核通过的有打印权限，当前步骤可以打印的，有打印权限
            if (workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.AuditComplete.ToString()))
            {
                this.AllowPrint = true;
            }
            else
            {
                if (workFlowCurrentEntity.ActivityId != null)
                {
                    string activityId = workFlowCurrentEntity.ActivityId.ToString();
                    BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.WorkFlowDbHelper, this.UserInfo);
                    this.AllowPrint = (workFlowActivityManager.GetEntity(activityId).AllowPrint == 1);
                }
            }
        }
    }

    private void GetPrintBegin()
    {
        // 一般人都没这个权限的,看不到最近的单价,超级管理员可以有,指定授权的人可以有
        // if (!this.IsAuthorized("ViewPreviousPrice", "查看报表最近价格权限"))
        // {
            switch (this.CategoryCode)
            {
                case "PuTongCaiGouDan":
                case "GuoNeiCaiGouHeTong":
                case "PutongCaiGouDanDGM":
                case "PutongCaiGouDanManager":
                case "MoJuCaiGouHeTongP":
                case "MoJuCaiGouHeTongGM":
                    this.PrintBegin = "Report.ColumnByName(\"最低单价\").Visible = false; \n\r";
                    this.PrintBegin += "ReportViewer.QuickRefresh(); \n\r";
                    break;
            }
        //}
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // 应该是检查是否已登录
        if (!Page.IsPostBack)
        {
            this.GetParamters();
            this.ShowDetails();
            this.SaveReport();
            this.GetPrintBegin();
            this.GetReportParamters();
            this.GetReportSignature();
        }
    }
}


/*

 
成员名称

枚举值

说明



grdtctSep
1
指定分隔按钮。

grdtctPrint
2
指定打印按钮。

grdtctPageSetup
3
指定打印页面设置按钮。

grdtctPrinterSetup
4
指定打印机设置按钮。

grdtctExport
5
指定导出按钮。

grdtctMail
6
指定邮件发送按钮。

grdtctSaveDocument
7
指定保存打印文档按钮。

grdtctPriorPage
14
指定上一页按钮。

grdtctNextPage
15
指定下一页按钮。

grdtctFirstPage
16
指定首页按钮。

grdtctLastPage
17
指定最后页按钮。

grdtctCurPageNo
18
指定页号编辑框。
grdtctClose
19
指定关闭按钮。
grdtctClip
20
指定按钮，尚未实现。
grdtctRefresh
21
指定刷新按钮。



grdtctFindTextBox

30

指定查找编辑框。



grdtctFind

31

指定查找按钮。



grdtctFindAgain

32

指定继续查找按钮。



grdtctFindDlg

33

指定查找对话框按钮。



grdtctPrintPreview

40

指定打印预览按钮。



grdtctPostLayout

41

指定打印提交布局选取框。



grdtctExportXLS

50

指定导出 Excel 菜单项。



grdtctExportTXT

51

指定导出文本菜单项。



grdtctExportHTM

52

指定导出 HTML 菜单项。



grdtctExportRTF

53

指定导出 RTF 菜单项。



grdtctExportPDF

54

指定导出 PDF 菜单项。



grdtctExportCSV

55

指定导出 CSV 菜单项。



grdtctExportIMG

56

指定导出图像菜单项。



grdtctExportXLSBtn

60

指定导出 Excel 按钮。



grdtctExportPDFBtn

61

指定导出 PDF 按钮。


 */