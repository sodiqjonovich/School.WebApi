using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School.Webapi.Data;
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

        public async Task<IEnumerable<Pupil>> GetAllAsync()
        {
            return await dbo.Pupils.ToListAsync();
        }

        public async Task<Pupil> GetAsync(Guid Id)
        {
            return await dbo.Pupils.FindAsync(Id);
        }

        public async Task<Pupil> UpdateAsync(Guid Id, Pupil obj)
        {
            obj.Id = Id;
            var newObj = dbo.Pupils.Attach(obj);
            newObj.State = EntityState.Modified;
            await dbo.SaveChangesAsync();
            return obj;
        }
    }
}
