

using school_api.Core.Interfaces;

namespace school_api.Core.Errors
{

    public class ModelStateError : Exception, IErrors
    {
        public int StatusCode { get; } = 400;
        public string Name { get; } = typeof(ModelStateError).Name;
        public string Type { get; } = "Model State Error";
        public object? Details { get; }

        public ModelStateError(string message, object details) : base(message)
        {
            Details = details;
        }
    }
}