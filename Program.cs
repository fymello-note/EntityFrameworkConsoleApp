using EntityFrameworkConsoleApp.Models;
using EntityFrameworkConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // SELECT GenreId, [Name] FROM dbo.Genre

            GenreService genreService = new GenreService();

            // IEnumerable<SelectListItem> items = genreService.GetGenrEnumerable();

            // var itemList = items.Where(e => e.Value == "1").Take(1).ToList();

            // var genre = genreService.GetGenreListItem();

            var filmService = new FilmService();
            var films = filmService.GetFilmsBySkipTake(0, 2);
            Console.WriteLine("DONE");
            Console.ReadKey();
            
        }
    }
}
