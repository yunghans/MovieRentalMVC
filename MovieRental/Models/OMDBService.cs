using System.Net;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using MovieRental.Models;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace MovieRental.Externals
{
    public class OMDBService
    {
        public static Movie GetMoviesByTitle(string Title)
        {
            WebRequest req = WebRequest.Create(@"http://www.omdbapi.com/?t=" + Title);

            req.Method = "GET";
            
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(MovieModel));
                object objMovieModel = jsonSerializer.ReadObject(resp.GetResponseStream());
                MovieModel jsonMovieModel = objMovieModel as MovieModel;
                Mapper.CreateMap<MovieModel, Movie>();

                //Do some filtering
                if (String.IsNullOrEmpty(jsonMovieModel.Title) || jsonMovieModel.Poster == "N/A")
                {
                    return null;
                }
                else
                {
                    Movie mappedMovie = Mapper.Map<Movie>(jsonMovieModel);

                    List<Genre> genres = new List<Genre>();
                    foreach (string aGenre in jsonMovieModel.Genre.Split(','))
                    {
                        genres.Add(new Genre(aGenre.Trim()));
                    }
                    mappedMovie.Genres = genres;

                    return mappedMovie;
                }

            }
            else
            {
                return null;
            }
        }
    }

    [DataContract]
    public class MovieModel
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember(Name = "Rated")]
        public string FilmRating { get; set; }
        [DataMember]
        public string Released { get; set; }
        public string ReleaseYear
        {
            get
            {
                try
                {
                    return DateTime.Parse(Released).Year.ToString();
                }
                catch
                {
                    return null;
                }
            }
        }
        [DataMember]
        public string Runtime { get; set; }
        [DataMember]
        public string Genre { get; set; }
        [DataMember]
        public string Actors { get; set; }
        [DataMember]
        public string Plot { get; set; }
        [DataMember]
        public string Language { get; set; }
        [DataMember]
        public string Poster { get; set; }
        [DataMember]
        public string imdbRating { get; set; }
        [DataMember]
        public string imdbID { get; set; }

        public string MovieId
        {
            get
            {
                return imdbID;
            }
        }
        public override string ToString()
        {
            return Title + " " + Year + " " + FilmRating;
        }
    }
}