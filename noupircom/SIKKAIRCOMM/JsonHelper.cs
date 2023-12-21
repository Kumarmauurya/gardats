using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCommDLL
{
    internal class JsonHelper
    {
        public JsonHelper()
        {
        }

        /// <summary>
        /// Converts a NameValueCollection into a properly formated JSON string,
        /// </summary>
        /// <param name="nvc">
        /// Keys must be in form of "sourceOfFunds.provided.card.expiry.month" using "." to
        /// represent the levels of nesting of the JSON structure
        /// </param>
        /// <returns>
        /// JSON String
        /// </returns>
        public static String BuildJsonFromNVC(NameValueCollection nvc)
        {
            // create base dictorary for building request structure in
            Dictionary<string, object> dict = new Dictionary<string, object>();

            // repeat for each key/value pair in list
            foreach (string key in nvc)
            {
                // split key into unique field name parts
                String[] parts = key.Split('.');

                // how many parts in total
                int count = parts.Length;

                // at beginning reset dictionary working with to base dictionary
                Dictionary<string, object> curdict = dict;

                // work way down dictionary structure for each level
                for (int i = 0; i < count; i++)
                {
                    String part = parts[i];

                    if (i == (count - 1))
                    {
                        // if at end of section, just add part name and value
                        curdict.Add(part, nvc[key]);
                    }
                    else
                    {
                        // if new level doesnt already exist, create a new nested dictionary
                        if (!curdict.ContainsKey(part))
                            curdict.Add(part, new Dictionary<string, object>());

                        // use this dictionary on next pass
                        curdict = (Dictionary<string, object>)curdict[part];
                    }
                }
            }

            // return serialized JSON result
            return JsonConvert.SerializeObject(dict, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Converts a JSON string into a NameValueCollection representing the JSON structure
        /// </summary>
        /// <param name="json">
        /// JSON string to convert
        /// </param>
        /// NameValueCollection, key names represent the JSON nesting using "." delimeters
        /// "sourceOfFunds.provided.cardDetails.card.expiry.month"
        /// <returns></returns>
        public static NameValueCollection BuildNVCFromJson(string json)
        {
            Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            // start the recursive traverse using base dictionary
            return TraverseDictionary("", dict);
        }

        /// <summary>
        /// Process and recursively keep calling itself to process all levels of the JSON string
        /// </summary>
        /// <param name="path">
        /// String that keeps track of what to prefix each key with to maintain JSON nesting
        /// </param>
        /// <param name="dict">
        /// The dictionary level working with
        /// </param>
        /// <returns>
        /// NameValueCollection of all the nested JSON parameters
        /// </returns>
        private static NameValueCollection TraverseDictionary(String path, Dictionary<string, object> dict)
        {
            NameValueCollection nvc = new NameValueCollection();

            foreach (KeyValuePair<string, object> kvp in dict)
            {
                // is another dictionary so recursively call routine with nested dictionary with updated field name prefixes
                if (kvp.Value is Dictionary<string, object>)
                {
                    nvc.Add(TraverseDictionary(path + kvp.Key + ".", (Dictionary<string, object>)kvp.Value));
                }
                // just a kvp so add to collection
                else
                {
                    nvc.Add(path + kvp.Key, kvp.Value.ToString());
                }
            }

            // done with this level of nesting so just return the accumelated NVC
            return nvc;
        }

        public static string prettyPrint(string json)
        {
            return JObject.Parse(json).ToString(Newtonsoft.Json.Formatting.Indented);
        }

        //check if the json body contains error message
        public static Boolean isErrorMessage(string json)
        {
            JObject jObject = JObject.Parse(json);
            return (jObject["result"] != null) && ("ERROR" == jObject["result"].ToObject<String>());
        }
    }
}
