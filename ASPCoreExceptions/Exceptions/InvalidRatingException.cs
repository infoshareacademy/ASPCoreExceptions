namespace ASPCoreExceptions.Exceptions
{
    public class InvalidRatingException : Exception
    {
        public int Rating { get; }
        public int UserId { get; }

        public InvalidRatingException(int rating, int userId)
        {
            Rating = rating;
            UserId = userId;
        }
    }
}
