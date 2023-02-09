using EventBus.Base.Standard;
using FitnessAppDemo.Data;
using FitnessAppDemo.Data.Models;
using FitnessAppDemo.Logging.Events;

namespace FitnessAppDemo.Logging.Services
{
    public class LogService : IIntegrationEventHandler<LogEvent>
    {
        private readonly ProductContext _context;

        public LogService(ProductContext context)
        {
            _context = context;
        }

        public async Task Handle(LogEvent @event)
        {
            if (!string.IsNullOrEmpty(@event.Action) && string.IsNullOrEmpty(@event.Message))
            {
                var log = new Log() { Action = @event.Action, Message = @event.Message, Date = DateTime.UtcNow };
                await _context.Logs.AddAsync(log).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                //try
                //{
                //    await _context.SaveChangesAsync().ConfigureAwait(false);
                //}
                //catch (Exception ex)
                //{
                //    throw new Exception($"Product category has not been created. {ex.Message}.");
                //}
            }
        }
    }
}
