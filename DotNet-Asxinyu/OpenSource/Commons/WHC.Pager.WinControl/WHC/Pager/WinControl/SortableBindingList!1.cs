namespace WHC.Pager.WinControl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;

    public class SortableBindingList<T> : BindingList<T>
    {
        private bool bool_0;
        private ListSortDirection listSortDirection_0;
        private PropertyDescriptor propertyDescriptor_0;
        private string string_0;

        public SortableBindingList()
        {
            this.bool_0 = true;
            this.listSortDirection_0 = ListSortDirection.Ascending;
            this.propertyDescriptor_0 = null;
        }

        public SortableBindingList(IList<T> list) : base(list)
        {
            this.bool_0 = true;
            this.listSortDirection_0 = ListSortDirection.Ascending;
            this.propertyDescriptor_0 = null;
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            this.bool_0 = true;
            this.propertyDescriptor_0 = prop;
            this.listSortDirection_0 = direction;
            this.method_0();
        }

        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (object.Equals(prop.GetValue(base[i]), key))
                {
                    return i;
                }
            }
            return -1;
        }

        private void method_0()
        {
            (base.Items as List<T>).Sort(new Comparison<T>(this.method_1));
            base.ResetBindings();
        }

        private int method_1(T o1, T o2)
        {
            int num = 0;
            if (this.SortPropertyCore != null)
            {
                num = SortableBindingList<T>.smethod_0(this.SortPropertyCore.GetValue(o1), this.SortPropertyCore.GetValue(o2), this.SortPropertyCore.PropertyType);
            }
            if ((num == 0) && (this.DefaultSortItem != null))
            {
                PropertyInfo info = typeof(T).GetProperty(this.DefaultSortItem, BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase, null, null, new Type[0], null);
                if (info != null)
                {
                    num = SortableBindingList<T>.smethod_0(info.GetValue(o1, null), info.GetValue(o2, null), info.PropertyType);
                }
            }
            if (this.SortDirectionCore == ListSortDirection.Descending)
            {
                num = -num;
            }
            return num;
        }

        protected override void RemoveSortCore()
        {
            if (this.bool_0)
            {
                this.bool_0 = false;
                this.propertyDescriptor_0 = null;
                this.listSortDirection_0 = ListSortDirection.Ascending;
                this.method_0();
            }
        }

        private static int smethod_0(object object_0, object object_1, Type type_0)
        {
            if (object_0 == null)
            {
                return ((object_1 == null) ? 0 : -1);
            }
            if (object_1 == null)
            {
                return 1;
            }
            if (type_0.IsPrimitive || type_0.IsEnum)
            {
                return Convert.ToDouble(object_0).CompareTo(Convert.ToDouble(object_1));
            }
            if (type_0 == typeof(DateTime))
            {
                return Convert.ToDateTime(object_0).CompareTo(object_1);
            }
            return string.Compare(object_0.ToString().Trim(), object_1.ToString().Trim());
        }

        public string DefaultSortItem
        {
            get
            {
                return this.string_0;
            }
            set
            {
                if (this.string_0 != value)
                {
                    this.string_0 = value;
                    this.method_0();
                }
            }
        }

        protected override bool IsSortedCore
        {
            get
            {
                return this.bool_0;
            }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return this.listSortDirection_0;
            }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return this.propertyDescriptor_0;
            }
        }

        protected override bool SupportsSearchingCore
        {
            get
            {
                return true;
            }
        }

        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }
    }
}

