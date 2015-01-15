namespace OMASM
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Исключение, вызванное отсутствием пути для перехода.
    /// </summary>
    [Serializable]
    public class TransitionNotFoundException : Exception
    {
        public TransitionNotFoundException() : base() { }
        public TransitionNotFoundException(string message) : base(message) { }
        public TransitionNotFoundException(string message, Exception inner) : base(message, inner) { }

        protected TransitionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}