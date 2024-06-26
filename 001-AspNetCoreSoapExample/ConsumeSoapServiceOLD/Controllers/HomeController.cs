﻿using ConsumeSoapService.Models;
using ConsumeSoapService.ViewModel;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System.Diagnostics;

namespace ConsumeSoapService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ISoapService soapServiceChannel = new SoapServiceClient(SoapServiceClient.EndpointConfiguration.BasicHttpBinding_ISoapService_soap);
            var sumResponse = await soapServiceChannel.SumAsync(new SumRequest()
            {
                Body = new SumRequestBody()
                {
                    num1 = 1287,
                    num2 = 3
                }
            });

            var sumResultModel = new SumResultModel { SumResult = sumResponse.Body.SumResult };
            return View(sumResultModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}