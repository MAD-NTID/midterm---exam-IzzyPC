namespace Coinbase.Exceptions
{
    public interface IUserErrorException
    {
        public int GetStatusCode();
        public string GetMessage();
    }
}