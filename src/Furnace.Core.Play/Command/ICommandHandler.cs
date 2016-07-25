namespace Furnace.Core.Play.Command
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
