namespace csharp_boolflix.Models.Repository.Interfacce
{
    public interface IFilmRepository
    {
        List<Film> All();
        void Create(Film film);
        void Delete(Film film);
        void Update(Film film);
    }
}