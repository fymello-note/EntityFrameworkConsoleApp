using EntityFrameworkConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsoleApp.Services
{
    public class GenreService
    {
        public List<SelectListItem> GetGenreListItem() { 
            using(var db = new TestaDatabaseDbContext())
            {
                db.Database.Log = (msg) => Console.WriteLine(msg);

                /*IQueryable<Genre> query = db.Genre;

                if (true)
                    query = query.Where(g => g.Name.StartsWith("A"));

                return query.Select(g => new SelectListItem
                {
                    Value = g.Name,
                    Text = g.Name
                }).ToList();*/

                return db.Genre.Select(g => new SelectListItem
                {
                    Value = g.Name,
                    Text = g.Name
                }).ToList();

                /*List<Genre> genreList = db.Genre.ToList();

                List<SelectListItem> genreListItem = new List<SelectListItem>();
                foreach (var genre in genreList)
                {
                    genreListItem.Add(new SelectListItem {
                        Value = genre.Name, //GenreId.ToString(), 
                        Text = genre.Name 
                    });
                }

                return genreListItem;*/
            }
        }

        public IEnumerable<SelectListItem> GetGenrEnumerable()
        {
            // yield blocca il return fino alla fine del metono o fino a yield break; successivamente nel metodo chiamate deve 
            // chiamare una funzione tipo .ToList() per poter accedere agli elementi interni
            yield return new SelectListItem() { Value = "1", Text = "Azione" };
            yield return new SelectListItem() { Value = "2", Text = "Avventura" };
            yield return new SelectListItem() { Value = "3", Text = "Romantico" };

            // yield break;
        }
    }
}
