using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPRClient.Net
{
    using System.Net;
    using System.Xml;
    using System.IO;

    class NetManager
    {
        private string mCloudIPAddress = "http://www.czcodezone.com/npr";
        private bool mProxyEnabled = false;
        private bool mDefaultCredentials = true;
        private string mUsername = "";
        private string mPassword = "";
        private string mProxyUrl = "";
        private string mProxyDomain = "";

        public string CloudIPAddress
        {
            set
            {
                mCloudIPAddress = value;
            }
        }

        public NetManager(string net_filename)
        {
            if (!string.IsNullOrEmpty(net_filename) && File.Exists(net_filename))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(net_filename);

                XmlElement doc_root = doc.DocumentElement;
                foreach (XmlElement doc_level1 in doc_root.ChildNodes)
                {
                    if (doc_level1.Name == "cloud_ip")
                    {
                        mCloudIPAddress = doc_level1.Attributes["uri"].Value.ToString();
                    }
                    else if (doc_level1.Name == "proxy")
                    {
                        string enabled_string = doc_level1.Attributes["enable"].Value.ToString().ToLower();
                        if (enabled_string == "false")
                        {
                            mProxyEnabled = false;
                        }
                        else
                        {
                            mProxyEnabled = true;
                        }
                        string default_credentials = doc_level1.Attributes["default_credentials"].Value.ToString().ToLower();
                        if (default_credentials == "true")
                        {
                            mDefaultCredentials = true;
                        }
                        else
                        {
                            mDefaultCredentials = false;
                        }
                        mProxyUrl = doc_level1.Attributes["proxy_url"].Value.ToString();
                        foreach (XmlElement doc_level2 in doc_level1.ChildNodes)
                        {
                            if (doc_level2.Name == "credential")
                            {
                                mUsername = doc_level2.Attributes["username"].Value.ToString();
                                mPassword = doc_level2.Attributes["password"].Value.ToString();
                                mProxyDomain = doc_level2.Attributes["domain"].Value.ToString();
                            }
                        }
                    }
                }
            }

        }

        public WebClient CreateWebClient()
        {
            WebClient client = new System.Net.WebClient();

            if (mProxyEnabled)
            {
                if (mDefaultCredentials)
                {
                    WebProxy proxyObj = new WebProxy(mProxyUrl);
                    proxyObj.Credentials = CredentialCache.DefaultCredentials;
                    client.Proxy = proxyObj;
                }
                else
                {
                    client.Credentials = new System.Net.NetworkCredential(mUsername, mPassword, mProxyDomain);
                    client.Proxy = new System.Net.WebProxy()
                    {
                        Credentials = new System.Net.NetworkCredential(mUsername, mPassword, mProxyDomain)
                    };
                }


            }
            return client;
        }

        public string GetUrl(string relative_url)
        {
            return mCloudIPAddress + "/" + relative_url;
        }

        public string ProxyUrl
        {
            get { return mProxyUrl; }
        }

        public string Password
        {
            get { return mPassword; }
        }

        public string Username
        {
            get { return mUsername; }
        }

        public bool DefaultCredentials
        {
            get { return mDefaultCredentials; }
        }

        public bool ProxyEnabled
        {
            get { return mProxyEnabled; }
        }
    }
}
