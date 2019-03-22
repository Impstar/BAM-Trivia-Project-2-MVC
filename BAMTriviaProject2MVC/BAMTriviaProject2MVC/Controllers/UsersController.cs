using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BAMTriviaProject2MVC.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BAMTriviaProject2MVC.Controllers
{
    public class UsersController : AServiceController
    {

        public UsersController(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration)
        { }

        // GET: Users
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login(ViewModels.UsersViewModel viewModel)
        {

            return View(viewModel);
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var request = CreateRequestToService(HttpMethod.Get, $"/api/Users/{id}");
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

            var users = JsonConvert.DeserializeObject<ApiUsers>(jsonString);

            return View(users);

        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}