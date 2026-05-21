namespace demoacademyminimalapi.Extensions;

public static class CategoryExtensions
{
    public static CategoriaDTO? ToDTO(this Category category)
    {
        if (category == null) return null;
        return new CategoriaDTO(category.CategoryId, category.CategoryName,category.Description,category.Products.Count);
    }
}
