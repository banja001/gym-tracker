using BuildingBlocks.Core.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Core.Domain.RepositoryInterfaces
{
    public interface IUserRepository : ICrudRepository<User>
    {
    }
}
