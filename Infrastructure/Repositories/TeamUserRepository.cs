using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;
using AutoMapper;
using Infrastructure.DatabaseContext;
using Infrastructure.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProjectManagerApi.Data.Repositories
{
    public class TeamUserRepository : IBaseRepository<TeamUser, (int userId, int teamId, int RoleId)>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public TeamUserRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TeamUser> Add(TeamUser entity)
        {
            var temaUser = mapper.Map<TeamUserEntity>(entity);
            await context.AddAsync(temaUser);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TeamUser> Delete((int userId, int teamId, int RoleId) id)
        {
            var entity = await context.TeamUsers.FirstOrDefaultAsync(x => x.UserId == id.userId && x.TeamId == id.teamId && x.RoleId == id.RoleId);
            context.Remove(entity);
            await context.SaveChangesAsync();
            return mapper.Map<TeamUser>(entity);
        }

        public async Task<List<TeamUser>> FindAll(Expression<Func<TeamUser, bool>> expression)
        {
            var exp = expression.Compile();
            return mapper.Map<List<TeamUser>>((await context.TeamUsers.ToListAsync()).Where(x => exp(mapper.Map<TeamUser>(x))));
        }

        public async Task<TeamUser> FindFirst(Expression<Func<TeamUser, bool>> expression)
        {
            var Users = (await FindAll(expression)).FirstOrDefault();
            return mapper.Map<TeamUser>(Users);
        }

        public async Task<TeamUser> Get((int userId, int teamId, int RoleId) id)
        {
            return await FindFirst(x => x.UserId == id.userId && x.RoleId == id.RoleId && x.TeamId == id.teamId);
        }

        public async Task<List<TeamUser>> GetAll()
        {
            return await FindAll(x => true);
        }

        public async Task<TeamUser> Update(TeamUser entity)
        {
            var lang = mapper.Map<TeamUserEntity>(entity);
            context.Update(lang);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
