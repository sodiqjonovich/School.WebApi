using School.Webapi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Webapi.Repasitories.Interfaces
{
    public interface IGetAll<T>
    {
        public Task<PagedList<T>> GetAllAsync(
            PaginationParametres paginationParametres);
    }
}
