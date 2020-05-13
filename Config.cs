using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lin.LogHelper
{
	/// <summary>
	/// 配置
	/// </summary>
	public static class Config
	{
		/// <summary>
		/// 
		/// </summary>
		public static void LogForDebugDisable()
		{
			var trace = new StackTrace();
			var thisclassname = trace.GetFrame(0).GetMethod().DeclaringType.Name;
			Type classtype = null;
			for (int i = 1; trace.GetFrame(i) != null; i++)
			{
				classtype = trace.GetFrame(i).GetMethod().DeclaringType;
				if (classtype.Name != thisclassname) break;
			}
			if (!Public_Var.DebugBlackLsit.Contains(classtype.AssemblyQualifiedName)) Public_Var.DebugBlackLsit.Add(classtype.AssemblyQualifiedName);
		}

        /// <summary>
		/// 
		/// </summary>
		public static void LogForInfomationDisable()
		{
			var trace = new StackTrace();
			var thisclassname = trace.GetFrame(0).GetMethod().DeclaringType.Name;
			Type classtype = null;
			for (int i = 1; trace.GetFrame(i) != null; i++)
			{
				classtype = trace.GetFrame(i).GetMethod().DeclaringType;
				if (classtype.Name != thisclassname) break;
			}
			if (!Public_Var.InfoBlackLsit.Contains(classtype.AssemblyQualifiedName)) Public_Var.InfoBlackLsit.Add(classtype.AssemblyQualifiedName);
		}
        
        /// <summary>
		/// 
		/// </summary>
		public static void LogForErrorDisable()
		{
			var trace = new StackTrace();
			var thisclassname = trace.GetFrame(0).GetMethod().DeclaringType.Name;
			Type classtype = null;
			for (int i = 1; trace.GetFrame(i) != null; i++)
			{
				classtype = trace.GetFrame(i).GetMethod().DeclaringType;
				if (classtype.Name != thisclassname) break;
			}
			if (!Public_Var.ErrorBlackLsit.Contains(classtype.AssemblyQualifiedName)) Public_Var.ErrorBlackLsit.Add(classtype.AssemblyQualifiedName);
		}

        /// <summary>
		/// 
		/// </summary>
		public static void LogForWarningDisable()
		{
			var trace = new StackTrace();
			var thisclassname = trace.GetFrame(0).GetMethod().DeclaringType.Name;
			Type classtype = null;
			for (int i = 1; trace.GetFrame(i) != null; i++)
			{
				classtype = trace.GetFrame(i).GetMethod().DeclaringType;
				if (classtype.Name != thisclassname) break;
			}
			if (!Public_Var.WarningBlackLsit.Contains(classtype.AssemblyQualifiedName)) Public_Var.WarningBlackLsit.Add(classtype.AssemblyQualifiedName);
		}
	}//End Class
}