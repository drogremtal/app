﻿using app.Models;
using app.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> SendMessage() {
            var emailService = new Mail_kit();
            await emailService.SendMailAsync("bp240@outlook.com", "test", "test");
            return RedirectToAction("Index");            
        }
        public  IActionResult SendMes()
        {
            var email = new MailSystem();
            email.SendMail("bp240@outlook.com", "test", "test");
            return RedirectToAction("Index");
        }
    }
}
