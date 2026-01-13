using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsoleApp.Models
{
    public class FilmViewModel
    {

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public short GenreId { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }

        public List<string> Cast { get; set; } = new List<string>();
    }
}
