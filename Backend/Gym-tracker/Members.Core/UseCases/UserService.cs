using AutoMapper;
using BuildingBlocks.Core.UseCases;
using Members.API.Dtos;
using Members.API.Public;
using Members.Core.Domain;
using Members.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Core.UseCases
{
    public class UserService : CrudService<UserDto, User>, IUserService
    {
        protected readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
            _mapper = mapper;
            _userRepository = crudRepository;
        }
    }
}
