using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.API.BL.Helper
{
    public static class ApiCall
    {
        public static string GetApi(string ApiUrl)
        {

            var responseString = "";
            var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            request.Method = "GET";
            request.ContentType = "application/json";


            using (var response1 = request.GetResponse())
            {
                using (var reader = new StreamReader(response1.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }
            return responseString;

        }
    }
}