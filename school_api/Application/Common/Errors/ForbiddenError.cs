

using school_api.Core.Interfaces;

namespace school_api.Application.Common.Errors
{

    public class ForbiddenError : Exception, IErrors
    {
        public int StatusCode { get; } = 400;
        public string Name { get; } = typeof(ForbiddenError).Name;
        public string Type { get; } = "";
        public object? Details { get; }

        public ForbiddenError(string message) : base(message){ }
    }
}