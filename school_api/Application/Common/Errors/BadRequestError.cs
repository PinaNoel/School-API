
using school_api.Core.Interfaces;

namespace school_api.Application.Common.Errors
{

    public class BadRequestError : Exception, IErrors
    {
        public int StatusCode { get; } = 400;
        public string Name { get; } = "Bad Request";
        public string Type { get; } = "";
        public object? Details { get; }

        public BadRequestError(string message) : base(message){ }
    }
}