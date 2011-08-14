﻿namespace MyGengo.Tests
{
    using System;
    using System.Collections.Generic;
    using MyGengo;
    using NUnit.Framework;
    
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void TestGetAccountStats()
        {
            var myGengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
            IDictionary<string,object> response = myGengo.GetAccountStats();
            Assert.AreEqual("ok", response["opstat"]);
        }

        [Test]
        public void TestGetAccountBalance()
        {
            var myGengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
            IDictionary<string, object> response = myGengo.GetAccountBalance();
            Assert.AreEqual("ok", response["opstat"]);
        }
    }
}
