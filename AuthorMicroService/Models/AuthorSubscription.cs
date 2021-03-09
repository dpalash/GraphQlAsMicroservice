using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AuthorMicroService.DTOs;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

// ReSharper disable UnusedMember.Global

namespace AuthorMicroService.Models
{
    // ReSharper disable once ClassNeverInstantiated.Global
    [ExtendObjectType(Name = "Subscription")]
    public class AuthorSubscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<List<Author>>> OnAuthorCreate([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            var result = await eventReceiver.SubscribeAsync<string, List<Author>>("AuthorCreated", cancellationToken);

            return result;
        }
    }
}
