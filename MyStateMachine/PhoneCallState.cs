namespace MyStateMachine
{
    using System.ComponentModel;

    public enum PhoneCallState
    {
        [Description("Тишина")]
        Silence,
        [Description("Мелодия звонка")]
        Ringtone,
        [Description("Разговор")]
        Talk,
        [Description("Конец звонка")]
        Ending
    }
}