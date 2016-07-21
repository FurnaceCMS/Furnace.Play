namespace Furnace.Core.Play.Kernal
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
