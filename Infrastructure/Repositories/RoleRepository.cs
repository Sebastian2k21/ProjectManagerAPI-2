namespace ProjectManagerApi.Data.Repositories
{
    using ApplicationCore.Commons.Repository;
    using ApplicationCore.Models;
    using AutoMapper;
    using Infrastructure.DatabaseContext;
    using Infrastructure.EF.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
    using System.Linq;
    using System.Linq.Expressions;

    namespace ProjectManagerApi.Data.Repositories
    {
        public class RoleRepository : IBaseRepository<Role, int>
        {
            private readonly AppDbContext context;
            private readonly IMapper mapper;

            public RoleRepository(AppDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<Role> Add(Role entity)
            {
                await context.AddAsync(mapper.Map<TeamRoleEntity>(entity));
                await context.SaveChangesAsync();
                return entity;
            }

            public async Task<Role> Delete(int id)
            {
                var entity = await Get(id);
                context.TeamRoles.Remove(mapper.Map<TeamRoleEntity>(entity));
                await context.SaveChangesAsync();
                return entity;
            }

            public async Task<List<Role>> FindAll(Expression<Func<Role, bool>> expression)
            {
                var exp = expression.Compile();
                return mapper.Map<List<Role>>((await context.TeamRoles.ToListAsync()).Where(x => exp(mapper.Map<Role>(x))));
            }

            public async Task<Role> FindFirst(Expression<Func<Role, bool>> expression)
            {
                var Users = (await FindAll(expression)).FirstOrDefault();
                return mapper.Map<Role>(Users);
            }

            public async Task<Role> Get(int id)
            {
                return await FindFirst(x => x.RoleId == id);
            }

            public async Task<List<Role>> GetAll()
            {
                return await FindAll(x => true);
            }

            public async Task<Role> Update(Role entity)
            {
                var lang = mapper.Map<TeamRoleEntity>(entity);
                context.Update(lang);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }

}
