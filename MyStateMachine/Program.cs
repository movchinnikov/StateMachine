namespace MyStateMachine
{
    using System;
    using OMASM;

    class Program
    {
        private static readonly IStateMachine<PhoneCallState, PhoneCallTrigger> _stateMachine;

        static Program()
        {
            _stateMachine = new StateMachine<PhoneCallState, PhoneCallTrigger>(
                new PhoneCallConfiguration());
            _stateMachine.OnFireSuccess += CheckFire;
        }

        static void Main(string[] args)
        {
            try
            {
                var phone = new Phone();
                _stateMachine.CurrentState = phone.State;
                phone.State = _stateMachine.Fire(PhoneCallTrigger.IncomingСall, phone.IncomingCall, new object[]{"+79120123456"});
                phone.State = _stateMachine.Fire(PhoneCallTrigger.ReceivingСall, phone.ReceivingСall);
                phone.State = _stateMachine.Fire(PhoneCallTrigger.EndCall, phone.EndCall);
                phone.State = _stateMachine.Fire(PhoneCallTrigger.ViewCallInfo, phone.ViewCallInfo);
            }
            catch (TransitionNotFoundException tnfe)
            {
                Console.WriteLine(tnfe.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Не известная ошибка");
            }
            finally
            {
                Console.ReadLine();
            }
        }

        static void CheckFire(object sender, FireSucessEventArgs<PhoneCallState> args)
        {
            Console.WriteLine("Осуществлен переход из состояния {0} в состояние {1}", args.PrevState, args.NewState);
        }
    }
}
