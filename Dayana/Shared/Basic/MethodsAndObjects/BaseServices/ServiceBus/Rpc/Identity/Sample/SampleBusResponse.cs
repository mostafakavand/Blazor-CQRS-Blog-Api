namespace Dayana.Shared.Basic.MethodsAndObjects.BaseServices.ServiceBus.Rpc.Identity.Sample;

public class SampleBusResponse : BusResponse
{
    public string Text { get; set; }

    /// <summary>
    /// Specific Possible Errors For This Response
    /// Usage:
    /// if (response.HasError()) {
    ///     var e = response.Error;
    ///     if (e.Is(SampleBusResponse.Errors.NotFound))
    ///     {
    ///     }else if (e.Is(SampleBusResponse.Errors.NotAllowed))
    ///     {
    ///     }
    /// }
    /// </summary>
    public enum Errors
    {
        NotFound = 1,
        NotAllowed = 2
    }
}