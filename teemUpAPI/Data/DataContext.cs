using Microsoft.EntityFrameworkCore;
using teemUpAPI.Models;

namespace teemUpAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Users> users { get; set; }
        public DbSet<Teams> teams { get; set; }
        public DbSet<Tasks> tasks { get; set; }
        public DbSet<teamMembers> teamMembers { get; set; }
        public DbSet<teemUpAPI.Models.dutyTypes> dutyTypes { get; set; }
        public DbSet<teemUpAPI.Models.taskAssignment> taskAssignment { get; set; }
        public DbSet<teemUpAPI.Models.license> license { get; set; }
        public DbSet<teemUpAPI.Models.licenseTypes> licenseTypes { get; set; }
        public DbSet<teemUpAPI.Models.userPositions> userPositions { get; set; }



    }
}
