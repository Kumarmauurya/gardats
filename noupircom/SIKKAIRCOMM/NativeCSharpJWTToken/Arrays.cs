using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace NativeCSharpJWTToken
{
	public class Arrays
	{
		public static readonly byte[] Empty = new byte[0];

		public static readonly byte[] Zero = new byte[1];

		private static RandomNumberGenerator rng;

		internal static RandomNumberGenerator RNG
		{
			get
			{
				RandomNumberGenerator result;
				if ((result = rng) == null)
				{
					result = (rng = RandomNumberGenerator.Create());
				}
				return result;
			}
		}

		public static byte[] FirstHalf(byte[] arr)
		{
			int num = arr.Length / 2;
			byte[] array = new byte[num];
			Buffer.BlockCopy(arr, 0, array, 0, num);
			return array;
		}

		public static byte[] SecondHalf(byte[] arr)
		{
			int num = arr.Length / 2;
			byte[] array = new byte[num];
			Buffer.BlockCopy(arr, num, array, 0, num);
			return array;
		}

		public static byte[] Concat(params byte[][] arrays)
		{
			byte[] array = new byte[arrays.Sum((byte[] a) => (a != null) ? a.Length : 0)];
			int num = 0;
			foreach (byte[] array2 in arrays)
			{
				if (array2 != null)
				{
					Buffer.BlockCopy(array2, 0, array, num, array2.Length);
					num += array2.Length;
				}
			}
			return array;
		}

		public static byte[][] Slice(byte[] array, int count)
		{
			int num = array.Length / count;
			byte[][] array2 = new byte[num][];
			for (int i = 0; i < num; i++)
			{
				byte[] array3 = new byte[count];
				Buffer.BlockCopy(array, i * count, array3, 0, count);
				array2[i] = array3;
			}
			return array2;
		}

		public static byte[] Xor(byte[] left, long right)
		{
			long num = BytesToLong(left);
			return LongToBytes(num ^ right);
		}

		public static byte[] Xor(byte[] left, byte[] right)
		{
			byte[] array = new byte[left.Length];
			for (int i = 0; i < left.Length; i++)
			{
				array[i] = (byte)(left[i] ^ right[i]);
			}
			return array;
		}

		public static bool ConstantTimeEquals(byte[] expected, byte[] actual)
		{
			if (expected == actual)
			{
				return true;
			}
			if (expected == null || actual == null)
			{
				return false;
			}
			if (expected.Length != actual.Length)
			{
				return false;
			}
			byte b = 0;
			for (int i = 0; i < expected.Length; i++)
			{
				b = (byte)(b | (byte)(expected[i] ^ actual[i]));
			}
			return b == 0;
		}

		public static string Dump(byte[] arr, string label = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Format("{0}({1} bytes): [", label + " ", arr.Length).Trim());
			foreach (byte value in arr)
			{
				stringBuilder.Append(value);
				stringBuilder.Append(",");
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			stringBuilder.Append("] Hex:[").Append(BitConverter.ToString(arr).Replace("-", " "));
			stringBuilder.Append("] Base64Url:").Append(Base64Url.Encode(arr)).Append("\n");
			return stringBuilder.ToString();
		}

		public static byte[] Random(int sizeBits = 128)
		{
			byte[] array = new byte[sizeBits / 8];
			RNG.GetBytes(array);
			return array;
		}

		public static byte[] IntToBytes(int value)
		{
			if (!BitConverter.IsLittleEndian)
			{
				return new byte[4]
				{
					(byte)((uint)value & 0xFFu),
					(byte)(((uint)value >> 8) & 0xFFu),
					(byte)(((uint)value >> 16) & 0xFFu),
					(byte)(((uint)value >> 24) & 0xFFu)
				};
			}
			return new byte[4]
			{
				(byte)(((uint)value >> 24) & 0xFFu),
				(byte)(((uint)value >> 16) & 0xFFu),
				(byte)(((uint)value >> 8) & 0xFFu),
				(byte)((uint)value & 0xFFu)
			};
		}

		public static byte[] LongToBytes(long value)
		{
			if (!BitConverter.IsLittleEndian)
			{
				return new byte[8]
				{
					(byte)(value & 0xFF),
					(byte)(((ulong)value >> 8) & 0xFF),
					(byte)(((ulong)value >> 16) & 0xFF),
					(byte)(((ulong)value >> 24) & 0xFF),
					(byte)(((ulong)value >> 32) & 0xFF),
					(byte)(((ulong)value >> 40) & 0xFF),
					(byte)(((ulong)value >> 48) & 0xFF),
					(byte)(((ulong)value >> 56) & 0xFF)
				};
			}
			return new byte[8]
			{
				(byte)(((ulong)value >> 56) & 0xFF),
				(byte)(((ulong)value >> 48) & 0xFF),
				(byte)(((ulong)value >> 40) & 0xFF),
				(byte)(((ulong)value >> 32) & 0xFF),
				(byte)(((ulong)value >> 24) & 0xFF),
				(byte)(((ulong)value >> 16) & 0xFF),
				(byte)(((ulong)value >> 8) & 0xFF),
				(byte)(value & 0xFF)
			};
		}

		public static long BytesToLong(byte[] array)
		{
			long num = (BitConverter.IsLittleEndian ? ((long)((array[0] << 24) | (array[1] << 16) | (array[2] << 8) | array[3]) << 32) : ((long)((array[7] << 24) | (array[6] << 16) | (array[5] << 8) | array[4]) << 32));
			long num2 = (BitConverter.IsLittleEndian ? (((array[4] << 24) | (array[5] << 16) | (array[6] << 8) | array[7]) & 0xFFFFFFFFu) : (((array[3] << 24) | (array[2] << 16) | (array[1] << 8) | array[0]) & 0xFFFFFFFFu));
			return num | num2;
		}

		public static byte[] LeftmostBits(byte[] data, int lengthBits)
		{
			int num = lengthBits / 8;
			byte[] array = new byte[num];
			Buffer.BlockCopy(data, 0, array, 0, num);
			return array;
		}

		public static byte[] RightmostBits(byte[] data, int lengthBits)
		{
			int num = lengthBits / 8;
			byte[] array = new byte[num];
			Buffer.BlockCopy(data, data.Length - num, array, 0, num);
			return array;
		}
	}
}
