using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;
using AutoMapper;
using Infrastructure.DatabaseContext;
using Infrastructure.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectManagerApi.Data.Repositories
{
    public class LanguageRepository : IBaseRepository<Language, int>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public LanguageRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Language> Add(Language entity)
        {
            await context.AddAsync(mapper.Map<LanguageEntity>(entity));
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Language> Delete(int id)
        {
            var entity = await Get(id);
            context.Languages.Remove(mapper.Map<LanguageEntity>(entity));
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Language>> FindAll(Expression<Func<Language, bool>> expression)
        {
            var exp = expression.Compile();
            return mapper.Map<List<Language>>((await context.Languages.ToListAsync()).Where(x => exp(mapper.Map<Language>(x))));
        }

        public async Task<Language> FindFirst(Expression<Func<Language, bool>> expression)
        {
            var Users = (await FindAll(expression)).FirstOrDefault();
            return mapper.Map<Language>(Users);
        }

        public async Task<Language> Get(int id)
        {
            return await FindFirst(x => x.LanguageId == id);
        }

        public async Task<List<Language>> GetAll()
        {
            return await FindAll(x => true);
        }

        public async Task<Language> Update(Language entity)
        {
            var lang = mapper.Map<LanguageEntity>(entity);
            context.Update(lang);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
