using System.Collections.Generic;

namespace angularASPApp.DataContext
{
    interface IDataRepository
    {
        List<object> GetAll();
        object Get(string userId);
        void Create(object obj);
        void Update(object obj);
        void Delete(object obj);
    }
}
