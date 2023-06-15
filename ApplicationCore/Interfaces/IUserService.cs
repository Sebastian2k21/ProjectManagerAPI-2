using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(User user, string password, List<int> technologies, List<int> languages);
        Task<string> Auth(string email, string password);
   
        //Task EditProfileInfo(ProjectManagerApi.Dto.UserEditDto updatedUser);
    }
}
