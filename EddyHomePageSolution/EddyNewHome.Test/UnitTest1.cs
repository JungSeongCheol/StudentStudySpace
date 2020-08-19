using System;
using System.Net;
using EddyNewHome.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EddyNewHome.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CommonGetExternalIp()
        {
            // 210.119.12.80
            string expectedIp = "192.168.0.165";

            string actualIp = Commons.GetIpAddress();
            Assert.AreEqual(expectedIp, actualIp);
        }
    }
}
