namespace MyGengo.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class LanguageServiceTests
    {
        [Test]
        public void TestGetServiceLanguages()
        {
            var myGengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
            IDictionary<string, object> response = myGengo.GetServiceLanguages();
            Assert.AreEqual("ok", response["opstat"]);
        }

        [Test]
        public void TestGetServiceLanguagePairs()
        {
            var myGengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
            IDictionary<string, object> response = myGengo.GetServiceLanguagePairs();
            Assert.AreEqual("ok", response["opstat"]);
        }
            }
}
