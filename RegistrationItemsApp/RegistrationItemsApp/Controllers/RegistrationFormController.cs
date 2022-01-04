using Microsoft.AspNetCore.Mvc;
using RegistrationItemsApp.Models;
using RegistrationItemsApp.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RegistrationItemsApp.Controllers
{
    public class RegistrationFormController:Controller
    {
        private RegistrationItemRepository _registrationItemRepository;

        public RegistrationFormController(RegistrationItemRepository registrationItemRepository)
        {
            _registrationItemRepository = registrationItemRepository;
        }

        public IActionResult Index(int regid)
        {
            return View(_registrationItemRepository.GetAll(regid));
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
                        return RedirectToAction("Index",new { regid=model.FirstOrDefault().Form.Id});
                    case "Atšaukti pataisymus":
                        return RedirectToAction("Index",new { regid = model.FirstOrDefault().Form.Id });
                }
                return RedirectToAction("Index", new { regid = model.FirstOrDefault().Form.Id });
            }
            return View(model);
        }
    }
}
