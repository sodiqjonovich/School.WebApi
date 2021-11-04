using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School.Webapi.Data;
using School.Webapi.Entities;
using School.Webapi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Webapi.Repasitories.NewRepasitory
{
    public class NewRepasitory : INewRepasitory
    {
        private readonly AppDBContext dbo;

        public NewRepasitory(AppDBContext appDBContext)
        {
            this.dbo = appDBContext;
        }

        public async Task<New> CreateAsync(New obj)
        {
            if (obj != null)
            {
                await dbo.News.AddAsync(obj);
                await dbo.SaveChangesAsync();
            }
            return obj;
        }

        public async Task DeleteAsync(Guid Id)
        {
            var obj = await dbo.News.FindAsync(Id);
            if (obj != null)
            {
                dbo.News.Remove(obj);
                await dbo.SaveChangesAsync();
            }
        }

        public async Task<PagedList<New>> GetAllAsync(
            PaginationParametres paginationParametres)
        {
            return await PagedList<New>.ToPagedListAsync(dbo.News,
                    paginationParametres.PageNumber,
                    paginationParametres.PageSize);
        }

        public async Task<New> GetAsync(Guid Id)
        {
            return await dbo.News.FindAsync(Id);
        }

        public async Task<New> UpdateAsync(Guid Id, New obj)
        {
            obj.Id = Id;
            await dbo.SaveChangesAsync();
            return obj;
        }
    }
}
