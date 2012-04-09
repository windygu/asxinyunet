namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using Microsoft.Win32;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Security.AccessControl;
    using System.Text;

    public class SqlScriptHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool AttachDB(string connectionString, string dataBaseName, string dataBase_MDF, string dataBase_LDF)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand {
                    Connection = connection,
                    CommandText = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xefa4)
                };
                command.Parameters.Add(new SqlParameter(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xefc0), SqlDbType.NVarChar));
                command.Parameters[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xefd0)].Value = dataBaseName;
                command.Parameters.Add(new SqlParameter(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xefe0), SqlDbType.NVarChar));
                command.Parameters[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeff6)].Value = dataBase_MDF;
                command.Parameters.Add(new SqlParameter(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf00c), SqlDbType.NVarChar));
                command.Parameters[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf022)].Value = dataBase_LDF;
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool BackupDataBase(string connectionString, string dataBaseName, string DataBaseOfBackupPath, string DataBaseOfBackupName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand {
                    Connection = connection,
                    CommandText = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf17e)
                };
                command.Parameters.Add(new SqlParameter(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf1f4), SqlDbType.NVarChar));
                command.Parameters[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf204)].Value = dataBaseName;
                command.Parameters.Add(new SqlParameter(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf214), SqlDbType.NVarChar));
                command.Parameters[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf22c)].Value = Path.Combine(DataBaseOfBackupPath, DataBaseOfBackupName);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool DetachDB(string connectionString, string dataBaseName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand {
                    Connection = connection,
                    CommandText = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf038)
                };
                command.Parameters.Add(new SqlParameter(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf054), SqlDbType.NVarChar));
                command.Parameters[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf064)].Value = dataBaseName;
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void DoSQL(string path)
        {
            string argument = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xee58), path);
            RunDos(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xee8a), argument, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void DoSQL(string path, string userID, string password, string server)
        {
            string argument = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xee9e), new object[] { userID, password, server, path });
            RunDos(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeede), argument, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string qCpqRb2bV(string text1, string text2, string text3, bool flag1)
        {
            Process process = new Process {
                StartInfo = { FileName = text1, Arguments = text2, UseShellExecute = false, RedirectStandardInput = true, RedirectStandardOutput = true, RedirectStandardError = true, CreateNoWindow = !flag1 }
            };
            if (flag1)
            {
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            }
            else
            {
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            }
            process.Start();
            if (text3 != null)
            {
                process.StandardInput.WriteLine(text3);
            }
            string str = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            process.Close();
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void r4vfcKJvu(string text1)
        {
            using (StreamWriter writer = new StreamWriter(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xef00), true, Encoding.Default))
            {
                writer.Write(text1);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ReplaceDBName(string filePath, string oldDBName, string newDBName)
        {
            if (newDBName.CompareTo(oldDBName) != 0)
            {
                string str = string.Empty;
                using (StreamReader reader = new StreamReader(filePath, Encoding.Default))
                {
                    str = reader.ReadToEnd();
                    str = str.Replace(oldDBName, newDBName);
                }
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.Default))
                {
                    writer.Write(str);
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool RestoreDataBase(string connectionString, string dataBaseName, string DataBaseOfBackupPath, string DataBaseOfBackupName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand {
                    Connection = connection,
                    CommandText = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf074)
                };
                command.Parameters.Add(new SqlParameter(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf116), SqlDbType.NVarChar));
                command.Parameters[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf132)].Value = dataBaseName;
                command.Parameters.Add(new SqlParameter(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf14e), SqlDbType.NVarChar));
                command.Parameters[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf166)].Value = Path.Combine(DataBaseOfBackupPath, DataBaseOfBackupName);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void RunDos(string fileName, string argument, bool hidden)
        {
            Process process = new Process {
                EnableRaisingEvents = false
            };
            process.StartInfo.FileName = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xeef2), fileName);
            process.StartInfo.Arguments = argument;
            if (hidden)
            {
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            }
            else
            {
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            }
            process.Start();
            process.WaitForExit();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void UpdatePathEnvironment(string physicalRoot)
        {
            string name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xef18);
            string str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xef8c);
            string str3 = Registry.LocalMachine.OpenSubKey(name).GetValue(str2).ToString();
            if (str3.IndexOf(physicalRoot) < 0)
            {
                str3 = str3 + string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xef98), physicalRoot);
            }
            Registry.LocalMachine.OpenSubKey(name, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.SetValue).SetValue(str2, str3);
        }
    }
}

