using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingPayment.Test
{
    [TestClass]
    public class FACPG2XMLTests
    {
        private const string BASE_XML_URL = @"https://ecm.firstatlanticcommerce.com";
        private readonly string MERCH_ID = "YOUR MERCHANT ID NUMBER GOES HERE";
        private readonly string MERCH_PWD = "YOUR MERCHANT PASSWORD GOES HERE";

        [TestMethod]
        public void TestAuthorize_WithCorrectCardInfo_ShouldSucceed()
        {
            //Arrange
            var request = @"<AuthorizeRequest xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""
                                              xmlns=""http://schemas.firstatlanticcommerce.com/gateway/data"">";

            string baseUrl = "https://ecm.firstatlanticcommerce.com/PGServiceXML";
            string url = "/Authorize";

            //Act
            var authResponse = postFACXMLMessage(request, baseUrl, url);

            //Assert
            Assert.IsNotNull(authResponse);
        }

        /// <summary>
        /// Posts an XML message using HTTP POST
        /// </summary>
        /// <param name="strRequest">xmlrequest</param>
        /// <param name="baseUrl">For example: baseUrl= @https://ecm.firstatlanticcommerce.com </param>
        /// <param name="url">For example: url = @"/PGService/Services.svc" </param>
        /// <returns></returns>
        public static string postFACXMLMessage(string strRequest, string baseUrl, string url)
        {
            StreamReader reader = null;
            string strResponse = "";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            byte[] byteArray = Encoding.UTF8.GetBytes(strRequest);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(baseUrl + url);
            req.Method = "POST";
            req.ContentType = string.Format("text/xml");
            req.ContentLength = byteArray.Length;
            try
            {
                // Get the request stream.
                Stream dataStream = req.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                WebResponse response = req.GetResponse();
                Debug.WriteLine("Service Status Code:" + ((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                reader = new StreamReader(dataStream);
                // Read the content.
                strResponse = reader.ReadToEnd();
                reader.Close();
            }
            catch (WebException ex)
            {
                string exMessage = ex.Message;
                if (ex.Response != null)
                {
                    using (var responseReader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        strResponse = responseReader.ReadToEnd();
                    }
                }
            }
            return strResponse;
        }
    }
}
