using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;


namespace EmptyProject.Common
{
    public class TextValidator
    {
        private readonly string _sourceName;
        private readonly string _text;

        private string _result = "Успешно";
        private bool _success = true;

        public TextValidator(string text, string sourceName)
            => (_text, _sourceName) = (text, sourceName);

        /// <summary>
        /// Проверяет текст на пустоту
        /// </summary>
        public TextValidator NotEmpty()
        {
            if (String.IsNullOrWhiteSpace(_text))
            {
                _success = false;
                _result = $"Поле ввода пусто. Источник ошибки: {_sourceName}";
            }
            else
            {
                _text.Trim();
            }
            return this;
        }

        /// <summary>
        /// Проверяет текст на минимальную длину
        /// </summary>
        public TextValidator MinLenght(int count)
        {
            if(_text.Length < count)
            {
                _success = false;
                _result = $"Длина текста должна быть не меньше: {count}. Источник ошибки: {_sourceName}";
            }
            return this;
        }

        /// <summary>
        /// Проверяет текст на максимальную длину
        /// </summary>
        public TextValidator MaxLenght(int count)
        {
            if(_text.Length >= count)
            {
                _success = false;
                _result = $"Длина текста должна быть не больше: {count}. Источник ошибки: {_sourceName}";
            }
            return this;
        }

        /// <summary>
        /// Проверяет правильность пароля
        /// </summary>
        public TextValidator Password()
        {
            Regex regex = new Regex("^[а-яА-ЯёЁa-zA-Z0-9!@#$%^&*()_+={};\':\"\\|,.<>/?]+$");
            if (!regex.IsMatch(_text))
            {
                _result = "Пароль может содержать только латиницу, кириллицу, цифры и следующие спец. символы: !@#$%^&*()_+={};':\"\\|,.<>/?." +
                    $" Источник ошибки: {_sourceName}";
                _success = false;
            }
            Regex regex2 = new Regex("^(?=(.*[a-zA-Zа-яА-я]){3}).*$");
            if (!regex2.IsMatch(_text))
            {
                _result = $"Пароль должен содержать как минимум 3 буквы (латиница и/или кириллица). Источник ошибки: {_sourceName}";
                _success = false;
            }
            Regex regex3 = new Regex("^(?=(.*\\d){2}).*$");
            if (!regex3.IsMatch(_text))
            {
                _result = $"Пароль должен содержать как минимум 2 цифры. Источник ошибки: {_sourceName}";
                _success = false;
            }
            return this;
        }

        /// <summary>
        /// Проверяет правильность имени/фамилии/отчетсва/названия
        /// </summary>
        public TextValidator Name()
        {
            Regex regex = new Regex("^[а-яА-ЯёЁa-zA-Z0-9]+$");
            if (!regex.IsMatch(_text))
            {
                _result = $"Текст может содержать только латиницу, кириллицу и цифры. Источник ошибки: {_sourceName}";
                _success = false;
            }
            return this;
        }

        /// <summary>
        /// Проверяет текст на правильность почты
        /// </summary>
        public TextValidator Email(string email)
        {
            try
            {
                _ = new MailAddress(email);
            } 
            catch (FormatException)
            {
                _result = $"Почта введена неверно. Источник ошибки: {_sourceName}";
                _success = false;
            }
            return this;
        }

        /// <summary>
        /// Возвращает результат проверок
        /// </summary>
        /// <returns>true - если ни одна из проверок не нашла ошибку, иначе - false</returns>
        public bool Validate(out string result)
        {
            result = _result;
            return _success;
        }
    }
}
