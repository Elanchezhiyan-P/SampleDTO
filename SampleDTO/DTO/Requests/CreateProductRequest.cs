﻿namespace SampleDTO.DTO.Requests
{
    public sealed record CreateProductRequest(
        string Name,
        string Description,
        decimal Price,
        int Quantity
    );
}
