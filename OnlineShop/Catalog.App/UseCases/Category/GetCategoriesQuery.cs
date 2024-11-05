using Catalog.App.Specifications;
using Catalog.App.UseCases.Category.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Category;

public record GetCategoriesQuery(int Skip, int Take) : IRequest<IEnumerable<CategoryResponse>>;

public class GetCategoriesQueryHandler(IRepository<CategoryEntity> categoryRepository)
    : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryResponse>>
{
    public async Task<IEnumerable<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var products = await categoryRepository.Find(request.Skip, request.Take, 
            new EmptyFilter<CategoryEntity>());
        
        return products.Select(x => new CategoryResponse
        {
            Id = x.Id, 
            Name = x.Name,
            Image = x.Image, 
            ParentCategory = x.ParentCategory
        });
    }
}