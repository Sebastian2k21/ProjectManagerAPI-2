using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;
using AutoMapper;
using Infrastructure.DatabaseContext;
using Infrastructure.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProjectManagerApi.Data.Repositories
{
    public class ProjectStatusRepository : IBaseRepository<ProjectStatus, int>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ProjectStatusRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ProjectStatus> Add(ProjectStatus entity)
        {
            await context.AddAsync(mapper.Map<ProjectStatusEntity>(entity));
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<ProjectStatus> Delete(int id)
        {
            var entity = await Get(id);
            context.ProjectStatuses.Remove(mapper.Map<ProjectStatusEntity>(entity));
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<ProjectStatus>> FindAll(Expression<Func<ProjectStatus, bool>> expression)
        {
            var exp = expression.Compile();
            return mapper.Map<List<ProjectStatus>>((await context.ProjectStatuses.ToListAsync()).Where(x => exp(mapper.Map<ProjectStatus>(x))));
        }

        public async Task<ProjectStatus> FindFirst(Expression<Func<ProjectStatus, bool>> expression)
        {
            var Users = (await FindAll(expression)).FirstOrDefault();
            return mapper.Map<ProjectStatus>(Users);
        }

        public async Task<ProjectStatus> Get(int id)
        {
            return await FindFirst(x => x.ProjectStatusId == id);
        }

        public async Task<List<ProjectStatus>> GetAll()
        {
            return await FindAll(x => true);
        }

        public async Task<ProjectStatus> Update(ProjectStatus entity)
        {
            var lang = mapper.Map<ProjectStatusEntity>(entity);
            context.Update(lang);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
