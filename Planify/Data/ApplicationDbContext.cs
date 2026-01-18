using Microsoft.EntityFrameworkCore;
using Planify.Models.Domain;

namespace Planify.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TaskItems> Tasks
        {
            get; set;

        }
    }
}
