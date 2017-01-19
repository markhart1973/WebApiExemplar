using FluentValidation.Attributes;
using WebApiWithStructureMap.Infrastructure.Validation;

namespace WebApiWithStructureMap.Models.Dto
{
    [Validator(typeof(MyObjectInsertDtoValidation))]
    public class MyObjectInsertDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}