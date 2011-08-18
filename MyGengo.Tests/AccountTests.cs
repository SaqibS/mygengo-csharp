namespace MyGengo.Tests
{
    using System;
    using System.Xml.Linq;
    using MyGengo;
    using NUnit.Framework;
    
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void TestGetAccountStats()
        {
            var myGengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
            XDocument response = myGengo.GetAccountStats();
            Assert.AreEqual("ok", response.Root.Element("opstat").Value);
        }

        [Test]
        public void TestGetAccountBalance()
        {
            var myGengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
            XDocument response = myGengo.GetAccountBalance();
            Assert.AreEqual("ok", response.Root.Element("opstat").Value);
        }
    }
}
