//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.Design;
////using System.Windows.Forms;

//using System.Drawing;
//using System.Text;
//using System.Web.UI;
//using System.Web.UI.Design;
//using System.Web.UI.Design.WebControls;
//using System.Web.UI.WebControls;
////using XCode.Configuration;
////using XCode.Attributes;

//namespace XControl
//{
//    /// <summary>
//    /// ��дFormView
//    /// </summary>
//    [ToolboxItem(false)]
//    [DefaultProperty("Text")]
//    [ToolboxData("<{0}:XFormView runat=server></{0}:XFormView>")]
//    [Designer(typeof(XFormViewDesigner))]
//    [ToolboxBitmap(typeof(FormView))]
//    public class XFormView : FormView
//    {
//        #region ÿ���ֶθ���
//        /// <summary>
//        /// ÿ���ֶθ��������ø����Ժ��Զ�����ģ��ʱ�����ݸ�������������
//        /// </summary>
//        [Category(" ר������"), DefaultValue(2), Description("ÿ���ֶθ��������ø����Ժ��Զ�����ģ��ʱ�����ݸ�������������")]
//        public Int32 ColumnSize
//        {
//            get
//            {
//                return ViewState["ColumnSize"] == null ? 2 : Int32.Parse(ViewState["ColumnSize"].ToString());
//            }
//            set
//            {
//                ViewState["ColumnSize"] = value;
//            }
//        }
//        #endregion

//        #region �Զ�ˢ�¶�Ӧ��XGridView
//        /// <summary>
//        /// �Զ�ˢ�¶�Ӧ��XGridView
//        /// </summary>
//        [Category(" ר������"), DefaultValue(false), Description("�Զ�ˢ�¶�Ӧ��XGridView")]
//        public Boolean AutoRefreshXGridView
//        {
//            get
//            {
//                return ViewState["AutoRefreshXGridView"] == null ? false : (Boolean)ViewState["AutoRefreshXGridView"];
//            }
//            set
//            {
//                ViewState["AutoRefreshXGridView"] = value;
//            }
//        }

//        /// <summary>
//        /// �����ء�
//        /// </summary>
//        /// <param name="e"></param>
//        protected override void OnItemInserted(FormViewInsertedEventArgs e)
//        {
//            base.OnItemInserted(e);
//            RefreshXGridView();
//        }

//        /// <summary>
//        /// �����ء�
//        /// </summary>
//        /// <param name="e"></param>
//        protected override void OnItemUpdated(FormViewUpdatedEventArgs e)
//        {
//            base.OnItemUpdated(e);
//            RefreshXGridView();
//        }

//        /// <summary>
//        /// �����ء�
//        /// </summary>
//        /// <param name="e"></param>
//        protected override void OnItemDeleted(FormViewDeletedEventArgs e)
//        {
//            base.OnItemDeleted(e);
//            RefreshXGridView();
//        }

//        /// <summary>
//        /// ���ù�����XGridView���°�����
//        /// </summary>
//        private void RefreshXGridView()
//        {
//            if (!AutoRefreshXGridView) return;
//            GridView xgv = FindGridView();
//            if (xgv == null) return;
//            xgv.DataBind();
//        }
//        #endregion

//        #region ȡ��ѡ��
//        /// <summary>
//        /// �����ء�
//        /// </summary>
//        /// <param name="e"></param>
//        protected override void OnItemCommand(FormViewCommandEventArgs e)
//        {
//            //ȡ��ѡ��
//            if (e.CommandName == "CancelSelect")
//            {
//                GridView xgv = FindGridView();
//                if (xgv == null) return;
//                xgv.SelectedIndex = -1;
//            }
//            else
//                base.OnItemCommand(e);
//        }
//        #endregion

//        /// <summary>
//        /// �ҵ�GridView
//        /// </summary>
//        /// <returns></returns>
//        private GridView FindGridView()
//        {
//            //�ҵ���Ӧ��ObjectDataSource
//            if (String.IsNullOrEmpty(DataSourceID)) return null;
//            ObjectDataSource ods = ViewHelper.Find(Page, DataSourceID) as ObjectDataSource;
//            if (ods == null) return null;
//            if (ods.SelectParameters.Count != 1) return null;
//            ControlParameter para = ods.SelectParameters[0] as ControlParameter;
//            if (para == null || String.IsNullOrEmpty(para.ControlID)) return null;
//            return ViewHelper.Find(Page, para.ControlID) as GridView;
//        }
//    }

//    /// <summary>
//    /// �ڿ��ӻ��������Ϊ XControl.XFormView �ؼ��ṩ���ʱ֧�֡�
//    /// </summary>
//    public class XFormViewDesigner : FormViewDesigner
//    {
//        /// <summary>
//        /// �������ؼ�������Դ�ܹ�����ʱ������������
//        /// </summary>
//        protected override void OnSchemaRefreshed()
//        {
//            base.OnSchemaRefreshed();
//            //������ԭ���ģ��������µ�
//            if (!InTemplateMode)
//            {
//#if !DEBUG
//                try
//#endif
//                {
//                    AddTemplates();
//                }
//#if !DEBUG
//                catch (Exception ex)
//                {
//                    ViewHelper.MsgBox<XFormView>(ex.Message);
//                }
//#endif
//            }
//        }

//        private ISite Site
//        {
//            get
//            {
//                return base.Component.Site;
//            }
//        }

//        //ǰ׺
//        static String perfix = "XCL";

//        private void AddTemplates()
//        {
//            //ȡ��ʵ����
//            Type t = ViewHelper.GetEntryType<XFormView>(Site);
//            if (t == null) return;
//            List<FieldItem> list = ViewHelper.AllFields(t);
//            if (list == null) return;

//            //˼·
//            //����ʵ�����Ա����������ģ��

//            IDesignerHost service = (IDesignerHost)Site.GetService(typeof(IDesignerHost));
//            if (service == null) return;

//            XFormView fv = Site.Component as XFormView;

//            Table Item = new Table();
//            Table Edit = new Table();
//            Table Inst = new Table();

//            Item.ID = fv.ClientID + "_Item";
//            Edit.ID = fv.ClientID + "_Edit";
//            Inst.ID = fv.ClientID + "_Inst";

//            #region ѭ������ģ��
//            int count = fv.ColumnSize;
//            if (count < 1) count = 1;
//            int index = 0;

//            //��ǰ��
//            Row ItemRow = new Row();
//            Row EditRow = new Row();
//            Row InstRow = new Row();
//            Item.Rows.Add(ItemRow);
//            Edit.Rows.Add(EditRow);
//            Inst.Rows.Add(InstRow);

//            foreach (FieldItem fi in list)
//            {
//                #region Ԥ����
//                //�Ƿ���
//                Boolean IsWrap = index % count == 0;
//                //��һ�в�����
//                if (index == 0) IsWrap = false;
//                index++;

//                String name = fi.Name;
//                //����õ�һ�����֣�ֻ������ĸ���ֺ��»��ߣ������ַ�תΪ�»���
//                char[] chArray = new char[name.Length];
//                for (int i = 0; i < name.Length; i++)
//                {
//                    char c = name[i];
//                    if (char.IsLetterOrDigit(c) || (c == '_'))
//                    {
//                        chArray[i] = c;
//                    }
//                    else
//                    {
//                        chArray[i] = '_';
//                    }
//                }
//                String controlID = new String(chArray);
//                String strEval = "Eval(\"" + name + "\")";
//                String strBind = "Bind(\"" + name + "\")";
//                if (fi.Info.PropertyType == typeof(DateTime))
//                {
//                    strEval = "Eval(\"" + name + "\", \"{0:yyyy-MM-dd HH:mm:ss}\")";
//                    strBind = "Bind(\"" + name + "\", \"{0:yyyy-MM-dd HH:mm:ss}\")";
//                }

//                //����ָ��Ϊ������
//                name = (String.IsNullOrEmpty(fi.Description)) ? fi.Name : fi.Description;

//                String strEdit = "";
//                String strItem = "";
//                String strInst = "";
//                #endregion

//                #region ʶ��ɲ�ͬ�Ŀؼ�
//                if (fi.DataObjectField.IsIdentity)
//                {
//                    strEdit = MakeLabel(controlID, strEval);
//                    strItem = MakeLabel(controlID, strEval);

//                    IsWrap = true;
//                    index = 0;
//                }
//                //�����ͣ�������Is��ͷ�ҵ�����ĸ�Ǵ�д��ĸ�����ͣ�����IsTop
//                else if (fi.Info.PropertyType == typeof(Boolean))
//                {
//                    strItem = MakeCheckBox(controlID, strBind, false);
//                    strEdit = MakeCheckBox(controlID, strBind, true);
//                    strInst = MakeCheckBox(controlID, strBind, true);
//                }
//                else if (fi.Info.PropertyType == typeof(Int32))
//                {
//                    if (fi.Info.PropertyType == typeof(Int32) && fi.Name.Length > 2 &&
//                    fi.Name.StartsWith("Is") && fi.Name[2] >= 'A' && fi.Name[2] <= 'Z')
//                    {
//                        strItem = MakeIntCheckBox(controlID, strBind, false);
//                        strEdit = MakeIntCheckBox(controlID, strBind, true);
//                        strInst = MakeIntCheckBox(controlID, strBind, true);
//                    }
//                    else
//                    {
//                        strItem = MakeLabel(controlID, strBind);
//                        strEdit = String.Format("<{2}:NumberBox Text='<%# {1} %>' runat=\"server\" id=\"{0}NumberBox\" />", controlID, strBind, perfix);
//                        strInst = strEdit;
//                    }
//                }
//                else if (fi.Info.PropertyType == typeof(Double))
//                {
//                    strItem = MakeLabel(controlID, strBind);
//                    strEdit = String.Format("<{2}:RealBox Text='<%# {1} %>' runat=\"server\" id=\"{0}RealBox\" />", controlID, strBind, perfix);
//                    strInst = strEdit;
//                }
//                else if (fi.Info.PropertyType == typeof(DateTime))
//                {
//                    strItem = MakeLabel(controlID, strBind);
//                    strEdit = String.Format("<{2}:DateBox Text='<%# {1} %>' runat=\"server\" id=\"{0}DateBox\" />", controlID, strBind, perfix);
//                    strInst = strEdit;
//                }
//                else if (fi.Name.ToLower() == "ip")
//                {
//                    strItem = MakeLabel(controlID, strBind);
//                    strEdit = String.Format("<{2}:IPBox Text='<%# {1} %>' runat=\"server\" id=\"{0}IPBox\" />", controlID, strBind, perfix);
//                    strInst = strEdit;
//                }
//                else if (fi.Name.ToLower() == "mail" || fi.Name.ToLower() == "email")
//                {
//                    strItem = MakeLabel(controlID, strBind);
//                    strEdit = String.Format("<{2}:MailBox Text='<%# {1} %>' runat=\"server\" id=\"{0}MailBox\" />", controlID, strBind, perfix);
//                    strInst = strEdit;
//                }
//                else if (fi.Name.ToLower() == "password")
//                {
//                    strItem = MakeLabel(controlID, strBind);
//                    strEdit = String.Format("<asp:TextBox Text='<%# {1} %>' runat=\"server\" id=\"{0}TextBox\" TextMode=\"Password\" />", controlID, strBind);
//                    strInst = strEdit;
//                }
//                else if (fi.DataObjectField.Length > 255)
//                {
//                    strItem = String.Format("<asp:Label Text='<%# {1} %>' runat=\"server\" id=\"{0}Label\" Width=\"440px\" style=\"word-break: break-all; min-height: 130px\" />", controlID, strBind);
//                    strEdit = String.Format("<asp:TextBox Text='<%# {1} %>' runat=\"server\" id=\"{0}TextBox\" Height=\"130px\" TextMode=\"MultiLine\" Width=\"440px\" />", controlID, strBind);
//                    strInst = strEdit;

//                    IsWrap = true;
//                    index = 0;
//                }
//                else
//                {
//                    strItem = MakeLabel(controlID, strBind);
//                    strEdit = String.Format("<asp:TextBox Text='<%# {1} %>' runat=\"server\" id=\"{0}TextBox\" />", controlID, strBind);
//                    strInst = strEdit;
//                }
//                #endregion

//                #region ��ʼ��ģ��
//                if (IsWrap)
//                {
//                    //���ı��ж���һ�У���ǰ������һ��
//                    ItemRow = new Row();
//                    EditRow = new Row();
//                    InstRow = new Row();
//                    Item.Rows.Add(ItemRow);
//                    Edit.Rows.Add(EditRow);
//                    Inst.Rows.Add(InstRow);
//                }

//                //���뵽��ǰ��
//                name = name + "��";
//                if (fi.DataObjectField.Length > 255)
//                {
//                    //���ı��ı�ǩ��ֵ�ֱ���Ҫ����һ��
//                    ItemRow.Cells.Add(new Cell(name, null));
//                    EditRow.Cells.Add(new Cell(name, null));
//                    if (!fi.DataObjectField.IsIdentity) InstRow.Cells.Add(new Cell(name, null));

//                    ItemRow = new Row();
//                    EditRow = new Row();
//                    InstRow = new Row();
//                    Item.Rows.Add(ItemRow);
//                    Edit.Rows.Add(EditRow);
//                    Inst.Rows.Add(InstRow);

//                    ItemRow.Cells.Add(new Cell(null, strItem));
//                    EditRow.Cells.Add(new Cell(null, strEdit));
//                    if (!fi.DataObjectField.IsIdentity) InstRow.Cells.Add(new Cell(null, strInst));
//                }
//                else
//                {
//                    ItemRow.Cells.Add(new Cell(name, strItem));
//                    EditRow.Cells.Add(new Cell(name, strEdit));
//                    if (!fi.DataObjectField.IsIdentity) InstRow.Cells.Add(new Cell(name, strInst));
//                }

//                if (IsWrap)
//                {
//                    //��ʶ�ж���һ�У���ǰ������һ��
//                    ItemRow = new Row();
//                    EditRow = new Row();
//                    InstRow = new Row();
//                    Item.Rows.Add(ItemRow);
//                    Edit.Rows.Add(EditRow);
//                    Inst.Rows.Add(InstRow);
//                }
//                #endregion
//            }
//            //�Ƴ�����
//            Item.RemoveEmptyRow();
//            Edit.RemoveEmptyRow();
//            Inst.RemoveEmptyRow();

//            if (DesignerView.CanUpdate || DesignerView.CanDelete || DesignerView.CanInsert)
//            {
//                Item.Foot = Foot.Item;
//                if (!DesignerView.CanUpdate) Item.Foot.Left = null;
//                if (!DesignerView.CanDelete) Item.Foot.Middle = null;
//                if (!DesignerView.CanInsert) Item.Foot.Right = null;
//            }

//            Edit.Foot = Foot.Edit;
//            Inst.Foot = Foot.Inst;
//            #endregion

//            #region ����ģ��
//#if !DEBUG
//            try
//#endif
//            {
//                //XFormView fv = base.Component as XFormView;
//                if (fv != null)
//                {
//                    fv.ItemTemplate = ControlParser.ParseTemplate(service, Item.ToString());
//                    if (base.DesignerView.CanUpdate)
//                        fv.EditItemTemplate = ControlParser.ParseTemplate(service, Edit.ToString());
//                    if (base.DesignerView.CanInsert)
//                        fv.InsertItemTemplate = ControlParser.ParseTemplate(service, Inst.ToString());

//                    DescriptionAttribute[] btas = t.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
//                    if (btas == null || btas.Length < 1 || String.IsNullOrEmpty(btas[0].Description))
//                        fv.EmptyDataTemplate = ControlParser.ParseTemplate(service, "<asp:LinkButton ID=\"LinkButton1\" runat=\"server\" CommandName=\"New\">����</asp:LinkButton>");
//                    else
//                        fv.EmptyDataTemplate = ControlParser.ParseTemplate(service, "<asp:LinkButton ID=\"LinkButton1\" runat=\"server\" CommandName=\"New\">����" + btas[0].Description + "</asp:LinkButton>");

//                    //���⹤��������AutoRefreshXGridView
//                    fv.AutoRefreshXGridView = true;
//                }
//            }
//#if !DEBUG
//            catch (Exception ex)
//            {
//                ViewHelper.MsgBox<XFormView>(ex.Message);
//            }
//#endif
//            #endregion
//        }

//        #region ����Ԫ��
//        private static String ValueDiv
//        {
//            get
//            {
//                return "<div class=\"XFormView_ItemValue\">{0}</div>";
//            }
//        }

//        private static String BlankDiv
//        {
//            get
//            {
//                return "<div style=\"width:5px; float:left\"></div>";
//            }
//        }

//        /// <summary>
//        /// ����Label
//        /// </summary>
//        /// <param name="controlid">�ؼ�ID</param>
//        /// <param name="bindstr">���ַ���</param>
//        /// <returns></returns>
//        private static String MakeLabel(String controlid, String bindstr)
//        {
//            return String.Format("<asp:Label Text='<%# {1} %>' runat=\"server\" id=\"{0}Label\" />", controlid, bindstr);
//        }

//        /// <summary>
//        /// ����TextBox
//        /// </summary>
//        /// <param name="controlid">�ؼ�ID</param>
//        /// <param name="bindstr">���ַ���</param>
//        /// <returns></returns>
//        private static String MakeTextBox(String controlid, String bindstr)
//        {
//            return String.Format("<asp:TextBox Text='<%# {1} %>' runat=\"server\" id=\"{0}TextBox\" />", controlid, bindstr);
//        }

//        /// <summary>
//        /// ����CheckBox
//        /// </summary>
//        /// <param name="controlid">�ؼ�ID</param>
//        /// <param name="bindstr">���ַ���</param>
//        /// <param name="enabled">�Ƿ�Enabled</param>
//        /// <returns></returns>
//        private String MakeCheckBox(String controlid, String bindstr, Boolean enabled)
//        {
//            String str = String.Format("<asp:CheckBox Checked='<%# {1} %>' runat=\"server\" id=\"{0}CheckBox\"{2} />", controlid, bindstr, enabled ? "" : " Enabled=\"false\"");
//            return String.Format(ValueDiv, str);
//        }

//        /// <summary>
//        /// ����IntCheckBox
//        /// </summary>
//        /// <param name="controlid">�ؼ�ID</param>
//        /// <param name="bindstr">���ַ���</param>
//        /// <param name="enabled">�Ƿ�Enabled</param>
//        /// <returns></returns>
//        private String MakeIntCheckBox(String controlid, String bindstr, Boolean enabled)
//        {
//            String str = String.Format("<{3}:IntCheckBox Value='<%# {1} %>' runat=\"server\" id=\"{0}IntCheckBox\"{2} />", controlid, bindstr, enabled ? "" : " Enabled=\"false\"", perfix);
//            return String.Format(ValueDiv, str);
//        }
//        #endregion

//        #region ģ����
//        private class Base
//        {
//            private String _CssClass;
//            /// <summary>
//            /// ��ʽ
//            /// </summary>
//            public String CssClass { get { return _CssClass; } set { _CssClass = value; } }

//            private String _ID;
//            /// <summary>
//            /// ��ID
//            /// </summary>
//            public String ID { get { return _ID; } set { _ID = value; } }

//            private String _Content;
//            /// <summary>
//            /// ����
//            /// </summary>
//            public virtual String Content { get { return _Content; } set { _Content = value; } }

//            /// <summary>
//            /// ��ǩͷ
//            /// </summary>
//            public String Begin
//            {
//                get
//                {
//                    try
//                    {
//                        StringBuilder sb = new StringBuilder();
//                        sb.Append("<div");
//                        if (!String.IsNullOrEmpty(ID)) sb.AppendFormat(" id=\"{0}\"", ID);
//                        if (!String.IsNullOrEmpty(CssClass)) sb.AppendFormat(" class=\"{0}\"", CssClass);
//                        sb.Append(">");
//                        return sb.ToString();
//                    }
//                    catch (Exception ex)
//                    {
//                        throw ex;
//                    }
//                }
//            }

//            /// <summary>
//            /// ��ǩβ
//            /// </summary>
//            public String End
//            {
//                get { return "</div>"; }
//            }

//            /// <summary>
//            /// �����ء��������ݡ�
//            /// </summary>
//            /// <returns></returns>
//            public override string ToString()
//            {
//                StringBuilder sb = new StringBuilder();
//                sb.Append(Begin);
//                if (!String.IsNullOrEmpty(Content)) sb.Append(Content);
//                sb.Append(End);
//                return sb.ToString();
//            }
//        }

//        private class Table : Base
//        {
//            public IList<Row> Rows = new List<Row>();
//            public Foot Foot;

//            public override string Content
//            {
//                get
//                {
//                    if (Rows == null || Rows.Count < 1) return null;
//                    StringBuilder sb = new StringBuilder();
//                    foreach (Row r in Rows)
//                    {
//                        sb.Append(r.ToString());
//                    }
//                    if (Foot != null) sb.Append(Foot.ToString());
//                    return sb.ToString();
//                }
//                set { }
//            }

//            public Table()
//            {
//                CssClass = "XFormView";
//            }

//            /// <summary>
//            /// �Ƴ�����
//            /// </summary>
//            public void RemoveEmptyRow()
//            {
//                IList<Row> todel = new List<Row>();
//                foreach (Row r in Rows)
//                {
//                    if (r.Cells == null || r.Cells.Count < 1) todel.Add(r);
//                }
//                foreach (Row r in todel)
//                {
//                    Rows.Remove(r);
//                }
//            }
//        }

//        private class Row : Base
//        {
//            public IList<Cell> Cells = new List<Cell>();

//            public override string Content
//            {
//                get
//                {
//                    if (Cells == null || Cells.Count < 1) return null;
//                    StringBuilder sb = new StringBuilder();
//                    foreach (Cell c in Cells)
//                    {
//                        sb.Append(c.ToString());
//                    }
//                    return sb.ToString();
//                }
//                set { }
//            }

//            public Row()
//            {
//                CssClass = "Row";
//            }
//        }

//        private class Foot : Base
//        {
//            public String Left;
//            public String Middle;
//            public String Right;
//            public String Ext;
//            public String Blank = "<div style=\"width:5px; float:left\"></div>";

//            public override string Content
//            {
//                get
//                {
//                    StringBuilder sb = new StringBuilder();
//                    bool hasitem = false;
//                    if (!String.IsNullOrEmpty(Left))
//                    {
//                        sb.Append("<div style=\"float: left\">");
//                        sb.Append(Left);
//                        sb.Append("</div>");
//                        hasitem = true;
//                    }
//                    if (!String.IsNullOrEmpty(Middle))
//                    {
//                        if (hasitem) sb.Append(Blank);
//                        sb.Append("<div style=\"float: left\">");
//                        sb.Append(Middle);
//                        sb.Append("</div>");
//                        hasitem = true;
//                    }
//                    if (!String.IsNullOrEmpty(Right))
//                    {
//                        if (hasitem) sb.Append(Blank);
//                        sb.Append("<div style=\"float: left\">");
//                        sb.Append(Right);
//                        sb.Append("</div>");
//                        hasitem = true;
//                    }
//                    if (!String.IsNullOrEmpty(Ext))
//                    {
//                        if (hasitem) sb.Append(Blank);
//                        sb.Append("<div style=\"float: left\">");
//                        sb.Append(Ext);
//                        sb.Append("</div>");
//                        hasitem = true;
//                    }
//                    return sb.ToString();
//                }
//                set { }
//            }

//            public Foot()
//            {
//                CssClass = "Foot";
//            }

//            public static Foot Item;
//            public static Foot Edit;
//            public static Foot Inst;

//            static Foot()
//            {
//                Item = new Foot();
//                Item.Left = "<asp:LinkButton runat=\"server\" Text=\"�༭\" CommandName=\"Edit\" id=\"EditButton\" CausesValidation=\"false\" />";
//                Item.Middle = "<asp:LinkButton runat=\"server\" Text=\"ɾ��\" CommandName=\"Delete\" id=\"DeleteButton\" CausesValidation=\"false\" />";
//                Item.Right = "<asp:LinkButton runat=\"server\" Text=\"�½�\" CommandName=\"New\" id=\"NewButton\" CausesValidation=\"false\" />";
//                Item.Ext = "<asp:LinkButton runat=\"server\" Text=\"ȡ��\" CommandName=\"CancelSelect\" id=\"CancelSelectButton\" CausesValidation=\"false\" />";

//                Edit = new Foot();
//                Edit.Left = "<asp:LinkButton runat=\"server\" Text=\"����\" CommandName=\"Update\" id=\"UpdateButton\" CausesValidation=\"true\" />";
//                Edit.Middle = "<asp:LinkButton runat=\"server\" Text=\"ȡ��\" CommandName=\"Cancel\" id=\"UpdateCancelButton\" CausesValidation=\"false\" />";

//                Inst = new Foot();
//                Inst.Left = "<asp:LinkButton runat=\"server\" Text=\"����\" CommandName=\"Insert\" id=\"InsertButton\" CausesValidation=\"true\" />";
//                Inst.Middle = "<asp:LinkButton runat=\"server\" Text=\"ȡ��\" CommandName=\"Cancel\" id=\"InsertCancelButton\" CausesValidation=\"false\" />";
//            }
//        }

//        private class Cell : Base
//        {
//            public CellName ItemName;
//            public CellValue ItemValue;

//            public override string Content
//            {
//                get
//                {
//                    if (ItemName == null && ItemValue == null) return null;
//                    StringBuilder sb = new StringBuilder();
//                    if (ItemName != null && !String.IsNullOrEmpty(ItemName.Content)) sb.Append(ItemName.ToString());
//                    if (ItemValue != null && !String.IsNullOrEmpty(ItemValue.Content)) sb.Append(ItemValue.ToString());
//                    return sb.ToString();
//                }
//                set { }
//            }

//            public Cell()
//            {
//                CssClass = "Item";
//            }

//            public Cell(String name, String val)
//            {
//                ItemName = new CellName(name);
//                ItemValue = new CellValue(val);
//                CssClass = "Item";
//            }
//        }

//        private class CellName : Base
//        {
//            public CellName(String content)
//            {
//                Content = content;
//                CssClass = "ItemName";
//            }
//        }

//        private class CellValue : Base
//        {
//            public CellValue(String content)
//            {
//                Content = content;
//                CssClass = "ItemValue";
//            }
//        }
//        #endregion
//    }
//}