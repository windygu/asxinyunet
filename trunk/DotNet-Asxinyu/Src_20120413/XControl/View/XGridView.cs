//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.Design;
//using System.Drawing;
//using System.Reflection;
//using System.Web.UI;
//using System.Web.UI.Design;
//using System.Web.UI.Design.WebControls;
//using System.Web.UI.WebControls;

//namespace XControl
//{
//    /// <summary>
//    /// ��дGridView
//    /// </summary>
//    [ToolboxItem(false)]
//    [DefaultProperty("Text")]
//    [ToolboxData("<{0}:XGridView runat=server></{0}:XGridView>")]
//    [Designer(typeof(XGridViewDesigner))]
//    [ToolboxBitmap(typeof(GridView))]
//    public class XGridView : GridView
//    {
//        private Boolean _SetEntry = false;
//        /// <summary>
//        /// ����ʵ���ֶ�
//        /// </summary>
//        [Category(" ר������"), DefaultValue(false), Description("����ʵ���ֶ�"), DesignOnly(true)]
//        public Boolean SetEntry
//        {
//            get
//            {
//                return _SetEntry;
//            }
//            set
//            {
//                try
//                {
//                    CreateEntryColumns();
//                }
//                catch (Exception ex)
//                {
//                    ViewHelper.MsgBox<XGridView>(ex.Message);
//                }
//                _SetEntry = value;
//            }
//        }

//        /// <summary>
//        /// ����ʵ�����ֶμ������Ѿ������õ���תΪʵ���С�
//        /// ��Ҫ�޸ĸ��е�HeaderTextΪ���ģ�ͬʱ��������˳��Ϊ��Ӧ��ʵ�����Ե�˳��
//        /// </summary>
//        private void CreateEntryColumns()
//        {
//            Type t = ViewHelper.GetEntryType<XGridView>(Site);
//            if (t == null) return;
//            List<FieldItem> list = ViewHelper.AllFields(t);
//            if (list == null) return;
//            XGridView gv = this;
//            if (gv == null) return;

//            // ˼·
//            // ����������ʵ��������ֶδ�cs��ɾ������ӵ�һ����ʱ�б�tcs��
//            // ��ͷ��ʼ����ʵ��������ԣ��ж�ÿ�������Ƿ������tcs�У��������޸�HeaderTextΪ���ģ�����ӵ�ncs��

//            Dictionary<String, DataControlField> tcs = new Dictionary<String, DataControlField>();
//            foreach (DataControlField dcf in gv.Columns)
//            {
//                foreach (FieldItem fi in list)
//                {
//                    if (fi.Name == dcf.HeaderText)
//                    {
//                        // ���ڱ���cs�Ĺ����в����޸�cs������������ʱ����cs��ɾ��dcf��������ɺ�ɾ��
//                        tcs.Add(fi.Name, dcf);
//                        break;
//                    }
//                }
//            }
//            // ɾ������ʵ�������
//            foreach (DataControlField dcf in tcs.Values)
//            {
//                gv.Columns.Remove(dcf);
//            }
//            String keyname = (gv.DataKeyNames != null && gv.DataKeyNames.Length > 0) ? gv.DataKeyNames[0] : null;
//            // ��˳�����ʵ����ĵ��������
//            foreach (FieldItem fi in list)
//            {
//                if (tcs.ContainsKey(fi.Name) && fi.DataObjectField.Length <= 255)
//                {
//                    DataControlField dcf = tcs[fi.Name];
//                    //��������������ֶΣ����Ǳ�ʶ�ֶΣ�����Ϊģ���а�Select����
//                    if (!String.IsNullOrEmpty(keyname) && fi.Name == keyname || String.IsNullOrEmpty(keyname) && fi.DataObjectField.IsIdentity)
//                    {
//                        TemplateField tf = new TemplateField();
//                        String str = String.Format("<asp:LinkButton id=\"{0}LinkButton1\" runat=\"server\"  CausesValidation=\"{1}\" Text='<%# Eval(\"{0}\") %>' CommandName=\"Select\"></asp:LinkButton>", fi.Name, Boolean.FalseString);
//                        tf.ItemTemplate = ControlParser.ParseTemplate((IDesignerHost)Site.GetService(typeof(IDesignerHost)), str);
//                        dcf = tf as DataControlField;
//                    }

//                    //ָ��������ʽ
//                    dcf.SortExpression = fi.Name;

//                    //ָ��ʱ���ʽ�ַ���
//                    if (fi.Info.PropertyType == typeof(DateTime))
//                    {
//                        BoundField bc = dcf as BoundField;
//                        if (bc != null) bc.DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}";
//                    }

//                    dcf.HeaderText = (String.IsNullOrEmpty(fi.Description)) ? fi.Name : fi.Description;

//                    if (fi.Info.PropertyType == typeof(Int32))
//                    {
//                        //dcf.HeaderStyle.Width = Unit.Pixel(40);
//                        //dcf.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
//                        dcf.HeaderStyle.CssClass = "IntHead";
//                        dcf.ItemStyle.CssClass = "IntItem";
//                    }
//                    else if (fi.Info.PropertyType == typeof(DateTime) || fi.Info.PropertyType == typeof(Nullable<DateTime>))
//                    {
//                        //dcf.HeaderStyle.Width = Unit.Pixel(140);
//                        //dcf.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
//                        dcf.HeaderStyle.CssClass = "DateHead";
//                        dcf.ItemStyle.CssClass = "DateItem";
//                    }
//                    else
//                    {
//                        //dcf.HeaderStyle.Width = Unit.Pixel(150);
//                        dcf.HeaderStyle.CssClass = "TextHead";
//                        dcf.ItemStyle.CssClass = "TextItem";
//                    }
//                    gv.Columns.Add(dcf);
//                }
//            }

//            //���⹤��������ObjectDataSource��SelectCountMethod
//            String datasourceid = gv.DataSourceID;
//            if (String.IsNullOrEmpty(datasourceid)) return;
//            // �ҵ����ݰ󶨿ؼ�ObjectDataSource
//            ObjectDataSource obj = gv.Page.FindControl(datasourceid) as ObjectDataSource;
//            if (obj == null) return;
//            //ָ����ҳ����
//            Boolean canpaging = true;
//            if (String.IsNullOrEmpty(obj.SelectCountMethod)) obj.SelectCountMethod = "FindCount";
//            //�������Ĭ�ϵ�FindAll����ʹ���¹��췽��
//            if (!obj.SelectMethod.Equals("FindAll", StringComparison.OrdinalIgnoreCase))
//                obj.SelectCountMethod = obj.SelectMethod + "Count";
//            //ָ����ҳ����
//            if (obj.SelectParameters["startRowIndex"] == null) 
//                canpaging = false;
//            else if (String.IsNullOrEmpty(obj.SelectParameters["startRowIndex"].DefaultValue))
//                obj.SelectParameters["startRowIndex"].DefaultValue = "0";

//            if (obj.SelectParameters["maximumRows"] == null)
//                canpaging = false;
//            else if (String.IsNullOrEmpty(obj.SelectParameters["maximumRows"].DefaultValue))
//                obj.SelectParameters["maximumRows"].DefaultValue = Int32.MaxValue.ToString();

//            //�򿪷�ҳ
//            if (canpaging)
//            {
//                obj.EnablePaging = true;
//                gv.AllowPaging = true;
//            }
//            else
//                ViewHelper.MsgBox<XGridView>(String.Format("��ǰ�Ĳ�ѯ����{0}��֧�ַ�ҳ����ѡ����з�ҳ�����Ĳ�ѯ������", obj.SelectMethod));

//            //ָ���������
//            Boolean cansort = false;//�Ƿ��������
//            if (obj.SelectParameters != null)
//            {
//                //��������Select�������ҵ���һ������order�����Ĳ�����Ϊ�������
//                foreach (Parameter item in obj.SelectParameters)
//                {
//                    if (item.Name.ToLower().IndexOf("order") >= 0)
//                    {
//                        obj.SortParameterName = item.Name;
//                        cansort = true;
//                        break;
//                    }
//                }
//            }
//            if (cansort)
//                gv.AllowSorting = true;
//            else
//                ViewHelper.MsgBox<XGridView>(String.Format("��ǰ�Ĳ�ѯ����{0}��֧��������ѡ�������������Ĳ�ѯ������", obj.SelectMethod));
//        }

//        private Boolean _SetDefaultStype = false;
//        /// <summary>
//        /// ������ʽ
//        /// </summary>
//        [Category(" ר������"), DefaultValue(false), Description("������ʽ"), DesignOnly(true)]
//        public Boolean SetDefaultStype
//        {
//            get { return _SetDefaultStype; }
//            set
//            {
//                try
//                {
//                    //XGridView gv = this;
//                    //if (gv == null) return;
//                    //gv.BorderColor = System.Drawing.Color.FromArgb(0x82, 0xA8, 0xCF);
//                    //gv.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
//                    //gv.BorderWidth = Unit.Pixel(1);
//                    //gv.Font.Underline = false;
//                    //gv.SelectedRowStyle.BackColor = System.Drawing.Color.FromArgb(0xc0, 0xff, 0xc0);
//                    //gv.AllowPaging = true;
//                    //gv.AlternatingRowStyle.BackColor = System.Drawing.Color.FromArgb(0xef, 0xe6, 0xf7);
//                    //gv.PagerStyle.HorizontalAlign = HorizontalAlign.Right;
//                    //gv.PagerStyle.Font.Size = FontUnit.Point(12);
//                    //gv.PagerStyle.Font.Underline = false;
//                    //if (gv.Columns == null || gv.Columns.Count < 1) return;
//                    //foreach (DataControlField dcf in gv.Columns)
//                    //{
//                    //    dcf.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
//                    //    dcf.HeaderStyle.BorderWidth = Unit.Pixel(1);
//                    //    dcf.HeaderStyle.BorderColor = System.Drawing.Color.FromArgb(0x82, 0xA8, 0xCF);
//                    //    dcf.HeaderStyle.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
//                    //    dcf.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(0xe3, 0xef, 0xff);
//                    //    dcf.HeaderStyle.Height = Unit.Pixel(20);
//                    //    dcf.HeaderStyle.Font.Bold = true;
//                    //    dcf.HeaderStyle.ForeColor = System.Drawing.Color.Black;
//                    //    //dcf.HeaderStyle.Font.Size = FontUnit.Point(11);
//                    //    dcf.HeaderStyle.Font.Underline = false;
//                    //    dcf.ItemStyle.BorderWidth = Unit.Pixel(1);
//                    //    dcf.ItemStyle.BorderColor = System.Drawing.Color.FromArgb(0x82, 0xA8, 0xCF);
//                    //    dcf.ItemStyle.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
//                    //    dcf.ItemStyle.Height = Unit.Pixel(25);
//                    //}
//                }
//                catch (Exception ex)
//                {
//                    ViewHelper.MsgBox<XGridView>(ex.Message);
//                }
//                _SetDefaultStype = value;
//            }
//        }

//        /// <summary>
//        /// ����д���л�ҳʱȡ��ԭѡ��
//        /// </summary>
//        /// <param name="e"></param>
//        protected override void OnPageIndexChanging(GridViewPageEventArgs e)
//        {
//            this.SelectedIndex = -1;
//            base.OnPageIndexChanging(e);
//        }
//    }

//    /// <summary>
//    /// �ڿ��ӻ��������Ϊ XControl.XGridView �ؼ��ṩ���ʱ֧�֡�
//    /// </summary>
//    public class XGridViewDesigner : GridViewDesigner
//    {
//        /// <summary>
//        /// �������ؼ�������Դ�ܹ�����ʱ������������
//        /// </summary>
//        protected override void OnSchemaRefreshed()
//        {
//            base.OnSchemaRefreshed();
//            //������ԭ���ģ��������µ�
//            //if (!InTemplateMode && !IgnoreSchemaRefreshedEvent)
//            if (!InTemplateMode)
//            {
//                try
//                {
//                    XGridView gv = base.Component as XGridView;
//                    if (gv == null) return;
//                    DataControlFieldCollection cs = gv.Columns;
//                    if (cs == null || cs.Count < 1) return;
//                    gv.SetEntry = !gv.SetEntry;
//                    //gv.SetDefaultStype = !gv.SetDefaultStype;
//                    //gv.CreateEntryColumns();
//                    //gv.SetDefaultStype();
//                    //gv.Columns = cs;
//                    //gv.Columns.Clear();
//                    //foreach (DataControlField dcf in cs) gv.Columns.Add(dcf);
//                }
//                catch (Exception ex)
//                {
//                    ViewHelper.MsgBox<XGridView>(ex.Message);
//                }
//            }
//        }

//        private Boolean IgnoreSchemaRefreshedEvent
//        {
//            get
//            {
//                Type t = typeof(GridViewDesigner);
//                if (t == null) return false;
//                PropertyInfo pi = t.GetProperty("_ignoreSchemaRefreshedEvent", BindingFlags.Instance | BindingFlags.NonPublic);
//                if (pi == null) return false;
//                return (Boolean)pi.GetValue((this as GridViewDesigner), null);
//            }
//        }

//        private ISite Site
//        {
//            get
//            {
//                return base.Component.Site;
//            }
//        }
//    }
//}