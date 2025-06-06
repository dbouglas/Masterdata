using Microsoft.AspNetCore.Mvc;
using Masterdata.Models;
using System.Collections.Generic;

namespace Masterdata.Controllers
{
    public class AccountController : Controller
    {
        private static readonly Dictionary<string, string> _codes = new()
        {
            {"1234", "Admin"},
            {"5678", "User"}
        };

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string accessCode)
        {
            if (_codes.TryGetValue(accessCode, out var user))
            {
                TempData["UserName"] = user;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Código inválido";
            return View();
        }
    }
}
