using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ITechService
    {
        Task<IEnumerable<Tech>> GetAllTechs();
        Task<Tech> AddNewTech(Tech tech);
    }
}
