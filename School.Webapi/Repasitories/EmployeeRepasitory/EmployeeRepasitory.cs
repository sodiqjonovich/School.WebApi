using Microsoft.EntityFrameworkCore;
using School.Webapi.Data;
using School.Webapi.Entities;
using School.Webapi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Webapi.Repasitories.EmployeeRepasitory
{
    public class EmployeeRepasitory : IEmployeeRepasitory
    {
        private readonly AppDBContext dbo;

        public EmployeeRepasitory(AppDBContext appDBContext)
        {
            this.dbo = appDBContext;
        }

        public async Task<Employee> CreateAsync(Employee obj)
        {
            if(obj != null)
            {
                await dbo.Employees.AddAsync(obj);
                await dbo.SaveChangesAsync();
            }
            return obj;
        }

        public async Task DeleteAsync(Guid Id)
        {
            var obj = await dbo.Employees.FindAsync(Id);
            if(obj != null)
            {
                dbo.Employees.Remove(obj);
                await dbo.SaveChangesAsync();
            }
        }

        public async Task<PagedList<Employee>> GetAllAsync(
            PaginationParametres paginationParametres)
        {
            return await PagedList<Employee>.ToPagedListAsync(dbo.Employees,
                    paginationParametres.PageNumber,
                    paginationParametres.PageSize);
        }

        public async Task<Employee> GetAsync(Guid Id)
        {
            return await dbo.Employees.FindAsync(Id);
        }

        public async Task<Employee> UpdateAsync(Guid Id, Employee obj)
        {
            obj.Id = Id;
            await dbo.SaveChangesAsync();
            return obj;
        }
    }
}
