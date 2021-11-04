using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School.Webapi.Data;
using School.Webapi.Entities;
using School.Webapi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Webapi.Repasitories.GroupRepasitory
{
    public class GroupRepasitory : IGroupRepasitory
    {
        private readonly AppDBContext dbo;

        public GroupRepasitory(AppDBContext appDBContext)
        {
            this.dbo = appDBContext;
        }
        public async Task<Group> CreateAsync(Group obj)
        {
            if (obj != null)
            {
                await dbo.Groups.AddAsync(obj);
                await dbo.SaveChangesAsync();
            }
            return obj;
        }

        public async Task DeleteAsync(Guid Id)
        {
            var obj = await dbo.Groups.FindAsync(Id);
            if(obj != null)
            {
                dbo.Groups.Remove(obj);
                await dbo.SaveChangesAsync();
            }
        }

        public async Task<PagedList<Group>> GetAllAsync(
            PaginationParametres paginationParametres)
        {
            return await PagedList<Group>.ToPagedListAsync(dbo.Groups,
                    paginationParametres.PageNumber,
                    paginationParametres.PageSize);
        }

        public async Task<Group> GetAsync(Guid Id)
        {
            var k = await dbo.Groups.FindAsync(Id);
            return k;
        }

        public async Task<Group> UpdateAsync(Guid Id, Group obj)
        {
            obj.Id = Id;
            var newObj = dbo.Groups.Attach(obj);
            newObj.State = EntityState.Modified;
            await dbo.SaveChangesAsync();
            return obj;
        }
    }
}
