using FluentValidation;

namespace NZWalks.API.Validation
{
    public class WalkDifficultyRequesValidation : AbstractValidator<Models.DTOs.WalkDifficultyReques>
    {
        public WalkDifficultyRequesValidation()
        {
            RuleFor(x => x.Code).NotNull();
        }
    }
}
