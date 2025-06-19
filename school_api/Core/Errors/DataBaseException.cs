
using school_api.Core.Interfaces;

namespace school_api.Core.Errors
{

    public class DataBaseError : Exception, IErrors
    {
        public int StatusCode { get; } = 500;
        public string Name { get; } = typeof(DataBaseError).Name;
        public string Type { get; }
        public object? Details { get; }

        public DataBaseError(Exception exception) : base(exception.Message, exception)
        {
            Type = exception.GetType().Name;
        }
    }
}