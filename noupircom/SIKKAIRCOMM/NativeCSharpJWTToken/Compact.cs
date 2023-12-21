using System.Text;

namespace NativeCSharpJWTToken
{
	public class Compact
	{
		public static string Serialize(params byte[][] parts)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte[] input in parts)
			{
				stringBuilder.Append(Base64Url.Encode(input)).Append(".");
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			return stringBuilder.ToString();
		}

		public static byte[][] Parse(string token)
		{
			string[] array = token.Split('.');
			byte[][] array2 = new byte[array.Length][];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = Base64Url.Decode(array[i]);
			}
			return array2;
		}
	}
}
