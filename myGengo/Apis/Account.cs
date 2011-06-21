/**
 * myGengo API Client
 *
 * LICENSE
 *
 * This source file is subject to the new BSD license that came
 * with this package in the file LICENSE.txt. It is also available 
 * through the world-wide-web at this URL:
 * http://mygengo.com/services/api/dev-docs/mygengo-code-license
 * If you did not receive a copy of the license and are unable to
 * obtain it through the world-wide-web, please send an email
 * to contact@mygengo.com so we can send you a copy immediately.
 *
 * @category   myGengo
 * @package    API Client Library
 * @copyright  Copyright (c) 2009-2010 myGengo, Inc. (http://mygengo.com)
 * @license    http://mygengo.com/services/api/dev-docs/mygengo-code-license New BSD License
 */

using System;
using System.Linq;
using System.Text;
using System.Collections;
namespace myGengo.Apis
{
    class Account : Api
    {
        public Account(string api_key, string private_key)
            : base(api_key,private_key)
        {

        }

        /**
         * account/balance (GET)
         * Retrieves account balance in credits
         *
         * @param string format The response format, xml or json
         * @param IDictionary params If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void getBalance(string format,IDictionary param)
        {
            this.setParamsNotId(ref format,ref param);
            string baseurl = config["baseurl"];
            baseurl += "account/balance";
            response = client.get(baseurl, format, param);
        }
        public void getBalance()
        {
            getBalance(null,null);
        }

        /**
         * account/stats (GET)
         * Retrieves account stats, such as orders made.
         *
         * @param string format The response format, xml or json
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void getStats(string format,IDictionary param)
        {
            setParamsNotId(ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "account/stats";
            response = client.get(baseurl, format, param);
        }
    }
}
