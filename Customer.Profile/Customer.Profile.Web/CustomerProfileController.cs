using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Profile.Web.Models;
using Customer.Profile.Web.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer.Profile.Web
{
    public class CustomerProfileController : Controller
    {
        private readonly ICustomerProfileRepository _customerProfileRepository;

        public CustomerProfileController(ICustomerProfileRepository customerProfileRepository)
        {
            _customerProfileRepository = customerProfileRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            TempData["ErrorMessage"] = null;
            var customerProfileList = _customerProfileRepository.GetCustomerProfileList();
            ViewBag.Title = "List All Customer Profile";
            return View(customerProfileList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var created = _customerProfileRepository.CreateCustomerProfile(model);
                if (string.IsNullOrEmpty(created))
                {
                    return RedirectToAction("Index");
                }
                ViewBag.ErrorMessage = created;
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var customerProfile = _customerProfileRepository.GetCustomerProfileDetails(id);
            ViewBag.Title = "Customer Profile Details";
            return View(customerProfile);
        }

        public ActionResult Update(CustomerProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                (var customerProfile, string errorMsg) = _customerProfileRepository.UpdateCustomerProfile(model);
                if (string.IsNullOrEmpty(errorMsg))
                {
                    return RedirectToAction("Index");
                }
                TempData["ErrorMessage"] = errorMsg;
            }
            else
            {
                TempData["ErrorMessage"] = "Error while updating customer profile.";
                
            }
            TempData.Keep("ErrorMessage");
            return RedirectToAction($"Edit/{model.Id}");
        }

        public ActionResult Details(int id)
        {
            var customerProfile = _customerProfileRepository.GetCustomerProfileDetails(id);
            ViewBag.Title = "Customer Profile Details";
            return View(customerProfile);
        }

        public ActionResult Delete(int id)
        {
            var result = _customerProfileRepository.DeleteCustomerProfile(id);
            return RedirectToAction("Index");

        }
    }
}
