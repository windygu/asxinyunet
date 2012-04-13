<#@ import namespace="XCode.DataAccessLayer" #><#@ import namespace="XCode.Configuration" #>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewLife.CommonEntity ;
using EntLib.Controls.WinForm ;
using XCode ;
using NewLife ;
namespace <#=Config.NameSpace#>
{
	public partial class AddForm<#=Table.Name#>: DataEditBaseForm
	{
		#region 公用变量	
        public string formTitle = "";
        public <#=Table.Name#> CurrEntity = new <#=Table.Name#>();
		BindingSource bs = new BindingSource();
		#endregion
		#region 初始化		
		public AddForm<#=Table.Name#>()
		{
			InitializeComponent();
		}
		/// <summary>
		/// 加载子窗口
		/// </summary>
		protected override void LoadChildData()
		{
			this.Text = formTitle;
			bs.DataSource = CurrEntity;
			<#foreach(IDataColumn Field in Table.Columns) 
			{ 
			if(Field.PrimaryKey) continue;
			TypeCode code = Type.GetTypeCode(Field.DataType);#>
			<#if(code == TypeCode.DateTime){#>this.txt<#=Field.Alias#>.DataBindings.Add("Value", bs, "<#=Field.Alias#>");
			<#}else{#>this.txt<#=Field.Alias#>.DataBindings.Add("Text", bs, "<#=Field.Alias#>");<#}#><#}#>
		}
		#endregion

        /// <summary>
        /// 判断数据源是否有改变
        /// </summary>
        /// <returns></returns>
        protected override bool ValidateChanges()
        {
            return true;
        }

        /// <summary>
        ///验证必填
        /// </summary>
        /// <returns></returns>
        protected override String ValidateInput()
        {
            return "";
        }

        ///<summary>
        ///插入数据保存
        ///</summary>
        protected override string CreateData()
        {
			try
			{
				CurrEntity.Insert();
				return string.Empty;
			}
			catch (Exception ex)
			{
				return "数据保存错误！";
			}
        }

        ///<summary>
        ///修改保存
        ///</summary>
        protected override string SaveData()
        {
			try
			{
				CurrEntity.Update();
				return string.Empty;
			}
			catch (Exception ex)
			{
				return "数据保存错误！";
			}
        }
	}
}
