using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace IRCommDLL
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Class8
	{
		private static ResourceManager resourceManager_0;

		private static CultureInfo cultureInfo_0;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager_0
		{
			get
			{
				if (resourceManager_0 == null)
				{
					resourceManager_0 = new ResourceManager("IRCommDLL.Class8", typeof(Class8).Assembly);
				}
				return resourceManager_0;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo CultureInfo_0
		{
			get
			{
				return cultureInfo_0;
			}
			set
			{
				cultureInfo_0 = value;
			}
		}

		internal static Bitmap Bitmap_0 => (Bitmap)ResourceManager_0.GetObject("25", cultureInfo_0);

		internal Class8()
		{
		}
	}
}
