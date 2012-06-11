using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Linq;
using System.IO;
using System.Text;
using ResouceEntity;
using NewLife.Log;
using NewLife.Reflection;
using System.Web;
using System.Web.SessionState;

namespace ResourceManage
{
    static class Program
    {     
        static void Main()
        {
            //测试调用任意方法，特别是带参数  GetPageEntityList  GetColunmsData
            //tb_resoucepageslist a = new tb_resoucepageslist();
            //string typeName = "tb_resoucepageslist";
            //string methodName = "GetPageEntityList";
            //var type = TypeX.GetType(typeName);
            //var method = TypeX.GetMethod(type, methodName, null);

            Console.WriteLine("OK!");
            Console.ReadKey();
        }
    }
}


public class AjaxTest 
{
    private HttpContext context;

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        this.context = context;
        try { Run(context); }
        catch (Exception ex) { XTrace.WriteException(ex); }
    }

    void Run(HttpContext context)
    {
        var Request = context.Request;
        var Response = context.Response;

        var typeName = Request["type"];
        var methodName = Request["method"];

        var type = TypeX.GetType(typeName);
        if (type == null)
        {
            Console.WriteLine(string.Format("找不到类{0}", typeName));           
            return;
        }
        var method = TypeX.GetMethod(type, methodName, null);
        // 支持静态属性
        if (method == null)
        {
            var pi = PropertyInfoX.Create(type, methodName);
            if (pi != null) method = pi.GetMethod;
        }
        if (method == null)
        {
            Console.WriteLine(string.Format("找不到类{0} 方法{1}", typeName, methodName));                   
            return;
        }
        object obj = null;
        // 是否以httpcontext为第一个参数，创建一个实例
        if (!String.IsNullOrEmpty(Request["HttpContext"]))
        {
            var objtype = TypeX.GetType(typeName);
            obj = TypeX.CreateInstance(objtype, new object[] { context });
        }
        // 是否 实例化对象
        else if (!String.IsNullOrEmpty(Request["Instance"]))
        {
            var objtype = TypeX.GetType(typeName);
            obj = TypeX.CreateInstance(objtype);
        }
        var result = MethodInfoX.Create(method).Invoke(obj, GetMethodParms(method, context));
                
    }

    public bool IsReusable { get { return false; } }

    #region 方法参数
    /// <summary>
    /// 获取方法的参数值
    /// </summary>
    /// <param name="method"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public static object[] GetMethodParms(MethodInfo method, HttpContext context)
    {
        var parms = method.GetParameters();
        return GetMethodParms(parms, context);
    }
    /// <summary>
    /// 获取方法的参数值
    /// </summary>
    /// <param name="parms"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public static object[] GetMethodParms(ParameterInfo[] parms, HttpContext context)
    {
        var objs = new object[parms.Length];
        for (var i = 0; i < parms.Length; i++)
        {
            var parm = parms[i];
            if (parm.ParameterType == typeof(NameValueCollection))
            {
                if (parm.Name.EqualIgnoreCase("Form"))
                    objs[i] = context.Request.Form;
                else if (parm.Name.EqualIgnoreCase("QueryString"))
                    objs[i] = context.Request.QueryString;
            }
            else
            {
                Type paramterType = parm.ParameterType;
                if (parm.ParameterType.IsGenericType)
                    paramterType = Nullable.GetUnderlyingType(parm.ParameterType) ?? parm.ParameterType;
                if (Type.GetTypeCode(paramterType) != TypeCode.Object)
                {
                    objs[i] = TypeX.ChangeType(context.Request[parm.Name], paramterType);
                }
                else
                {
                    //如果这个参数 是自定义的类，那么实例化一个对象，然后使用 Request键值对 赋值
                    var obj = Activator.CreateInstance(paramterType);

                    foreach (var fi in paramterType.GetFields(BindingFlags.Instance | BindingFlags.Public))
                    {
                        var val = TypeX.ChangeType(context.Request[fi.Name], fi.FieldType);
                        if (val != null) FieldInfoX.Create(fi).SetValue(obj, val);
                    }
                    foreach (var pi in paramterType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        var val = TypeX.ChangeType(context.Request[pi.Name], pi.PropertyType);
                        if (val != null) PropertyInfoX.Create(pi).SetValue(obj, val);
                    }
                    objs[i] = obj;
                }
            }
        }
        return objs;
    }
    #endregion
}


#region Verycd测试

//string fileName = @"D:\DevelopMent\大蚂蚁客户端.exe";
//FileInfo fi = new FileInfo(fileName);
//Console.WriteLine(fi.Extension);

//bool status = true;
//while (status)
//{
//    Console.Write("请输入文件夹路径：");
//    string path = Console.ReadLine();
//    if (Directory.Exists(path))
//    {
//        ResourceHelper.ScanFolder(path);
//    }
//    else
//    {
//        status = false;
//    }
//}
//VeryCdResouce.ExportLinkToLst();

//string url = @"http://www.verycd.com/topics/2900979/";
//VeryCdResouce.StartCollectResouceList();
//VeryCdResouce.Test();
//			for (int i = 0; i <20; i++)
//			{		
//				Thread.Sleep (1000) ;
//				Thread thread=new Thread(VeryCdResouce.StartCollectResouceDownLoadLink);
//				thread.Start();
//			}	
#endregion