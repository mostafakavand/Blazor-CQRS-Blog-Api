namespace Dayana.Shared.Basic.MethodsAndObjects.BaseServices.ServiceBus.Events;

public class UserStateUpdatedBusEvent : BusEvent
{
    public int UserId { get; set; }
    public string State { get; set; }
}