using System.Web.Http;
using WebApiWithStructureMap.Services;

namespace WebApiWithStructureMap.Controllers
{
    [Route("api/test")]
    public class TestController : ApiController
    {
        private readonly IMyData _myData;

        public TestController(IMyData myData)
        {
            _myData = myData;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_myData.GetAll());
        }

        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
