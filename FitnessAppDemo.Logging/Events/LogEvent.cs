using EventBus.Base.Standard;

namespace FitnessAppDemo.Logging.Events
{
    public class LogEvent : IntegrationEvent
    {
        public string Action { get; set; }
        public string Message { get; set; }

        public LogEvent (string action, string message)
        {
            Action = action;
            Message = message;
        }
    }
}
