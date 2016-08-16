using FreeForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeForum.Helpers
{
    /// <summary>
    /// Класс выполняет действия, связанные с авторизацией и аутентификацией пользователя в системе
    /// </summary>
    public static class AuthHelper
    {
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="httpContext"> HTTP-контекст запроса</param>
        /// <param name="cookies"> Куки пользователя </param>
        public static void LogInUser(HttpContextBase httpContext, string cookies)
        {
            HttpCookie cookie = new HttpCookie("__AUTH")
            {
                Value = cookies,
                Expires = DateTime.Now.AddYears(1)
            };

            httpContext.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Осуществляет выход из аккаунта
        /// </summary>
        /// <param name="httpContext"> HTTP-контекст запроса</param>
        public static void LogOutUser(HttpContextBase httpContext)
        {
            HttpCookie cookie = new HttpCookie("__AUTH")
            {
                Value = httpContext.Request.Cookies["__AUTH"].Value,
                Expires = DateTime.Now.AddDays(-1),
            };
            httpContext.Response.Cookies.Add(cookie);
            DataBase.RemoveCookie(GetUser(httpContext));
        }

        /// <summary>
        /// Получает текущего пользователя (по значению куков запроса)
        /// </summary>
        /// <param name="httpContext"> HTTP-контекст запроса</param>
        /// <returns> Аутентифицированный пользователь или null </returns>
        public static User GetUser(HttpContextBase httpContext)
        {
            HttpCookie authCookie = httpContext.Request.Cookies["__AUTH"];
            return (authCookie == null) ? null : FreeForum.Models.DataBase.GetUserByCookie(authCookie.Value);
        }

        /// <summary>
        /// Проверка аутентификации пользователя
        /// </summary>
        /// <param name="httpContext"> HTTP-контекст запроса</param>
        /// <returns> Пользователь аутентифицирован в системе (да/нет)</returns>
        public static bool IsAuthenticated(HttpContextBase httpContext)
        {
            HttpCookie authCookie = httpContext.Request.Cookies["__AUTH"];

            if (authCookie != null)
            {
                User user = FreeForum.Models.DataBase.GetUserByCookie(authCookie.Value);
                return user != null;
            }

            return false;
        }

        /// <summary>
        /// Проверка наличия у пользователя прав администратора
        /// </summary>
        /// <param name="httpContext"> HTTP-контекст запроса</param>
        /// <returns> Пользователь является администратором системы (да/нет)</returns>
        public static bool IsAdmin(HttpContextBase httpContext)
        {
            HttpCookie authCookie = httpContext.Request.Cookies["__AUTH"];

            if (authCookie != null)
            {
                User user = FreeForum.Models.DataBase.GetUserByCookie(authCookie.Value);
                return user!=null && user.Email == "school5diary@mail.ru";
            }

            return false;
        }
    }
}