using System;

namespace Furnace.Core.Play.GraphTheory.Graphs.Exceptions
{
    public class NonAcyclicGraphException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public NonAcyclicGraphException()
        {
        }

        public NonAcyclicGraphException(string message) : base(message)
        {
        }

        public NonAcyclicGraphException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
