using System;
using System.Threading.Tasks;

namespace School.Webapi.Repasitories.Interfaces
{
    public interface IUpdate<T>
    {
        public Task<T> UpdateAsync(Guid Id, T obj);
    }
}
