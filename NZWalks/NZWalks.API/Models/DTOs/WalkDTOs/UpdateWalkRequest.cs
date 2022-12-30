namespace NZWalks.API.Models.DTOs.WalkDTOs
{
    public class UpdateWalkRequest
    {
        public string Name { get; set; }
        public double Length { get; set; }

        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public Guid Id { get; internal set; }
    }
}
