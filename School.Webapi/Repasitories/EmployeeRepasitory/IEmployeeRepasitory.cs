using School.Webapi.Entities.Models;
using School.Webapi.Repasitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Webapi.Repasitories.EmployeeRepasitory
{
    public interface IEmployeeRepasitory
        :ICRUD<Employee>,IGetAll<Employee>
    {
    }
}
