using ASPCoreExceptions.Exceptions;
using System.Diagnostics;

namespace ASPCoreExceptions.Middlewares
{
    public class RequestTooLongMiddleWare
    {
        private RequestDelegate _next;
        private ILogger<RequestTooLongMiddleWare> _logger;
        private const int MaxProcessingTimieMs = 1000;

        public RequestTooLongMiddleWare(RequestDelegate next, ILogger<RequestTooLongMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                Thread.Sleep(1100);
                await _next(context);
                stopwatch.Stop();
                //Jeżeli krokowo przechodzi się i stawia się breakPoint w 18 linijce to wchodzi w tego if
                //Wywołany zostaje wyjatek i przechodzi do catcha do obsługi wyjatku
                //Nie zatrzymuje się na throw bo mamy od razu obsługę, w przypadku pierwszego zadanie bład nie był w bloku try-catch tylko w if w controlerze
                //obsługa była dalej w middelware i bloku try-catch z mideelware czyli w momencie wywołania błędu i throw program nie widział, że obsługa jest wyżej w Invoke
                //Efektem jest o 1 sek dłuzsze otwieranie strony przez Thread.Sleep(1100);
                var processingTime = stopwatch.ElapsedMilliseconds;
                if (processingTime > MaxProcessingTimieMs)
                {
                    throw new RequestProcessingTooLongException(processingTime);
                }
                var requestPath = context.Request.Path;
                _logger.LogInformation($"Request to {requestPath} processed in: {processingTime} ms");
            }
            catch (RequestProcessingTooLongException ex)
            {
                _logger.LogInformation(ex, "Request to {Path} processed too long {Tmie} ms", context.Request.Path, ex.ProcessingTime);
                context.Response.StatusCode = StatusCodes.Status408RequestTimeout;
                await context.Response.WriteAsync("Request processing too long");
            }
        }
    }
}
