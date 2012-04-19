using System.Data;
using System.Data.SqlClient;

/////////////////////////////////////////////////////////////////////////////////////////////////////////
//class SqlReportData
public class SqlReportData
{
    //★特别提示★：
    //连接SQL Server数据库的连接串，应该修改为与实际一致。如果是运行Grid++Report本身的例子，应该首先附加例子数据库到
    //SQL Server2000/2005数据库上。
    public const string SqlConnStr = "Data Source=192.168.0.66;Initial Catalog=newData;User Id = sincocn ; Password = sincocndnzx;";

    //定义在SQL中表示日期值的包围符号，Access用“#”, 而MS SQl Server用“'”，为了生成两者都可用的查询SQL语句，将其参数化定义出来。这样处理只是为了演示例子方便
    public const char DateSqlBracketChar = '\'';

    //根据查询SQL,产生提供给报表生成需要的XML数据，采用 Sql 数据引擎
    public static void GenNodeXmlData(System.Web.UI.Page DataPage, string QuerySQL, bool ToCompress)
    {
        SqlConnection myConn = new SqlConnection(SqlConnStr);
        SqlDataAdapter myda = new SqlDataAdapter(QuerySQL, myConn);
        DataSet myds = new DataSet();
        myConn.Open();
        myda.Fill(myds);
        myConn.Close();

        ReportData.GenNodeXmlData(DataPage, myds, ToCompress);
    }

    //根据查询SQL,产生提供给报表生成需要的XML数据，采用 Sql 数据引擎, 这里只产生报表参数数据
    //当报表没有明细时，调用本方法生成数据，查询SQL应该只能查询出一条记录
    public static void GenParameterReportData(System.Web.UI.Page DataPage, string ParameterQuerySQL)
    {
        SqlConnection myConn = new SqlConnection(SqlConnStr);
        SqlCommand myCommand = new SqlCommand(ParameterQuerySQL, myConn);
        myConn.Open();
        SqlDataReader myReader = myCommand.ExecuteReader();
        ReportData.GenParameterData(DataPage, myReader);
        myReader.Close();
        myConn.Close();
    }

    //根据查询SQL,产生提供给报表生成需要的XML数据，采用 Sql 数据引擎, 根据RecordsetQuerySQL获取报表明细数据，根据ParameterQuerySQL获取报表参数数据
    public static void GenEntireReportData(System.Web.UI.Page DataPage, string RecordsetQuerySQL, string ParameterQuerySQL, bool ToCompress)
    {
        SqlConnection myConn = new SqlConnection(SqlConnStr);
        myConn.Open();

        SqlDataAdapter myda = new SqlDataAdapter(RecordsetQuerySQL, myConn);
        DataSet myds = new DataSet();
        myda.Fill(myds);

        SqlCommand mycmd = new SqlCommand(ParameterQuerySQL, myConn);
        SqlDataReader mydr = mycmd.ExecuteReader(CommandBehavior.CloseConnection);
        string ParameterPart = ReportData.GenParameterXMLText(mydr);

        ReportData.GenEntireReportData(DataPage, myds, ref ParameterPart, ToCompress);

        myConn.Close();
    }

    //根据查询SQL,产生提供给报表生成需要的XML数据，采用 Sql 数据引擎，字段值为空也产生数据
    public static void FullGenNodeXmlData(System.Web.UI.Page DataPage, string QuerySQL, bool ToCompress)
    {
        SqlConnection myConn = new SqlConnection(SqlConnStr);
        SqlCommand myCommand = new SqlCommand(QuerySQL, myConn);
        myConn.Open();
        SqlDataReader myReader = myCommand.ExecuteReader();
        ReportData.GenNodeXmlDataFromReader(DataPage, myReader, ToCompress);
        myReader.Close();
        myConn.Close();
    }

    //分批取数时，用 SqlDataReader 产生报表XML数据
    //参数 SessionItemName 指定在 Session 中记录 SqlDataReader 对象的名称，应该保证每个报表用不同的名称
    //参数 QuerySQL 指定获取报表数据的查询SQL
    //参数 StartNo 指定本次取数的第一条记录的序号，从0开始；当为0时，表示是取第一批次的数据
    //参数 WantRows 指定本次取数希望获取的记录条数，当为0时，自动按100获取
    //参数 ToCompress 指定是否对XML数据进行压缩
    public static void BatchGenXmlDataByDataReader(System.Web.UI.Page DataPage, string SessionItemName, string QuerySQL, int StartNo, int WantRows, bool ToCompress)
    {
        if (WantRows <= 0)
            WantRows = 100;

        SqlDataReader myReader = (SqlDataReader)DataPage.Session[SessionItemName];

        //如果是第一次取数，不应该用前面的数据
        if ((StartNo == 0) && (myReader != null))
        {
            DataPage.Session.Remove(SessionItemName);
            myReader = null;
        }

        if (myReader == null)
        {
            SqlConnection myConn = new SqlConnection(SqlConnStr);
            SqlCommand myCommand = new SqlCommand(QuerySQL, myConn);
            myConn.Open();
            myReader = myCommand.ExecuteReader();
            DataPage.Session[SessionItemName] = myReader;
            //myConn.Close();
        }

        int Rows = ReportData.BatchGenXmlDataFromDataReader(DataPage, myReader, WantRows, ToCompress);

        if (Rows <= 0) //if (Rows < WantRows)
        {
            DataPage.Session.Remove(SessionItemName);
            myReader.Close();
        }
    }

    //分批取数时，用 DataTable 产生报表XML数据，此方法可以在HTTP响应头中指定记录的总数，以便报表插件在客户端展现时产生更准确的分页信息 
    //参数 SessionItemName 指定在 Session 中记录 SqlDataReader 对象的名称，应该保证每个报表用不同的名称
    //参数 QuerySQL 指定获取报表数据的查询SQL
    //参数 StartNo 指定本次取数的第一条记录的序号，从0开始；当为0时，表示是取第一批次的数据
    //参数 WantRows 指定本次取数希望获取的记录条数，当为0时，自动按100获取
    //参数 ToCompress 指定是否对XML数据进行压缩
    public static void BatchGenXmlDataByDataTable(System.Web.UI.Page DataPage, string SessionItemName, string QuerySQL, int StartNo, int WantRows, bool ToCompress)
    {
        if (WantRows <= 0)
            WantRows = 100;

        DataTable dt = (DataTable)DataPage.Session[SessionItemName];

        //如果是第一次取数，不应该用前面的数据
        if ((StartNo == 0) && (dt != null))
        {
            DataPage.Session.Remove(SessionItemName);
            dt = null;
        }

        if (dt == null)
        {
            SqlConnection myConn = new SqlConnection(SqlConnStr);
            SqlDataAdapter myda = new SqlDataAdapter(QuerySQL, myConn);
            dt = new DataTable();
            myConn.Open();
            myda.Fill(dt);
            myConn.Close();

            DataPage.Session[SessionItemName] = dt;
        }

        int Rows = ReportData.BatchGenXmlDataFromDataTable(DataPage, dt, StartNo, WantRows, ToCompress);

        //如果没有取得数据，说明数据已经取完，则清理掉Session中记录的数据
        if (Rows <= 0) //if (Rows < WantRows)
            DataPage.Session.Remove(SessionItemName);
    }

    //获取 Count(*) SQL 查询到的数据行数
    //参数 QuerySQL 指定获取报表数据的查询SQL
    public static int BatchGetDataCount(string QuerySQL)
    {
        int Total = 0;

        SqlConnection myConn = new SqlConnection(SqlConnStr);
        SqlCommand myCommand = new SqlCommand(QuerySQL, myConn);
        myConn.Open();
        SqlDataReader myReader = myCommand.ExecuteReader();
        if (myReader.Read())
            Total = myReader.GetInt32(0);
        myReader.Close();
        myConn.Close();

        return Total;
    }
}