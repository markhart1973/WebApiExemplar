using FluentValidation.Attributes;
using WebApiWithStructureMap.Infrastructure.Validation;

namespace WebApiWithStructureMap.Models.Dto
{
    [Validator(typeof(MyObjectUpdateDtoValidation))]
    public class MyObjectUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}