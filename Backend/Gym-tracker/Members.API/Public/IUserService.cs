using BuildingBlocks.Core.UseCases;
using FluentResults;
using Members.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.API.Public
{
    public interface IUserService
    {
        Result<PagedResult<UserDto>> GetPaged(int page, int pageSize);
    }
}
