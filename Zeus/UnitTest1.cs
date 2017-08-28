using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Zeus
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new Client();
            client.EndPoint = @"https://restcountries.eu";
            client.Method = Action.GET;
            var pdata = client.PostData;
            var response = client.Request("/rest/v1/callingcode/65");
            Console.WriteLine("response ===="+ response);
                var des = JsonConvert.DeserializeObject(response);
                Console.WriteLine("deseriliaxtoin===" + des);
                var ser = JsonConvert.SerializeObject(response);
                Console.WriteLine("sericatoin===" + des);
          //  var rawJson = new StreamReader(response).ReadToEnd();
          //var json = JObject.Parse(rawJson);  //Turns your raw string into a key value lookup
          //  string licsene_value = json["capital"].ToObject<string>();
          //  Console.WriteLine(licsene_value);
          //  Console.WriteLine(response);
        }
   
    }
}
