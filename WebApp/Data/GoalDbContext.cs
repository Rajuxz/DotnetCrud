using Microsoft.EntityFrameworkCore;
using WebApp.Models.Domain;

namespace WebApp.Data
{
    public class GoalDbContext: DbContext
    {
        public GoalDbContext(DbContextOptions<GoalDbContext> options) : base(options)
        {

        }

        public DbSet<GoalModel> Goal { get; set; }
    }
}
