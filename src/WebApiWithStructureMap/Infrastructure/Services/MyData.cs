using System.Collections.Generic;
using System.Linq;
using WebApiWithStructureMap.Models.Core;

namespace WebApiWithStructureMap.Services
{
    public class MyData : IMyData
    {
        private List<MyObject> _data;

        public MyData()
        {
            _data = new List<MyObject>
            {
                new MyObject { Id = 1, Name = "Name1", Description = "The description of Name1" },
                new MyObject { Id = 2, Name = "Name2", Description = "The description of Name2" }
            };
        }

        public ICollection<MyObject> GetAll()
        {
            return _data;
        }

        public MyObject Get(int id)
        {
            return _data
                .SingleOrDefault(x => x.Id == id);
        }

        public MyObject Add(MyObject myObject)
        {
            var highestId = _data
                .Max(x => x.Id);
            myObject.Id = highestId + 1;
            _data.Add(myObject);
            return myObject;
        }

        public void Delete(int id)
        {
            var delete = _data
                .SingleOrDefault(x => x.Id == id);
            if (delete != null)
            {
                _data.Remove(delete);
            }
        }
    }
}