using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FreeForum.Models
{
    public class UserModel
    {
        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Некорректный Email")]
        [EmailAddress(ErrorMessage = "Некорректный Email")]
        [Display(Name = "Адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        [CustomAttributes.RegistrationValidation(false, ErrorMessage = "Пользователь с таким адресом электронной почты уже зарегистрирован в системе")]
        public string Email { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        [Required(ErrorMessage = "*")]
        [Display(Name = "Логин")]
        [MinLength(6, ErrorMessage = "Логин должен составлять не менее 6 символов")]
        [CustomAttributes.RegistrationValidation(true, ErrorMessage = "Пользователь с таким именем уже зарегистрирован в системе")]
        public string Login { get; set; }


        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "*")]
        [MinLength(6, ErrorMessage = "Пароль должен составлять не менее 6 символов")]
        [Display(Name = "Пароль", Prompt = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Повторный пароль
        /// </summary>
        [Required(ErrorMessage = "*")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Повторите пароль")]
        public string PasswordConfirm { get; set; }
    }
}