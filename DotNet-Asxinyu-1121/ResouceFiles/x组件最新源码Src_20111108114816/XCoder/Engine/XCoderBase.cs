﻿using System;
using System.Collections.Generic;
using System.Reflection;
using XCode.DataAccessLayer;
using XTemplate.Templating;

namespace XCoder
{
    /// <summary>
    /// 代码生成器模版基类
    /// </summary>
    public class XCoderBase : TemplateBase
    {
        #region 属性
        private IDataTable _Table;
        /// <summary>表架构</summary>
        public virtual IDataTable Table
        {
            get { return _Table; }
            set { _Table = value; }
        }

        private XConfig _Config;
        /// <summary>配置</summary>
        public XConfig Config
        {
            get { return _Config; }
            set { _Config = value; }
        }

        private List<IDataTable> _Tables;
        /// <summary>表集合</summary>
        public List<IDataTable> Tables
        {
            get { return _Tables; }
            set { _Tables = value; }
        }
        #endregion

        #region 扩展属性
        /// <summary>经过修正的表名</summary>
        public virtual String ClassName
        {
            get { return GetClassName(Table); }
        }

        /// <summary>经过修正的表说明</summary>
        public virtual String ClassDescription
        {
            get { return GetClassDescription(Table); }
        }

        /// <summary>文件版本</summary>
        public static String Version { get { return Engine.FileVersion; } }
        #endregion

        #region 重载
        /// <summary>初始化</summary>
        public override void Initialize()
        {
            base.Initialize();

            if (Data.ContainsKey("Table")) Table = (IDataTable)Data["Table"];
            if (Data.ContainsKey("Config")) Config = (XConfig)Data["Config"];
            if (Data.ContainsKey("Tables")) Tables = (List<IDataTable>)Data["Tables"];
        }
        #endregion

        #region 格式化方法
        /// <summary>
        /// 去掉前后缀、自动去掉第一个_之前的前缀、修正大小写
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual String FixName(String name)
        {
            return FixWord(CutPrefix(name));
        }

        /// <summary>
        /// 去掉前后缀、自动去掉第一个_之前的前缀
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual String CutPrefix(String name)
        {
            return Engine.CutPrefix(name);
        }

        /// <summary>
        /// 修正大小写
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual String FixWord(String name)
        {
            return Engine.FixWord(name);
        }

        /// <summary>
        /// 修正字段名，在FixName的基础上，去掉表名前缀
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public virtual String GetPropertyName(IDataColumn field)
        {
            String name = field.Name;
            if (Config.AutoCutPrefix)
            {
                String s = CutPrefix(name);
                if (field.Table.Columns.Exists(item => item.Name == s)) name = s;
                //if (!Array.Exists<IDataColumn>(field.Table.Columns, delegate(IDataColumn item) { return item.Name == s; })) name = s;
                String str = ClassName;
                if (!s.Equals(str, StringComparison.OrdinalIgnoreCase) &&
                    s.StartsWith(str, StringComparison.OrdinalIgnoreCase) &&
                    s.Length > str.Length && Char.IsLetter(s, str.Length))
                    s = s.Substring(str.Length);
                //if (!Array.Exists<IDataColumn>(field.Table.Columns, delegate(IDataColumn item) { return item.Name == s; })) name = s;
                if (field.Table.Columns.Exists(item => item.Name == s)) name = s;
            }
            if (Config.AutoFixWord)
            {
                name = FixWord(name);
            }

            return name;
        }

        /// <summary>
        /// 英文名转为中文名
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public virtual String GetPropertyDescription(IDataColumn field)
        {
            if (!String.IsNullOrEmpty(field.Description) || !Config.UseCNFileName) return field.Description;
            return Engine.ENameToCName(field.Name);
        }

        /// <summary>
        /// 修正表名，去前缀，自动大小写
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public virtual String GetClassName(IDataTable table)
        {
            String name = table.Name;
            if (Config.AutoCutPrefix) name = CutPrefix(name);
            if (Config.AutoFixWord) name = FixWord(name);
            return name;
        }

        /// <summary>
        /// 表注释
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public virtual String GetClassDescription(IDataTable table)
        {
            if (!Config.UseCNFileName) return table.Description;

            String remark = table.Description;
            if (Config.UseCNFileName && String.IsNullOrEmpty(remark)) remark = Engine.ENameToCName(GetClassName(table));

            return remark;
        }
        #endregion

        #region 辅助方法
        /// <summary>
        /// 根据指定名称查找表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public IDataTable FindTable(String tableName)
        {
            return Tables.Find(delegate(IDataTable item)
            {
                String name = item.Name;
                if (String.Equals(name, tableName, StringComparison.OrdinalIgnoreCase)) return true;

                if (Config.AutoCutPrefix) name = CutPrefix(name);
                if (String.Equals(name, tableName, StringComparison.OrdinalIgnoreCase)) return true;

                return false;

            });
        }
        #endregion
    }
}