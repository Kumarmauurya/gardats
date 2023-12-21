using System;
using System.IO;

internal sealed class Class76
{
	public sealed class Class77
	{
		private Class79 class79_0 = new Class79(32769);

		private Class78 class78_0;

		private Class75 class75_0;

		private int int_0 = -1;

		private int int_1 = -1;

		private bool bool_0;

		private int int_2;

		private bool bool_1;

		private int int_3;

		private bool bool_2;

		public Class77(Stream stream_0)
		{
			class78_0 = new Class78(stream_0);
		}

		public int method_0(byte[] byte_0, int int_4, int int_5)
		{
			if (int_5 != 0 && !bool_1)
			{
				int num = 0;
				while (num < int_5)
				{
					while (int_0 < 0 && !bool_1)
					{
						bool_1 = !method_1();
					}
					if (bool_1)
					{
						break;
					}
					int num2 = method_2(byte_0, int_4 + num, int_5 - num);
					if (num2 > 0)
					{
						num += num2;
					}
					else
					{
						int_0 = -1;
					}
				}
				return num;
			}
			return 0;
		}

		private bool method_1()
		{
			if (bool_0)
			{
				return false;
			}
			bool_0 = class78_0.method_0(1) > 0;
			int_0 = class78_0.method_0(4);
			if (int_0 == 7)
			{
				class78_0.method_1();
				int_2 = class78_0.method_0(16) ^ 0x3352;
				class75_0 = null;
				bool_2 = true;
			}
			else if (int_0 == 3)
			{
				Struct5[] struct5_ = Class71.struct5_0;
				Struct5[] struct5_2 = Class71.struct5_1;
				int_2 = 0;
				class75_0 = Class71.class75_0;
				bool_2 = false;
			}
			else if (int_0 == 4)
			{
				method_6(class78_0, out var struct5_3, out var struct5_4);
				int_2 = 0;
				class75_0 = Class71.smethod_4(struct5_3, struct5_4);
				bool_2 = false;
			}
			return true;
		}

		private int method_2(byte[] byte_0, int int_4, int int_5)
		{
			int num = int_4;
			if (int_0 == 7)
			{
				if (int_2 > 0)
				{
					int num2 = Math.Min(int_5, int_2);
					class78_0.method_2(byte_0, int_4, num2);
					class79_0.method_1(byte_0, int_4, num2);
					int_2 -= num2;
					int_5 -= num2;
					int_4 += num2;
				}
			}
			else if (!bool_2)
			{
				if (int_3 > 0)
				{
					method_3(byte_0, ref int_4, ref int_5);
				}
				if (int_5 > 0)
				{
					do
					{
						int num3 = smethod_0(class78_0, class75_0.class74_0);
						bool_2 = num3 == 256;
						if (bool_2)
						{
							break;
						}
						if (num3 < 256)
						{
							byte_0[int_4++] = (byte)num3;
							class79_0.method_0((byte)num3);
							int_5--;
						}
						else if (num3 <= 285)
						{
							int num4 = smethod_1(class78_0, num3);
							int_1 = smethod_2(class78_0, class75_0.class74_1);
							int_3 = num4;
							method_3(byte_0, ref int_4, ref int_5);
						}
					}
					while (int_5 > 0);
				}
			}
			return int_4 - num;
		}

		private void method_3(byte[] byte_0, ref int int_4, ref int int_5)
		{
			int num = Math.Min(int_3, int_5);
			byte[] array = class79_0.method_2(int_1, Math.Min(num, int_1));
			int_5 -= num;
			int_3 -= num;
			while (num > array.Length)
			{
				Array.Copy(array, 0, byte_0, int_4, array.Length);
				int_4 += array.Length;
				num -= array.Length;
				class79_0.method_1(array, 0, array.Length);
			}
			Array.Copy(array, 0, byte_0, int_4, num);
			int_4 += num;
			class79_0.method_1(array, 0, num);
		}

		private static int smethod_0(Class78 class78_1, Class74 class74_0)
		{
			while (class74_0 != null && !class74_0.bool_0)
			{
				class74_0 = ((class78_1.method_0(1) > 0) ? class74_0.class74_1 : class74_0.class74_0);
			}
			return class74_0.ushort_0;
		}

		private static int smethod_1(Class78 class78_1, int int_4)
		{
			Class71.smethod_7(int_4, out var int_5, out var int_6);
			if (int_6 > 0)
			{
				return int_5 + class78_1.method_0(int_6);
			}
			return int_5;
		}

		private static int smethod_2(Class78 class78_1, Class74 class74_0)
		{
			int num = smethod_0(class78_1, class74_0);
			int num2 = Class71.int_3[num];
			int num3 = Class71.int_4[num];
			if (num3 > 0)
			{
				int num4 = class78_1.method_0(num3);
				return num2 + num4;
			}
			return num2;
		}

		private void method_6(Class78 class78_1, out Struct5[] struct5_0, out Struct5[] struct5_1)
		{
			int num = class78_1.method_0(5) + 257;
			int num2 = class78_1.method_0(5) + 1;
			int num3 = class78_1.method_0(4) + 4;
			int[] array = Class71.int_0;
			int[] array2 = new int[19];
			for (int i = 0; i < num3; i++)
			{
				array2[array[i]] = class78_1.method_0(3);
			}
			Class74 class74_ = Class71.smethod_5(Class71.smethod_2(array2));
			int[] array3 = smethod_3(class78_1, class74_, num + num2);
			struct5_0 = new Struct5[num];
			for (int j = 0; j < num; j++)
			{
				struct5_0[j].int_1 = array3[j];
			}
			Class71.smethod_3(struct5_0);
			struct5_1 = new Struct5[num2];
			for (int k = 0; k < num2; k++)
			{
				struct5_1[k].int_1 = array3[k + num];
			}
			Class71.smethod_3(struct5_1);
		}

		private static int[] smethod_3(Class78 class78_1, Class74 class74_0, int int_4)
		{
			int[] array = new int[int_4];
			for (int i = 0; i < int_4; i++)
			{
				int num = smethod_0(class78_1, class74_0);
				if (num < 16)
				{
					array[i] = num;
					continue;
				}
				switch (num)
				{
				case 16:
				{
					int num4 = class78_1.method_0(2) + 3;
					for (int j = 0; j < num4; j++)
					{
						array[i + j] = array[i - 1];
					}
					i += num4 - 1;
					break;
				}
				case 17:
				{
					int num3 = class78_1.method_0(3) + 3;
					i += num3 - 1;
					break;
				}
				case 18:
				{
					int num2 = class78_1.method_0(7) + 11;
					i += num2 - 1;
					break;
				}
				}
			}
			return array;
		}
	}

	private sealed class Class78
	{
		private uint uint_0;

		private int int_0;

		private int int_1;

		private Stream stream_0;

		internal long long_0;

		internal Class78(Stream stream_1)
		{
			stream_0 = stream_1;
		}

		internal int method_0(int int_2)
		{
			long_0 += int_2;
			for (int num = int_2 - (int_1 - int_0); num > 0; num -= 8)
			{
				uint_0 |= checked((uint)stream_0.ReadByte()) << int_1;
				int_1 += 8;
			}
			uint result = (uint_0 >> int_0) & (uint)((1 << int_2) - 1);
			int_0 += int_2;
			if (int_1 == int_0)
			{
				int_0 = 0;
				int_1 = 0;
				uint_0 = 0u;
				return (int)result;
			}
			if (int_0 >= 8)
			{
				uint_0 >>= int_0;
				int_1 -= int_0;
				int_0 = 0;
			}
			return (int)result;
		}

		internal void method_1()
		{
			if (int_1 != int_0)
			{
				long_0 += int_1 - int_0;
			}
			int_0 = 0;
			int_1 = 0;
			uint_0 = 0u;
		}

		internal void method_2(byte[] byte_0, int int_2, int int_3)
		{
			int num = stream_0.Read(byte_0, int_2, int_3);
			long_0 += (long)num << 3;
		}
	}

	private sealed class Class79
	{
		private byte[] byte_0;

		private int int_0;

		internal int int_1;

		internal long long_0;

		internal Class79(int int_2)
		{
			int_1 = int_2;
			byte_0 = new byte[int_2];
		}

		internal void method_0(byte byte_1)
		{
			byte[] array = byte_0;
			array[int_0++] = byte_1;
			if (int_0 >= int_1)
			{
				int_0 = 0;
			}
			long_0++;
		}

		internal void method_1(byte[] byte_1, int int_2, int int_3)
		{
			long_0 += int_3;
			if (int_3 >= int_1)
			{
				Array.Copy(byte_1, int_2, byte_0, 0, int_1);
				int_0 = 0;
			}
			else if (int_0 + int_3 > int_1)
			{
				int num = int_1 - int_0;
				int length = int_0 + int_3 - int_1;
				Array.Copy(byte_1, int_2, byte_0, int_0, num);
				Array.Copy(byte_1, int_2 + num, byte_0, 0, length);
				int_0 = length;
			}
			else
			{
				Array.Copy(byte_1, int_2, byte_0, int_0, int_3);
				int_0 += int_3;
				if (int_0 == int_1)
				{
					int_0 = 0;
				}
			}
		}

		internal byte[] method_2(int int_2, int int_3)
		{
			byte[] array = new byte[int_3];
			if (int_0 >= int_2)
			{
				Array.Copy(byte_0, int_0 - int_2, array, 0, int_3);
			}
			else
			{
				int num = int_2 - int_0;
				if (num < int_3)
				{
					Array.Copy(byte_0, int_1 - num, array, 0, num);
					Array.Copy(byte_0, 0, array, num, int_3 - num);
				}
				else
				{
					Array.Copy(byte_0, int_1 - num, array, 0, int_3);
				}
			}
			return array;
		}
	}

	public static void smethod_0(Stream stream_0, Stream stream_1)
	{
		byte[] array = new byte[81920];
		Class77 @class = new Class77(stream_0);
		while (true)
		{
			int num = @class.method_0(array, 0, array.Length);
			if (num <= 0)
			{
				break;
			}
			stream_1.Write(array, 0, num);
		}
	}
}
