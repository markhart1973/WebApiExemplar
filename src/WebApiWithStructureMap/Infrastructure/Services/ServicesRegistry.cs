using StructureMap;

namespace WebApiWithStructureMap.Services
{
    public class ServicesRegistry :
        Registry
    {
        public ServicesRegistry()
        {
            For<IMyData>().Use<MyData>().Singleton();
        }
    }
}