using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FreeForum.CustomAttributes
{
    /// <summary>
    /// Атрибут валидации модели регистрации
    /// </summary>
    public class RegistrationValidationAttribute:ValidationAttribute
    {
        private bool _isByLogin;

        public RegistrationValidationAttribute(bool isByLogin)
        {
            this._isByLogin = isByLogin;
        }

        public override bool IsValid(object obj)
        {
            string inputString = (obj as string);

            var entity = new FreeForumEntities();
            var users = entity.Users;
            
            if (_isByLogin)
            {
                if (users.Where(us => us.Login == inputString).Count() > 0)
                    return false;
            }
            else
            {
                if (users.Where(us => us.Email == inputString).Count() > 0)
                    return false;
            }
            return true;
        }
    }
}