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

        #region create/parse Subject
        public static NewSubjectModel Create(Subject subject)
        {
            var model = new NewSubjectModel
            {
                Title = subject.Title,
                MessageText = new FreeForumEntities().Messages.Find(subject.Id).Text
            };
            return model;
        }

        public static Subject Parse(NewSubjectModel model)
        {
            Subject subject = new Subject
            {
                Title = model.Title
            };
            return subject;
        }
        #endregion
    }
}