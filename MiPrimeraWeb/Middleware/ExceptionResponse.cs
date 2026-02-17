using System.Net;

namespace MiPrimeraWeb.Middleware
{
    public record ExceptionResponse(HttpStatusCode statusCode, string description);

}
