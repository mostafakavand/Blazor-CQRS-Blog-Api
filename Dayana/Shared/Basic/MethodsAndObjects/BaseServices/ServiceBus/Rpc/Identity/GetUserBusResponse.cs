using Dayana.Shared.Basic.MethodsAndObjects.BaseServices.ServiceBus.Rpc.Identity.Models;

namespace Dayana.Shared.Basic.MethodsAndObjects.BaseServices.ServiceBus.Rpc.Identity;

public class GetUserBusResponse : BusResponse
{
    public enum Errors
    {
        NotFound = 1
    }

    public UserBusModel User { get; set; }
}