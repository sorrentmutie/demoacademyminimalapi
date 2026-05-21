namespace Academy.API.Minimal.Extensions;

public static  class CategoryExtensions
{
    public static CategoriaDTO? ToDTO(this Category category)
    {
        if (category == null) return null;
        return new CategoriaDTO
            (
                category.CategoryId,
                category.CategoryName,
                category.Description,
                category.Products.Count
            );
    }


    public static Category? FromDTO(this CategoriaCreaDTO cat) {
        if (cat == null) return null;
        return new Category { CategoryName = cat.Nome, Description = cat.Descrizione };      
    }

    public static Category? FromDTO(this CategoriaAggiornaDTO cat)
    {
        if (cat == null) return null;
        return new Category { CategoryName = cat.Nome, Description = cat.Descrizione, CategoryId = cat.Id };
    }
}
