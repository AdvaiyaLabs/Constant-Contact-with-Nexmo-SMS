using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConstantContact
{
    public class SmsSender
    {
        public string SendSMS(string number, string from, string username, string pasword, string text)
        {
        
            string uri = string.Format("https://rest.nexmo.com/sms/json?api_key={0}&api_secret={1}&from={2}&to={3}&text={4}", username, pasword, from, number, text);
            var json = new WebClient().DownloadString(uri);
            return json;

        }

        private SmsResponse ParseSmsResponseJson(string json)
        {
            // hyphens are not allowed in in .NET var names
            json = json.Replace("message-count", "MessageCount");
            json = json.Replace("message-price", "MessagePrice");
            json = json.Replace("message-id", "MessageId");
            json = json.Replace("remaining-balance", "RemainingBalance");
            return new JavaScriptSerializer().Deserialize<SmsResponse>(json);
        }
        public string GetAccountNumber(string apikey, string secretkey)
        {
            string FromNumber = string.Empty;
            string uri = string.Format("https://rest.nexmo.com/account/numbers/{0}/{1}", apikey, secretkey);
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Method = "GET";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string result = string.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<RootObject>(result);
            if (dict.numbers.Count > 0)
            {
                FromNumber = dict.numbers[0].msisdn;
            }
            return FromNumber;
        }
        public bool ValidateNexmoCredential(string apikey, string secretkey)
        {
            string FromNumber = string.Empty;
            string uri = string.Format("https://api.nexmo.com/verify/json?api_key={0}&api_secret={1}", apikey, secretkey);
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Method = "GET";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string result = string.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            return true;

        }
    }
  
    public class Number
    {
        public string country { get; set; }
        public string msisdn { get; set; }
        public string type { get; set; }
        public List<string> features { get; set; }
    }

    public class RootObject
    {
        public int count { get; set; }
        public List<Number> numbers { get; set; }
    }
    public class Message
    {
        public string To { get; set; }
        public string Messageprice { get; set; }
        public string Status { get; set; }
        public string MessageId { get; set; }
        public string RemainingBalance { get; set; }
    }

    public class SmsResponse
    {
        public string Messagecount { get; set; }
        public List<Message> Messages { get; set; }
    }
}
