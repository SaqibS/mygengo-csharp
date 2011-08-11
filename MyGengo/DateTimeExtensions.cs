namespace MyGengo
{
    using System;

    internal static class DateTimeExtensions
    {
        public static ulong SecondsSinceEpoch(this DateTime dt)
        {
            return (ulong)(dt - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
