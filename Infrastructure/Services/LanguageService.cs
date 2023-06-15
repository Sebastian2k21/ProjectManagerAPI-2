using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public class LanguageService : ILanguageService
    {
        private readonly IBaseRepository<Language, int> languageRepository;

        public LanguageService(IBaseRepository<Language, int> languageRepository)
        {
            this.languageRepository = languageRepository;
        }


        public async Task<IEnumerable<Language>> GetAllLanguages()
        {
            return await languageRepository.GetAll();
        }

        public async Task<Language> AddNewLanguage(Language language)
        {
            await languageRepository.Add(language);
            return language;
        }
    }
}
