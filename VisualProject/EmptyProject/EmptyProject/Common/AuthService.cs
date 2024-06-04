using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyProject.Common
{
    public class AuthService
    {
        /// <summary>
        /// Текущий вошедший пользователь
        /// </summary>
        public object currentUser = null;
        
        /// <summary>
        /// Выполняет вход в аккаунт
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>true - если вход успешен, иначе - false</returns>
        public bool LogIn(string login, string password)
        {
            return false;
        }

        /// <summary>
        /// Выполняет выход из текущей учетной записи
        /// </summary>
        /// <returns></returns>
        public bool LogOut()
        {
            if (currentUser != null)
            {
                currentUser = null;
                // to authpage

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
