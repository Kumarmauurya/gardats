using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[CompilerGenerated]
internal sealed class Class46
{
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 122)]
	internal struct Struct1
	{
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 376)]
	internal struct Struct2
	{
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 298)]
	internal struct BNTaGYIWyNuK
	{
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 74)]
	internal struct FNKGEhoMURrk
	{
	}

	internal static readonly int int_0;

	internal static readonly long long_0;

	internal static readonly Struct1 BPNSwyExWbRG;

	internal static readonly long long_1;

	internal static readonly Struct2 PRoXEIZvVaOU;

	internal static readonly BNTaGYIWyNuK CNzmjoDwFFOD;

	internal static readonly FNKGEhoMURrk kVvEQjJuRRUr;

	internal static uint smethod_0(string string_0)
	{
		uint num = 0u;
		if (string_0 != null)
		{
			num = 2166136261u;
			for (int i = 0; i < string_0.Length; i++)
			{
				num = (string_0[i] ^ num) * 16777619;
			}
		}
		return num;
	}
}
