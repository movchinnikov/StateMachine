namespace OMASM
{
    using System;

    public interface IStateMachine<TState, in TTrigger>
        where TState : struct, IConvertible
        where TTrigger : struct, IConvertible
    {
        event EventHandler<FireSucessEventArgs<TState>> OnFireSuccess;

        TState CurrentState { get; set; }

        bool CanFire(TTrigger trigger);
        TState Fire(TTrigger trigger, Action callback);
        TState Fire(TTrigger trigger, Action<object[]> callback, object[] context);
    }
}