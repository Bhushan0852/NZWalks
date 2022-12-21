﻿namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }

        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        //Navigation prop

        public Region Regions { get; set; }
        public WalkDifficulty WalkDifficulties { get; set; }
    }
}
