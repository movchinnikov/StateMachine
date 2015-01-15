namespace OMASM
{
    using System;

    public class FireSucessEventArgs<TState> : EventArgs
        where TState : struct, IConvertible
    {
        public TState PrevState { get; set; } 
        public TState NewState { get; set; }
    }
}