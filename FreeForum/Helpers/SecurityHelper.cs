using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FreeForum.Helpers
{
    /// <summary>
    /// Класс, отвечающий за шифрование данных и обеспечение безопасности
    /// </summary>
    public class SecurityHelper
    {
        /// <summary>
        /// Выполняет хеширование
        /// </summary>
        /// <param name="input">Строка для хеширования</param>
        /// <returns>MD5 хеш-код введенной строки</returns>
        public static string Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}