namespace csharp_boolflix.Models.Repository.Interfacce
{
    public interface IActorRepository
    {
        List<Actor> All();
        void Create(Actor actor);
    }
}