using System.Collections.Generic;
using WebApiWithStructureMap.Models;

namespace WebApiWithStructureMap.Services
{
    public interface IMyData
    {
        ICollection<MyObject> GetAll();
    }
}