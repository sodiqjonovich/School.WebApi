using School.Webapi.Entities.Models;
using School.Webapi.Repasitories.Interfaces;

namespace School.Webapi.Repasitories.NewRepasitory
{
    public interface INewRepasitory 
        : ICRUD<New>, IGetAll<New>
    {

    }
}
