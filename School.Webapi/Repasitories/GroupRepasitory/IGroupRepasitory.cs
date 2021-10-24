using School.Webapi.Entities.Models;
using School.Webapi.Repasitories.Interfaces;

namespace School.Webapi.Repasitories.GroupRepasitory
{
    public interface IGroupRepasitory : 
        ICRUD<Group>, IGetAll<Group>
    {
    }
}
