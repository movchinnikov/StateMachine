namespace OMASM
{
    using System;
    using System.Collections.Generic;

    public class StateMachine<TState, TTrigger> : IStateMachine<TState, TTrigger>
        where TState : struct, IConvertible
        where TTrigger : struct, IConvertible
    {
        private TState _currentState;
        private readonly IStateMachineConfiguration<TState, TTrigger> _configuration;
        public event EventHandler<FireSucessEventArgs<TState>> OnFireSuccess;

        /// <summary>
        /// Задает или возвращает текущее состояние машины
        /// </summary>
        public TState CurrentState { get; set; }

        public StateMachine(IStateMachineConfiguration<TState, TTrigger> configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// Проверяет возможность перехода машины в новое состояние
        /// </summary>
        /// <param name="trigger">Тригер перехода</param>
        /// <returns>Есть ли возможность выполнения указаного триггера</returns>
        public virtual bool CanFire(TTrigger trigger)
        {
            return this._configuration.CanFire(new StateTransition<TState, TTrigger>(_currentState, trigger));
        }

        /// <summary>
        /// Выполняет переход машины в новое состояние
        /// </summary>
        /// <param name="trigger">Тригер перехода</param>
        /// <param name="callback">Действие после перехода</param>
        /// <returns>Новое состояние машины</returns>
        public virtual TState Fire(TTrigger trigger, Action callback)
        {
            var prevState = this._currentState;
            try
            {
                this._currentState = _configuration.Fire(new StateTransition<TState, TTrigger>(_currentState, trigger));
                if (callback != null) callback();
                OnFireSuccess(this, new FireSucessEventArgs<TState> { PrevState = prevState, NewState = this._currentState });
                return this._currentState;
            }
            catch (KeyNotFoundException knfe)
            {
                this._currentState = prevState;
                throw new TransitionNotFoundException("Данный переход между состояниями не возможен.");
            }
            catch (Exception e)
            {
                this._currentState = prevState;
                throw e;
            }
        }

        /// <summary>
        /// Выполняет переход машины в новое состояние
        /// </summary>
        /// <param name="trigger">Тригер перехода</param>
        /// <param name="callback">Действие после перехода</param>
        /// <param name="context">Аргументы обратного вызова</param>
        /// <returns>Новое состояние машины</returns>
        public virtual TState Fire(TTrigger trigger, Action<object[]> callback, object[] context)
        {
            var prevState = this._currentState;
            try
            {
                this._currentState = _configuration.Fire(new StateTransition<TState, TTrigger>(_currentState, trigger));
                if (callback != null) callback(context);
                OnFireSuccess(this, new FireSucessEventArgs<TState> { PrevState = prevState, NewState = this._currentState });
                return this._currentState;
            }
            catch (KeyNotFoundException knfe)
            {
                this._currentState = prevState;
                throw new TransitionNotFoundException("Данный переход между состояниями не возможен.");
            }
            catch (Exception e)
            {
                this._currentState = prevState;
                throw e;
            }
        }
    }
}