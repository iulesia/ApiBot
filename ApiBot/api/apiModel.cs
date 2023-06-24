namespace Model
{
    public class Models
    {
        public Results[] Results { get; set; }
        public Models()
        {
            Results = new Results[] { };
        }
    }
    public class Results
    {
        public string Poster_path { get; set; }
        public string Overview { get; set; }
        public string Release_date { get; set; }
        public string Title { get; set; }
        public string Vote_average { get; set; }
    }
    
    
    public class Movie
    {
        public string Movie_name { get; set; }
        public int Movie_rate { get; set; }
        public string Movie_comment { get; set; }
        public string Movie_id { get; set; }
        public int id { get; set; }
    }
    
}

