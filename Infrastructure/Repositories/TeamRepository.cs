using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;
using AutoMapper;
using Infrastructure.DatabaseContext;
using Infrastructure.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProjectManagerApi.Data.Repositories
{
    public class TeamRepository : IBaseRepository<Team, int>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public TeamRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Team> Add(Team entity)
        {
            var team = mapper.Map<TeamEntity>(entity);
            await context.AddAsync(team);
            await context.SaveChangesAsync();
            return mapper.Map<Team>(team);
        }

        public async Task<Team> Delete(int id)
        {
            var entity = await Get(id);
            context.Teams.Remove(mapper.Map<TeamEntity>(entity));
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Team>> FindAll(Expression<Func<Team, bool>> expression)
        {
            var exp = expression.Compile();
            return mapper.Map<List<Team>>((await context.Teams.ToListAsync()).Where(x => exp(mapper.Map<Team>(x))));
        }

        public async Task<Team> FindFirst(Expression<Func<Team, bool>> expression)
        {
            var Users = (await FindAll(expression)).FirstOrDefault();
            return mapper.Map<Team>(Users);
        }

        public async Task<Team> Get(int id)
        {
            return await FindFirst(x => x.TeamId == id);
        }

        public async Task<List<Team>> GetAll()
        {
            return await FindAll(x => true);
        }

        public async Task<Team> Update(Team entity)
        {
            var lang = mapper.Map<TeamEntity>(entity);
            context.Update(lang);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
