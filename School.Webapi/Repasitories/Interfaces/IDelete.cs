using System;
using System.Threading.Tasks;

namespace School.Webapi.Repasitories.Interfaces
{
    public interface IDelete<T>
    {
        public Task DeleteAsync(Guid Id);
    }
}
