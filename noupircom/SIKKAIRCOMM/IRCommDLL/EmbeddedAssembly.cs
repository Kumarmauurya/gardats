using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace IRCommDLL
{
	public class EmbeddedAssembly
	{
		private static Dictionary<string, Assembly> dictionary_0;

		public static void Assembly_Load()
		{
			Load("IRCommDLL.include.BhimAXIS.dll", "BhimAXIS.dll");
			AppDomain.CurrentDomain.AssemblyResolve += smethod_0;
		}

		private static Assembly smethod_0(object object_0, ResolveEventArgs resolveEventArgs_0)
		{
			return Get(resolveEventArgs_0.Name);
		}

		public static void Load(string embeddedResource, string fileName)
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<string, Assembly>();
			}
			byte[] array = null;
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedResource))
			{
				if (stream == null)
				{
					throw new Exception(embeddedResource + " is not found in Embedded Resources.");
				}
				array = new byte[(int)stream.Length];
				stream.Read(array, 0, (int)stream.Length);
				try
				{
					Assembly assembly = Assembly.Load(array);
					dictionary_0.Add(assembly.FullName, assembly);
					return;
				}
				catch
				{
				}
			}
			bool flag = false;
			string path = "";
			using (SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider())
			{
				string text = BitConverter.ToString(sHA1CryptoServiceProvider.ComputeHash(array)).Replace("-", string.Empty);
				path = Path.GetTempPath() + fileName;
				if (File.Exists(path))
				{
					byte[] buffer = File.ReadAllBytes(path);
					string text2 = BitConverter.ToString(sHA1CryptoServiceProvider.ComputeHash(buffer)).Replace("-", string.Empty);
					flag = text == text2;
				}
				else
				{
					flag = false;
				}
			}
			if (!flag)
			{
				File.WriteAllBytes(path, array);
			}
			Assembly assembly2 = Assembly.LoadFile(path);
			dictionary_0.Add(assembly2.FullName, assembly2);
		}

		public static Assembly Get(string assemblyFullName)
		{
			object obj = ((dictionary_0 == null || dictionary_0.Count == 0) ? null : ((!dictionary_0.ContainsKey(assemblyFullName)) ? null : dictionary_0[assemblyFullName]));
			return (Assembly)obj;
		}
	}
}
