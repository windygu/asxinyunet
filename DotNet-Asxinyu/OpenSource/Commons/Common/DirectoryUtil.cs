namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Text;

    public class DirectoryUtil
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void AppendText(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void AssertDirExist(string filePath)
        {
            DirectoryInfo info = new DirectoryInfo(filePath);
            if (!info.Exists)
            {
                info.Create();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Stream BytesToStream(byte[] bytes)
        {
            return new MemoryStream(bytes);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ClearDirectory(string directoryPath)
        {
            if (IsExistDirectory(directoryPath))
            {
                int num;
                string[] fileNames = GetFileNames(directoryPath);
                for (num = 0; num < fileNames.Length; num++)
                {
                    DeleteFile(fileNames[num]);
                }
                string[] directories = GetDirectories(directoryPath);
                for (num = 0; num < directories.Length; num++)
                {
                    DeleteDirectory(directories[num]);
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ClearFile(string filePath)
        {
            File.Delete(filePath);
            CreateFile(filePath);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool CompareFilesHash(string fileName1, string fileName2)
        {
            bool flag;
            using (HashAlgorithm algorithm = HashAlgorithm.Create())
            {
                using (FileStream stream = new FileStream(fileName1, FileMode.Open))
                {
                    using (FileStream stream2 = new FileStream(fileName2, FileMode.Open))
                    {
                        byte[] buffer = algorithm.ComputeHash(stream);
                        byte[] buffer2 = algorithm.ComputeHash(stream2);
                        flag = BitConverter.ToString(buffer) == BitConverter.ToString(buffer2);
                    }
                }
            }
            return flag;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ContainFile(string directoryPath, string searchPattern)
        {
            bool flag;
            try
            {
                if (GetFileNames(directoryPath, searchPattern, false).Length == 0)
                {
                    return false;
                }
                flag = true;
            }
            catch (IOException exception)
            {
                throw exception;
            }
            return flag;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ContainFile(string directoryPath, string searchPattern, bool isSearchChild)
        {
            bool flag;
            try
            {
                if (GetFileNames(directoryPath, searchPattern, true).Length == 0)
                {
                    return false;
                }
                flag = true;
            }
            catch (IOException exception)
            {
                throw exception;
            }
            return flag;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ulong ConvertByteCountToKByteCount(ulong byteCount)
        {
            return (byteCount / ((ulong) 0x400L));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float ConvertKByteCountToMByteCount(ulong kByteCount)
        {
            return (float) (kByteCount / ((ulong) 0x400L));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float ConvertMByteCountToGByteCount(float kByteCount)
        {
            return (kByteCount / 1024f);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Copy(string sourceFilePath, string destFilePath)
        {
            File.Copy(sourceFilePath, destFilePath, true);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CreateDirectory(string directoryPath)
        {
            if (!IsExistDirectory(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CreateDirectoryByDate(string rootPath)
        {
            return CreateDirectoryByDate(rootPath, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x59de));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CreateDirectoryByDate(string rootPath, string formatString)
        {
            string str;
            if (!IsExistDirectory(rootPath))
            {
                throw new DirectoryNotFoundException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x59f6));
            }
            bool flag = false;
            string str3 = formatString;
            if (str3 != null)
            {
                if (!(str3 == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5a2c)))
                {
                    if (str3 == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5a44))
                    {
                        flag = true;
                        goto Label_0077;
                    }
                }
                else
                {
                    flag = false;
                    goto Label_0077;
                }
            }
            flag = false;
        Label_0077:
            str = rootPath + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5a62) + DateTime.Now.Year.ToString();
            CreateDirectory(str);
            str = str + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5a68) + DateTime.Now.Month.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5a6e));
            CreateDirectory(str);
            str = str + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5a76) + DateTime.Now.Day.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5a7c));
            CreateDirectory(str);
            if (flag)
            {
                str = str + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5a84) + DateTime.Now.Hour.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5a8a));
                CreateDirectory(str);
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CreateFile(string filePath)
        {
            try
            {
                if (!IsExistFile(filePath))
                {
                    File.Create(filePath);
                }
            }
            catch (IOException exception)
            {
                throw exception;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CreateFile(string filePath, byte[] buffer)
        {
            try
            {
                if (!IsExistFile(filePath))
                {
                    using (FileStream stream = File.Create(filePath))
                    {
                        stream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
            catch (IOException exception)
            {
                throw exception;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CreateTempZeroByteFile()
        {
            return Path.GetTempFileName();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void DeleteDirectory(string directoryPath)
        {
            if (IsExistDirectory(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void DeleteFile(string filePath)
        {
            if (IsExistFile(filePath))
            {
                File.Delete(filePath);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool FileIsExist(string path)
        {
            return File.Exists(path);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool FileIsReadOnly(string fullpath)
        {
            FileInfo info = new FileInfo(fullpath);
            return ((info.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] FileToBytes(string filePath)
        {
            byte[] buffer2;
            int fileSize = GetFileSize(filePath);
            byte[] buffer = new byte[fileSize];
            FileStream stream = new FileInfo(filePath).Open(FileMode.Open);
            try
            {
                stream.Read(buffer, 0, fileSize);
                buffer2 = buffer;
            }
            catch (IOException exception)
            {
                throw exception;
            }
            finally
            {
                stream.Close();
            }
            return buffer2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Stream FileToStream(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            return new MemoryStream(buffer);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string FileToString(string filePath)
        {
            return FileToString(filePath, Encoding.Default);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string FileToString(string filePath, Encoding encoding)
        {
            string str;
            try
            {
                using (StreamReader reader = new StreamReader(filePath, encoding))
                {
                    str = reader.ReadToEnd();
                }
            }
            catch (IOException exception)
            {
                throw exception;
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DriveInfo[] GetAllDrives()
        {
            return DriveInfo.GetDrives();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] GetDirectories(string directoryPath)
        {
            string[] directories;
            try
            {
                directories = Directory.GetDirectories(directoryPath);
            }
            catch (IOException exception)
            {
                throw exception;
            }
            return directories;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] GetDirectories(string directoryPath, string searchPattern, bool isSearchChild)
        {
            string[] strArray;
            try
            {
                if (isSearchChild)
                {
                    return Directory.GetDirectories(directoryPath, searchPattern, SearchOption.AllDirectories);
                }
                strArray = Directory.GetDirectories(directoryPath, searchPattern, SearchOption.TopDirectoryOnly);
            }
            catch (IOException exception)
            {
                throw exception;
            }
            return strArray;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Encoding GetEncoding(string filePath)
        {
            return GetEncoding(filePath, Encoding.Default);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Encoding GetEncoding(string filePath, Encoding defaultEncoding)
        {
            Encoding bigEndianUnicode = defaultEncoding;
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4))
            {
                if ((stream == null) || (stream.Length < 2L))
                {
                    return bigEndianUnicode;
                }
                long position = stream.Position;
                stream.Position = 0L;
                int[] numArray = new int[] { stream.ReadByte(), stream.ReadByte(), stream.ReadByte(), stream.ReadByte() };
                stream.Position = position;
                if ((numArray[0] == 0xfe) && (numArray[1] == 0xff))
                {
                    bigEndianUnicode = Encoding.BigEndianUnicode;
                }
                if ((numArray[0] == 0xff) && (numArray[1] == 0xfe))
                {
                    bigEndianUnicode = Encoding.Unicode;
                }
                if (((numArray[0] == 0xef) && (numArray[1] == 0xbb)) && (numArray[2] == 0xbf))
                {
                    bigEndianUnicode = Encoding.UTF8;
                }
            }
            return bigEndianUnicode;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetExtension(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            return info.Extension;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DateTime GetFileCreateTime(string fullpath)
        {
            FileInfo info = new FileInfo(fullpath);
            return info.CreationTime;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetFileName(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            return info.Name;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetFileName(string fullpath, bool removeExt)
        {
            FileInfo info = new FileInfo(fullpath);
            string name = info.Name;
            if (removeExt)
            {
                name = name.Remove(name.IndexOf('.'));
            }
            return name;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetFileNameNoExtension(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            return info.Name.Substring(0, info.Name.LastIndexOf('.'));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] GetFileNames(string directoryPath)
        {
            if (!IsExistDirectory(directoryPath))
            {
                throw new FileNotFoundException();
            }
            return Directory.GetFiles(directoryPath);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] GetFileNames(string directoryPath, string searchPattern, bool isSearchChild)
        {
            string[] strArray;
            if (!IsExistDirectory(directoryPath))
            {
                throw new FileNotFoundException();
            }
            try
            {
                if (isSearchChild)
                {
                    return Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);
                }
                strArray = Directory.GetFiles(directoryPath, searchPattern, SearchOption.TopDirectoryOnly);
            }
            catch (IOException exception)
            {
                throw exception;
            }
            return strArray;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetFileSize(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            return (int) info.Length;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double GetFileSizeKB(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            return ConvertHelper.ToDouble<double>(Convert.ToDouble(info.Length) / 1024.0, 1.0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double GetFileSizeMB(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            return ConvertHelper.ToDouble<double>((Convert.ToDouble(info.Length) / 1024.0) / 1024.0, 1.0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ulong GetFreeSpace(string driveName)
        {
            ulong availableFreeSpace = 0L;
            try
            {
                DriveInfo info = new DriveInfo(driveName);
                availableFreeSpace = (ulong) info.AvailableFreeSpace;
            }
            catch
            {
            }
            return availableFreeSpace;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static char[] GetInvalidPathChars()
        {
            return Path.GetInvalidPathChars();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DateTime GetLastWriteTime(string fullpath)
        {
            FileInfo info = new FileInfo(fullpath);
            return info.LastWriteTime;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetLineCount(string filePath)
        {
            return File.ReadAllLines(filePath).Length;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetRandomFileName()
        {
            return Path.GetRandomFileName();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetSpeicalFolder(Environment.SpecialFolder folderType)
        {
            return Environment.GetFolderPath(folderType);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetSystemDirectory()
        {
            return Environment.SystemDirectory;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTempPath()
        {
            return Path.GetTempPath();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsDiskSpaceEnough(string path, ulong requiredSpace)
        {
            ulong freeSpace = GetFreeSpace(Path.GetPathRoot(path));
            return (requiredSpace <= freeSpace);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsEmptyDirectory(string directoryPath)
        {
            bool flag;
            try
            {
                if (GetFileNames(directoryPath).Length > 0)
                {
                    return false;
                }
                if (GetDirectories(directoryPath).Length > 0)
                {
                    return false;
                }
                flag = true;
            }
            catch (IOException exception)
            {
                throw exception;
            }
            return flag;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsExistDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsExistFile(string filePath)
        {
            return File.Exists(filePath);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsWriteable(string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch
                {
                    return false;
                }
            }
            try
            {
                string str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x59b0) + Guid.NewGuid().ToString().Substring(0, 5);
                string str2 = Path.Combine(path, str);
                File.WriteAllLines(str2, new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x59c0) });
                File.Delete(str2);
            }
            catch
            {
                return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Move(string sourceFilePath, string descDirectoryPath)
        {
            string fileName = GetFileName(sourceFilePath);
            if (IsExistDirectory(descDirectoryPath))
            {
                if (IsExistFile(descDirectoryPath + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x59cc) + fileName))
                {
                    DeleteFile(descDirectoryPath + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x59d2) + fileName);
                }
                File.Move(sourceFilePath, descDirectoryPath + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x59d8) + fileName);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetCurrentDirectory(string path)
        {
            Directory.SetCurrentDirectory(path);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetFileReadonly(string fullpath, bool flag)
        {
            FileInfo info = new FileInfo(fullpath);
            if (flag)
            {
                info.Attributes |= FileAttributes.ReadOnly;
            }
            else
            {
                info.Attributes &= ~FileAttributes.ReadOnly;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] StreamToBytes(Stream stream)
        {
            byte[] buffer2;
            try
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
                buffer2 = buffer;
            }
            catch (IOException exception)
            {
                throw exception;
            }
            finally
            {
                stream.Close();
            }
            return buffer2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void StreamToFile(Stream stream, string fileName)
        {
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Seek(0L, SeekOrigin.Begin);
            FileStream output = new FileStream(fileName, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(output);
            writer.Write(buffer);
            writer.Close();
            output.Close();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteText(string filePath, string content)
        {
            File.WriteAllText(filePath, content, Encoding.Default);
        }
    }
}

