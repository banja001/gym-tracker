using BuildingBlocks.Core.UseCases;
using BuildingBlocks.Infrastructure.Database;
using Members.Core.Domain;
using Members.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly MembersContext _dbContext;
        private readonly DbSet<User> _dbSet;

        public UserRepository(MembersContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<User>();
        }
        public User Create(User entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(long id)
        {
            var entity = Get(id);
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public User Get(long id)
        {

            var user = _dbSet
                .Where(t => t.Id == id)
                .FirstOrDefault();
            return user ?? throw new KeyNotFoundException("Not found: " + id);
        }

        public PagedResult<User> GetPaged(int page, int pageSize)
        {
            var task = _dbSet.GetPaged(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public User Update(User entity)
        {

            try
            {
                _dbContext.Update(entity);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new KeyNotFoundException(e.Message);
            }
            return entity;
        }
        public User? GetByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Username == username);
        }
        public void SetRefreshToken(string username, string refreshToken)
        {
            var user = GetByUsername(username);
            user.RefreshToken = refreshToken;
            _dbContext.SaveChanges();
        }
        public bool Exists(string username)
        {
            return _dbContext.Users.Any(user => user.Username == username);
        }
    }
}
