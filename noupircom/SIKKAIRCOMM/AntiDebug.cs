using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Anti
{
    internal class AntiDebug
    {
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll", SetLastError = true)]
		private static extern int GetWindowTextLengthA(IntPtr HWND);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern int GetWindowTextA(IntPtr HWND, StringBuilder WindowText, int nMaxCount);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool IsDebuggerPresent();

		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		private static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

		private static bool isDebuggerPresent = false;
		public static bool GetForegroundWindowAntiDebug()
		{
			string[] array = new string[13]
			{
				"x32dbg", "x64dbg", "windbg", "ollydbg", "dnspy", "immunity debugger", "hyperdbg", "debug", "debugger", "cheat engine", "cheatengine", "ida", "http analyzer"
			};
			IntPtr foregroundWindow = GetForegroundWindow();
			int windowTextLengthA = GetWindowTextLengthA(foregroundWindow);
			if (windowTextLengthA != 0)
			{
				StringBuilder stringBuilder = new StringBuilder(windowTextLengthA + 1);
				GetWindowTextA(foregroundWindow, stringBuilder, windowTextLengthA + 1);
				string[] array2 = array;
				foreach (string value in array2)
				{
					if (stringBuilder.ToString().ToLower().Contains(value))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool DebuggerIsAttached()
		{
			return Debugger.IsAttached;
		}

		public static bool IsDebuggerPresentCheck()
		{
			if (IsDebuggerPresent())
			{
				return true;
			}
			return false;
		}

		public static bool CheckForBlacklistedNames()
		{
			string[] array = new string[11]
			{
				"Johnson", "Miller", "malware", "maltest", "CurrentUser", "Sandbox", "virus", "John Doe", "test user", "sand box", "WDAGUtilityAccount"
			};
			string text = Environment.UserName.ToLower();
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				if (text == text2.ToLower())
				{
					return true;
				}
			}
			return false;
		}

		public static void AntiDebugger()
		{
			while (true)
			{
				Process process = Process.GetCurrentProcess();
				CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);
				if (isDebuggerPresent)
				{
					Process.GetCurrentProcess().Kill();
				}
				if (Debugger.IsAttached || Debugger.IsLogging())
				{
					Environment.Exit(0);
				}
				Thread.Sleep(500);
			}
		}

		public static void CheckDGProcesses()
		{
			while (true)
			{
				Process[] processes = Process.GetProcesses();
				foreach (Process process in processes)
				{
					if(process.ProcessName.Contains("HTTPAnalyzerStdV7"))
                    {

                    }
					if (string.IsNullOrEmpty(process.MainWindowTitle))
					{
						continue;
					}
					if (DG.debuggertitles.Contains(process.MainWindowTitle.ToLower()))
					{
						Console.WriteLine("Exited due to {0}", process.MainWindowTitle.ToLower());
						Environment.Exit(1);
					}
					if (DG.debuggertitles2.Contains(process.MainWindowTitle.ToLower()))
					{
						Console.WriteLine("Exited due to {0}", process.MainWindowTitle.ToLower());
						Environment.Exit(1);
					}
					if (DG.debuggertitles.Contains(process.MainWindowTitle))
					{
						Console.WriteLine("Exited due to {0}", process.MainWindowTitle);
						Environment.Exit(1);
					}
					if (DG.debuggertitles2.Contains(process.MainWindowTitle))
					{
						Console.WriteLine("Exited due to {0}", process.MainWindowTitle);
						Environment.Exit(1);
					}
				}
				Thread.Sleep(1000);
			}
		}
	}
}
