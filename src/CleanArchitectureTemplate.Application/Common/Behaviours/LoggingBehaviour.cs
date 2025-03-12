using System.Diagnostics;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureTemplate.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse>(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly Stopwatch _timer = new();

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            

            _timer.Start();

            logger.LogInformation(
                "Request started: {RequestName}",
                requestName);

            var response = await next();

            _timer.Stop();

            if (response is IErrorOr errorOr && errorOr.IsError)
            {
                logger.LogWarning(
                    "Request completed with errors: {RequestName} ({ElapsedMilliseconds}ms) | Errors: {@Errors}",
                    requestName,
                    _timer.ElapsedMilliseconds,
                    errorOr.Errors);
            }
            else
            {
                logger.LogInformation(
                    "Request completed successfully: {RequestName} ({ElapsedMilliseconds}ms)",
                    requestName,
                    _timer.ElapsedMilliseconds);
            }

            return response;
        }
    }
}
