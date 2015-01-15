namespace MyStateMachine
{
    using System.ComponentModel;

    public enum PhoneCallTrigger
    {
        [Description("Входящий звонок")]
        IncomingСall,
        [Description("Прием звонка")]
        ReceivingСall,
        [Description("Конец звонка")]
        EndCall,
        [Description("Просмотр информации о звонке")]
        ViewCallInfo
    }
}