namespace Furnace.Core.Play.Middleware
{
    public abstract class FurnaceMiddlewareDecorator : FurnaceMiddleware, IFurnaceMiddlewareDecorator
    {
        public override int Weight => Decoratee.Weight;

        protected readonly FurnaceMiddleware Decoratee;

        protected FurnaceMiddlewareDecorator(FurnaceMiddleware decoratee)
        {
            Decoratee = decoratee;
        }
    }
}
