﻿namespace NZWalks.API.Models.DTOs
{
    public class WalkDifficulty
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

        public Walk Walks { get; set; }
    }
}
