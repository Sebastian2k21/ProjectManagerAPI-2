using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;
using AutoMapper;
using Infrastructure.DatabaseContext;
using Infrastructure.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace ProjectManagerApi.Data.Repositories
{
    public class TechRepository : IBaseRepository<Tech, int>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public TechRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Tech> Add(Tech entity)
        {
            await context.AddAsync(mapper.Map<TechEntity>(entity));
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Tech> Delete(int id)
        {
            var entity = await Get(id);
            context.Technologies.Remove(mapper.Map<TechEntity>(entity));
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Tech>> FindAll(Expression<Func<Tech, bool>> expression)
        {
            var exp = expression.Compile();
            return mapper.Map<List<Tech>>((await context.Technologies.ToListAsync()).Where(x => exp(mapper.Map<Tech>(x))));
        }

        public async Task<Tech> FindFirst(Expression<Func<Tech, bool>> expression)
        {
            var Users = (await FindAll(expression)).FirstOrDefault();
            return mapper.Map<Tech>(Users);
        }

        public async Task<Tech> Get(int id)
        {
            return await FindFirst(x => x.TechId == id);
        }

        public async Task<List<Tech>> GetAll()
        {
            return await FindAll(x => true);
        }

        public async Task<Tech> Update(Tech entity)
        {
            var lang = mapper.Map<TechEntity>(entity);
            context.Update(lang);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
