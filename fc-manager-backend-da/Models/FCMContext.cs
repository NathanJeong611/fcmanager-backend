using Microsoft.EntityFrameworkCore;

namespace fc_manager_backend_da.Models
{
    public class FCMContext : DbContext
    {
        public FCMContext() { }
        public FCMContext(DbContextOptions<FCMContext> options) : base(options)
        {

        }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchRecord> MatchRecords { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=FCManager;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseIdentityColumns();
        }
    }
}