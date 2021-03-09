using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlogPostMicroService.DTOs;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

// ReSharper disable UnusedMember.Global

namespace BlogPostMicroService.Models
{
    // ReSharper disable once ClassNeverInstantiated.Global
    [ExtendObjectType(Name = "Subscription")]
    public class BlogPostSubscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<List<BlogPost>>> OnBlogPostCreate([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            var result = await eventReceiver.SubscribeAsync<string, List<BlogPost>>("BlogPostCreated", cancellationToken);

            return result;
        }
    }
}
