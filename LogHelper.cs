using System;
using System.Diagnostics;
using System.IO;

namespace Lin.LogHelper
{
	/// <summary>
	/// 
	/// </summary>
	public static class LogHelper
	{
		#region 一些算法

		/// <summary>
		/// 字节数组转16进制字符串
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>	 
		private static string ToHexString(byte[] bytes)
		{
			string str = "";
			if (bytes == null) return null;
			for (int i = 0; i < bytes.Length; i++) str += bytes[i].ToString("X2");
			return str;
		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private static object LOCKER = new object();

		#region string
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <param name="cls"></param>
		public static void Log(this string str, string cls)
		{
			var trace = new StackTrace();
			var thisclassname = trace.GetFrame(0).GetMethod().DeclaringType.Name;
			Type classtype = null;
			for (int i = 1; trace.GetFrame(i) != null; i++)
			{
				classtype = trace.GetFrame(i).GetMethod().DeclaringType;
				if (classtype.Name != thisclassname) break;
			}
			var classname = classtype == null ? thisclassname : classtype.Name;

			if (cls == "Debug" && Public_Var.DebugBlackLsit.Contains(classtype.AssemblyQualifiedName)) return;
			if (cls == "Info" && Public_Var.InfoBlackLsit.Contains(classtype.AssemblyQualifiedName)) return;
			if (cls == "Error" && Public_Var.ErrorBlackLsit.Contains(classtype.AssemblyQualifiedName)) return;
			if (cls == "Warning" && Public_Var.WarningBlackLsit.Contains(classtype.AssemblyQualifiedName)) return;

			var path = $"./Logs/{DateTime.Now.ToString("yyyy-MM-dd")}/";
			lock (LOCKER)
			{
				Directory.CreateDirectory(path);
				File.AppendAllText($"{path}{classname}.log", $"{DateTime.Now.ToString("HH:mm:ss.fff")} {cls} > {str}{Environment.NewLine}");
			}
			//Console.WriteLine($"[{path}][{cls}]{str}");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		public static void LogForInfomation(this string str) => str.Log("Info");

		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		public static void LogForDebug(this string str) => str.Log("Debug");

		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		public static void LogForWarning(this string str) => str.Log("Warning");

		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		public static void LogForError(this string str) => str.Log("Error");
		#endregion

		#region Exception 这个类型只能保存为Error
		/// <summary>
		/// 
		/// </summary>
		/// <param name="err"></param>
		/// <param name="cls"></param>
		public static void Log(this Exception err, string cls)
		{
			($"{err.Message}\r\n{err.StackTrace}").Log(cls);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="err"></param>
		public static void LogForError(this Exception err) => err.Log("Error");
		#endregion

		#region byte[]
		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <param name="cls"></param>
		public static void Log(this byte[] data, string cls)
		{
			ToHexString(data).Log(cls);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		public static void LogForInfomation(this byte[] data) => data.Log("Info");

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		public static void LogForDebug(this byte[] data) => data.Log("Debug");

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		public static void LogForWarning(this byte[] data) => data.Log("Warning");

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		public static void LogForError(this byte[] data) => data.Log("Error");
		#endregion
	}//End Class
}