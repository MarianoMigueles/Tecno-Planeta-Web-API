namespace Exeptions
{
    public class EntityNotFoundException : AbstractBaseExeption
    {
        public EntityNotFoundException(string message) : base(message) { }
        public override string Type => "https://miapi.com/errors/entity-not-found";
        public override string Title => "Entity not found";


    }
}
