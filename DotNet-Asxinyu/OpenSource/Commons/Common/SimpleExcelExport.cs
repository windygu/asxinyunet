namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class SimpleExcelExport
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Output(DataTable dataTable)
        {
            Output(dataTable, DateTime.Now.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf2b0)));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Output(DataTable dataTable, string name)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            string path = "";
            dialog.Filter = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf2d6);
            dialog.FileName = name;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.FileName;
                if (File.Exists(path))
                {
                    try
                    {
                        File.Delete(path);
                    }
                    catch
                    {
                        MessageBox.Show(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf308));
                        return;
                    }
                }
                OleDbConnection connection = new OleDbConnection();
                OleDbCommand command = new OleDbCommand();
                string str2 = "";
                try
                {
                    connection.ConnectionString = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf33e) + path + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf39c);
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf3f2);
                    int num = 0;
                    while (num < dataTable.Columns.Count)
                    {
                        if (num < (dataTable.Columns.Count - 1))
                        {
                            str2 = str2 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf420) + dataTable.Columns[num].Caption + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf426);
                        }
                        else
                        {
                            str2 = str2 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf444) + dataTable.Columns[num].Caption + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf44a);
                        }
                        num++;
                    }
                    command.CommandText = str2;
                    command.ExecuteNonQuery();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf468);
                        for (num = 0; num < dataTable.Columns.Count; num++)
                        {
                            if (num < (dataTable.Columns.Count - 1))
                            {
                                str2 = str2 + dataTable.Rows[i][num].ToString() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf4a2);
                            }
                            else
                            {
                                str2 = str2 + dataTable.Rows[i][num].ToString() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf4ae);
                            }
                        }
                        command.CommandText = str2;
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf4b8));
                }
                catch (Exception exception)
                {
                    MessageBox.Show(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf4ce) + exception.Message);
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
    }
}

