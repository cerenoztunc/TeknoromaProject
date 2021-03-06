using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstracts.Repositories
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
    }
}
