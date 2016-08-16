using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeForum.CustomAttributes
{
    /// <summary>
    /// Атрибут авторизации, проверяющий наличие прав пользователя для выполнения действия
    /// </summary>
    public class RoleAttribute:AuthorizeAttribute
    {
        public bool IsNeedAuthorized { get; set; }
        public bool IsNeedAdmin { get; set; }

        public RoleAttribute()
        {
            IsNeedAuthorized = true;
        }
        public RoleAttribute(bool isNeedAuth, bool isNeedAdmin)
        {
            IsNeedAuthorized = isNeedAuth;
            IsNeedAdmin = isNeedAdmin;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpCookie authCookie = httpContext.Request.Cookies["__AUTH"];
            if (authCookie != null && authCookie.Value.Length>0)
            {
                var user = FreeForum.Helpers.AuthHelper.GetUser(httpContext);

                if (IsNeedAuthorized)
                {
                    if (user == null) return false;

                    if (IsNeedAdmin)
                    {
                        return Helpers.AuthHelper.IsAdmin(httpContext);
                    }
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}