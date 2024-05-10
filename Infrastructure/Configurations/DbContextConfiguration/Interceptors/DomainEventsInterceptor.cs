using Domain.Common.Contract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Configurations.DbContextConfiguration.Interceptors;

public class DomainEventsInterceptor(IPublisher publisher, ILogger logger) : SaveChangesInterceptor
{

    public async override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;

        await SendDomainEventsAsync(context);

        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private async Task SendDomainEventsAsync(DbContext context)
    {
        var entitiesWithEvents = context.ChangeTracker.Entries<IEntity>()
                                                      .Select(entry => entry.Entity)
                                                      .SelectMany(entity =>
                                                      {
                                                          var domainEvents = entity.GetDomainEvents();

                                                          entity.ClearDomainEvents();

                                                          return domainEvents;
                                                      }).ToList();

        foreach (var entity in entitiesWithEvents)
        {
            try
            {
                await publisher.Publish(entity);
            }
            catch (Exception ex)
            {
                logger.LogError("Eevent Error :", ex);
            }
        }
    }
}
