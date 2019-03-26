using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BAMTriviaProject2MVC.ApiModels;
using BAMTriviaProject2MVC.ViewModels;
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

            return View();
            //return View();
        }

        // GET: Quizes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Quizes/Create
        public async Task<ActionResult> Create()
        {
            QuizzesViewModel quizzes = new QuizzesViewModel();

            return View(quizzes);
        }

        // POST: Quizes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuizzesViewModel model)
        {
            try
            {
                var request = CreateRequestToService(HttpMethod.Post, $"/api/Quizzes", model);
                var response = await HttpClient.SendAsync(request);

                var jsonString = await response.Content.ReadAsStringAsync();

                var questions = JsonConvert.DeserializeObject<List<ApiQuestions>>(jsonString);

                var request2 = CreateRequestToService(HttpMethod.Post, $"/api/Quizzes/Answers", questions);
                var response2 = await HttpClient.SendAsync(request2);

                var jsonString2 = await response2.Content.ReadAsStringAsync();

                var answers = JsonConvert.DeserializeObject<List<ApiAnswers>>(jsonString2);

                model.questions = questions;
                model.answers = answers;

                return RedirectToAction("TakeQuiz", model);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> TakeQuiz(List<ApiQuestions> questions)
        {
            var request = CreateRequestToService(HttpMethod.Post, $"/api/Quizzes/Create", questions);
            var response = await HttpClient.SendAsync(request);



            return View("TakeQuiz", questions);
        }

        //[HttpPost]
        //public async Task<ActionResult> TakeQuiz(QuizzesViewModel model)
        //{



        //    return View(model);
        //}

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