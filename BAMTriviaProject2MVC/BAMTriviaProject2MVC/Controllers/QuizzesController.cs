using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BAMTriviaProject2MVC.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BAMTriviaProject2MVC.Controllers
{
    public class QuizzesController : AServiceController
    {
        public QuizzesController(HttpClient httpClient, IConfiguration configuration)
    : base(httpClient, configuration)
        { }

        // GET: Quizzes
        public async Task<ActionResult> Index()
        {
            var request = CreateRequestToService(HttpMethod.Get, $"/api/Quizzes");
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

            var quizzes = JsonConvert.DeserializeObject<ApiQuizzes>(jsonString);

            return View(quizzes);
            //return View();
        }

        // GET: Quizes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Quizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quizes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Quizes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Quizes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Quizes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Quizes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}