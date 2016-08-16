using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeForum.Models
{
    public static class ModelFactory
    {
        #region create/parse User
        public static UserModel Create(User user)
        {
            UserModel model = new UserModel
            {
                Email = user.Email,
                Login = user.Login
            };
            return model;
        }

        public static User Parse(UserModel model)
        {
            User user = new User
            {
                Email = model.Email,
                Login = model.Login
            };
            return user;
        }
        #endregion
    }
}