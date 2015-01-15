namespace MyStateMachine
{
    using System;

    public class Phone
    {
        public Phone()
        {
            State = PhoneCallState.Silence;
        }

        public PhoneCallState State { get; set; }

        public void IncomingCall(object[] args)
        {
            Console.WriteLine("*Ту-ту-ту* {0} вызывает вас", args[0]);
        }

        public void ReceivingСall()
        {
            Console.WriteLine("Алло?");
        }

        public void EndCall()
        {
            Console.WriteLine("Пока");
        }

        public void ViewCallInfo()
        {
            Console.WriteLine("Разговор окончен");
        }
    }
}