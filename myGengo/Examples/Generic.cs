using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myGengo.Examples
{
    abstract class Generic
    {
        public static void printNice(string s)
        {
            int l = s.Length;
            int total = 42;
            if (total < l)
            {
                Console.WriteLine(s);
                return;
            }
            int stars = (total - l) / 2;
            for (int i = 0; i < stars; i++)
                Console.Write("*");
            Console.Write(s);
            for (int i = 0; i < stars; i++)
                Console.Write("*");
            if ( (total - l) % 2 != 0)
            {
                Console.Write("*");
            }
            Console.WriteLine("");
        }
        public abstract void test();
    }
}
