namespace Kwtc.ErrorMonitoring.Application.Events.Commands;

using System.Transactions;
using Domain.Event;
using MediatR;
using Persistence.Event;
using Persistence.Exception;
using Persistence.Trace;

public record PersistEventCommand(Event Event) : IRequest;

internal sealed class PersistEventCommandHandler : IRequestHandler<PersistEventCommand>
{
    private readonly IEventRepository eventRepository;
    private readonly IExceptionRepository exceptionRepository;
    private readonly ITraceRepository traceRepository;

    public PersistEventCommandHandler(IEventRepository eventRepository, IExceptionRepository exceptionRepository, ITraceRepository traceRepository)
    {
        this.eventRepository = eventRepository;
        this.exceptionRepository = exceptionRepository;
        this.traceRepository = traceRepository;
    }

    public async Task Handle(PersistEventCommand request, CancellationToken cancellationToken)
    {
        using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var persistedEvent = await this.eventRepository.AddAsync(request.Event, cancellationToken);
        foreach (var exception in request.Event.Exceptions)
        {
            exception.EventId = persistedEvent.Id;
            var persistedException = await this.exceptionRepository.AddAsync(exception, cancellationToken);
            foreach (var traceLine in exception.TraceLines)
            {
                traceLine.ExceptionId = persistedException.Id;
            }

            await this.traceRepository.AddBulkAsync(exception.TraceLines, cancellationToken);
        }

        // TODO: persist metadata if any

        transactionScope.Complete();
    }
}
