using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeForum.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        /// TODO: 1. fix Role custom Attribute
        /// TODO: 2. RoleEnum, role table in DB
        /// TODO: 3. Universal BaseGrid
        [CustomAttributes.Role(IsNeedAuthorized = true, IsNeedAdmin = true)]
        public ActionResult Database()
        {
            return View(FreeForum.Models.DataBase.GetUsersList());
        }
    }
}
