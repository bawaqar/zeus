using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Zeus
{
    public class Client
    {
        public string EndPoint { get; set; }
        public Action Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }

        public Client()
        {
            EndPoint = "";
            Method = Action.GET;
            ContentType = "application/JSON";
            PostData = "";
        }

        public Client(string endpoint, Action method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "text/json";
            PostData = postData;
        }
        public string Request(string parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);
            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = String.Format("Faile: Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }

                return responseValue;
            }
        }
        public JValue Request(string parameters, bool json = true)
        {

            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);
            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                JValue responseValue = null;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = String.Format("Faile: Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = (JValue) reader.ReadToEnd();
                        
                        }
                }
                //var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                //responseValue = JValue.Parse(rawJson);
                return responseValue;
            }
        
        }

    }
}
