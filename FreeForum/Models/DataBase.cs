using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeForum.Models
{
    public class DataBase
    {
        private static FreeForumEntities _entity = new FreeForumEntities();

        #region Пользователи
        /// <summary>
        /// Определяет пользователяей по кукам
        /// </summary>
        /// <param name="cookie">Куки пользователя</param>
        /// <returns>Пользователь с заданными куками или null</returns>
        public static User GetUserByCookie(string cookie)
        {
            return _entity.Users.FirstOrDefault(user => user.Cookie == cookie);
        }

        /// <summary>
        /// Определяет пользователя по адресу электронной почты
        /// </summary>
        /// <param name="email">E-mail пользователя</param>
        /// <returns>Пользователь с заданным адресом или null</returns>
        public static User GetUser(string email)
        {
            var users = _entity.Users.Where(us => us.Email == email);
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
            User user = _entity.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            _entity.Dispose();
            return user;
        }
        /// <summary>
        /// Определяет пользователяей по логину в системе
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Коллекция пользователей с заданным логином или null</returns>
        public static IEnumerable<User> GetUsersByLogin(string login)
        {
            var users = _entity.Users.Where(us => us.Login == login);
            return users;
        }

        /// <summary>
        /// Добавляет объект типа User в БД
        /// </summary>
        /// <param name="user">Добавляемый объект</param>
        public static void AddUser(User user)
        {
            _entity.Users.Add(user);
            _entity.SaveChanges();
        }

        public static IEnumerable<User> GetUsers()
        {
            return _entity.Users;
        }

        public static void RemoveCookie(User user)
        {
            try
            {
                _entity.Users.Find(user.Id).Cookie = "";
            }
                /// TODO: Logger
            catch (Exception) { }
            _entity.SaveChanges();
        }
        #endregion

        #region Беседы
        public static IEnumerable<Subject> GetSubjects(Func<Subject, bool> predicate = null)
        {
            if (predicate == null) predicate = subj => true;
            return _entity.Subjects; //.Where(predicate).AsEnumerable();
        }

        public static int AddSubject(Subject subject)
        {
            var added = _entity.Subjects.Add(subject);
            _entity.SaveChanges();
            return added.Id;
        }
        #endregion

        #region Сообщения
        public static Message GetMessage(int id)
        {
            return _entity.Messages.Find(id); //.Where(predicate).AsEnumerable();
        }

        public static IEnumerable<Message> GetMessages(Func<Message, bool> predicate = null)
        {
            if (predicate == null) predicate = mes => true;
            return _entity.Messages.AsEnumerable(); //.Where(predicate).AsEnumerable();
        }

        public static int AddMessage(Message message)
        {
            message = _entity.Messages.Add(message);
            _entity.SaveChanges();
            return message.Id;
        }
        #endregion 
    }
}