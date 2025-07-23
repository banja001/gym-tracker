using BuildingBlocks.Core.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Core.Domain.RepositoryInterfaces
{
    public interface IWorkoutRepository : ICrudRepository<Workout>
    {
        IEnumerable<Workout> GetByUserId(long userId);
        IEnumerable<Workout> GetWorkoutsInMonth(int year, int month, long userId);
    }
}
