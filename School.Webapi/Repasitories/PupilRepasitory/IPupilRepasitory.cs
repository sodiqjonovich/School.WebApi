using School.Webapi.Entities.Models;
using School.Webapi.Repasitories.Interfaces;

namespace School.Webapi.Repasitories.PupilRepasitory
{
    public interface IPupilRepasitory
        :ICRUD<Pupil>,IGetAll<Pupil>, IGetImage
    {
    }
}
