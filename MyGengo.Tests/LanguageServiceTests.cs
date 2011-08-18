namespace MyGengo.Tests
{
    using System;
    using System.Xml.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class LanguageServiceTests
    {
        [Test]
        public void TestGetServiceLanguages()
        {
            var myGengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
            XDocument response = myGengo.GetServiceLanguages();
            Console.WriteLine(response.ToString());
            Assert.AreEqual("ok", response.Root.Element("opstat").Value);
        }

        [Test]
        public void TestGetServiceLanguagePairs()
        {
            var myGengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
            XDocument response = myGengo.GetServiceLanguagePairs();
            Assert.AreEqual("ok", response.Root.Element("opstat").Value);
        }

        [Test]
        public void TestGetServiceLanguagePairsForLanguage()
        {
            var myGengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
            XDocument response = myGengo.GetServiceLanguagePairs("en-us");
            Assert.AreEqual("ok", response.Root.Element("opstat").Value);
        }
            }
}
