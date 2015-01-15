namespace OMASM
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Базовый класс конфигурации машины
    /// </summary>
    /// <typeparam name="TState">Состояния</typeparam>
    /// <typeparam name="TTrigger">Триггеры</typeparam>
    public class BaseStateMachineConfiguration<TState, TTrigger> : 
        IStateMachineConfiguration<TState, TTrigger>
        where TState : struct, IConvertible
        where TTrigger : struct, IConvertible
    {
        private readonly Dictionary<StateTransition<TState, TTrigger>, TState> _transitions;
        private TState _configurateState;

        public BaseStateMachineConfiguration()
        {
            if (!typeof (TState).IsEnum)
            {
                throw new ArgumentException("TState должен быть типом-перечисления");
            }
            if (!typeof(TTrigger).IsEnum)
            {
                throw new ArgumentException("TTrigger должен быть типом-перечисления");
            }
            this._transitions = new Dictionary<StateTransition<TState, TTrigger>, TState>();
        }

        /// <summary>
        /// Начало конфигурирования переходов для указанного состояния
        /// </summary>
        /// <param name="state">Состояния для настройки</param>
        public virtual IStateMachineConfiguration<TState, TTrigger> Configure(TState state)
        {
            this._configurateState = state;
            return this;
        }

        /// <summary>
        /// Создание перехода из настраиваемого состояния в следующее
        /// </summary>
        /// <param name="trigger">Триггер</param>
        /// <param name="definationState">Конечное состояние</param>
        public virtual IStateMachineConfiguration<TState, TTrigger> Permit(TTrigger trigger, TState definationState)
        {
            this._transitions.Add(new StateTransition<TState, TTrigger>(_configurateState, trigger), definationState);
            return this;
        }
        
        /// <summary>
        /// Проверка возможности ерехода из текущего состояния по указанному триггеру
        /// </summary>
        /// <param name="transition">Проверяемый переход</param>
        /// <returns></returns>
        public virtual bool CanFire(StateTransition<TState, TTrigger> transition)
        {
            return this._transitions.ContainsKey(transition);
        }

        /// <summary>
        /// Переход из текущего состояния по указанному триггеру
        /// </summary>
        /// <param name="transition">Выполняемый переход</param>
        /// <returns>Новое состояние</returns>
        public virtual TState Fire(StateTransition<TState, TTrigger> transition)
        {
            return this._transitions[transition];
        }
    }
}