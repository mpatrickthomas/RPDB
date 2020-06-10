using RPDB.Data.Entities;
using RPDB.Data.Entities.LinkingTables;
using System;
using System.Linq;

namespace RPDB.Data
{
    public class DbInit
    {
        public static void Initialize(RPDBContext context)
        {
            if (context.Queens.Any()) return; // DB has already been seeded

            #region Add Queens

            var queens = new Queen[]
            {
                new Queen
                {
                    Name = "Trixie Mattel",
                    Hometown = "Milwuakee"
                },
                new Queen
                {
                    Name = "Shangela",
                    Hometown = "Paris"
                },
                new Queen
                {
                    Name = "Katya",
                    Hometown = "Boston"
                },
                new Queen
                {
                    Name = "Jujubee",
                    Hometown = "Boston"
                }
            };

            context.Queens.AddRange(queens);
            context.SaveChanges();

            #endregion

            #region Add Judges

            var judges = new Judge[]
            {
                new Judge
                {
                    Name = "Merle Ginsberg",
                    IsGuest = false
                },
                new Judge
                {
                    Name = "Michelle Visage",
                    IsGuest = false
                }
            };

            context.Judges.AddRange(judges);
            context.SaveChanges();

            #endregion

            #region Add Seasons

            var seasons = new Season[]
            {
                new Season
                {
                    Name = "Two",
                    AirDate = new DateTime(2012, 2, 10)
                },
                new Season
                {
                    Name = "Seven",
                    AirDate = new DateTime(2016, 2, 15)
                },
                new Season
                {
                    Name = "All Stars 3",
                    AirDate = new DateTime(2018, 7, 19)
                }
            };

            context.Seasons.AddRange(seasons);
            context.SaveChanges();

            #endregion

            #region Add Genres
            var genres = new Genre[]
            {
                new Genre
                {
                    Name = "Comedy",
                },
                new Genre
                {
                    Name = "Lewk"
                },
                new Genre
                {
                    Name = "Theater"
                },
                new Genre
                {
                    Name = "Spooky"
                },
                new Genre
                {
                    Name = "Turnting"
                }
            };

            context.Genres.AddRange(genres);
            context.SaveChanges();
            #endregion

            #region Judge Seasons
            var judgeSeasons = new JudgeSeason[]
            {
                new JudgeSeason
                {
                    JudgeId = judges.Single(j => j.Name == "Michelle Visage").JudgeId,
                    SeasonId = seasons.Single(s => s.Name == "Seven").SeasonId
                },
                new JudgeSeason
                {
                    JudgeId = judges.Single(j => j.Name == "Michelle Visage").JudgeId,
                    SeasonId = seasons.Single(s => s.Name == "All Stars 3").SeasonId
                },
                new JudgeSeason
                {
                    JudgeId = judges.Single(j => j.Name == "Merle Ginsberg").JudgeId,
                    SeasonId = seasons.Single(s => s.Name == "Two").SeasonId
                }
            };

            context.JudgeSeasons.AddRange(judgeSeasons);
            context.SaveChanges();
            #endregion

            #region Queen Seasons
            var queenSeasons = new QueenSeason[]
            {
                new QueenSeason
                {
                    QueenId = queens.Single(q => q.Name == "Trixie Mattel").QueenId,
                    SeasonId = seasons.Single(s => s.Name == "Seven").SeasonId
                },
                new QueenSeason
                {
                    QueenId = queens.Single(q => q.Name == "Katya").QueenId,
                    SeasonId = seasons.Single(s => s.Name == "Seven").SeasonId
                },
                new QueenSeason
                {
                    QueenId = queens.Single(q => q.Name == "Trixie Mattel").QueenId,
                    SeasonId = seasons.Single(s => s.Name == "All Stars 3").SeasonId
                },
                new QueenSeason
                {
                    QueenId = queens.Single(q => q.Name == "Jujubee").QueenId,
                    SeasonId = seasons.Single(s => s.Name == "Two").SeasonId
                },
                new QueenSeason
                {
                    QueenId = queens.Single(q => q.Name == "Shangela").QueenId,
                    SeasonId = seasons.Single(s => s.Name == "Two").SeasonId
                },
                new QueenSeason
                {
                    QueenId = queens.Single(q => q.Name == "Shangela").QueenId,
                    SeasonId = seasons.Single(s => s.Name == "All Stars 3").SeasonId
                }
            };

            context.QueenSeasons.AddRange(queenSeasons);
            context.SaveChanges();
            #endregion

            #region Queen Genres
            var queenGenres = new QueenGenre[]
            {
                new QueenGenre
                {
                    QueenId = queens.Single(q => q.Name == "Trixie Mattel").QueenId,
                    GenreId = genres.Single(g => g.Name == "Comedy").GenreId
                },
                new QueenGenre
                {
                    QueenId = queens.Single(q => q.Name == "Katya").QueenId,
                    GenreId = genres.Single(g => g.Name == "Comedy").GenreId
                },
                new QueenGenre
                {
                    QueenId = queens.Single(q => q.Name == "Katya").QueenId,
                    GenreId = genres.Single(g => g.Name == "Lewk").GenreId
                },
                new QueenGenre
                {
                    QueenId = queens.Single(q => q.Name == "Katya").QueenId,
                    GenreId = genres.Single(g => g.Name == "Spooky").GenreId
                },
                new QueenGenre
                {
                    QueenId = queens.Single(q => q.Name == "Jujubee").QueenId,
                    GenreId = genres.Single(g => g.Name == "Lewk").GenreId
                },
                new QueenGenre
                {
                    QueenId = queens.Single(q => q.Name == "Shangela").QueenId,
                    GenreId = genres.Single(g => g.Name == "Turnting").GenreId
                },
            };

            context.QueenGenres.AddRange(queenGenres);
            context.SaveChanges();
            #endregion
        }
    }
}
