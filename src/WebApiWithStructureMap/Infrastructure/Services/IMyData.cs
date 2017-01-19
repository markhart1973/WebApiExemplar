using System.Collections.Generic;
using WebApiWithStructureMap.Models.Core;

namespace WebApiWithStructureMap.Services
{
    public interface IMyData
    {
        ICollection<MyObject> GetAll();
        MyObject Get(int id);
        MyObject Add(MyObject myObject);
        void Delete(int id);
    }
}