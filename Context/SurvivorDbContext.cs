using Microsoft.EntityFrameworkCore;
using PatikaSurvivor.Entities;

namespace PatikaSurvivor.Context
{
    public class SurvivorDbContext : DbContext
    {
        public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options) : base(options) { }

        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<CompetitorEntity> Competitors => Set<CompetitorEntity>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CompetitorEntity>().HasQueryFilter(x=>x.IsDeleted==false);
            modelBuilder.Entity<CategoryEntity>().HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<CategoryEntity>().HasData(
                 new CategoryEntity { Id = 1, Name = "Ünlüler"},
                 new CategoryEntity { Id = 2, Name = "Gönüllüler"}              
            );

            modelBuilder.Entity<CompetitorEntity>().HasData(
                new CompetitorEntity { Id = 1, FirstName = "Acun", LastName = "Ilıcalı",CategoryId = 1 },
                new CompetitorEntity { Id = 2, FirstName = "Fatih", LastName = "Terim", CategoryId = 2 },
                new CompetitorEntity { Id = 3, FirstName = "Sezen", LastName = "Aksu", CategoryId = 1 }
            );
            base.OnModelCreating(modelBuilder);
        }

        



    }
}
