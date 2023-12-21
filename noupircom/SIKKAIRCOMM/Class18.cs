using System.Collections.Generic;
using System.Linq;
using IRCommDLL;

internal class Class18
{
	internal Dictionary<string, int> dictionary_0 = new Dictionary<string, int>();

	internal Dictionary<string, int> dictionary_1 = new Dictionary<string, int>();

	internal Dictionary<string, string> dictionary_2 = new Dictionary<string, string>();

	internal Dictionary<string, Class6> dictionary_3 = new Dictionary<string, Class6>();

	internal string string_0 = "";

	public static int int_0;

	public static byte[] byte_0;

	public static byte[] byte_1;

	public static byte[] byte_2;

	public static byte[] byte_3;

	internal string method_0(ref string string_1, string string_2, bool bool_0, int int_1, string string_3)
	{
		try
		{
			int num = dictionary_0[string_2.ToUpper()];
			int num2 = dictionary_0[string_1.ToUpper()];
			if (int_1 == 2)
			{
				num = dictionary_0.Count - 1;
			}
			if (num - num2 <= 1)
			{
				if (num2 <= 0)
				{
					return string_2.ToUpper();
				}
				num2 = 0;
			}
			if (bool_0)
			{
				foreach (string item in dictionary_1.Keys.Reverse())
				{
					if (dictionary_1[item] < num)
					{
						return item;
					}
				}
			}
			if (string_3.ToUpper() == "GN")
			{
				num--;
				return dictionary_0.ElementAt(num).Key;
			}
			if (int_1 == 3 && num - num2 >= 9)
			{
				num -= 4;
			}
			else if (int_1 == 3 && num - num2 >= 8)
			{
				num -= 3;
			}
			if (int_1 == 2 && num - num2 >= 8)
			{
				num -= 3;
			}
			else if (int_1 == 2 && num - num2 >= 7)
			{
				num -= 2;
			}
			if ((int_1 == 1 || int_1 == 2) && num - num2 >= 4)
			{
				string key = dictionary_0.ElementAt(++num2).Key;
				if (dictionary_2[key] == dictionary_2[string_1])
				{
					string_1 = key;
				}
				else
				{
					num2 -= 2;
					if (num2 >= 0)
					{
						key = dictionary_0.ElementAt(num2).Key;
						if (dictionary_2[key] == dictionary_2[string_1])
						{
							string_1 = key;
						}
					}
				}
			}
			if (string_0.Length > 0)
			{
				string_1 = string_0;
			}
			num--;
			return dictionary_0.ElementAt(num).Key;
		}
		catch
		{
			return string_2;
		}
	}

	internal string method_1(ref string string_1, string string_2, bool bool_0, int int_1, string string_3)
	{
		try
		{
			int num = dictionary_0[string_2.ToUpper()];
			int num2 = dictionary_0[string_1.ToUpper()];
			if (int_1 == 2)
			{
				num = dictionary_0.Count - 1;
			}
			if (num - num2 <= 1)
			{
				if (num2 <= 0)
				{
					return string_2.ToUpper();
				}
				num2 = 0;
			}
			if (bool_0)
			{
				foreach (string item in dictionary_1.Keys.Reverse())
				{
					if (dictionary_1[item] < num)
					{
						return item;
					}
				}
			}
			if (string_3.ToUpper() == "GN")
			{
				num--;
				return dictionary_0.ElementAt(num).Key;
			}
			if (int_1 == 3 && num - num2 >= 9)
			{
				num -= 4;
			}
			else if (int_1 == 3 && num - num2 >= 8)
			{
				num -= 3;
			}
			if (int_1 == 2 && num - num2 >= 8)
			{
				num -= 3;
			}
			else if (int_1 == 2 && num - num2 >= 7)
			{
				num -= 2;
			}
			if ((int_1 == 1 || int_1 == 2) && num - num2 >= 4)
			{
				string key = dictionary_0.ElementAt(++num2).Key;
				if (dictionary_2[key] == dictionary_2[string_1])
				{
					string_1 = key;
				}
				else
				{
					num2 -= 2;
					if (num2 >= 0)
					{
						key = dictionary_0.ElementAt(num2).Key;
						if (dictionary_2[key] == dictionary_2[string_1])
						{
							string_1 = key;
						}
					}
				}
			}
			if (string_0.Length > 0)
			{
				string_1 = string_0;
			}
			num--;
			return dictionary_0.ElementAt(num).Key;
		}
		catch
		{
			return string_2;
		}
	}

	internal void method_2(string string_1)
	{
		try
		{
			int num = string_1.IndexOf("</partial-response>");
			int num2 = string_1.IndexOf("Day");
			int num3 = 0;
			dictionary_0.Clear();
			dictionary_1.Clear();
			dictionary_2.Clear();
			try
			{
				while (num2 > 0 && num2 < num)
				{
					num2 = string_1.IndexOf("<tr align", num2);
					if (num2 < 0)
					{
						break;
					}
					num2 = string_1.IndexOf("left", num2);
					num2 = string_1.IndexOf(">", num2) + 1;
					int length = string_1.IndexOf("<", num2) - num2;
					string key = string_1.Substring(num2, length).Trim().ToUpper();
					dictionary_0.Add(key, num3);
					num2 = string_1.IndexOf("</tr>", num2);
					num2 = string_1.LastIndexOf("rf-dt-c", num2);
					num2 = string_1.IndexOf(">", num2) + 1;
					length = string_1.IndexOf("<", num2) - num2;
					dictionary_2.Add(key, string_1.Substring(num2, length).Trim().ToUpper());
					num3++;
				}
			}
			catch
			{
			}
			num = string_1.IndexOf("</partial-response>");
			num2 = string_1.IndexOf("Day");
			num3 = 0;
			dictionary_3.Clear();
			while (num2 > 0 && num2 < num)
			{
				Class6 @class = new Class6();
				num2 = string_1.IndexOf("<tr align", num2);
				if (num2 <= 0)
				{
					break;
				}
				num2 = string_1.IndexOf(">", num2);
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf(">", num2) + 1;
				int length2 = string_1.IndexOf("<", num2) - num2;
				@class.int_0 = int.Parse(string_1.Substring(num2, length2).Trim().ToUpper());
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf(">", num2) + 1;
				length2 = string_1.IndexOf("<", num2) - num2;
				@class.string_0 = string_1.Substring(num2, length2).Trim().ToUpper();
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf(">", num2) + 1;
				length2 = string_1.IndexOf("<", num2) - num2;
				int.TryParse(string_1.Substring(num2, length2).Trim().ToUpper()
					.Replace(":00", ""), out @class.int_1);
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf(">", num2) + 1;
				length2 = string_1.IndexOf("<", num2) - num2;
				@class.int_2 = int.Parse(string_1.Substring(num2, length2).Trim().ToUpper());
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf(">", num2) + 1;
				length2 = string_1.IndexOf("<", num2) - num2;
				@class.int_3 = int.Parse(string_1.Substring(num2, length2).Trim().ToUpper());
				dictionary_3.Add(@class.string_0.ToUpper(), @class);
				num3++;
			}
		}
		catch
		{
		}
	}

	public void method_3(string string_1)
	{
		try
		{
			int num = string_1.IndexOf("</partial-response>");
			int num2 = string_1.IndexOf("Day");
			int num3 = 0;
			dictionary_0.Clear();
			dictionary_1.Clear();
			dictionary_2.Clear();
			try
			{
				while (num2 > 0 && num2 < num)
				{
					num2 = string_1.IndexOf("<tr align", num2);
					if (num2 < 0)
					{
						break;
					}
					num2 = string_1.IndexOf("left", num2);
					num2 = string_1.IndexOf(">", num2) + 1;
					int length = string_1.IndexOf("<", num2) - num2;
					string key = string_1.Substring(num2, length).Trim().ToUpper();
					dictionary_0.Add(key, num3);
					num2 = string_1.IndexOf("</tr>", num2);
					num2 = string_1.LastIndexOf("rf-dt-c", num2);
					num2 = string_1.IndexOf(">", num2) + 1;
					length = string_1.IndexOf("<", num2) - num2;
					dictionary_2.Add(key, string_1.Substring(num2, length).Trim().ToUpper());
					num3++;
				}
			}
			catch
			{
			}
			num = string_1.IndexOf("</partial-response>");
			num2 = string_1.IndexOf("Day");
			num3 = 0;
			dictionary_3.Clear();
			while (num2 > 0 && num2 < num)
			{
				Class6 @class = new Class6();
				num2 = string_1.IndexOf("<tr align", num2);
				if (num2 <= 0)
				{
					break;
				}
				num2 = string_1.IndexOf(">", num2);
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf(">", num2) + 1;
				int length2 = string_1.IndexOf("<", num2) - num2;
				@class.int_0 = int.Parse(string_1.Substring(num2, length2).Trim().ToUpper());
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf(">", num2) + 1;
				length2 = string_1.IndexOf("<", num2) - num2;
				@class.string_0 = string_1.Substring(num2, length2).Trim().ToUpper();
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf(">", num2) + 1;
				length2 = string_1.IndexOf("<", num2) - num2;
				int.TryParse(string_1.Substring(num2, length2).Trim().ToUpper()
					.Replace(":00", ""), out @class.int_1);
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf(">", num2) + 1;
				length2 = string_1.IndexOf("<", num2) - num2;
				@class.int_2 = int.Parse(string_1.Substring(num2, length2).Trim().ToUpper());
				num2 = string_1.IndexOf("rf-dt-c", num2) + 1;
				num2 = string_1.IndexOf(">", num2) + 1;
				length2 = string_1.IndexOf("<", num2) - num2;
				@class.int_3 = int.Parse(string_1.Substring(num2, length2).Trim().ToUpper());
				dictionary_3.Add(@class.string_0.ToUpper(), @class);
				num3++;
			}
		}
		catch
		{
		}
	}

	internal void method_4(string string_1, string string_2, int int_1, string string_3, ref string string_4, ref string string_5, bool bool_0)
	{
		byte[] array = new byte[258];
		array[79] = 241;
		string text = "cßÀ:ûKM9E\u0013\u0087Î";
		for (int i = 0; i < text.Length; i++)
		{
			array[i + 80] = (byte)text[i];
		}
		array[114] = 71;
		string text2 = "h\u0012Ê\u0005N#G\u008am\u00b85ù\u0004Ó\u0011ó";
		for (int j = 0; j < text2.Length; j++)
		{
			array[j + 116] = (byte)text2[j];
		}
		array[134] = 21;
		array[141] = 160;
		array[76] = 112;
		array[95] = 38;
		array[142] = 132;
		string text3 = string_1.ToUpper();
		array[96] = 155;
		array[97] = 7;
		string_4 = text3;
		array[78] = 134;
		array[98] = 74;
		string text4 = "\u0002[£ùÿÎ< \0\0\0";
		for (int k = 0; k < text4.Length; k++)
		{
			array[k + 100] = (byte)text4[k];
		}
		array[111] = 52;
		array[112] = 181;
		array[132] = 167;
		string text5 = "×~\u0092 Þ\u0086";
		for (int l = 0; l < text5.Length; l++)
		{
			array[l + 135] = (byte)text5[l];
		}
		array[92] = 14;
		array[93] = 154;
		array[94] = 124;
		array[77] = 183;
		array[113] = 150;
		array[115] = 170;
		string text6 = string_2.ToUpper();
		array[75] = 125;
		array[133] = 91;
		string_5 = text6;
		try
		{
			string text7 = "ó§[\u0015×~\u0092 Þ\u0086";
			for (int m = 0; m < text7.Length; m++)
			{
				array[m + 131] = (byte)text7[m];
			}
			array[141] = 160;
			array[142] = 132;
			array[99] = 49;
			GClass0.byte_1 = array;
			if (dictionary_3.Count <= 4)
			{
				return;
			}
			Class6 @class = dictionary_3[string_5.ToUpper()];
			Class6 class2 = dictionary_3[string_4.ToUpper()];
			int num = -1;
			int num2 = -1;
			for (int n = 0; n < dictionary_3.Count; n++)
			{
				Class6 value = dictionary_3.ElementAt(n).Value;
				if (value.int_3 == class2.int_3 && num == -1)
				{
					num = n;
				}
				if (value.int_3 != class2.int_3 + 1 || num2 != -1)
				{
					continue;
				}
				num2 = n - 1;
				if (num2 == -1)
				{
					num2 = dictionary_3.Count / 2;
				}
				int num3 = (bool_0 ? (num + (num2 - num) / 2) : ((dictionary_3.ElementAt(class2.int_0 + 1).Value.int_3 == class2.int_3) ? (class2.int_0 + 1) : ((dictionary_3.ElementAt(class2.int_0).Value.int_3 != class2.int_3) ? (class2.int_0 - 1) : class2.int_0)));
				int num4 = dictionary_3.Count - 1;
				if (num4 - num3 >= 2)
				{
					for (num4 = num3 + (num4 - num3) / 2; num4 < dictionary_3.Count && dictionary_3.ElementAt(num3).Value.int_2 + 70 > dictionary_3.ElementAt(num4).Value.int_2; num4++)
					{
					}
					if (num4 > num3)
					{
						string_4 = dictionary_3.ElementAt(num3).Value.string_0.ToUpper();
						string_5 = dictionary_3.ElementAt(num4).Value.string_0.ToUpper();
					}
				}
				break;
			}
		}
		catch
		{
		}
	}

	internal void method_5(string string_1, string string_2, int int_1, string string_3, ref string string_4, ref string string_5, bool bool_0)
	{
		string_4 = string_1.ToUpper();
		string_5 = string_2.ToUpper();
		try
		{
			if (dictionary_3.Count <= 4)
			{
				return;
			}
			Class6 @class = dictionary_3[string_5.ToUpper()];
			Class6 class2 = dictionary_3[string_4.ToUpper()];
			int num = -1;
			int num2 = -1;
			int num3 = 0;
			while (0 < dictionary_3.Count)
			{
				Class6 value = dictionary_3.ElementAt(num3).Value;
				if (value.int_3 == class2.int_3 && num == -1)
				{
					num = num3;
				}
				if (value.int_3 == class2.int_3 + 1 && num2 == -1)
				{
					num2 = num3 - 1;
					if (num2 == -1)
					{
						num2 = dictionary_3.Count / 2;
					}
					int num4 = (bool_0 ? (num + (num2 - num) / 2) : ((dictionary_3.ElementAt(class2.int_0 + 1).Value.int_3 == class2.int_3) ? (class2.int_0 + 1) : ((dictionary_3.ElementAt(class2.int_0).Value.int_3 != class2.int_3) ? (class2.int_0 - 1) : class2.int_0)));
					int num5 = dictionary_3.Count - 1;
					if (num5 - num4 >= 2)
					{
						for (num5 = num4 + (num5 - num4) / 2; num5 < dictionary_3.Count && dictionary_3.ElementAt(num4).Value.int_2 + 70 > dictionary_3.ElementAt(num5).Value.int_2; num5++)
						{
						}
						if (num5 > num4)
						{
							string_4 = dictionary_3.ElementAt(num4).Value.string_0.ToUpper();
							string_5 = dictionary_3.ElementAt(num5).Value.string_0.ToUpper();
						}
					}
					break;
				}
				num3++;
			}
		}
		catch
		{
		}
	}

	internal static int smethod_0(int int_1)
	{
		if (1 == 0)
		{
		}
		int result;
		switch (int_1)
		{
		case 112:
			result = -26;
			break;
		case 117:
			result = -32;
			break;
		case 119:
			result = -243;
			break;
		case 122:
			result = -27;
			break;
		case 126:
			result = -245;
			break;
		case 128:
			result = -254;
			break;
		default:
			result = -1;
			break;
		}
		if (1 == 0)
		{
		}
		return result;
	}
}
