using Microsoft.EntityFrameworkCore;
using BerryTestProject1.Models;

namespace BerryTestProject1.Data 
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<UserData> UserData { get; set; }
        public DbSet<PersonDetails> PersonDetails { get; set; }
        public DbSet<Response> Response { get; set; }
        public DbSet<ResultCategory> ResultCategory { get; set; }
        public DbSet<Statement> Statement { get; set; }
        public DbSet<Score> Score { get; set; }
    }
}