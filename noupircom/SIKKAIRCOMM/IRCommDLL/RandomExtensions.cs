using System;

namespace IRCommDLL
{
	public static class RandomExtensions
	{
		public static ulong NextULong(this Random rng)
		{
			byte[] array = new byte[8];
			rng.NextBytes(array);
			return BitConverter.ToUInt64(array, 0);
		}

		public static ulong NextULong(this Random rng, ulong max, bool inclusiveUpperBound = false)
		{
			return rng.NextULong(0uL, max, inclusiveUpperBound);
		}

		public static ulong NextULong(this Random rng, ulong min, ulong max, bool inclusiveUpperBound = false)
		{
			ulong num = max - min;
			if (inclusiveUpperBound)
			{
				if (num == ulong.MaxValue)
				{
					return rng.NextULong();
				}
				num++;
			}
			if (num == 0)
			{
				throw new ArgumentOutOfRangeException("Max must be greater than min when inclusiveUpperBound is false, and greater than or equal to when true", "max");
			}
			ulong num2 = ulong.MaxValue - ulong.MaxValue % num;
			ulong num3;
			do
			{
				num3 = rng.NextULong();
			}
			while (num3 > num2);
			return num3 % num + min;
		}

		public static long NextLong(this Random rng)
		{
			byte[] array = new byte[8];
			rng.NextBytes(array);
			return BitConverter.ToInt64(array, 0);
		}

		public static long NextLong(this Random rng, long max, bool inclusiveUpperBound = false)
		{
			return rng.NextLong(long.MinValue, max, inclusiveUpperBound);
		}

		public static long NextLong(this Random rng, long min, long max, bool inclusiveUpperBound = false)
		{
			ulong num = (ulong)(max - min);
			if (inclusiveUpperBound)
			{
				if (num == ulong.MaxValue)
				{
					return rng.NextLong();
				}
				num++;
			}
			if (num == 0)
			{
				throw new ArgumentOutOfRangeException("Max must be greater than min when inclusiveUpperBound is false, and greater than or equal to when true", "max");
			}
			ulong num2 = ulong.MaxValue - ulong.MaxValue % num;
			ulong num3;
			do
			{
				num3 = rng.NextULong();
			}
			while (num3 > num2);
			return (long)(num3 % num) + min;
		}
	}
}
