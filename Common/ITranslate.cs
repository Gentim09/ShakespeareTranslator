using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface ITranslate
    {
        Task<string> TranslateTextAsync(string text);
    }
}
