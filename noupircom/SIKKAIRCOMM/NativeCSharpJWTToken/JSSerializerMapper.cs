using System.Web.Script.Serialization;

namespace NativeCSharpJWTToken
{
	public class JSSerializerMapper
	{
		private static JavaScriptSerializer js;

		private static JavaScriptSerializer JS
		{
			get
			{
				JavaScriptSerializer result;
				if ((result = js) == null)
				{
					result = (js = new JavaScriptSerializer());
				}
				return result;
			}
		}

		public static string Serialize(object obj)
		{
			return JS.Serialize(obj);
		}

		public static T Parse<T>(string json)
		{
			return JS.Deserialize<T>(json);
		}
	}
}
