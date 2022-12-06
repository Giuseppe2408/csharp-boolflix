using csharp_boolflix.Models.Form;

namespace csharp_boolflix.Models.Repository.Interfacce
{
    public interface IFilmRepository
    {
        List<Film> All();
        void Create(Film film, List<int> selectedCategories, List<int> selectedActors);

        Film GetById(int id);

        void AddFilmRelations(MediaForm formData);

        void AddFilmRelations(MediaForm formData, Film film);

        void Delete(Film film);

        void Update(Film film, Film formData, List<int> selectedCategories, List<int> selectedActors);
    }
}