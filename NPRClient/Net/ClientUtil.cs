using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPRClient.Net
{
    using System.Web;
    using System.Net;
    using System.IO;

    public class ClientUtil
    {
        public static string PostUpload(string upload_filename, string base_address, string relative_address)
        {
            NetManager nm = new NetManager(null);
            nm.CloudIPAddress = base_address;

            System.Net.WebClient Client = nm.CreateWebClient();

            Client.Headers.Add("Content-Type", "binary/octet-stream");

            string post_url = nm.GetUrl(relative_address);

            //Console.WriteLine(post_url);

            byte[] result = Client.UploadFile(post_url, "POST", upload_filename);

            string s = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);

            //Console.WriteLine("POST at {0} RESULT: {1}", DateTime.Now.ToString(), s);

            return s;
        }

        private static CookieContainer _cookieContainer = new CookieContainer();

        public string HttpStringGet(string _baseUrl, string relativeUrl)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_baseUrl + relativeUrl);
            req.CookieContainer = _cookieContainer;

            return ReadBasicResponse(req.GetResponse());
        }

        public byte[] HttpBinaryGet(string _baseUrl, string relativeUrl)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_baseUrl + relativeUrl);
            req.CookieContainer = _cookieContainer;

            byte[] result = null;
            byte[] buffer = new byte[4096];

            using (WebResponse resp = req.GetResponse())
            using (Stream responseStream = resp.GetResponseStream())
            using (MemoryStream memoryStream = new MemoryStream())
            {
                int count = 0;
                do
                {
                    count = responseStream.Read(buffer, 0, buffer.Length);
                    memoryStream.Write(buffer, 0, count);

                } while (count != 0);

                result = memoryStream.ToArray();
            }

            return result;
        }

        private string ReadBasicResponse(WebResponse response)
        {
            using (WebResponse resp = response)
            using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                return sr.ReadToEnd().Trim();
        }

        public static string UrlEncode(DateTime dt)
        {
            return HttpUtility.UrlEncode(dt.ToString());
        }

        public static string UrlEncode(double val)
        {
            return HttpUtility.UrlEncode(Convert.ToString(val));
        }

        public static string UrlEncode(int val)
        {
            return HttpUtility.UrlEncode(Convert.ToString(val));
        }

        public static string UrlEncode(string raw_text)
        {
            string text = raw_text.Replace("'", "");
            return HttpUtility.UrlEncode(text);
        }

        public string HttpPost(string uri, Dictionary<string, string> parameters)
        {
            bool httppostbank_empty = true;
            StringBuilder sb = new StringBuilder();
            foreach (string key in parameters.Keys)
            {
                string value = HttpUtility.UrlEncode(parameters[key]);

                if (httppostbank_empty == false)
                {
                    sb.Append("&");
                }
                else
                {
                    httppostbank_empty = false;
                }
                sb.AppendFormat("{0}={1}", key, value);
            }
            return HttpPost(uri, sb.ToString());
        }

        public string HttpPost(string uri, string parameters)
        {
            // parameters: name1=value1&name2=value2	
            WebRequest webRequest = WebRequest.Create(uri);
            //string ProxyString = 
            //   System.Configuration.ConfigurationManager.AppSettings
            //   [GetConfigKey("proxy")];
            //webRequest.Proxy = new WebProxy (ProxyString, true);
            //Commenting out above required change to App.Config
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(parameters);
            Stream os = null;
            try
            { // send the Post
                webRequest.ContentLength = bytes.Length;   //Count bytes to send
                os = webRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);         //Send it
            }
            catch (WebException ex)
            {
                //MessageBox.Show(ex.Message, "HttpPost: Request error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (os != null)
                {
                    os.Close();
                }
            }

            try
            { // get the response
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                { return null; }
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {
                //MessageBox.Show(ex.Message, "HttpPost: Response error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        } // end HttpPost 
    }
}
