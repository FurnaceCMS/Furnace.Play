namespace Furnace.Core.Play.Command
{
    public abstract class CommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : Play.Command.Command
    {
        protected readonly ICommandHandler<TCommand> Decorated;

        protected CommandHandlerDecorator(ICommandHandler<TCommand> decorated)
        {
            Decorated = decorated;
        }

        public abstract void Handle(TCommand command);
    }
}
