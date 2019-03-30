using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BAMTriviaProject2MVC.BLLModels;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Net;
using BAMTriviaProject2MVC.AuthModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BAMTriviaProject2MVC.ApiModels;

namespace BAMTriviaProject2MVC.Controllers
{
    public class HomeController : AServiceController
    {
        public HomeController(HttpClient httpClient, IConfiguration configuration,
            ILogger<HomeController> logger)
            : base(httpClient, configuration)
        { _logger = logger; }

        private readonly ILogger<HomeController> _logger;

        public ActionResult Login()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(AuthLogin login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            HttpRequestMessage request = CreateRequestToService(HttpMethod.Post,
                "api/Users/Login", login);

            HttpResponseMessage response;
            try
            {
                response = await HttpClient.SendAsync(request);
            }
            catch
            {
                ModelState.AddModelError("", "Unexpected server error");
                return View(login);
            }

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // login failed because bad credentials
                    ModelState.AddModelError("", "Login or password incorrect.");
                }
                else
                {
                    ModelState.AddModelError("", "Unexpected server error");
                }
                return View(login);
            }

            var success = PassCookiesToClient(response);
            if (!success)
            {
                ModelState.AddModelError("", "Unexpected server error");
                return View(login);
            }

            // login success
            return RedirectToAction("Account", "Home");
        }

        public async Task<ActionResult> Account()
        {
            var request = CreateRequestToService(HttpMethod.Get, $"/api/Users/Account");
            var response = await HttpClient.SendAsync(request);

            //if (!response.IsSuccessStatusCode)
            //{
            //    if (response.StatusCode == HttpStatusCode.Unauthorized)
            //    {
            //        return RedirectToAction("Login", "Account");
            //    }
            //    return View("Error");
            //}

            var jsonString = await response.Content.ReadAsStringAsync();

            ApiUsersModel quizzes = JsonConvert.DeserializeObject<ApiUsersModel>(jsonString);

            return View(quizzes);
        }

        // POST: /Account/Logout
        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            HttpRequestMessage request = CreateRequestToService(HttpMethod.Post,
                "api/Users/Logout");

            HttpResponseMessage response;
            try
            {
                response = await HttpClient.SendAsync(request);
            }
            catch (HttpRequestException)
            {
                return View("Error", new ErrorViewModel());
            }

            if (!response.IsSuccessStatusCode)
            {
                return View("Error", new ErrorViewModel());
            }

            var success = PassCookiesToClient(response);
            if (!success)
            {
                return View("Error", new ErrorViewModel());
            }

            // logout success
            return RedirectToAction("Login", "Home");
        }

        // GET: /Home/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Home/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(AuthRegister register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            HttpRequestMessage request = CreateRequestToService(HttpMethod.Post,
                "api/Users/Register", register);

            HttpResponseMessage response;
            try
            {
                response = await HttpClient.SendAsync(request);
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError("", "Unexpected server error");
                return View(register);
            }

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Unexpected server error");
                return View(register);
            }

            var success = PassCookiesToClient(response);
            if (!success)
            {
                ModelState.AddModelError("", "Unexpected server error");
                return View(register);
            }

            // login success
            return RedirectToAction("Login", "Home");
        }

        private bool PassCookiesToClient(HttpResponseMessage apiResponse)
        {
            // the header value contains both the name and value of the cookie itself
            if (apiResponse.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> values) &&
                values.FirstOrDefault(x => x.StartsWith(Configuration["ServiceCookieName"])) is string headerValue)
            {
                // copy that cookie to the response we will send to the client
                Response.Headers.Add("Set-Cookie", headerValue);
                return true;
            }
            return false;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
