using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Webapi.Repasitories.Interfaces
{
    public interface IGetImage
    {
        public Task<string> GetImageAsync(Guid Id);
    }
}
