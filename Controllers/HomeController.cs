using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyDbConnection.Models;
//need below to hash passwords
using Microsoft.AspNetCore.Identity;

namespace MyDbConnection.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("")]
        public IActionResult Index()
        {
             ViewBag.Users = DbConnector.Query("select * from newusers");

            // ViewBag.Users = users;
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            //check uniquness of emails
            if(DbConnector.Query("SELECT id FROM newusers WHERE email = '{user.email]'").Count != 0 )
            {
                ModelState.AddModelError("email", "email already in use");
            }

            //if modle state is true create new entry must pass all validations
            if(ModelState.IsValid)
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                string hashedpw = hasher.HashPassword(user, user.password);
                // builkd user with SQL

                string query = $@"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES ('{user.first_name}', '{user.last_name}',  '{user.email}',  '{hashedpw}', NOW(), NOW())";
                DbConnector.Execute(query);
                 return Json(new { 
                     success = true,
                     NewsStyleUriParser = user
                 });

            }
            ViewBag.User = DbConnector.Query("SELECT * FROM newusers;");
            return View("Index");

           
        }
    

    }
}
