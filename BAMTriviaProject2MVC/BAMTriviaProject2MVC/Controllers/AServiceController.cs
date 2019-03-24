using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BAMTriviaProject2MVC.AuthModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BAMTriviaProject2MVC.Controllers
{
    public abstract class AServiceController : Controller
    {
        public HttpClient HttpClient { get; }
        public IConfiguration Configuration { get; }
        public Uri ServiceUrl { get; }

        public AuthAccountDetails Account { get; set; }

        protected AServiceController(HttpClient httpClient, IConfiguration configuration,
            object body = null)
        {
            HttpClient = httpClient;
            Configuration = configuration;
            ServiceUrl = new Uri(configuration["ServiceUrl"]);
        }

        public HttpRequestMessage CreateRequestToService(HttpMethod method,
            string relativeUrl, object body = null)
        {
            var url = new Uri(ServiceUrl, relativeUrl);
            var apiRequest = new HttpRequestMessage(method, url);

            if (body != null)
            {
                var jsonString = JsonConvert.SerializeObject(body);
                apiRequest.Content = new StringContent(jsonString, Encoding.UTF8,
                    "application/json");
            }

            // get the value of the app's auth cookie from the browser's request.
            // (if present) and copy it to the api request.
            var cookieName = Configuration["ServiceCookieName"];
            var cookieValue = Request.Cookies[cookieName];

            if (cookieValue != null)
            {
                var headerValue = new CookieHeaderValue(cookieName, cookieValue);
                apiRequest.Headers.Add("Cookie", headerValue.ToString());
            }

            return apiRequest;
        }

    }
}