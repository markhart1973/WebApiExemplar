using FluentValidation;
using WebApiWithStructureMap.Models.Dto;

namespace WebApiWithStructureMap.Infrastructure.Validation
{
    public class MyObjectUpdateDtoValidation :
        AbstractValidator<MyObjectUpdateDto>
    {
        public MyObjectUpdateDtoValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(1, 50);
            RuleFor(x => x.Description).Length(0, 200);
        }
    }
}