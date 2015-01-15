namespace OMASM
{
    using System;

    public class StateTransition<TState, TTrigger>
        where TState : struct, IConvertible
        where TTrigger : struct, IConvertible
    {
        private readonly TState _state;
        private readonly TTrigger _trigger;

        public StateTransition(TState state, TTrigger trigger)
        {
            _state = state;
            _trigger = trigger;
        }

        public override int GetHashCode()
        {
            return 17 + 31 * _state.GetHashCode() + 31 * _trigger.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as StateTransition<TState, TTrigger>;
            return other != null && this._state.Equals(other._state) && this._trigger.Equals(other._trigger);
        }  
    }
}