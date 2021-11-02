using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School.Webapi.Data;
using School.Webapi.Entities;
using School.Webapi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Webapi.Repasitories.PupilRepasitory
{
    public class PupilRepasitory : IPupilRepasitory
    {
        private readonly AppDBContext dbo;

        public PupilRepasitory(AppDBContext appDBContext)
        {
            this.dbo = appDBContext;
        }

        public async Task<Pupil> CreateAsync(Pupil obj)
        {
            if (obj != null)
            {
                await dbo.Pupils.AddAsync(obj);
                await dbo.SaveChangesAsync();
            }
            return obj;
        }

        public async Task DeleteAsync(Guid Id)
        {
            var obj = await dbo.Pupils.FindAsync(Id);
            if (obj != null)
            {
                dbo.Pupils.Remove(obj);
                await dbo.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Pupil>> GetAllAsync(
            PaginationParametres paginationParametres)
        {
            return await dbo.Pupils
                .Skip((paginationParametres.PageNumber - 1) * paginationParametres.PageSize)
                .Take(paginationParametres.PageSize)
                .ToListAsync();
        }

        public async Task<Pupil> GetAsync(Guid Id)
        {
            return await dbo.Pupils.FindAsync(Id);
        }

        public async Task<string> GetImageAsync(Guid Id)
        {
            using (dbo)
            {
                string t = (await dbo.Pupils.FindAsync(Id)).ImageName.ToString();
                return t;
            }
        }

        public async Task<Pupil> UpdateAsync(Guid Id, Pupil obj)
        {
            obj.Id = Id;
            await dbo.SaveChangesAsync();
            return obj;
        }
    }
}
