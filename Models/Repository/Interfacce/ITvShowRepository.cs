namespace csharp_boolflix.Models.Repository.Interfacce
{
    public interface ITvShowRepository
    {
        List<TvShow> All();
        void Create(TvShow tvShow);
        void Delete(TvShow tvShow);
        void Update(TvShow tvShow);
    }
}