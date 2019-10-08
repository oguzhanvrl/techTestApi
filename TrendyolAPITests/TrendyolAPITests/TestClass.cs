using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Tests
{
    public class TestClass
    {
       
        [SetUp]
        public void Setup()
        {
        }
        RestClient client;
        RestRequest request;
        IRestResponse response;
        string url = "http://localhost:57451/api/values";

        //veri tipinin json olduðunun testi
        [Test]
        public void ContentTypeTest()
        {
            client = new RestClient(url);
            request = new RestRequest(url,Method.GET);
            response = client.Execute(request);
            string JsonData = "application/json";
            Assert.IsTrue(response.ContentType.IndexOf(JsonData,StringComparison.OrdinalIgnoreCase)!=-1);
        }

        //id si 1 olan veriyi arattýgýmýzda baþarýlý dönüp 4 arattýðýmýz zaman not found döndüðünün testi
        [TestCase("1", HttpStatusCode.OK)]
        [TestCase("4",HttpStatusCode.NotFound)]
        public void StatusCodeTest(string id,HttpStatusCode expectedHttpStatusCode)
        {
            client = new RestClient(url+"/"+id);
            request = new RestRequest(url + "/" + id, Method.GET);
            response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }

        public class JSONBook
        {
            [JsonProperty("id")]
            public int bookID { get; set; }

            [JsonProperty("Author")]
            public string bookAuthor { get; set; }

            [JsonProperty("Title")]
            public string bookTitle { get; set; }
        }

        //id ye göre veri çekme testi
        [TestCase("2")]
        public void CountryAbbreviationSerializationTest(string id)
        {
            client = new RestClient(url + "/" + id);
            request = new RestRequest(url + "/" + id, Method.GET);
            response = client.Execute(request);
            JSONBook book = new JsonDeserializer().Deserialize<JSONBook>(response);
            Assert.AreEqual(book.bookID, 2);
        }
    }
}