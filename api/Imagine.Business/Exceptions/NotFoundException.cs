namespace Imagine.Business.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message = "No data found") : base(message)
        {

        }
    }
}
