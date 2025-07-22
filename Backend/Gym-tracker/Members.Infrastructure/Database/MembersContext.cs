using Members.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Infrastructure.Database
{
    public class MembersContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MembersContext(DbContextOptions<MembersContext> options) : base(options) { }
    }
}
