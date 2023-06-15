using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;
using AutoMapper;
using Infrastructure.DatabaseContext;
using Infrastructure.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProjectManagerApi.Data.Repositories
{
    public class UserRepository : IBaseRepository<User, int>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public UserRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<User> Add(User entity)
        {
            var user = mapper.Map<UserEntity>(entity);

            for(int i = 0; i < user.Laguages.Count; i++)
            {
                user.Laguages[i] = await context.Languages.FirstOrDefaultAsync(x => x.LanguageId == user.Laguages[i].LanguageId);
            }
            for (int i = 0; i < user.Technologies.Count; i++)
            {
                user.Technologies[i] = await context.Technologies.FirstOrDefaultAsync(x => x.TechId == user.Technologies[i].TechId);
            }

            await context.AddAsync(user);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> Delete(int id)
        {
            var entity = await Get(id);
            context.Users.Remove(mapper.Map<UserEntity>(entity));
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<User>> FindAll(Expression<Func<User, bool>> expression)
        {
            var exp = expression.Compile();
            return mapper.Map<List<User>>((await context.Users.ToListAsync()).Where(x => exp(mapper.Map<User>(x))));
        }

        public async Task<User> FindFirst(Expression<Func<User, bool>> expression)
        {
            var Users = (await FindAll(expression)).FirstOrDefault();
            return mapper.Map<User>(Users);
        }

        public async Task<User> Get(int id)
        {
            return await FindFirst(x => x.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await FindAll(x => true);
        }

        public async Task<User> Update(User entity)
        {
            var lang = mapper.Map<UserEntity>(entity);
            context.Update(lang);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
