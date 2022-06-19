using Homework67_Tasks.Data;
using Homework67_Tasks.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Homework67_Tasks.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly string _connectionString;
        public AccountController(IConfiguration confiuration)
        {
            _connectionString = confiuration.GetConnectionString("ConStr");
        }
        [HttpPost]
        [Route ("signup")]
        public void Signup(SignupViewModel model)
        {
            var repo = new UserRepository(_connectionString);
            repo.AddUser(model, model.Password);
        }
        [HttpPost]
        [Route ("login")]
        public User Login(LoginViewModel model)
        {
            var repo = new UserRepository(_connectionString);
            var user = repo.Login(model.Email, model.Password);
            if(user == null)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim("user", model.Email)
            };
            HttpContext.SignInAsync(new ClaimsPrincipal(
                new ClaimsIdentity(claims, "Cookies", "user", "role"))).Wait();
            return user;
        }
        [HttpGet]
        [Route ("getcurrentuser")]
        public User GetCurrentUser()
        {
           if(!User.Identity.IsAuthenticated)
            {
                return null;
            }
            var repo = new UserRepository(_connectionString);
            return repo.GetByEmail(User.Identity.Name);
        }
        [HttpGet]
        [Route ("logout")]
        public void Logout()
        {
            HttpContext.SignOutAsync().Wait();
        }

    }
}
