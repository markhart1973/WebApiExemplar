using FluentValidation;
using WebApiWithStructureMap.Models.Dto;

namespace WebApiWithStructureMap.Infrastructure.Validation
{
    public class MyObjectInsertDtoValidation :
        AbstractValidator<MyObjectInsertDto>
    {
        public MyObjectInsertDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(1, 50);
            RuleFor(x => x.Description).Length(0, 200);
        }
    }
}