using System;

namespace NativeCSharpJWTToken
{
	internal class JavaUUID
	{
		public struct Uuid : IEquatable<Uuid>
		{
			private readonly long leastSignificantBits;

			private readonly long mostSignificantBits;

			public long LeastSignificantBits => leastSignificantBits;

			public long MostSignificantBits => mostSignificantBits;

			public Uuid(long mostSignificantBits, long leastSignificantBits)
			{
				this.mostSignificantBits = mostSignificantBits;
				this.leastSignificantBits = leastSignificantBits;
			}

			public override bool Equals(object obj)
			{
				if (obj == null || !(obj is Uuid))
				{
					return false;
				}
				Uuid uuid = (Uuid)obj;
				return Equals(uuid);
			}

			public bool Equals(Uuid uuid)
			{
				return mostSignificantBits == uuid.mostSignificantBits && leastSignificantBits == uuid.leastSignificantBits;
			}

			public override int GetHashCode()
			{
				return ((Guid)this).GetHashCode();
			}

			public override string ToString()
			{
				return ((Guid)this).ToString();
			}

			public static bool operator ==(Uuid a, Uuid b)
			{
				return a.Equals(b);
			}

			public static bool operator !=(Uuid a, Uuid b)
			{
				return !a.Equals(b);
			}

			public static explicit operator Guid(Uuid uuid)
			{
				if (uuid == default(Uuid))
				{
					return default(Guid);
				}
				byte[] bytes = BitConverter.GetBytes(uuid.mostSignificantBits);
				byte[] bytes2 = BitConverter.GetBytes(uuid.leastSignificantBits);
				byte[] b = new byte[16]
				{
					bytes[4],
					bytes[5],
					bytes[6],
					bytes[7],
					bytes[2],
					bytes[3],
					bytes[0],
					bytes[1],
					bytes2[7],
					bytes2[6],
					bytes2[5],
					bytes2[4],
					bytes2[3],
					bytes2[2],
					bytes2[1],
					bytes2[0]
				};
				return new Guid(b);
			}

			public static implicit operator Uuid(Guid value)
			{
				if (value == default(Guid))
				{
					return default(Uuid);
				}
				byte[] array = value.ToByteArray();
				byte[] value2 = new byte[16]
				{
					array[6],
					array[7],
					array[4],
					array[5],
					array[0],
					array[1],
					array[2],
					array[3],
					array[15],
					array[14],
					array[13],
					array[12],
					array[11],
					array[10],
					array[9],
					array[8]
				};
				return new Uuid(BitConverter.ToInt64(value2, 0), BitConverter.ToInt64(value2, 8));
			}

			public static Uuid FromString(string input)
			{
				return Guid.Parse(input);
			}
		}
	}
}
