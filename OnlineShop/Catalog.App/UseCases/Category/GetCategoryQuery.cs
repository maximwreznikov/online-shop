using Catalog.App.Dtos;
using Catalog.App.UseCases.Category.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Category;

public record GetCategoryQuery(int Id) : IRequest<CategoryResponse>;

public class GetCategoryQueryHandler(IRepository<CategoryEntity> categoryRepository)
    : IRequestHandler<GetCategoryQuery, CategoryResponse>
{
    public async Task<CategoryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.Get(request.Id);

        return new CategoryResponse
        {
            Id = category.Id, 
            Name = category.Name, 
            Image = category.Image, 
            ParentCategory = category.ParentCategory
        };
    }
}