namespace csharp_boolflix.Models.Repository.Interfacce
{
    public interface ICategoryRepository
    {
        List<Category> All();
        void Create(Category category);
    }
}