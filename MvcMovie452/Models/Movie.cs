using System;

namespace MvcMovie452.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime releaseDate { get; set; }
        public string genre { get; set; }
        public decimal price { get; set; }
    }
}