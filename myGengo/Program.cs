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
using System.Collections.Generic;
using myGengo.Apis;
using myGengo.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
namespace myGengo
{
    class Program
    {
        static void Main(string[] args)
        {
            myGengo.Examples.Service sexample = new myGengo.Examples.Service();
            sexample.test();
            Console.ReadLine();

            myGengo.Examples.JobsExample jsexample = new myGengo.Examples.JobsExample();
            jsexample.test();
            Console.ReadLine();

            myGengo.Examples.AccountExample aexample = new myGengo.Examples.AccountExample();
            aexample.test();
            Console.ReadLine();
             
            myGengo.Examples.JobExample jexample = new myGengo.Examples.JobExample();
            jexample.testLazyLoading();
            jexample.test();
            Console.ReadLine();
        }
    }
}
