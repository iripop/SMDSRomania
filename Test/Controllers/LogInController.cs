using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;

namespace Test.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult SignIn()
        {
            return View();
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("LogIn")]
        public HttpResponseMessage GetLogIn(string username, string password)
        {
            UserMng user = new UserMng();
            return user.LogIn(username, password);
        }

        [Route("LogInAdmin")]
        public HttpResponseMessage GetLogInAdmin(string username, string password)
        {
            UserMng user = new UserMng();
            return user.LoginAdmin(username, password);
        }
    }
}