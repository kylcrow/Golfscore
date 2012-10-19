using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Scorekeeper.Models
{
    public class MovieGameModel
    {
        private const string MovieInfo_Url = @"http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey={1}&q={0}";
        private const string MovieInfoName_Url = @"http://http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey={0}&q={1}&page_limit=1";
        string apiKey { get; set; }

        public string Movie { get; set; }
        public string Actor { get; set; }
        public bool isIn { get; set; }
        public bool FirstLoad { get; set; }
        public int Total { get; set; }
        public string CharacterName { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }

        public MovieGameModel()
        {
        }

        public Movie GetMovieInfo(int id, string apiKey)
        {
            string formatted_url = string.Format(MovieInfo_Url, id, apiKey);

            return JSONToObject<Movie>(formatted_url);
        }

        public MovieSearchResults GetMovieInfoByName(string name, string apiKey)
        {
            string formatted_url = string.Format(MovieInfo_Url, name, apiKey);

            return JSONToObject<MovieSearchResults>(formatted_url);
        }

        private T JSONToObject<T>(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                var stream = response.Content.ReadAsStreamAsync().Result;

                var javascriptSerializer = new DataContractJsonSerializer(typeof(T));
                return (T)javascriptSerializer.ReadObject(stream);
            }
        }

        public Movie GetMovieWithCast(string movieName)
        {
            apiKey = "vknvka2sz6w8fkdbus3pbx3y";
            string movieNameForUrl = movieName.Replace(' ','+');
            MovieSearchResults m = GetMovieInfoByName(movieNameForUrl, apiKey);

            Movie targetMovie = new Movie();
            targetMovie = m.movies.Where(x => x.title.ToLower() == movieName.ToLower()).FirstOrDefault();

            return targetMovie;
        }
    }

    [DataContract]
    public class Movie
    {
        [DataMember]
        public int? id { get; set; }

        [DataMember]
        public string title { get; set; }

        [DataMember]
        public string year { get; set; }

        [DataMember]
        public List<string> genres { get; set; }

        [DataMember]
        public string mpaa_rating { get; set; }

        [DataMember]
        public string runtime { get; set; }

        //[DataMember]
        //public Release_Dates release_dates { get; set; }

        //[DataMember]
        //public Ratings ratings { get; set; }

        [DataMember]
        public string synopsis { get; set; }

        [DataMember]
        public Poster posters { get; set; }

        [DataMember]
        public List<Cast> abridged_cast { get; set; }

        //[DataMember]
        //public List<Director> abridged_directors { get; set; }

        //[DataMember]
        //public Links links { get; set; }
    }

    [DataContract]
    public class Cast
    {
        [DataMember]
        public int? id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public List<string> characters { get; set; }
    }

    [DataContract]
    public class MovieSearchResults
    {
        [DataMember]
        public string total { get; set; }

        [DataMember]
        public List<Movie> movies { get; set; }
    }

    [DataContract]
    public class Poster
    {
        [DataMember]
        public string thumbnail { get; set; }

        [DataMember]
        public string profile { get; set; }
        
        [DataMember]
        public string detailed { get; set; }

        [DataMember]
        public string original { get; set; }
    }

}


