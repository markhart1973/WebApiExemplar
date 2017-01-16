using System.Collections.Generic;
using WebApiWithStructureMap.Models;

namespace WebApiWithStructureMap.Services
{
    public class MyData : IMyData
    {
        public ICollection<MyObject> GetAll()
        {
            return new List<MyObject>
            {
                new MyObject { Id = 1, Name = "Name1" },
                new MyObject { Id = 2, Name = "Name2" }
            };
        }
    }
}