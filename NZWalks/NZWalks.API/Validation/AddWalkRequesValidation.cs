using FluentValidation;

namespace NZWalks.API.Validation
{
    public class AddWalkRequesValidation : AbstractValidator<Models.DTOs.AddWalkReques>
    {
        public AddWalkRequesValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThanOrEqualTo(0);
        }
    }
}
