namespace demoacademyminimalapi.Extensions;

public static class CategoryExtensions
{
    public static CategoriaDTO? ToDTO(this Category category)
    {
        if (category == null) return null;
        return new CategoriaDTO(category.CategoryId, category.CategoryName,category.Description,category.Products.Count);
    }

    public static Category? FromDTO(this CategoriaCreaDTO category) 
    {
        if (category == null) return null;
        return new Category { CategoryName = category.Nome, Description = category.Descrizione };
    }
    public static Category? FromDTO(this CategoriaAggiornaDTO category)
    {
        if (category == null) return null;
        return new Category { CategoryName = category.Nome, Description = category.Descrizione, CategoryId=category.Id };
    }
}
