using System;
using System.Collections.Generic;

namespace MediaStorage
{

    public class MovieRepository : Repository<Movie>
    {
        private List<Movie> MovieList = new List<Movie>();

        public List<Movie> GetList()
        {
            return MovieList;
        }

        public int NextId()
        {
            return MovieList.Count;
        }

        public Movie FindMediaById(int id)
        {
            return MovieList[id];
        }

        public void Insert(Movie media)
        {
            MovieList.Add(media);
        }

        public void Update(int id, Movie media)
        {
            MovieList[id] = media;
        }

        public void Delete(int id)
        {
            MovieList[id].Delete();
        }

    }
}