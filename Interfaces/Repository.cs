using System.Collections.Generic;

namespace MediaStorage
{

    public interface Repository<T>
    {
         public List<T> GetList();
         public T FindMediaById(int id);
         public int NextId();
         public void Insert(T media);
         public void Update(int id, T media);
         public void Delete(int id);
    }
}