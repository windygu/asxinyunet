//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Reflection;
//using System.ComponentModel;
//using System.Web.UI.WebControls;
//using System.Web.UI;

//namespace XControl
//{
//    /// <summary>
//    /// ����������
//    /// </summary>
//    internal class ViewHelper
//    {
//        /// <summary>
//        /// ȡ������������
//        /// </summary>
//        /// <param name="t"></param>
//        /// <returns></returns>
//        public static List<FieldItem> AllFields(Type t)
//        {
//            List<FieldItem> Fields = new List<FieldItem>();
//            PropertyInfo[] pis = t.GetProperties();
//            foreach (PropertyInfo pi in pis)
//            {
//                DescriptionAttribute[] Des = pi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
//                DataObjectFieldAttribute[] Dof = pi.GetCustomAttributes(typeof(DataObjectFieldAttribute), false) as DataObjectFieldAttribute[];
//                // �������DataObjectFieldAttribute��DescriptionAttribute����Ϊ��
//                if (Dof != null && Dof.Length > 0)
//                    if (Des != null && Des.Length > 0)
//                        Fields.Add(new FieldItem(pi, Dof[0], Des[0]));
//                    else
//                        Fields.Add(new FieldItem(pi, Dof[0]));
//            }
//            return Fields;
//        }

//        /// <summary>
//        /// ȡ��ʵ������
//        /// </summary>
//        /// <returns></returns>
//        public static Type GetEntryType<T>(ISite Site) where T : DataBoundControl
//        {
//            if (Site == null || Site.Component == null || !(Site.Component is T)) return null;
//            T dbc = Site.Component as T;
//            if (dbc == null || dbc.Page == null) return null;
//            String datasourceid = dbc.DataSourceID;
//            if (String.IsNullOrEmpty(datasourceid)) return null;
//            // �ҵ����ݰ󶨿ؼ�ObjectDataSource
//            //ObjectDataSource obj = dbc.Page.FindControl(datasourceid) as ObjectDataSource;
//            ObjectDataSource obj = Find(dbc.Page, datasourceid) as ObjectDataSource;
//            if (obj == null)
//            {
//                MsgBox<T>("�޷��ҵ���Ϊ " + datasourceid + " ��ObjectDataSource��");
//                return null;
//            }
//            // �ҵ�ʵ������
//            String typeName = obj.DataObjectTypeName;
//            if (String.IsNullOrEmpty(typeName)) typeName = obj.TypeName;
//            if (String.IsNullOrEmpty(typeName))
//            {
//                MsgBox<T>("�������ú�" + datasourceid + "�ٰ�����Դ��");
//                return null;
//            }
//            Type t = Type.GetType(typeName);
//            if (t == null)
//            {
//                t = System.Web.Compilation.BuildManager.GetType(typeName, false, true);
//                if (t == null)
//                {
//                    Assembly[] abs = AppDomain.CurrentDomain.GetAssemblies();
//                    foreach (Assembly ab in abs)
//                    {
//                        t = ab.GetType(typeName, false, true);
//                        if (t != null) break;
//                    }
//                    if (t == null)
//                    {
//                        MsgBox<T>("�޷���λ��������ࣺ" + typeName + "����������Ҫ����һ�����������������Ŀ��");
//                        return null;
//                    }
//                }
//            }
//            return t;
//        }

//        public static void MsgBox<T>(String msg)
//        {
//            System.Windows.Forms.MessageBox.Show(msg, typeof(T).ToString() + "�ؼ����ʱ����");
//        }

//        public static Control Find(Control control, String id)
//        {
//            if (control == null || String.IsNullOrEmpty(id)) return null;
//            if (control.ID == id) return control;
//            if (control.Controls == null || control.Controls.Count < 1) return null;
//            foreach (Control w in control.Controls)
//                if (w.ID == id) return w;
//            foreach (Control w in control.Controls)
//            {
//                Control webc = Find(w, id);
//                if (webc != null) return webc;
//            }
//            return null;
//        }

//    }

//    /// <summary>
//    /// ��������Ԫ�����Լ�����
//    /// </summary>
//    internal class FieldItem
//    {
//        /// <summary>
//        /// ����Ԫ����
//        /// </summary>
//        public PropertyInfo Info;
//        /// <summary>
//        /// ����˵��
//        /// </summary>
//        public String Description;
//        /// <summary>
//        /// �����ֶ�����
//        /// </summary>
//        public DataObjectFieldAttribute DataObjectField;
//        /// <summary>
//        /// ������
//        /// </summary>
//        public String Name
//        {
//            get
//            {
//                return Info.Name;
//            }
//        }

//        /// <summary>
//        /// ���캯��
//        /// </summary>
//        /// <param name="pi"></param>
//        /// <param name="dof"></param>
//        public FieldItem(PropertyInfo pi, DataObjectFieldAttribute dof)
//        {
//            Info = pi;
//            DataObjectField = dof;
//        }
//        /// <summary>
//        /// ���캯��
//        /// </summary>
//        /// <param name="pi"></param>
//        /// <param name="dof"></param>
//        /// <param name="bc"></param>
//        public FieldItem(PropertyInfo pi, DataObjectFieldAttribute dof, DescriptionAttribute bc)
//        {
//            Info = pi;
//            DataObjectField = dof;
//            Description = bc.Description;
//        }
//    }
//}