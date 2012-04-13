namespace DotNet.Core.Commons
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// �ļ�������
    /// </summary>
    public class IOHelper
    {
        #region �����ļ���
        /// <summary>
        /// �����ļ���,Ĭ�ϸ���
        /// </summary>
        /// <param name="strPathSrc">ԭʼ�ļ�·��</param>
        /// <param name="strPathDest">Ŀ��·��</param>
        /// <param name="blnOverwrite">�Ƿ񸲸�</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public static bool CopyFolder(string strPathSrc, string strPathDest, bool blnOverwrite = true )
        {
            bool flag = true;
            DirectoryInfo info2 = new DirectoryInfo(strPathSrc);
            DirectoryInfo info = new DirectoryInfo(strPathDest);
            try
            {
                if (!info.Exists)
                {
                    info.Create();
                }
                foreach (FileInfo info4 in info2.GetFiles())
                {
                    info4.CopyTo(Path.Combine(info.FullName, info4.Name), blnOverwrite);
                }
                foreach (DirectoryInfo info3 in info2.GetDirectories())
                {
                    flag &= CopyFolder(info3.FullName, Path.Combine(info.FullName, info3.Name), blnOverwrite);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }
        #endregion

        #region �����ļ�����
        /// <summary>
        /// �����ļ���Ŀ
        /// </summary>
        /// <param name="path">�ļ���·��</param>
        /// <param name="filter">�ļ����ˣ���׺��</param>
        /// <returns>�����ļ��а����ƶ��ļ�����Ŀ</returns>
        public static int CountFiles(string path, string filter = "")
        {
            if (!Directory.Exists(path))
            {
                return 0;
            }
            return Directory.GetFiles(path, filter).Length;
        }
        #endregion

        #region �����ļ��Ĵ�С��KB��
        /// <summary>
        /// �����ļ��Ĵ�С��KB��
        /// </summary>
        /// <param name="strPath">�ļ�·��</param>
        /// <returns>�ļ���С����λKB</returns>
        public static int GetFileSizeKbytes(string strPath)
        {
            FileInfo info = new FileInfo(strPath);
            if (info.Exists)
            {
                return Convert.ToInt32((double) (((double) info.Length) / 1024.0));
            }
            return 0;
        }
        #endregion

        #region �����ļ��еĴ�С(MB)
        public static long GetFolderSizeMbytes(string strPath)
        {
            //�жϸ�����·���Ƿ����,������������˳�
            if (!Directory.Exists(strPath))
                return 0;
            long len = 0;
            //����һ��DirectoryInfo����
            DirectoryInfo di = new DirectoryInfo(strPath);
            //ͨ��GetFiles����,��ȡdiĿ¼�е������ļ��Ĵ�С
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
            }
            //��ȡdi�����е��ļ���,���浽һ���µĶ���������,�Խ��еݹ�
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetFolderSizeMbytes(dis[i].FullName);
                }
            }
            return Convert.ToInt64 (len/1024/1024) ;
        }
        #endregion

        #region ��ȡ����
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="strPath">�ļ�·��</param>
        /// <param name="objEncoding">����</param>
        /// <returns>��ȡ�������ַ���</returns>
        public static string ReadFile(string strPath, Encoding objEncoding)
        {
            string str2 = string.Empty;
            if (File.Exists(strPath))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(strPath, objEncoding))
                    {
                        return reader.ReadToEnd();
                    }
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    ProjectData.ClearProjectError();
                }
            }
            return str2;
        }
        #endregion

        #region ��֤·���Ƿ�Ϸ�
        /// <summary>
        /// ��֤·���Ƿ�Ϸ�
        /// </summary>
        /// <param name="value">�ļ�·���ַ���</param>
        /// <returns>�Ƿ�Ϸ�</returns>
        public static bool ValidatePath(string value)
        {
            if (value == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(value.Trim()))
            {
                return false;
            }
            foreach (char ch in Path.GetInvalidPathChars())
            {
                if (value.IndexOf(ch) > 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region ��֤����·���Ƿ�Ϸ�
        /// <summary>
        /// ��֤����·���Ƿ�Ϸ�
        /// </summary>
        /// <param name="strPath">����·��</param>
        /// <returns>�Ƿ�Ϸ�</returns>
        public static bool ValidatePhysicalPath(string strPath)
        {
            if (!ValidatePath(strPath))
            {
                return false;
            }
            return ((strPath.IndexOf(Path.VolumeSeparatorChar) > 0) && ((strPath.IndexOf(Path.DirectorySeparatorChar) > 0) | (strPath.IndexOf(Path.AltDirectorySeparatorChar) > 0)));
        }
        #endregion

        #region д�ļ�
        /// <summary>
        /// ���ַ�������д���ƶ��ļ�
        /// </summary>
        /// <param name="strPath">�ļ�·��</param>
        /// <param name="strValue">д����ַ�������</param>
        /// <param name="objEncoding">����</param>
        /// <param name="blnAppend">�Ƿ�׷��</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public static bool WriteFile(string strPath, string strValue, Encoding objEncoding,bool blnAppend = false)
        {
            bool flag;
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(strPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(strPath));
                }
                using (StreamWriter writer = new StreamWriter(strPath, blnAppend, objEncoding))
                {
                    writer.Write(strValue);
                }
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }
        #endregion
    }
}
