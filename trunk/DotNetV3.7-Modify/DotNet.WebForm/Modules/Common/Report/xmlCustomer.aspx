<%@ Page Language="C#" %>

<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Runtime.Serialization" %>
<%@ Import Namespace="System.Runtime.Serialization.Formatters.Binary" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="DotNet.Utilities" %>

<script runat="server">

    string CategoryCode = string.Empty;
    string ObjectId = string.Empty;

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
    }
    #endregion

    /// <summary>
    /// dataset 转转换byte[] 字节
    /// </summary>
    /// <param name="ds"></param>
    public static byte[] DataToByte(DataSet ds)
    {
        byte[] bArrayResult = null;
        ds.RemotingFormat = SerializationFormat.Binary;
        MemoryStream ms = new MemoryStream();
        IFormatter bf = new BinaryFormatter();
        bf.Serialize(ms, ds);
        bArrayResult = ms.ToArray();
        ms.Close();
        ms.Dispose();
        return bArrayResult;
    }
    
    /// <summary>
    /// byte[] 字节转datasheet
    /// </summary>
    /// <param name="bArrayResult"></param>
    /// <returns></returns>
    public static DataSet ByteToDataset(byte[] bArrayResult)
    {
        DataSet dsResult = new DataSet();
        MemoryStream ms = new MemoryStream(bArrayResult);
        IFormatter bf = new BinaryFormatter();
        object obj = bf.Deserialize(ms);
        dsResult = (DataSet)obj;
        ms.Close();
        ms.Dispose();
        return dsResult;
    }
    
    /// <summary>
    /// 第二种方法转换
    /// </summary>
    /// <param name="ds"></param>
    /// <returns></returns>
    public static byte[] GetBinaryFormatDataSet(DataSet ds)
    {
        //创建内存流
        MemoryStream memStream = new MemoryStream();
        //产生二进制序列化格式
        IFormatter formatter = new BinaryFormatter();
        //指定DataSet串行化格式是二进制
        ds.RemotingFormat = SerializationFormat.Binary;
        //串行化到内存中
        formatter.Serialize(memStream, ds);
        //将DataSet转化成byte[]
        byte[] binaryResult = memStream.ToArray();
        //清空和释放内存流
        memStream.Close();
        memStream.Dispose();
        return binaryResult;
    }
    
    /// <summary>
    ///  第二种方法转换
    /// </summary>
    /// <param name="binaryData"></param>
    /// <returns></returns>
    public static DataSet RetrieveDataSet(byte[] binaryData)
    {
        //创建内存流
        MemoryStream memStream = new MemoryStream(binaryData);
        memStream.Seek(0, SeekOrigin.Begin);
        //产生二进制序列化格式
        IFormatter formatter = new BinaryFormatter();
        //反串行化到内存中
        object obj = formatter.Deserialize(memStream);
        //类型检验
        if (obj is DataSet)
        {
            DataSet dataSetResult = (DataSet)obj;
            return dataSetResult;
        }
        else
        {
            return null;
        }
    }

    private void GetReport()
    {
        if (!string.IsNullOrEmpty(this.CategoryCode) && !string.IsNullOrEmpty(this.ObjectId))
        {
            // ReportHelper reportHelper = new ReportHelper();
            // DataSet ds = reportHelper.GetReportDate(this.CategoryCode, this.ObjectId);

            IDbHelper dbHelper = new SqlHelper(BaseSystemInfo.BusinessDbConnection);
            string commandText = "SELECT 报表附件 FROM OA网页报表 WHERE 报表类型= '" + CategoryCode + "' AND 单据号码 = '" + ObjectId + "' ";
            IDataReader dataReader = dbHelper.ExecuteReader(commandText);
            string fileName = string.Empty;
            byte[] binaryData = null;
            while (dataReader.Read())
            {
                binaryData = (byte[])dataReader["报表附件"];
            }
            if (binaryData != null)
            {
                DataSet ds = RetrieveDataSet(binaryData);
                ReportData.GenNodeXmlData(this, ds, true);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.GetParamters();
            this.GetReport();
        }
    }
</script>
