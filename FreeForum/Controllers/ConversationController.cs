using FreeForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeForum.Controllers
{
    public class ConversationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var subjects = DataBase.GetSubjects();
            return View(subjects);
        }

        [HttpGet]
        public ActionResult Read(int index)
        {
            Subject subject=(new FreeForumEntities().Subjects.Find(index));
            if (subject != null)
                return View(subject);
            return View("~/Views/Shared/Error");
        }

        [HttpPost]
        public ActionResult Add(Message message)
        {
            var ctx = new FreeForumEntities();
            ctx.Messages.Add(message);
            ctx.SaveChanges();
            return View();
        }
    }
}
