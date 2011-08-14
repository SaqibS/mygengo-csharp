namespace MyGengo
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;

    internal static class DictionaryExtensions
    {
        public static string ToJson(this IDictionary<string, object> dict)
        {
            return new JavaScriptSerializer().Serialize(dict);
        }
    }
}
