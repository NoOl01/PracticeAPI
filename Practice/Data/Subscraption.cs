using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using Practice.Models;

namespace Practice.Data;

public class Subscraption
{
    [Subscribe]
    public async ValueTask<ISourceStream<User>> OnUserCreate([Service] ITopicEventReceiver eventReceiver,
        CancellationToken cancellationToken)
    {
        return await eventReceiver.SubscribeAsync<User>("UserCreated", cancellationToken);
    }
    [Subscribe]
    public async ValueTask<ISourceStream<Employee>> OnEmployeeCreate([Service] ITopicEventReceiver eventReceiver,
        CancellationToken cancellationToken)
    {
        return await eventReceiver.SubscribeAsync<Employee>("EmployeeCreated", cancellationToken);
    }
    [Subscribe]
    public async ValueTask<ISourceStream<Service>> OnServiceCreate([Service] ITopicEventReceiver eventReceiver,
        CancellationToken cancellationToken)
    {
        return await eventReceiver.SubscribeAsync<Service>("ServiceCreated", cancellationToken);
    }
    [Subscribe]
    public async ValueTask<ISourceStream<Tour>> OnTourCreate([Service] ITopicEventReceiver eventReceiver,
        CancellationToken cancellationToken)
    {
        return await eventReceiver.SubscribeAsync<Tour>("TourCreated", cancellationToken);
    }
}