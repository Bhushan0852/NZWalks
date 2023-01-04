using FluentValidation;

namespace NZWalks.API.Validation
{
    public class RegionDTOValidator : AbstractValidator<Models.DTOs.RegionDTO>
    {
        public RegionDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThan(0);
            RuleFor(x => x.Lat).GreaterThan(0);
            RuleFor(x => x.Long).GreaterThan(0);
        }
    }
}
