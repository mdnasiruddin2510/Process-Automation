using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ProcessAutomation.Controllers;

namespace ProcessAutomation
{
    public static class GlobalVariabls
    {
        public static HttpClient WebApiClient = new HttpClient();
		public static string token = (string)HttpContext.Current.Session["token"];
        //public static string token = "";
        static GlobalVariabls()
        {
            WebApiClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]+"/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var t = JsonConvert.DeserializeObject<TokenResponse>(token);
            WebApiClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + t.access_token);
        }
    }
}