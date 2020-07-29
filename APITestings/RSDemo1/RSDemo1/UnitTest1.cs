using System;
using System.Collections.Generic;
using Dynamitey.DynamicObjects;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using Utf8Json;

namespace RSDemo1
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);

            ////1. use jsonDeserializer 
            //var des = new JsonDeserializer();
            //var output = des.Deserialize<Dictionary<string, string>>(response);
            //var result = output["author"];
            //Assert.That(result, Is.EqualTo("Karthik KK"), "Author is not correct");


            ////2. use JOBJECT
            //var obs = JObject.Parse(response.Content);

            //Assert.That(obs["author"].ToString(), Is.EqualTo("Karthik KK"), "Author is not correct");

        }

        [Test]
        public void TestMethod2()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);
            
            //1. use jsonDeserializer 
            var des = new JsonDeserializer();
            var output = des.Deserialize<Dictionary<string, string>>(response);
            var result = output["author"];
            Assert.That(result, Is.EqualTo("Karthik KK"), "Author is not correct");


            //2. use JOBJECT
            var obs = JObject.Parse(response.Content);

            Assert.That(obs["author"].ToString(), Is.EqualTo("Karthik KK"), "Author is not correct");

        }
    }
}
