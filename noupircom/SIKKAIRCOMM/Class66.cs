using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

internal class Class66
{
	private delegate int Delegate7(IntPtr intptr_0, int int_0, ref Struct3 struct3_0, int int_1, out int int_2);

	public struct Struct3
	{
		public IntPtr intptr_0;

		public IntPtr intptr_1;

		public IntPtr intptr_2;

		public IntPtr intptr_3;

		public IntPtr intptr_4;

		public IntPtr intptr_5;
	}

	private static readonly Delegate7 delegate7_0;

	private Process process_0;

	public bool Boolean_0
	{
		get
		{
			try
			{
				object type = Type.GetType("System.Diagnostics.Debugger");
				if (type != null)
				{
					try
					{
						if ((bool)((Type)type).InvokeMember("IsAttached", BindingFlags.GetProperty, null, null, null))
						{
							return true;
						}
					}
					catch
					{
					}
				}
				return method_1();
			}
			catch
			{
			}
			return false;
		}
	}

	static Class66()
	{
		try
		{
			delegate7_0 = (Delegate7)Class63.smethod_0<Delegate7>("ntdll.dll", "NtQueryInformationProcess");
		}
		catch
		{
		}
	}

	public Class66()
	{
		try
		{
			process_0 = Process.GetCurrentProcess();
		}
		catch
		{
		}
	}

	public void method_0()
	{
		if (process_0 != null)
		{
			process_0.Dispose();
		}
	}

	public bool method_1()
	{
		if (delegate7_0 == null || process_0 == null)
		{
			return false;
		}
		Struct3 struct3_ = default(Struct3);
		if (delegate7_0(process_0.Handle, 0, ref struct3_, Marshal.SizeOf(struct3_), out var _) != 0)
		{
			return false;
		}
		Process processById = Process.GetProcessById(struct3_.intptr_5.ToInt32());
		if (processById != null)
		{
			string processName = processById.ProcessName;
			StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;
			return processName.IndexOf("dnspy", StringComparison.OrdinalIgnoreCase) != -1 || processName.IndexOf("de4dot", comparisonType) != -1 || processName.IndexOf("vsdbg", comparisonType) != -1 || processName.IndexOf("debug", comparisonType) != -1;
		}
		return false;
	}
}
