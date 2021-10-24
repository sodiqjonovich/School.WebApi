using Microsoft.EntityFrameworkCore;
using School.Webapi.Data;
using School.Webapi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Webapi.Repasitories.InformationRepasitory
{
    public class InformationRepasitory 
        : IInformationRepasitory
    {
        private readonly AppDBContext dbo;

        public InformationRepasitory(AppDBContext appDBContext)
        {
            this.dbo = appDBContext;
        }
        public async Task<Information> Get()
        {
            return await dbo.Informations.FirstOrDefaultAsync();
        }

        public async Task<Information> UpdateAsync(Guid Id, 
            Information obj)
        {
            obj.Id = Id;
            var newObj = dbo.Informations.Attach(obj);
            newObj.State = EntityState.Modified;
            await dbo.SaveChangesAsync();
            return obj;
        }
    }
}
