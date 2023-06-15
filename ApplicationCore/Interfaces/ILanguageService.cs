using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ILanguageService
    {
        Task<IEnumerable<Language>> GetAllLanguages();
        Task<Language> AddNewLanguage(Language language);


    }
}
