using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lin.LogHelper
{
	/// <summary>
	/// 配置
	/// </summary>
	internal class Public_Var
	{
		/// <summary>
		/// Debug黑名单
		/// </summary>
		/// <returns></returns>
		internal static HashSet<string> DebugBlackLsit = new HashSet<string>();
		/// <summary>
		/// Info黑名单
		/// </summary>
		/// <returns></returns>
		internal static HashSet<string> InfoBlackLsit = new HashSet<string>();
		/// <summary>
		/// Error黑名单
		/// </summary>
		/// <returns></returns>
		internal static HashSet<string> ErrorBlackLsit = new HashSet<string>();
		
		/// <summary>
		/// Warning黑名单
		/// </summary>
		/// <returns></returns>
		internal static HashSet<string> WarningBlackLsit = new HashSet<string>();
	}
}