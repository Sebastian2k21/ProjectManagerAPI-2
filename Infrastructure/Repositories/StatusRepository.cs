using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;
using AutoMapper;
using Infrastructure.DatabaseContext;
using Infrastructure.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProjectManagerApi.Data.Repositories
{
    public class StatusRepository : IBaseRepository<Status, int>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public StatusRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Status> Add(Status entity)
        {
            await context.AddAsync(mapper.Map<StatusEntity>(entity));
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Status> Delete(int id)
        {
            var entity = await Get(id);
            context.Statuses.Remove(mapper.Map<StatusEntity>(entity));
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Status>> FindAll(Expression<Func<Status, bool>> expression)
        {
            var exp = expression.Compile();
            return mapper.Map<List<Status>>((await context.Statuses.ToListAsync()).Where(x => exp(mapper.Map<Status>(x))));
        }

        public async Task<Status> FindFirst(Expression<Func<Status, bool>> expression)
        {
            var Users = (await FindAll(expression)).FirstOrDefault();
            return mapper.Map<Status>(Users);
        }

        public async Task<Status> Get(int id)
        {
            return await FindFirst(x => x.StatusId == id);
        }

        public async Task<List<Status>> GetAll()
        {
            return await FindAll(x => true);
        }

        public async Task<Status> Update(Status entity)
        {
            var lang = mapper.Map<StatusEntity>(entity);
            context.Update(lang);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
