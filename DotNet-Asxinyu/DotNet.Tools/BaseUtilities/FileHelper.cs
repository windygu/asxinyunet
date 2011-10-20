using System;
using System.Collections ;
using System.IO ;
using System.Text;
using System.Web ;
using System.Web.UI.WebControls;

namespace DotNet.Tools
{
	/// <summary>
	/// 文件操作常见类库
	/// </summary>
	public class FileHelper
	{
		#region  ArrayList GetAllFilesByFolder 获取指定文件夹下所有的文件名称
		/// <summary>
		/// 获取指定文件夹下所有的文件名称
		/// </summary>
		/// <param name="folderName">指定文件夹名称,绝对路径</param>
		/// <param name="fileFilter">文件类型过滤,根据文件后缀名,如:*,*.txt,*.xls</param>
		/// <param name="isContainSubFolder">是否包含子文件夹</param>
		/// <returns>ArrayList数组,为所有需要的文件路径名称</returns>
		public static ArrayList GetAllFilesByFolder(string folderName, string fileFilter,bool isContainSubFolder)
		{
			ArrayList resArray = new ArrayList ();
			string[] files = Directory.GetFiles(folderName, fileFilter);
			for (int i = 0; i < files.Length ; i++)
			{
				resArray.Add(files[i]);
			}
			if (isContainSubFolder)
			{
				string[] folders = Directory.GetDirectories(folderName);
				for (int j = 0; j < folders.Length; j++)
				{
					//遍历所有文件夹
					ArrayList temp = GetAllFilesByFolder(folders[j], fileFilter, isContainSubFolder);
					resArray.AddRange(temp);
				}
			}
			return resArray;
		}
		/// <summary>
		/// 获取指定文件夹下所有的文件名称,不过滤文件类型
		/// </summary>
		/// <param name="folderName">指定文件夹名称,绝对路径</param>
		/// <param name="isContainSubFolder">是否包含子文件夹</param>
		/// <returns>ArrayList数组,为所有需要的文件路径名称</returns>
		public static ArrayList GetAllFilesByFolder(string folderName, bool isContainSubFolder)
		{
			return GetAllFilesByFolder(folderName, "*", isContainSubFolder);
		}
		#endregion
		
		#region 文件存在性
		/// <summary>
		/// 文件存在性
		/// </summary>
		/// <returns></returns>
		public bool FileExist(string filefullname)
		{
			string filepath = filefullname.Substring(0, filefullname.LastIndexOf("/") + 1);
			string filename = filefullname.Remove(0, filepath.Length);
			string Fileparentpath = Convertor.WebPathTran(filepath);
			return File.Exists(Fileparentpath + filename);
		}
		#endregion

		#region 获取文件名称
		/// <summary>
		/// 获取文件名称
		/// </summary>
		public static string GetFileName(string webfilename)
		{
			try
			{
				int lastslash = webfilename.LastIndexOf('/');
				string filename = webfilename.Substring(lastslash + 1);
				return filename;
			}
			catch
			{
				return "";
			}
		}
		#endregion

		#region 上传文件（默认文件名）
		/// <summary>
		/// 上传文件（默认文件名）
		/// </summary>
		/// <param name="fileUploadControl">上传控件ID</param>
		/// <param name="SavePath">指定目录</param>
		/// <param name="IsTimeName">启用时间重命名</param>
		/// <returns></returns>
		public bool UploadFile(FileUpload fileUploadControl, string SavePath, bool IsTimeName)
		{
			string filename = fileUploadControl.FileName;
			if (IsTimeName)
			{
				//时间+扩展名
				filename = DateTime.Now.Ticks.ToString() + filename.Substring(filename.LastIndexOf("."));
			}
			try
			{

				string FileInServerName = Convertor.WebPathTran(SavePath) + filename;
				fileUploadControl.SaveAs(FileInServerName);
				return true;
			}
			catch (Exception ex)
			{
				return false;
				throw ex;
			}
		}
		#endregion
		
		#region 文件下载
		/// <summary>
		/// 文件下载
		/// </summary>
		/// <param name="parentpath">所在目录</param>
		/// <param name="filename">文件名</param>
		/// <returns></returns>
		public static void DownLoadFile(string parentpath, string filename, HttpContext httpcontext)
		{
			string Filepath = Convertor.WebPathTran(parentpath);
			HttpResponse response = httpcontext.Response;
			HttpRequest request = httpcontext.Request;
			if (File.Exists(Filepath + filename))
			{

				response.ContentType = "application/octet-stream";
				response.AddHeader("Content-Disposition", "attachment;filename=" + httpcontext.Server.UrlEncode(filename));
				response.WriteFile(Filepath + filename);
			}
			else
			{
				response.Redirect(request.ServerVariables["HTTP_REFERER"]);
			}

		}
		#endregion
		
		#region 小文件下载
		/// <summary>
		///  小文件下载
		/// </summary>
		/// <param name="filefullname">完整文件名</param>
		public static void DownLoadSmallFile(string filefullname, HttpContext httpcontext)
		{
			HttpResponse response = httpcontext.Response;
			HttpRequest request = httpcontext.Request;
			string filepath = filefullname.Substring(0, filefullname.LastIndexOf("/") + 1);
			string filename = filefullname.Remove(0, filepath.Length);
			string Fileparentpath = Convertor.WebPathTran(filepath);
			if (File.Exists(Fileparentpath + filename))
			{
				response.ContentType = "application/octet-stream";
				response.AddHeader("Content-Disposition", "attachment;filename=" + httpcontext.Server.UrlEncode(filename));
				response.TransmitFile(Fileparentpath + filename);
			}
			else
			{
				response.Redirect(request.ServerVariables["HTTP_REFERER"]);
			}
		}
		#endregion

		#region 备份文件
		/// <summary>
		/// 备份文件
		/// </summary>
		/// <param name="sourceFileName">源文件名</param>
		/// <param name="destFileName">目标文件名</param>
		/// <param name="overwrite">当目标文件存在时是否覆盖</param>
		/// <returns>操作是否成功</returns>
		public static bool BackupFile(string sourceFileName, string destFileName, bool overwrite)
		{
			if (!System.IO.File.Exists(sourceFileName))
			{
				throw new FileNotFoundException(sourceFileName + "文件不存在！");
			}
			if (!overwrite && System.IO.File.Exists(destFileName))
			{
				return false;
			}
			try
			{
				System.IO.File.Copy(sourceFileName, destFileName, true);
				return true;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		/// <summary>
		/// 备份文件,当目标文件存在时覆盖
		/// </summary>
		/// <param name="sourceFileName">源文件名</param>
		/// <param name="destFileName">目标文件名</param>
		/// <returns>操作是否成功</returns>
		public static bool BackupFile(string sourceFileName, string destFileName)
		{
			return BackupFile(sourceFileName, destFileName, true);
		}
		
		/// <summary>
		/// 恢复文件
		/// </summary>
		/// <param name="backupFileName">备份文件名</param>
		/// <param name="targetFileName">要恢复的文件名</param>
		/// <param name="backupTargetFileName">要恢复文件再次备份的名称,如果为null,则不再备份恢复文件</param>
		/// <returns>操作是否成功</returns>
		public static bool RestoreFile(string backupFileName, string targetFileName, string backupTargetFileName)
		{
			try
			{
				if (!System.IO.File.Exists(backupFileName))
				{
					throw new FileNotFoundException(backupFileName + "文件不存在！");
				}
				if (backupTargetFileName != null)
				{
					if (!System.IO.File.Exists(targetFileName))
					{
						throw new FileNotFoundException(targetFileName + "文件不存在！无法备份此文件！");
					}
					else
					{
						System.IO.File.Copy(targetFileName, backupTargetFileName, true);
					}
				}
				System.IO.File.Delete(targetFileName);
				System.IO.File.Copy(backupFileName, targetFileName);
			}
			catch (Exception e)
			{
				throw e;
			}
			return true;
		}
		
		public static bool RestoreFile(string backupFileName, string targetFileName)
		{
			return RestoreFile(backupFileName, targetFileName, null);
		}

		#endregion

		#region 文件删除
		/// <summary>
		/// 文件删除
		/// </summary>
		/// <param name="parentPath">所在父级目录</param>
		/// <param name="filename">文件名</param>
		/// <returns></returns>
		public static bool DeleteFile(string parentPath, string filename)
		{
			try
			{
				string filefullname = Convertor.WebPathTran(parentPath) + filename;
				File.Delete(filefullname);
				return true;
			}
			catch
			{

				return false;
			}
		}
		
		/// <summary>
		/// 文件删除
		/// </summary>
		/// <param name="FileFullName">物理路径文件名</param>
		/// <returns></returns>
		public static bool DeleteFile(string FileFullName)
		{
			FileInfo fi = new FileInfo(FileFullName);
			if (fi.Exists)
			{
				try
				{
					fi.Delete();
					return true;

				}
				catch
				{
					return false;
				}
			}
			return true;
		}
		#endregion
				
		#region 目录基本操作
		/// <summary>
		/// 创建目录
		/// </summary>
		/// <param name="parentPath">父级目录名</param>
		/// <param name="DirName">目录名</param>
		/// <returns></returns>
		public bool CreateDir(string parentPath, string DirName)
		{
			try
			{
				Directory.CreateDirectory(Convertor.WebPathTran(parentPath) + DirName);
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}
		#endregion

		#region 删除目录（包括子文件及文件夹）
		/// <summary>
		/// 删除目录（包括子文件及文件夹）
		/// </summary>
		/// <param name="parentPath">父级目录</param>
		/// <param name="DirName">文件夹名</param>
		public bool DeleteDir(string parentPath, string DirName)
		{
			try
			{
				Directory.Delete(Convertor.WebPathTran(parentPath) + DirName, true);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		///  删除目录（包括子文件及子文件夹）
		/// </summary>
		/// <param name="Dirfullname">删除目录的路径（完整名称）</param>
		/// <returns></returns>
		public bool DeleteDir(string Dirfullname)
		{
			try
			{
				Directory.Delete(Dirfullname, true);
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}
		#endregion

	}
}
