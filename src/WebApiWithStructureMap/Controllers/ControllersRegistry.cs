using StructureMap;
using System.Web.Http;

namespace WebApiWithStructureMap.Controllers
{
    public class ControllersRegistry :
        Registry
    {
        public ControllersRegistry()
        {
            Scan(x =>
            {
                x.AddAllTypesOf<ApiController>();
            });
        }
    }
}