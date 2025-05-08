﻿namespace SampleDTO.DTO.Responses
{
    public sealed record ProductResponse(
        int Id,
        string Name,
        string Description,
        decimal Price,
        int Quantity
    );
}
