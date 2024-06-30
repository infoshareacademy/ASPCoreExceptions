namespace ASPCoreExceptions.Exceptions
{
    public class RequestProcessingTooLongException:Exception
    {
        public long ProcessingTime { get; }

        public RequestProcessingTooLongException(long processingTime) 
            :base($"Request processing took too long {processingTime} ms")
        {
            ProcessingTime = processingTime;
        }
    }
}
