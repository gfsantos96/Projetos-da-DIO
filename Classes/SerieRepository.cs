using System;
using System.Collections.Generic;

namespace MediaStorage
{

    public class SerieRepository : Repository<Serie>
    {
        private List<Serie> SerieList = new List<Serie>();

        public List<Serie> GetList()
        {
            return SerieList;
        }

        public int NextId()
        {
            return SerieList.Count;
        }

        public Serie FindMediaById(int id)
        {
            return SerieList[id];
        }

        public void Insert(Serie media)
        {
            SerieList.Add(media);
        }

        public void Update(int id, Serie media)
        {
            SerieList[id] = media;
        }

        public void Delete(int id)
        {
            SerieList[id].Delete();
        }

    }
}