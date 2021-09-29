using BankUI.Models;
using EO.WebBrowser.DOM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankUI.Controllers
{
    public class LoginController : Controller
    {
        Uri baseAddress;
        HttpClient client;
        IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
            baseAddress = new Uri(_config["Links:CLAIM"]);
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
   //     [Authorize(Roles ="Employee")]
        public IActionResult SaveToken(Token token)
        {
            return View("~/Views/Customer/Index.cshtml");
            //return View(token);
        }
        public IActionResult Index()
        {
            return View();
        }
    
         public  async Task<IActionResult> Login(User user)
         {
            try
            {
                string data = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(client.BaseAddress , content);
                //client.
                Token token = new Token();
                token.LoginToken = await response.Content.ReadAsStringAsync();
                ViewBag.Token = await response.Content.ReadAsStringAsync();
            
                return RedirectToAction("SaveToken",token);
            }
            catch (Exception e)
            {
                return View("Index");
            }
        }
    }
}
