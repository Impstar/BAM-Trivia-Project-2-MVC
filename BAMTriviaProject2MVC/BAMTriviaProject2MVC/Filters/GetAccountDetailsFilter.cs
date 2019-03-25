using BAMTriviaProject2MVC.AuthModels;
using BAMTriviaProject2MVC.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BAMTriviaProject2MVC.Filters
{
    public class GetAccountDetailsFilter : IAsyncActionFilter
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UsersController> _logger;

        public GetAccountDetailsFilter(IConfiguration configuration, ILogger<UsersController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            // do something before the action executes
            // if the controller is an aservicecontroller, then
            // fetch the details, otherwise, do nothing.
            if (context.Controller is AServiceController controller)
            {
                HttpRequestMessage request = controller.CreateRequestToService(
                HttpMethod.Get, "api/Users/Details");

                HttpResponseMessage response = await controller.HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    // setting "Result" in a filter short-circuits the rest
                    // of the MVC pipeline
                    // but i won't do that, i should just log it.
                }
                else
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    AuthAccountDetails details = JsonConvert.DeserializeObject<AuthAccountDetails>(jsonString);
                    controller.ViewData["accountDetails"] = details;
                    controller.Account = details;
                }
            }

            await next();
        }
    }
}
