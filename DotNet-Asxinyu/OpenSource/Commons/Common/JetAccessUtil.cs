namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class JetAccessUtil
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static DataTable 01FqmBarm(string text1, OleDbConnection connection1)
        {
            IDbCommand command = new OleDbCommand {
                CommandText = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x93d2), text1),
                Connection = connection1
            };
            using (IDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo | CommandBehavior.SchemaOnly))
            {
                return reader.GetSchemaTable();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CompactMDB(string mdbFilePath)
        {
            return CompactMDB(mdbFilePath, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CompactMDB(string mdbFilePath, string password)
        {
            string str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8ecc);
            string str2 = str;
            string sourceFileName = mdbFilePath + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8f42);
            if ((password == null) || (password.Trim() == ""))
            {
                str = str + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8f4e) + mdbFilePath;
                str2 = str2 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8f6a) + sourceFileName;
            }
            else
            {
                string str6 = str;
                str = str6 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8f86) + password + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8fc2) + mdbFilePath;
                str6 = str2;
                str2 = str6 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8fe0) + password + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x901c) + mdbFilePath + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x903a);
            }
            string message = "";
            try
            {
                object target = Activator.CreateInstance(Type.GetTypeFromProgID(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9046)));
                object[] args = new object[] { str, str2 };
                target.GetType().InvokeMember(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9064), BindingFlags.InvokeMethod, null, target, args);
                Marshal.ReleaseComObject(target);
                target = null;
            }
            catch (Exception exception)
            {
                message = exception.Message;
            }
            try
            {
                File.Delete(mdbFilePath);
                File.Move(sourceFileName, mdbFilePath);
            }
            catch (Exception exception2)
            {
                message = message + exception2.Message;
            }
            return ((message == "") ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9086) : message);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CreateMDB(string mdbFilePath)
        {
            return CreateMDB(mdbFilePath, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CreateMDB(string mdbFilePath, string password)
        {
            try
            {
                string str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8dde);
                if ((password == null) || (password.Trim() == ""))
                {
                    str = str + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8e24) + mdbFilePath;
                }
                else
                {
                    string str3 = str;
                    str = str3 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8e40) + password + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8e7c) + mdbFilePath;
                }
                object target = Activator.CreateInstance(Type.GetTypeFromProgID(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8e9a)));
                object[] args = new object[] { str };
                target.GetType().InvokeMember(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8eb6), BindingFlags.InvokeMethod, null, target, args);
                Marshal.ReleaseComObject(target);
                target = null;
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8ec6);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Dictionary<string, string> ListColumns(string mdbFilePath, string password, string tableName)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string connectionString = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x92ce);
            if ((password == null) || (password.Trim() == ""))
            {
                connectionString = connectionString + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9314) + mdbFilePath;
            }
            else
            {
                string str5 = connectionString;
                connectionString = str5 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9330) + password + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x936c) + mdbFilePath;
            }
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                DataTable table = 01FqmBarm(tableName, connection);
                foreach (DataRow row in table.Rows)
                {
                    string key = row[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x938a)].ToString();
                    string str3 = ((OleDbType) row[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x93a2)]).ToString();
                    string str4 = row[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x93be)].ToString();
                    dictionary.Add(key, str4);
                }
            }
            return dictionary;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> ListTables(string mdbFilePath, string password)
        {
            List<string> list = new List<string>();
            string connectionString = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x91ec);
            if ((password == null) || (password.Trim() == ""))
            {
                connectionString = connectionString + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9232) + mdbFilePath;
            }
            else
            {
                string str3 = connectionString;
                connectionString = str3 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x924e) + password + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x928a) + mdbFilePath;
            }
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                object[] restrictions = new object[4];
                restrictions[3] = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x92a8);
                DataTable oleDbSchemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);
                for (int i = 0; i < oleDbSchemaTable.Rows.Count; i++)
                {
                    string item = oleDbSchemaTable.Rows[i][kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x92b6)].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SetMDBPassword(string mdbFilePath, string oldPwd, string newPwd)
        {
            string message;
            OleDbConnection connection = new OleDbConnection(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x908c) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x90d2) + (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9122) + oldPwd + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x915e) + mdbFilePath));
            try
            {
                connection.Open();
                string str2 = ((oldPwd == null) || (oldPwd.Trim() == "")) ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9188) : (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x917c) + oldPwd + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9182));
                string str3 = ((newPwd == null) || (newPwd.Trim() == "")) ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x91a0) : (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9194) + newPwd + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x919a));
                new OleDbCommand(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x91ac) + str3 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x91e0) + str2, connection).ExecuteNonQuery();
                connection.Close();
                message = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x91e6);
            }
            catch (Exception exception)
            {
                message = exception.Message;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
            }
            return message;
        }
    }
}

