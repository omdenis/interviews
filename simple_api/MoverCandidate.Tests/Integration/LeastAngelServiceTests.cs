using Microsoft.AspNetCore.Mvc.Testing;
using MoverCandidateTest;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelogger.Api.Tests.Lib;

namespace MoverCandidate.Tests.Integration
{
    [TestClass]
    public class LeastAngelSeviceTests
    {
        private HttpClient _httpClient;

        [TestInitialize]
        public async Task Setup()
        {
            var webHost = new WebApplicationFactory<Startup>();
            _httpClient = webHost.CreateClient();
        }

        [TestMethod]
        public async Task Given_DateTime_When_LeastAngel()
        {
            var result = await _httpClient.Get<string>("CalculateLeastAngle?DateTime=11/25/2020%204:07:12%20PM");
            Assert.AreEqual("30", result);
        }

        [TestMethod]
        public async Task GivenInvalideDate_When_ErrorJson()
        {
            var result = await _httpClient.Get<JObject>("CalculateLeastAngle?DateTime=WRONG_DATE");

            Assert.AreEqual("The value 'WRONG_DATE' is not valid for DateTime.", result["errors"]["DateTime"][0]);
        }

    }
}
