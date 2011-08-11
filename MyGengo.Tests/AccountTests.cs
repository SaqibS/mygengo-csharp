namespace MyGengo.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using MyGengo;
    
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void TestGetAccountStats()
        {
            var myGengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: false);
            IDictionary<string,object> response = myGengo.GetAccountStats();
            Assert.AreEqual("ok", response["opstat"]);
        }
    }
}
