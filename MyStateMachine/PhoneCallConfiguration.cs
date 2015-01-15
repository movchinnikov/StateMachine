namespace MyStateMachine
{
    using OMASM;

    public sealed class PhoneCallConfiguration : 
        BaseStateMachineConfiguration<PhoneCallState, PhoneCallTrigger>
    {
        public PhoneCallConfiguration()
        {
            this.Configure(PhoneCallState.Silence)
                .Permit(PhoneCallTrigger.IncomingСall, PhoneCallState.Ringtone);
            this.Configure(PhoneCallState.Ringtone)
                .Permit(PhoneCallTrigger.ReceivingСall, PhoneCallState.Talk)
                .Permit(PhoneCallTrigger.EndCall, PhoneCallState.Ending);
            this.Configure(PhoneCallState.Talk)
                .Permit(PhoneCallTrigger.EndCall, PhoneCallState.Ending);
            this.Configure(PhoneCallState.Ending)
                .Permit(PhoneCallTrigger.ViewCallInfo, PhoneCallState.Silence);

        }
    }
}