namespace OMASM
{
    using System;

    public interface IStateMachineConfiguration<TState, TTrigger>
        where TState : struct, IConvertible
        where TTrigger : struct, IConvertible
    {
        IStateMachineConfiguration<TState, TTrigger> Configure(TState state);
        IStateMachineConfiguration<TState, TTrigger> Permit(TTrigger trigger, TState definationState);
        bool CanFire(StateTransition<TState, TTrigger> transition);
        TState Fire(StateTransition<TState, TTrigger> transition);
    }
}