namespace Furnace.Core.Play.Kernal.Command
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
