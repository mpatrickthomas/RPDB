using Microsoft.EntityFrameworkCore;
using RPDB.Data.Entities;
using RPDB.Data.Entities.LinkingTables;

namespace RPDB.Data
{
    public class RPDBContext : DbContext
    {

        public RPDBContext(DbContextOptions<RPDBContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Queen> Queens { get; set; }
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<JudgeSeason> JudgeSeasons { get; set; }
        public DbSet<QueenSeason> QueenSeasons { get; set; }
        public DbSet<QueenGenre> QueenGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Judge>()
                .Property(j => j.IsGuest)
                .HasDefaultValue(false);

            #region Primary Key Setup
            modelBuilder.Entity<JudgeSeason>()
                .HasKey(js => new { js.JudgeId, js.SeasonId });
            modelBuilder.Entity<QueenSeason>()
                .HasKey(qs => new { qs.QueenId, qs.SeasonId });
            modelBuilder.Entity<QueenGenre>()
                .HasKey(qg => new { qg.QueenId, qg.GenreId });
            #endregion

            #region JudgeSeason Associations
            modelBuilder.Entity<JudgeSeason>()
                .HasOne(js => js.Judge)
                .WithMany(j => j.JudgeSeasons)
                .HasForeignKey(js => js.JudgeId);
            modelBuilder.Entity<JudgeSeason>()
                .HasOne(js => js.Season)
                .WithMany(s => s.JudgeSeasons)
                .HasForeignKey(js => js.SeasonId);
            #endregion

            #region QueenSeason Associations
            modelBuilder.Entity<QueenSeason>()
                .HasOne(qs => qs.Queen)
                .WithMany(q => q.QueenSeasons)
                .HasForeignKey(qs => qs.QueenId);
            modelBuilder.Entity<QueenSeason>()
                .HasOne(qs => qs.Season)
                .WithMany(s => s.QueenSeasons)
                .HasForeignKey(qs => qs.SeasonId);
            #endregion

            #region QueenGenre Associations
            modelBuilder.Entity<QueenGenre>()
                .HasOne(qg => qg.Queen)
                .WithMany(q => q.QueenGenres)
                .HasForeignKey(qg => qg.QueenId);
            modelBuilder.Entity<QueenGenre>()
                .HasOne(qg => qg.Genre)
                .WithMany(g => g.QueenGenres)
                .HasForeignKey(qg => qg.GenreId);
            #endregion
        }
    }
}
