using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CustomComboBox
{
    public class FilmService
    {
        public async Task<List<Movie>> GetMoviesAsync()
        {
            // generate an integer between 1 and 1000
            var random = new Random();
            var delay = random.Next(1, 500);
            await Task.Delay(delay);
            return new List<Movie>
            {
                new Movie{Id=1, Title="The Dark Knight" },
                new Movie{Id=2, Title="The Big Lebowski" },
                new Movie{Id=3, Title="The Shawshank Redemption" },
                new Movie{Id=4, Title="Schindler's List" },
                new Movie{Id=5, Title="Pulp Fiction" },
                new Movie{Id=6, Title="Fight Club" }
            };
        }

    }
}