namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;

    public class SearchCondition
    {
        private Hashtable PQMwwy6pB = new Hashtable();

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal bool 37jAJ3Bnt(string text1)
        {
            return Regex.IsMatch(text1, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2854));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string 408MSTia8(SqlOperator operator1)
        {
            string str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x22e4);
            switch (operator1)
            {
                case SqlOperator.Like:
                    return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x230e);

                case SqlOperator.Equal:
                    return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x22ee);

                case SqlOperator.NotEqual:
                    return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2334);

                case SqlOperator.MoreThan:
                    return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x231e);

                case SqlOperator.LessThan:
                    return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x22f8);

                case SqlOperator.MoreThanOrEqual:
                    return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2328);

                case SqlOperator.LessThanOrEqual:
                    return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2302);

                case SqlOperator.In:
                    return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2340);
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public SearchCondition AddCondition(string fielName, object fieldValue, SqlOperator sqlOperator)
        {
            this.PQMwwy6pB.Add(Guid.NewGuid(), new SearchInfo(fielName, fieldValue, sqlOperator));
            return this;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public SearchCondition AddCondition(string fielName, object fieldValue, SqlOperator sqlOperator, bool excludeIfEmpty)
        {
            this.PQMwwy6pB.Add(Guid.NewGuid(), new SearchInfo(fielName, fieldValue, sqlOperator, excludeIfEmpty));
            return this;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public SearchCondition AddCondition(string fielName, object fieldValue, SqlOperator sqlOperator, bool excludeIfEmpty, string groupName)
        {
            this.PQMwwy6pB.Add(Guid.NewGuid(), new SearchInfo(fielName, fieldValue, sqlOperator, excludeIfEmpty, groupName));
            return this;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string BuildConditionSql(DatabaseType dbType)
        {
            string str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1eb2);
            SearchInfo info = null;
            StringBuilder builder = new StringBuilder();
            str = str + this.mUvqAX6rk(dbType);
            foreach (DictionaryEntry entry in this.PQMwwy6pB)
            {
                info = (SearchInfo) entry.Value;
                TypeCode typeCode = Type.GetTypeCode(info.FieldValue.GetType());
                if ((!info.ExcludeIfEmpty || ((info.FieldValue != null) && !string.IsNullOrEmpty(info.FieldValue.ToString()))) && string.IsNullOrEmpty(info.GroupName))
                {
                    if (info.SqlOperator == SqlOperator.Like)
                    {
                        builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1ed0), info.FieldName, this.408MSTia8(info.SqlOperator), string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1ef8), info.FieldValue));
                    }
                    else if (info.SqlOperator == SqlOperator.In)
                    {
                        builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1f06), info.FieldName, this.408MSTia8(info.SqlOperator), string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1f2a), info.FieldValue));
                    }
                    else if (dbType == DatabaseType.Oracle)
                    {
                        if (this.JiYUNJcCW(info.FieldValue.ToString()))
                        {
                            builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1f38), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                        }
                        else if (this.37jAJ3Bnt(info.FieldValue.ToString()))
                        {
                            builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1f8c), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                        }
                        else
                        {
                            builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1fec), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                        }
                    }
                    else if (dbType == DatabaseType.Access)
                    {
                        if (((info.SqlOperator == SqlOperator.Equal) && (typeCode == TypeCode.String)) && string.IsNullOrEmpty(info.FieldValue.ToString()))
                        {
                            builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2014), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                        }
                        else if (typeCode == TypeCode.DateTime)
                        {
                            builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x205e), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                        }
                        else if ((((((typeCode == TypeCode.Byte) || (typeCode == TypeCode.Decimal)) || ((typeCode == TypeCode.Double) || (typeCode == TypeCode.Int16))) || (((typeCode == TypeCode.Int32) || (typeCode == TypeCode.Int64)) || ((typeCode == TypeCode.SByte) || (typeCode == TypeCode.Single)))) || ((typeCode == TypeCode.UInt16) || (typeCode == TypeCode.UInt32))) || (typeCode == TypeCode.UInt64))
                        {
                            builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2086), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                        }
                        else
                        {
                            builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x20aa), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                        }
                    }
                    else
                    {
                        builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x20d2), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                    }
                }
            }
            return (str + builder.ToString());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private DbType GPY6Re0PF(object obj1)
        {
            DbType type = DbType.String;
            switch (obj1.GetType().ToString())
            {
                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x234c):
                    return DbType.Int16;

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2368):
                    return DbType.UInt16;

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2386):
                    return DbType.Single;

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x23a4):
                    return DbType.UInt32;

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x23c2):
                    return DbType.Int32;

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x23de):
                    return DbType.UInt64;

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x23fc):
                    return DbType.Int64;

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2418):
                    return DbType.String;

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2436):
                    return DbType.Double;

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2454):
                    return DbType.Decimal;

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2474):
                    return DbType.Byte;

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x248e):
                    return DbType.Boolean;

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x24ae):
                    return DbType.DateTime;

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x24d0):
                    return DbType.Guid;
            }
            return type;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal bool JiYUNJcCW(string text1)
        {
            return Regex.IsMatch(text1, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x24ea));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string mUvqAX6rk(DatabaseType type1)
        {
            Hashtable hashtable = this.XPOfx7u7N();
            SearchInfo info = null;
            StringBuilder builder = new StringBuilder();
            string str = string.Empty;
            string format = string.Empty;
            foreach (string str3 in hashtable.Keys)
            {
                builder = new StringBuilder();
                format = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x20fa);
                foreach (DictionaryEntry entry in this.PQMwwy6pB)
                {
                    info = (SearchInfo) entry.Value;
                    TypeCode typeCode = Type.GetTypeCode(info.FieldValue.GetType());
                    if ((!info.ExcludeIfEmpty || ((info.FieldValue != null) && !string.IsNullOrEmpty(info.FieldValue.ToString()))) && str3.Equals(info.GroupName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (info.SqlOperator == SqlOperator.Like)
                        {
                            builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2112), info.FieldName, this.408MSTia8(info.SqlOperator), string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2138), info.FieldValue));
                        }
                        else if (type1 == DatabaseType.Oracle)
                        {
                            if (this.JiYUNJcCW(info.FieldValue.ToString()))
                            {
                                builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2146), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                            }
                            else if (this.37jAJ3Bnt(info.FieldValue.ToString()))
                            {
                                builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2198), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                            }
                            else
                            {
                                builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x21f6), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                            }
                        }
                        else if (type1 == DatabaseType.Access)
                        {
                            if (typeCode == TypeCode.DateTime)
                            {
                                builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x221c), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                            }
                            else if ((((((typeCode == TypeCode.Byte) || (typeCode == TypeCode.Decimal)) || ((typeCode == TypeCode.Double) || (typeCode == TypeCode.Int16))) || (((typeCode == TypeCode.Int32) || (typeCode == TypeCode.Int64)) || ((typeCode == TypeCode.SByte) || (typeCode == TypeCode.Single)))) || ((typeCode == TypeCode.UInt16) || (typeCode == TypeCode.UInt32))) || (typeCode == TypeCode.UInt64))
                            {
                                builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2242), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                            }
                            else
                            {
                                builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2264), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                            }
                        }
                        else if (info.SqlOperator == SqlOperator.Like)
                        {
                            builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x228a), info.FieldName, this.408MSTia8(info.SqlOperator), string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x22b0), info.FieldValue));
                        }
                        else
                        {
                            builder.AppendFormat(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x22be), info.FieldName, this.408MSTia8(info.SqlOperator), info.FieldValue);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(builder.ToString()))
                {
                    format = string.Format(format, builder.ToString().Substring(3));
                    str = str + format;
                }
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private Hashtable XPOfx7u7N()
        {
            Hashtable hashtable = new Hashtable();
            SearchInfo info = null;
            foreach (DictionaryEntry entry in this.PQMwwy6pB)
            {
                info = (SearchInfo) entry.Value;
                if (!(string.IsNullOrEmpty(info.GroupName) || hashtable.Contains(info.GroupName)))
                {
                    hashtable.Add(info.GroupName, info.GroupName);
                }
            }
            return hashtable;
        }

        public Hashtable ConditionTable
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.PQMwwy6pB;
            }
        }
    }
}

