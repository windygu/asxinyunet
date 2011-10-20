/*
 * 由SharpDevelop创建。
 * 用户： 董斌辉
 * 日期: 2011-10-4
 * 时间: 17:15
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using XCode ;

namespace DotNet.Tools.Controls
{
	/// <summary>
	/// Description of SearchConditionForm.
	/// </summary>
	public partial class SearchConditionForm  : Form 
	{
		public SearchConditionForm()
		{
			InitializeComponent();
		}
		public string CurConditions
		{
			get {return searchCondition1.CurConditions ;}
			set {searchCondition1.CurConditions = value ;}
		}
		public string[] ColumnsName
		{
			set
			{
				searchCondition1.ColumnsName = value ;
			}
		}
        public Type EntityName
        {
            set
            {
                searchCondition1.EntityName = value;
            }
        } 
        public string CutEntityName
        {
            set
            {
                searchCondition1.CutEntityName  = value;
            }
        }             
	}
}
