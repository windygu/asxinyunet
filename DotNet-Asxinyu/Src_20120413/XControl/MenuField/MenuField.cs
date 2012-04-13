﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// 特别要注意，这里得加上默认命名空间和目录名，因为vs2005编译的时候会给文件加上这些东东的
[assembly: WebResource("XControl.MenuField.jquery.contextmenu.r2.packed.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("XControl.MenuField.MenuFieldCss.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("XControl.MenuField.dropdown.gif", "image/jpg")]

namespace XControl
{
    /// <summary>MenuField 的摘要说明</summary>
    public class MenuField : DataControlField
    {
        #region 属性

        /// <summary>菜单层样式</summary>
        [DefaultValue(""), Themeable(false), WebCategory("Css"), WebSysDescription("DIV.Css")]
        public virtual String MenuCss
        {
            get
            {
                String str = (String)ViewState["MenuCss"];
                if (str == null) return String.Empty;

                return str;
            }
            set
            {
                ViewState["MenuCss"] = value;
            }
        }

        /// <summary>重写CssClass</summary>
        [DefaultValue(""), Themeable(false), WebCategory("Css"), WebSysDescription("Control.Css")]
        public virtual String ControlCss
        {
            get
            {
                return base.ControlStyle.CssClass;
            }
            set
            {
                base.ControlStyle.CssClass = value;
            }
        }

        private ViewStateCollection<MenuParameterItem> _MenuParameters;
        /// <summary>重写CssClass</summary>
        [DefaultValue(null), WebCategory("Data"), WebSysDescription("MenuField_MenuParameters"), PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual ViewStateCollection<MenuParameterItem> MenuParameters
        {
            get
            {
                if (_MenuParameters == null)
                    _MenuParameters = new ViewStateCollection<MenuParameterItem>();

                return _MenuParameters;
            }
        }

        /// <summary>项显示内容</summary>
        [WebCategory("Appearance"), DefaultValue(""), WebSysDescription("MenuField_Text")]
        public virtual String Text
        {
            get
            {
                object obj2 = base.ViewState["Text"];
                if (obj2 != null)
                {
                    return (string)obj2;
                }
                return String.Empty;
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        /// <summary>菜单响应事件</summary>
        [Localizable(true), WebCategory("Menu"), DefaultValue("click"), WebSysDescription("MenuField_Mouse")]
        public virtual String TriggerEvent
        {
            get
            {
                object obj2 = base.ViewState["TriggerEvent"];
                if (obj2 != null)
                {
                    return (string)obj2;
                }
                return "click";
            }
            set
            {
                ViewState["TriggerEvent"] = value;
            }
        }

        /// <summary>绑定字段</summary>
        [WebCategory("Data"), DefaultValue(""), WebSysDescription("MenuField_Data")]
        public virtual String DataField
        {
            get
            {
                object obj2 = base.ViewState["DataField"];
                if (obj2 != null)
                {
                    return (string)obj2;
                }
                return String.Empty;
            }
            set
            {
                ViewState["DataField"] = value;
            }
        }

        /// <summary>
        /// 条件字段
        /// 用于模版控制
        /// </summary>
        [WebCategory("Data"), DefaultValue(""), WebSysDescription("MenuField_ConditionField")]
        public virtual String ConditionField
        {
            get
            {
                object obj2 = base.ViewState["ConditionField"];
                if (obj2 != null)
                {
                    return (string)obj2;
                }
                return String.Empty;
            }
            set
            {
                ViewState["ConditionField"] = value;
            }
        }

        private ViewStateCollection<MenuTemplateItem> _MenuTemplate;
        /// <summary>条件模版</summary>
        [DefaultValue(null), MergableProperty(false), PersistenceMode(PersistenceMode.InnerProperty), WebCategory("Menu"), WebSysDescription("MenuField_MenuTemplate")]
        public virtual ViewStateCollection<MenuTemplateItem> MenuTemplate
        {
            get
            {
                if (_MenuTemplate == null)
                    _MenuTemplate = new ViewStateCollection<MenuTemplateItem>();

                return _MenuTemplate;
            }
        }

        #endregion

        /// <summary>构造方法</summary>
        public MenuField()
        {
        }

        /// <summary>重写</summary>
        /// <returns></returns>
        protected override DataControlField CreateField()
        {
            return new MenuField();
        }

        /// <summary>初始化单元格</summary>
        /// <param name="cell"></param>
        /// <param name="cellType"></param>
        /// <param name="rowState"></param>
        /// <param name="rowIndex"></param>
        public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
        {
            base.InitializeCell(cell, cellType, rowState, rowIndex);

            switch (cellType)
            {
                case DataControlCellType.DataCell:

                    cell.DataBinding += new EventHandler(CellDataBinding);

                    #region 原始实现

                    //if (cellType != DataControlCellType.DataCell) return;

                    //////添加按钮
                    //Panel CurrentPanel = CreateMenuButton();

                    //cell.Controls.Add(CurrentPanel);

                    ////添加菜单
                    //XLiteral lit = CreateMenuLiteral(CurrentPanel);

                    //if ((this.DataField.Length != 0) && base.Visible)
                    //{
                    //    lit.DataBinding += new EventHandler(this.OnDataBindField);
                    //}

                    //cell.Controls.Add(lit);

                    #endregion

                    break;
                case DataControlCellType.Footer:
                    cell.Text = FooterText;
                    break;
                case DataControlCellType.Header:
                    cell.Text = HeaderText;
                    break;
                default:
                    break;
            }
        }

        /// <summary>单无格数据绑定事件</summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void CellDataBinding(Object sender, EventArgs args)
        {
            DataControlFieldCell cell = sender as DataControlFieldCell;

            ////添加按钮
            Panel CurrentPanel = CreateMenuButton();

            cell.Controls.Add(CurrentPanel);

            //菜单开头
            Literal MenuStart = new Literal()
            {
                Text = String.Format("<div class=\"{0}\" id=\"{1}\" style=\"display:none;\">", MenuCss, CreateMenuDivID(CurrentPanel.ClientID))
            };

            cell.Controls.Add(MenuStart);

            //生成菜单
            CreateMenu(cell);

            //菜单结尾
            Literal MenuEnd = new Literal()
            {
                Text = "</div>" + CreateJSBlack(CurrentPanel)
            };

            cell.Controls.Add(MenuEnd);
        }

        /// <summary>生成菜单</summary>
        /// <param name="cell"></param>
        public void CreateMenu(DataControlFieldCell cell)
        {
            Control namingContainer = cell.NamingContainer;
            object component = null;
            if (namingContainer == null)
            {
                throw new HttpException("DataControlField_NoContainer Is Null");
            }
            component = DataBinder.GetDataItem(namingContainer);
            if ((component == null) && !base.DesignMode)
            {
                throw new HttpException("DataItem_Not_Found");
            }

            //获取绑定字段值
            String DataFieldValue = GetDataFileValue(component, DataField);

            //获取条件模版字段值
            String ConditionFieldValue = GetDataFileValue(component, ConditionField);

            //菜单参数创建
            if (MenuParameters != null && MenuParameters.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (MenuParameterItem item in MenuParameters)
                {
                    String iConCss = item.IConCss;
                    String url = item.Url;
                    String onClick = item.OnClick;
                    String text = item.Text;

                    if (!String.IsNullOrEmpty(DataFieldValue) && !String.IsNullOrEmpty(iConCss))
                        iConCss = " class=\"" + String.Format(iConCss, DataFieldValue) + "\"";

                    if (!String.IsNullOrEmpty(DataFieldValue) && !String.IsNullOrEmpty(url))
                        url = " href=\"" + String.Format(url, DataFieldValue) + "\"";

                    if (!String.IsNullOrEmpty(DataFieldValue) && !String.IsNullOrEmpty(onClick))
                        onClick = " onclick=\"" + String.Format(onClick, DataFieldValue) + "\"";

                    if (!String.IsNullOrEmpty(DataFieldValue) && !String.IsNullOrEmpty(text))
                        text = String.Format(text, DataFieldValue);

                    sb.AppendFormat("<li{0}><a{1}{2}>{3}</a></li>"
                        , iConCss
                        , url
                        , onClick
                        , text
                        );
                    sb.AppendLine();
                }

                //加入菜单
                cell.Controls.Add(new Literal() { Text = "<ul>" + sb.ToString() + "</ul>" });
            }
            else if (MenuTemplate != null && MenuTemplate.Count > 0)
            {
                MenuTemplateItem currentMenu = null; ;
                //条件模版创建
                foreach (MenuTemplateItem item in MenuTemplate)
                {
                    if (String.Equals(item.ConditionFieldValue, ConditionFieldValue, StringComparison.CurrentCultureIgnoreCase))
                    {
                        currentMenu = item;
                        break;
                    }
                }

                if (currentMenu != null)
                {
                    currentMenu.Template.InstantiateIn(cell);
                }
                else
                {
                    //没有到符合条件的，取第一项
                    currentMenu = MenuTemplate[0];
                    currentMenu.Template.InstantiateIn(cell);
                }
            }
        }

        /// <summary>生成菜单 JS</summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private String CreateJSBlack(Control control)
        {
            return String.Format(@"<script type='text/javascript'>
                               $(document).ready(function () {{
                                   $('#{0}').contextMenu('#{1}', {{triggerEvent: '{2}', menuOffset: 'under'}});
                               }});
                            </script>", control.ClientID, CreateMenuDivID(control.ClientID), TriggerEvent);
        }

        /// <summary>生成菜单DIVID</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String CreateMenuDivID(String id)
        {
            return id + "_Menu";
        }

        /// <summary>菜单按钮</summary>
        private Panel CreateMenuButton()
        {
            Panel r = new Panel();
            r.PreRender += new EventHandler(MenuButtonPreRender);
            return r;
        }

        /// <summary>菜单按钮呈显</summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void MenuButtonPreRender(object sender, EventArgs arg)
        {
            Panel p = sender as Panel;

            //&nbsp; 统一行高
            p.Controls.Add(new Literal() { Text = !String.IsNullOrEmpty(this.Text) ? this.Text : "&nbsp;<img src='" + p.Page.ClientScript.GetWebResourceUrl(typeof(MenuField), "XControl.MenuField.dropdown.gif") + "'/>&nbsp;" });
            p.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
            //p.Attributes.Add("onclick", "javascript:showMenu('" + p.ClientID + "','" + CreateMenuDivID(p.ClientID) + "');");

            p.Page.ClientScript.RegisterClientScriptResource(typeof(MenuField), "XControl.MenuField.jquery.contextmenu.r2.packed.js");

            //      HtmlLink link = new HtmlLink();
            //      link.Href = p.Page.ClientScript.GetWebResourceUrl(typeof(MenuField), "XControl.MenuField.MenuFieldCss.css");
            //      link.Attributes["rel"] = "stylesheet";
            //      link.Attributes["type"] = "text/css";
            //      p.Page.Form.Controls.Add(link);

            //      string includeTemplate =
            //"<link rel='stylesheet' text='text/css' href='{0}' />";
            //      string includeLocation =
            //            Page.ClientScript.GetWebResourceUrl(this.GetType(), "myStylesheet _Links.css");
            //      LiteralControl include =
            //            new LiteralControl(String.Format(includeTemplate, includeLocation));
            //      ((HtmlControls.HtmlHead)Page.Header).Controls.Add(include);
        }

        /// <summary>已重载。</summary>
        /// <param name="newField"></param>
        protected override void CopyProperties(DataControlField newField)
        {
            MenuField f = newField as MenuField;
            f.MenuCss = this.MenuCss;
            f.ControlCss = this.ControlCss;
            //f.MenuParameters = this.MenuParameters;
            f.Text = this.Text;
            f.TriggerEvent = this.TriggerEvent;
            f.DataField = this.DataField;
            f.ConditionField = this.ConditionField;
            //f.MenuTemplate = this.MenuTemplate;
            base.CopyProperties(newField);
        }

        /// <summary>获取字段值</summary>
        /// <param name="component"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        private String GetDataFileValue(object component, String field)
        {
            String r = String.Empty;
            if (component == null || String.IsNullOrEmpty(field)) return r;

            PropertyDescriptor textFieldDesc;

            string dataTextField = field;
            textFieldDesc = TypeDescriptor.GetProperties(component).Find(dataTextField, true);

            if (textFieldDesc == null && !base.DesignMode)
            {
                throw new HttpException("Field_Not_Found [" + dataTextField + "]");
            }

            if (textFieldDesc != null && component != null)
            {
                object dataTextValue = textFieldDesc.GetValue(component);
                r = dataTextValue.ToString();
            }
            else
            {
                r = "Not Value";
            }

            return r;
        }

        #region 原始实现

        //        /// <summary>
        //        /// 创建菜单
        //        /// </summary>
        //        /// <returns></returns>
        //        private XLiteral CreateMenuLiteral(Control control)
        //        {
        //            XLiteral literal = new XLiteral();
        //            literal.PreRender += delegate(object sender, EventArgs err)
        //            {
        //                MenuOnPreRender(sender, control);
        //            };

        //            return literal;
        //        }

        //        /// <summary>
        //        /// 菜单呈显事件
        //        /// </summary>
        //        /// <param name="sender"></param>
        //        /// <param name="control"></param>
        //        private void MenuOnPreRender(object sender, Control buttonControl)
        //        {
        //            XLiteral menu = sender as XLiteral;
        //            if (menu == null) return;

        //            menu.Text = CreateMenuDiv(menu, buttonControl);
        //        }

        //        /// <summary>
        //        /// 生成DIV文本
        //        /// </summary>
        //        /// <param name="literalControl"></param>
        //        /// <param name="buttoncontrol"></param>
        //        /// <returns></returns>
        //        private String CreateMenuDiv(XLiteral literalControl, Control buttoncontrol)
        //        {
        //            String menu = "<div class=\"{0}\" id=\"{1}\" style=\"display:none;\"><ul>{2}</ul></div>{3}";

        //            StringBuilder sb = new StringBuilder();

        //            //菜单参数创建
        //            if (MenuParameters != null && MenuParameters.Count > 0)
        //            {
        //                foreach (MenuItem item in MenuParameters)
        //                {
        //                    String iConCss = item.IConCss;
        //                    String url = item.Url;
        //                    String onClick = item.OnClick;
        //                    String text = item.Text;

        //                    if (!String.IsNullOrEmpty(literalControl.DataFieldValue) && !String.IsNullOrEmpty(iConCss))
        //                        iConCss = " class=\"" + String.Format(iConCss, literalControl.DataFieldValue) + "\"";

        //                    if (!String.IsNullOrEmpty(literalControl.DataFieldValue) && !String.IsNullOrEmpty(url))
        //                        url = " href=\"" + String.Format(url, literalControl.DataFieldValue) + "\"";

        //                    if (!String.IsNullOrEmpty(literalControl.DataFieldValue) && !String.IsNullOrEmpty(onClick))
        //                        onClick = " onclick=\"" + String.Format(onClick, literalControl.DataFieldValue) + "\"";

        //                    if (!String.IsNullOrEmpty(literalControl.DataFieldValue) && !String.IsNullOrEmpty(text))
        //                        text = String.Format(text, literalControl.DataFieldValue);

        //                    sb.AppendFormat("<li{0}><a{1}{2}>{3}</a></li>"
        //                        , iConCss
        //                        , url
        //                        , onClick
        //                        , text
        //                        );
        //                    sb.AppendLine();

        //                }
        //            }
        //            else if (MenuTemplate != null && MenuTemplate.Count > 0)
        //            {
        //                MenuTemplateItem currentMenu = null; ;
        //                //条件模版创建
        //                foreach (MenuTemplateItem item in MenuTemplate)
        //                {
        //                    if (String.Equals(item.ConditionFieldValue, literalControl.ConditionFieldValue, StringComparison.CurrentCultureIgnoreCase))
        //                    {
        //                        currentMenu = item;
        //                        break;
        //                    }
        //                }

        //                if (currentMenu != null)
        //                {
        //                    //sb.AppendFormat(currentMenu.Template, literalControl.DataFieldValue);
        //                }
        //            }

        //            String menuDivID = CreateMenuDivID(buttoncontrol.ClientID);

        //            // 菜单 JS
        //            String MenuJS = String.Format(@"<script type='text/javascript'>
        //                               $(document).ready(function () {{
        //                                   $('#{0}').contextMenu('#{1}', {{triggerEvent: '{2}', menuOffset: 'under'}});
        //                               }});
        //                            </script>", buttoncontrol.ClientID, menuDivID, TriggerEvent);

        //            return String.Format(menu, MenuCss, menuDivID, sb.ToString(), MenuJS);
        //        }

        //        /// <summary>
        //        /// 设置DataField
        //        /// </summary>
        //        /// <param name="sender"></param>
        //        /// <param name="e"></param>
        //        private void OnDataBindField(object sender, EventArgs e)
        //        {
        //            Control control = (Control)sender;
        //            Control namingContainer = control.NamingContainer;
        //            object component = null;
        //            if (namingContainer == null)
        //            {
        //                throw new HttpException("DataControlField_NoContainer Is Null");
        //            }
        //            component = DataBinder.GetDataItem(namingContainer);
        //            if ((component == null) && !base.DesignMode)
        //            {
        //                throw new HttpException("DataItem_Not_Found");
        //            }

        //            XLiteral xl = control as XLiteral;

        //            xl.DataFieldValue = GetDataFileValue(component, DataField);
        //            xl.DataField = DataField;

        //            xl.ConditionFieldValue = GetDataFileValue(component, ConditionField);
        //            xl.ConditionField = ConditionField;
        //        }

        #endregion
    }

    /// <summary>
    /// 视图状态集合,用于作为服务端控件集合属性的类型,T是集合元素类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ViewStateCollection<T> : StateManagedCollection where T : IViewState, new()
    {
        private Type[] types = { typeof(T) };

        /// <summary>
        /// 重写自StateManagedCollection类
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override object CreateKnownType(int index)
        {
            return new T();
        }

        /// <summary>
        /// 重写自StateManagedCollection类
        /// </summary>
        /// <returns></returns>
        protected override Type[] GetKnownTypes()
        {
            return types;
        }

        /// <summary>
        /// 实现StateManagedCollection类
        /// </summary>
        /// <param name="o"></param>
        protected override void SetDirtyObject(object o)
        {
            var item = o as IViewState;
            if (item != null)
            {
                item.ViewState.SetDirty(true);
            }
        }

        /// <summary>
        /// 实现IList接口
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return (T)(this as IList)[index];
            }
            set
            {
                (this as IList)[index] = value;
            }
        }

        /// <summary>
        /// 实现IList接口
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            (this as IList).Add(item);
        }

        /// <summary>
        /// 实现IList接口
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void AddAt(int index, T item)
        {
            (this as IList).Insert(index, item);
        }

        /// <summary>
        /// 实现IList接口
        /// </summary>
        public new void Clear()
        {
            (this as IList).Clear();
        }

        /// <summary>
        /// 实现IList接口
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return (this as IList).Contains(item);
        }

        /// <summary>
        /// 实现IList接口
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(T[] array, int index)
        {
            (this as IList).CopyTo(array, index);
        }

        /// <summary>
        /// 实现IList接口
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public new void CopyTo(Array array, int index)
        {
            (this as IList).CopyTo(array, index);
        }

        /// <summary>
        /// 实现IList接口
        /// </summary>
        /// <returns></returns>
        public new IEnumerator GetEnumerator()
        {
            return (this as IList).GetEnumerator();
        }

        /// <summary>
        /// 实现IList接口
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            return (this as IList).IndexOf(item);
        }

        /// <summary>
        /// 实现IList接口
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            (this as IList).Remove(item);
        }

        /// <summary>
        /// 实现IList接口
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            (this as IList).RemoveAt(index);
        }
    }

    /// <summary>
    /// 可访问到ViewState属性的接口
    /// </summary>
    public interface IViewState
    {
        /// <summary>
        /// 视图状态属性
        /// </summary>
        StateBag ViewState { get; }
    }
}