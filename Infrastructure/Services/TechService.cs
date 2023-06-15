using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public class TechService : ITechService
    {
        private readonly IBaseRepository<Tech, int> techRepository;

        public TechService(IBaseRepository<Tech, int> techRepository)
        {
            this.techRepository = techRepository;
        }


        public async Task<IEnumerable<Tech>> GetAllTechs()
        {
            return await techRepository.GetAll();
        }

        public async Task<Tech> AddNewTech(Tech tech)
        {
            await techRepository.Add(tech);
            return tech;
        }
    }
}
