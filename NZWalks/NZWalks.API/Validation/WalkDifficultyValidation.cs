using FluentValidation;

namespace NZWalks.API.Validation
{
    public class WalkDifficultyValidation : AbstractValidator<Models.DTOs.WalkDifficulty>
    {
        public WalkDifficultyValidation()
        {
            RuleFor(x => x.Code).NotEmpty().NotNull();
        }
    }
}
