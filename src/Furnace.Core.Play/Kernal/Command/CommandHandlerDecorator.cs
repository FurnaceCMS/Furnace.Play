namespace Furnace.Core.Play.Kernal.Command
{
    public abstract class CommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : Kernal.Command.Command
    {
        protected readonly ICommandHandler<TCommand> Decorated;

        protected CommandHandlerDecorator(ICommandHandler<TCommand> decorated)
        {
            Decorated = decorated;
        }

        public abstract void Handle(TCommand command);
    }
}
