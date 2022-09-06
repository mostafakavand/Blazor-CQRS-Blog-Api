using Dayana.Shared.Basic.MethodsAndObjects.BaseServices.ServiceBus.Rpc.Identity;
using Dayana.Shared.Basic.MethodsAndObjects.BaseServices.ServiceBus.Rpc.Identity.Models;
using Dayana.Shared.Persistence.Models.Identity.Base;
using Dayana.Shared.Persistence.Models.Identity.Queries;
using MassTransit;
using MediatR;

namespace Dayana.Server.ServiceBus.Consumers;

public class GetUserBusRequestConsumer : IConsumer<GetUserBusRequest>
{
    private readonly IMediator _mediator;

    public GetUserBusRequestConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<GetUserBusRequest> context)
    {
        // Payload
        var userId = context.Message.UserId;

        // Operation
        var operation = await _mediator.Send(new GetUserByIdQuery { UserId = userId });

        var value = operation.Value as UserModel;

        // Response
        await context.RespondAsync(new GetUserBusResponse
        {
            User = new UserBusModel
            {
                Id = value.Id,
                Username = value.Username,
                Email = value.Email
            }
        });
    }
}