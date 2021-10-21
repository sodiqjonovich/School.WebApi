using System;
using System.Threading.Tasks;

namespace School.Webapi.Repasitories.Interfaces
{
    public interface IRead<T>
    {
        public Task<T> GetAsync(Guid Id);
    }
}
