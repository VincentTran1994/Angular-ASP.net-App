using System.Collections.Generic;

namespace angularASPApp.DataContext
{
    public interface IDataRepository
    {
        List<object> GetAll();
        object Get(string userId);
        bool Create(object obj);
        bool Update(object obj);
        bool Delete(object obj);
    }
}
