using BuildingBlocks.Core.UseCases;
using BuildingBlocks.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Training.Core.Domain;
using Training.Core.Domain.RepositoryInterfaces;

namespace Training.Infrastructure.Database.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly TrainingContext _dbContext;
        private readonly DbSet<Workout> _dbSet;

        public WorkoutRepository(TrainingContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Workout>();
        }
        public Workout Create(Workout entity)
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

        public Workout Get(long id)
        {

            var workout = _dbSet
                .Where(t => t.Id == id)
                .FirstOrDefault();
            return workout ?? throw new KeyNotFoundException("Not found: " + id);
        }

        public IEnumerable<Workout> GetByUserId(long userId)
        {
            var workouts = _dbSet.Where(t => t.UserId == userId).ToList();

            return workouts;
        }

        public PagedResult<Workout> GetPaged(int page, int pageSize)
        {
            var task = _dbSet.GetPaged(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public Workout Update(Workout entity)
        {
            var existing = _dbContext.Workouts.Find(entity.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Workout with id {entity.Id} not found.");

            _dbContext.Entry(existing).CurrentValues.SetValues(entity);

            _dbContext.SaveChanges();

            return existing;
        }

    }
}
