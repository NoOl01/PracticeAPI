using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using Practice.Models;

namespace Practice.DataAccess;

public class Subscribtion
{
    // [Subscription]
    // public async ValueTask<ISourceStream<User>> OnUserCreate([Service] ITopicEventReceiver eventReceiver,
    //     CancellationToken cancellationToken)
    // {
    //     return await eventReceiver.SubscribeAsync<string, User>("PostCreated", cancellationToken);
    // }
}