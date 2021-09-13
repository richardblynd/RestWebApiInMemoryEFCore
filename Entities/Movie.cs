using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Movie
    {
        public int Year { get; set; }

        [Key]
        public string Title { get; set; }

        public string Studios { get; set; }

        public string Producers { get; set; }

        public bool Winner { get; set; }
    }
}
