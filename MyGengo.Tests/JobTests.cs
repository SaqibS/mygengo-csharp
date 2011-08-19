namespace MyGengo.Tests
{
    using System;
    using NUnit.Framework;
    using MyGengo;
    using System.Xml.Linq;

    [TestFixture]
    public class JobTests
    {
        [Test]
        public void TestJobCreation()
        {
            var myGengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
            var rnd = new Random();
            string text = string.Format("Test{0}ing myGe{1}ngo A{2}PI li{3}brary calls.", rnd.Next(1, 226), rnd.Next(1, 226), rnd.Next(1, 226), rnd.Next(1, 226));
            var job = new TranslationJob(text, "en", "ja", Tier.Standard);
            XDocument response = myGengo.PostTranslationJob(job);
            Assert.AreEqual("ok", response.Root.Element("opstat").Value);
            Assert.IsNotNull(response.Root.Element("response").Element("job").Element("job_id").Value);
        }
    }
}
