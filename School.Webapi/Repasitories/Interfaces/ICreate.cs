using System.Threading.Tasks;

namespace School.Webapi.Repasitories.Interfaces
{
    public interface ICreate<T>
    {
        public Task<T> CreateAsync(T obj);
    }
}
