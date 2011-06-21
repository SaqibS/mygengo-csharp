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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using System.IO;
namespace myGengo
{
    class Config
    {
        protected static Config instance = null;
        private string config_path = "config.xml";
        /**
         * the default constructor  
         */
        protected Config()
        {
        }

        /**
         * gets the singletone Config instance
         */
        public static Config getInstance()
        {
            if(instance == null)
            {
                instance = new Config();
            }
            return instance;
        }
        /**
         * for allowing config[x] = y and x = config[y]
         */
        public string this[string key]
        {
            get { return _get(key); }
            set { _set(key, value); }
        }

        /**
         * private function for writing/reading to/from file
         */
        private string _get(string key)
        {
            if (!File.Exists(config_path))
            {
                throw new GengoException("file " + config_path + " does not exist");
            }
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(config_path);
            }
            catch (Exception e)
            {
                throw new GengoException(e.Message);
            }
            XmlNodeList list = doc.GetElementsByTagName(key);
            if (list.Count == 0)
            {
                throw new GengoException("cannot get config parameter " + key);
            }
            return list[0].InnerText;
        }
        private void _set(string key, string value)
        {
            if (!File.Exists(config_path))
            {
                XmlDocument root = new XmlDocument();
                root.AppendChild(root.CreateElement("config"));
                root.Save(config_path);
            }
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(config_path);
            }
            catch (Exception e)
            {
                throw new GengoException(e.Message);
            }
            XmlNodeList keys = doc.GetElementsByTagName(key);
            if (keys.Count != 0)
            {
                keys[0].InnerText = value;
            }
            else
            {
                XmlElement el = doc.CreateElement(key);
                el.InnerText = value;
                doc.DocumentElement.AppendChild(el);
            }
            doc.Save(config_path);
        }
        /**
         * returns number of seconds since epoch
         */
        public static string timestamp()
        {
            TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            return ((ulong)t.TotalSeconds).ToString();
        }
    }
}
