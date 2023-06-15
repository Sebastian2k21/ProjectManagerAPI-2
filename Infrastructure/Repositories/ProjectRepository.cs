using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;
using AutoMapper;
using Infrastructure.DatabaseContext;
using Infrastructure.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProjectManagerApi.Data.Repositories
{
    public class ProjectRepository : IBaseRepository<Project, int>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ProjectRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Project> Add(Project entity)
        {
            var project = mapper.Map<ProjectEntity>(entity);
            for (int i = 0; i < project.Languages.Count; i++)
            {
                project.Languages[i] = await context.Languages.FirstOrDefaultAsync(x => x.LanguageId == project.Languages[i].LanguageId);
            }
            for (int i = 0; i < project.Technologies.Count; i++)
            {
                project.Technologies[i] = await context.Technologies.FirstOrDefaultAsync(x => x.TechId == project.Technologies[i].TechId);
            }

            await context.AddAsync(project);
            await context.SaveChangesAsync();
            return mapper.Map<Project>(project);
        }

        public async Task<Project> Delete(int id)
        {
            var entity = await Get(id);
            context.Projects.Remove(mapper.Map<ProjectEntity>(entity));
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Project>> FindAll(Expression<Func<Project, bool>> expression)
        {
            var exp = expression.Compile();
            return mapper.Map<List<Project>>((await context.Projects.Include(x=> x.Languages).Include(x => x.Technologies).ToListAsync()).Where(x => exp(mapper.Map<Project>(x))));
        }

        public async Task<Project> FindFirst(Expression<Func<Project, bool>> expression)
        {
            var Users = (await FindAll(expression)).FirstOrDefault();
            return mapper.Map<Project>(Users);
        }

        public async Task<Project> Get(int id)
        {
            return await FindFirst(x => x.ProjectId == id);
        }

        public async Task<List<Project>> GetAll()
        {
            return await FindAll(x => true);
        }

        public async Task<Project> Update(Project entity)
        {
            var project = await context.Projects.FirstOrDefaultAsync(x => x.ProjectId == entity.ProjectId);
            mapper.Map(entity, project);
            context.Update(project);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
