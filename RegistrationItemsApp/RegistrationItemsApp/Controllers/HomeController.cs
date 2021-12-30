﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegistrationItemsApp.Models;
using RegistrationItemsApp.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationItemsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RegistrationItemRepository _registrationItemRepository;

        public HomeController(ILogger<HomeController> logger, RegistrationItemRepository registrationItemRepository)
        {
            _registrationItemRepository = registrationItemRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_registrationItemRepository.GetAll());
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendSubmitData(List<RegistrationItem> model, string answer)
        {
            if ((ModelState.IsValid) && !String.IsNullOrWhiteSpace(answer))
            {
                switch (answer)
                {
                    case "Saugoti pataisymus":
                        foreach (RegistrationItem item in model)
                        {
                            var registrationItemToUpdate = _registrationItemRepository.Get(item.Id);
                            registrationItemToUpdate.SelectedValueId = item.SelectedValueId;
                            _registrationItemRepository.Update(registrationItemToUpdate);
                        }
                        return RedirectToAction("Index");
                    case "Atšaukti pataisymus":
                        return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
