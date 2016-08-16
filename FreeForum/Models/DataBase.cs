using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeForum.Models
{
    public class DataBase
    {
        #region Пользователи
        /// <summary>
        /// Определяет пользователяей по кукам
        /// </summary>
        /// <param name="cookie">Куки пользователя</param>
        /// <returns>Пользователь с заданными куками или null</returns>
        public static User GetUserByCookie(string cookie)
        {
            FreeForumEntities entity = new FreeForumEntities();
            return entity.Users.FirstOrDefault(user => user.Cookie == cookie);
        }

        /// <summary>
        /// Определяет пользователя по адресу электронной почты
        /// </summary>
        /// <param name="email">E-mail пользователя</param>
        /// <returns>Пользователь с заданным адресом или null</returns>
        public static User GetUser(string email)
        {
            var entity = new FreeForumEntities();
            var users = entity.Users.Where(us => us.Email == email);
            return (users.Count() > 0) ? users.FirstOrDefault() : null;
        }
        /// <summary>
        /// Определяет пользователя по адресу электронной почты и паролю
        /// </summary>
        /// <param name="email">E-mail пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Пользователь с заданными значениями параметров или null</returns>
        public static User GetUser(string email, string password)
        {
            var entity = new FreeForumEntities();
            User user = entity.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            entity.Dispose();
            return user;
        }
        /// <summary>
        /// Определяет пользователяей по логину в системе
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Коллекция пользователей с заданным логином или null</returns>
        public static IEnumerable<User> GetUsersByLogin(string login)
        {
            var entity = new FreeForumEntities();
            var users = entity.Users.Where(us => us.Login == login);
            return users;
        }

        /// <summary>
        /// Добавляет объект типа User в БД
        /// </summary>
        /// <param name="user">Добавляемый объект</param>
        public static void AddUser(User user)
        {
            var entity = new FreeForumEntities();
            entity.Users.Add(user);
            entity.SaveChanges();
        }

        public static IEnumerable<User> GetUsersList()
        {
            return new FreeForumEntities().Users;
        }

        public static void RemoveCookie(User user)
        {
            var entity = new FreeForumEntities();
            try
            {
                entity.Users.Find(user.Id).Cookie = "";
            }
                /// TODO: Logger
            catch (Exception) { }
            entity.SaveChanges();
        }
        #endregion

        #region Сообщения
        public static IEnumerable<Subject> GetSubjects(Func<Subject, bool> predicate = null)
        {
            if (predicate == null) predicate = subj => true;
            return new FreeForumEntities().Subjects; //.Where(predicate).AsEnumerable();
        }

        public static Message GetMessage(int id)
        {
            return new FreeForumEntities().Messages.Find(id); //.Where(predicate).AsEnumerable();
        }

        public static IEnumerable<Message> GetMessages(Func<Message, bool> predicate = null)
        {
            if (predicate == null) predicate = mes => true;
            return new FreeForumEntities().Messages.AsEnumerable(); //.Where(predicate).AsEnumerable();
        }
        #endregion 
    }
}