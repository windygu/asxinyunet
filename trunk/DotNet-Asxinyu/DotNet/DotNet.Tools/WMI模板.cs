using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace <#=Data["NameSpace"]#>
{
    public class <#=Data["ClassName"]#>:WMIBase
    {
	    #region 字段定义
        <#foreach(KeyValuePair<string,object> item in Data){if((!item.Key.Contains("NameSpace"))||(!item.Key.Contains("ClassName"))){#>
        private <#=item.Value#> _<#=item.Key.ToLower()#> ;<#}}#>
		private ManagementObject _mo;
		#endregion
        
        #region 初始化
        public <#=Data["ClassName"]#> (ManagementObject managementObject)
        {
            this._mo = managementObject;
            this.<#=Data["ClassName"]#>_Init();
        }
        private void <#=Data["ClassName"]#>_Init()
        {<# foreach(KeyValuePair<string,object> item in Data){if((!item.Key.Contains("NameSpace"))||(!item.Key.Contains("ClassName"))){#>
		    this._<#=item.Key.ToLower ()#> = GetPropStr(_mo, "<#=item.Key#>");<#}}#>            
	    }	   
		#endregion	
    
    	#region 属性-默认只读，其他手动修改
		 <# foreach(KeyValuePair<string,object> item in Data)
		 {if((!item.Key.Contains("NameSpace"))||(!item.Key.Contains("ClassName"))){#>
		    ///<summary></summary>
		public <#=item.Value#> <#=item.Key#>
		{
		   get{ return this._<#=item.Key.ToLower()#>;}
        }
		<#}}#>
		#endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        public Object this[String name]
        {
            get{
			switch (name)
            {	
				<# foreach(KeyValuePair<string,object> item in Data)
		        { if((!item.Key.Contains("NameSpace"))||(!item.Key.Contains("ClassName"))){#>
		        case "<#=item.Key#>" : return _<#=item.Key.ToLower()#>;<#}}#>  
                default: return "" ;  		  
			} }
        }
        #endregion

		#region 字段名
		public class _
        {<# foreach(KeyValuePair<string,object> item in Data)
		 { if((!item.Key.Contains("NameSpace"))||(!item.Key.Contains("ClassName"))){#>
		   ///<summary></summary>
           public static readonly string <#=item.Key#> = "<#=item.Key#>";
		   <#}}#>
		}
		#endregion
	}
}