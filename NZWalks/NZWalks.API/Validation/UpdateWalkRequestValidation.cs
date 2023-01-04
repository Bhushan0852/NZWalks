using FluentValidation;

namespace NZWalks.API.Validation
{
    public class UpdateWalkRequestValidation : AbstractValidator<Models.DTOs.WalkDTOs.UpdateWalkRequest>
    {
        public UpdateWalkRequestValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThanOrEqualTo(0);
        }
    }
}
