using ApplicationCore.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Commons.Repository
{
    public static class RepositoryExtension
    {
        public static async Task<List<T>> GetCollectionFromDB<T, TKey>(this IBaseRepository<T, TKey> repository, List<TKey> ids, string? errorMessage = null) where T : class where TKey : struct
        {
            List<T> items = new List<T>();
            foreach (var id in ids)
            {
                items.Add(await repository.Get(id) ?? throw new InvalidItemException(errorMessage));
            }
            return items;
        }
    }
}
