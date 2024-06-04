using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyProject.Common
{
    public static class TextValidationService
    {
        public static TextValidator TextRules(this string text, string sourceName) => new TextValidator(text, sourceName);
    }
}
