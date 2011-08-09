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

namespace myGengo
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class GengoException : Exception
    {
        public GengoException()
            : base()
        {
        }

        public GengoException(string message)
            : base(message)
        {
        }

        public GengoException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GengoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
