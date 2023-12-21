using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Microsoft.VisualBasic;

internal class Class11
{
	public static string smethod_0(string string_0, string string_1)
	{
		string result = "";
		try
		{
			DataTable dataTable = new DataTable();
			new SQLiteDataAdapter("SELECT * FROM [TBL_USER] WHERE [UserName] = '" + string_0 + "'", clsMain.string_44).Fill(dataTable);
			if (dataTable != null)
			{
				if (dataTable.Rows.Count > 0)
				{
					foreach (object row in dataTable.Rows)
					{
						result = ((DataRow)row)[string_1].ToString();
					}
					return result;
				}
				return result;
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static void smethod_1(string string_0, string string_1, string string_2, string string_3)
	{
		smethod_4(string.Concat("UPDATE [TBL_USER] SET [" + string_1 + "] = '", string_2, "' WHERE [UserName] = '", string_3, "'"));
	}

	public static void smethod_2(string string_0, string string_1)
	{
		smethod_4("UPDATE [TBL_BANK] SET [BANK_DETAILS] = '" + string_0 + "' WHERE [BANK_SAVEAS] = '" + string_1 + "'");
	}

	public static void smethod_3(string string_0, string string_1)
	{
		smethod_4("DELETE from TBL_BANK where BANK_SAVEAS = '" + string_0 + "' AND BANK_ISDEBIT = " + string_1);
	}

	public static void smethod_4(string string_0)
	{
		try
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection(clsMain.string_44);
			sQLiteConnection.Open();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
			sQLiteCommand.CommandText = string_0;
			sQLiteCommand.ExecuteNonQuery();
			sQLiteConnection.Close();
			sQLiteCommand.Dispose();
		}
		catch
		{
		}
	}

	public static void smethod_5(string string_0, string string_1)
	{
		SQLiteConnection sQLiteConnection = new SQLiteConnection(clsMain.string_44);
		sQLiteConnection.Open();
		SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
		sQLiteCommand.CommandText = "UPDATE [TBL_USER] SET [UserState] = '" + string_0 + "||" + DateTime.Now.Date.ToString("dd/M/yyyy") + "' WHERE [UserName] = '" + string_1 + "'";
		sQLiteCommand.ExecuteNonQuery();
	}

	public static string smethod_6(string string_0)
	{
		string result = "";
		try
		{
			DataTable dataTable = new DataTable();
			new SQLiteDataAdapter("SELECT BANK_DETAILS FROM TBL_BANK WHERE BANK_SAVEAS = '" + string_0 + "'", clsMain.string_44).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				result = dataTable.Rows[0][0].ToString();
				dataTable.Dispose();
				return result;
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static Dictionary<string, string> smethod_7()
	{
		while (true)
		{
			try
			{
				DataTable dataTable = new DataTable();
				new SQLiteDataAdapter("SELECT BANK_SAVEAS, BANK_DETAILS FROM TBL_BANK", clsMain.string_44).Fill(dataTable);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					foreach (object row in dataTable.Rows)
					{
						DataRow dataRow = (DataRow)row;
						dictionary.Add(dataRow["BANK_SAVEAS"].ToString(), dataRow["BANK_DETAILS"].ToString());
					}
				}
				return dictionary;
			}
			catch
			{
			}
		}
	}

	public static string smethod_8(string string_0, string string_1)
	{
		string text = "";
		string[] array = Strings.Split(string_1, "#");
		try
		{
			DataTable dataTable = new DataTable();
			new SQLiteDataAdapter(string_0, clsMain.string_44).Fill(dataTable);
			if (dataTable != null)
			{
				if (dataTable.Rows.Count > 0)
				{
					foreach (object row in dataTable.Rows)
					{
						DataRow dataRow = (DataRow)row;
						for (int i = 0; i < array.Length; i++)
						{
							if (i != 0)
							{
								text += "$";
							}
							text += dataRow[array[i]].ToString();
						}
					}
					return text;
				}
				return text;
			}
			return text;
		}
		catch
		{
			return text;
		}
	}
}
