using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FreeForum.Models;
using FreeForum.Helpers;

namespace FreeForum.Controllers
{
    public class AccountController : Controller
    {
        #region Регистрация
        /// <summary>
        /// Возвращает представление для регистрации пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Registration(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                User user = new FreeForum.User();
                user.Email = userModel.Email;
                user.Login = userModel.Login;
                user.Password = Helpers.SecurityHelper.Hash(userModel.Password);
                user.Cookie = Guid.NewGuid().ToString();

                FreeForum.Models.DataBase.AddUser(user);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        #endregion

        #region Вход/выход

        /// <summary>
        /// Обеспечивает вход в аккаунт
        /// </summary>
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        /// <summary>
        /// Обеспечивает вход в аккаунт
        /// </summary>
        /// <param name="homeModel"> Модель профиля пользователя</param>
        /// <returns>Представление главной страницы или сообщение об ошибке</returns>
        [HttpPost]
        public ActionResult LogIn(UserModel homeModel)
        {
            User user = DataBase.GetUser(homeModel.Email,
                Helpers.SecurityHelper.Hash(homeModel.Password));
            if (user != null)
            {
                Helpers.AuthHelper.LogInUser(HttpContext, user.Cookie);
                return RedirectToAction("Index", "Home");
            }

            return View();
            //ViewData["message"] = "Вероятно, вы ошиблись при вводе данных...";
            //return View("~/Views/Shared/Error.cshtml");
        }

        /// <summary>
        /// Обеспечивает корректный выход из аккаунта
        /// </summary>
        /// <returns>Представление главной страницы</returns>
        public ActionResult LogOut()
        {
            Helpers.AuthHelper.LogOutUser(HttpContext);
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
