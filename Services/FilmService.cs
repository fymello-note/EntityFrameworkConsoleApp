using EntityFrameworkConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsoleApp.Services
{
    public class FilmService
    {

        Dictionary<int, FilmDataGridItemViewModel> films;

        public List<Film> GetFilmsBySkipTake(int skip, int take)
        {
            using(var db = new TestaDatabaseDbContext())
            {
                db.Database.Log = (msg) => Console.WriteLine(msg);
                return db.Film.OrderBy(g => g.FilmId).Skip(skip).Take(take).ToList();
            }
        }

        public List<FilmDataGridItemViewModel> GetFilms()
        {
            using (var db = new TestaDatabaseDbContext()) {

                films = db.Film.Select(f => new FilmDataGridItemViewModel {
                    FilmId = f.FilmId,
                    Title = f.Title,
                    Director = f.Director,
                    Producer = f.Producer,
                    ReleaseDate = f.ReleaseDate,
                    Cast = f.Actor.Select(a => a.Name).ToList(),
                    Genre = f.Genre.Name
                }).ToDictionary(f => f.FilmId);

                var actors = db.Actor.Select(a => new {a.FilmId, a.Name}).AsEnumerable();

                foreach(var actor in actors)
                {
                    if (films.TryGetValue(actor.FilmId, out var film))
                    {
                        film.Cast.Add(actor.Name); 
                    }
                }

                //return db.Film.Select(f => new FilmDataGridItemViewModel
                //{
                //    FilmId = f.FilmId,
                //    Title = f.Title,
                //    Director = f.Director,
                //    Producer = f.Producer,
                //    ReleaseDate = f.ReleaseDate,
                //    Cast = f.Actor.Select(a => a.Name).ToList(),
                //    Genre = f.Genre.Name
                //}).ToList();
            }

            return films.Values.ToList();
        }

        public void AddFilm(FilmViewModel film)
        {

            using (var db = new TestaDatabaseDbContext())
            {
                var newFilm = new Film()
                {
                    Title = film.Title,
                    ReleaseDate = film.ReleaseDate,
                    Producer = film.Producer,
                    Director = film.Director,
                    GenreId = film.GenreId,
                    CreationDate = DateTime.Now,
                    Actor = film.Cast.Select(actorName => new Actor() { Name = actorName, CreationDate = DateTime.Now }).ToList() 
                };

                db.Film.Add(newFilm);

                /*foreach (var actorName in film.Cast)
                {
                    var NewActor = new Actor()
                    {
                        FilmId = newFilm.FilmId,
                        Name = actorName
                    };

                    db.Actor.Add(NewActor);
                }*/

                db.SaveChanges();
            }

        }
    }
}
