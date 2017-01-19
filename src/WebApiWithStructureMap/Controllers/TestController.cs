using AutoMapper;
using Marvin.JsonPatch;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WebApiWithStructureMap.Services;
using Core = WebApiWithStructureMap.Models.Core;
using Dto = WebApiWithStructureMap.Models.Dto;

namespace WebApiWithStructureMap.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private const string GetMyObject = "GetMyObject";

        private readonly IMyData _myData;
        private readonly IMapper _mapper;

        public TestController(IMyData myData,
            IMapper mapper)
        {
            _myData = myData;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var result = _mapper.Map<List<Dto.MyObjectDto>>(_myData.GetAll());
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}", Name = GetMyObject)]
        public IHttpActionResult Get(int id)
        {
            var result = _myData.Get(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Dto.MyObjectDto>(result));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody]Dto.MyObjectInsertDto myObject)
        {
            if (myObject == null)
            {
                return BadRequest("The supplied MyObject should not be null.");
            }

            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var addedMyObject = _myData.Add(_mapper.Map<Core.MyObject>(myObject));

            return CreatedAtRoute(GetMyObject,
                new { id = addedMyObject.Id },
                _mapper.Map<Dto.MyObjectDto>(addedMyObject));
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody]Dto.MyObjectUpdateDto myObject)
        {
            if (myObject == null)
            {
                return BadRequest("The supplied MyObject should not be null.");
            }

            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var existingMyObject = _myData.Get(id);

            if (existingMyObject == null)
            {
                return NotFound();
            }

            _mapper.Map(myObject, existingMyObject);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPatch]
        [Route("{id}")]
        public IHttpActionResult Patch(int id,
            [FromBody]JsonPatchDocument<Dto.MyObjectUpdateDto> myObjectPatch)
        {
            if (myObjectPatch == null)
            {
                return BadRequest("The supplied MyObject patch document should not be null.");
            }

            var existingMyObject = _myData.Get(id);

            if (existingMyObject == null)
            {
                return NotFound();
            }

            var existingMyObjectUpdateDto = _mapper.Map<Dto.MyObjectUpdateDto>(existingMyObject);
            myObjectPatch.ApplyTo(existingMyObjectUpdateDto);

            this.Validate(existingMyObjectUpdateDto);

            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            _mapper.Map(existingMyObjectUpdateDto, existingMyObject);

            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var existingMyObject = _myData.Get(id);

            if (existingMyObject == null)
            {
                return NotFound();
            }

            _myData.Delete(id);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
