using Microsoft.Extensions.Logging;
using System;

namespace TicketGrpcService.Helpers
{
	public interface ILogHelper<T>
	{
		void LogErrorInvokingGrpcMethod(Exception exception, string methodName, string containerName, object argument);
		void LogInvokingGrpcMethod(string methodName, string containerName, object argument);
		void LogNullException(string argumentName);
	}

	public class LogHelper<T> : ILogHelper<T>
	{
		private readonly ILogger<T> _logger;

		public LogHelper(ILogger<T> logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public void LogInvokingGrpcMethod(string methodName, string containerName, object argument)
		{
			_logger.LogInformation("Invoking grpc {methodName} on {containerName}. Argument {@argument}", methodName, containerName, argument);
		}

		public void LogErrorInvokingGrpcMethod(Exception exception, string methodName, string containerName, object argument)
		{
			_logger.LogError(exception, "An unexpected error occurred when invoking grpc {methodName} on {containerName}. Argument {@argumenr}", methodName, containerName, argument);
		}

		public void LogNullException(string argumentName)
		{
			_logger.LogCritical("The argument {argumentName} was null", argumentName);
		}
	}
}
