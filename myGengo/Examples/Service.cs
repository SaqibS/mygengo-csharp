using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myGengo;
using myGengo.Http;
namespace myGengo.Examples
{
    class Service: Generic
    {
        public override void test()
        {
            printNice("service");
            Config config = Config.getInstance();
            SortedDictionary<string, object> param = new SortedDictionary<string, object>();
            param["ts"] = Config.timestamp();
            param["api_key"] = config["api_key"];
            param["api_sig"] = Crypto.sign(Utils.buildQuery(param), config["private_key"]);
            myGengo.Apis.Service service = (myGengo.Apis.Service)Api.factory("service");

            /**
             * translate/service/languages (GET)
             * Returns a list of supported languages and their language codes.
             */
            printNice("getLanguages");
            service.getLanguages("xml",param);
            printNice(service.getResponseBody());

            /**
             * translate/service/language_pairs (GET)
             * Returns supported translation language pairs, tiers, and credit
             * prices.
             */
            printNice("getLanguagePair");
            service.getLanguagePair("json", param);
            printNice(service.getResponseBody());
        }
    }
}
