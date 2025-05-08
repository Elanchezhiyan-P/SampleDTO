using Microsoft.AspNetCore.Mvc;
using SampleDTO.DTO.Requests;
using SampleDTO.Extenstions;
using SampleDTO.Repositories;

namespace SampleDTO.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            var productGroup = app.MapGroup("/api/products").WithTags("Products");

            //GetAllProducts
            productGroup.MapGet("/", async (IProductRepository repository, [FromQuery] int page = 1, [FromQuery] int pageSize = 10) =>
            {
                var products = (await repository.GetAll())
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(x => x.ToDto());

                return Results.Ok(products);
            });

            //GetByProductId
            productGroup.MapGet("/{id:int}", async (int id, IProductRepository repository) =>
            {
                var product = await repository.GetProductByIdAsync(id);
                return product is not null ? Results.Ok(product.ToDto()) : Results.Problem("Product not found", statusCode: 404);
                ;
            })
                .WithName("GetByProductId");

            //CreateProduct
            productGroup.MapPost("/", async (CreateProductRequest product, IProductRepository repository) =>
            {
                if (product is null)
                {
                    return Results.BadRequest("Product cannot be null");
                }
                var entity = product.ToEntity();
                await repository.CreateProductAsync(entity);
                return Results.Created($"/api/products/{entity.Id}", entity.ToDto());
            });

            //PatchProduct
            productGroup.MapPatch("/{id:int}", async (int id, [FromBody] UpdateProductRequest request, [FromServices] IProductRepository repository) =>
            {
                if (request is null)
                {
                    return Results.BadRequest("Product cannot be null");
                }

                var existingProduct = await repository.GetProductByIdAsync(id);
                if (existingProduct is null)
                {
                    return Results.Problem("Product not found", statusCode: 404);
                }

                await repository.UpdateProductAsync(id, request.ToEntity(existingProduct));
                return Results.NoContent();
            });

            //DeleteProduct
            productGroup.MapDelete("/{id:int}", async (int id, IProductRepository repository) =>
            {
                var product = await repository.GetProductByIdAsync(id);
                if (product is null)
                {
                    return Results.Problem("Product not found", statusCode: 404);
                }
                await repository.DeleteProductAsync(id);
                return Results.NoContent();
            });
        }
    }
}
