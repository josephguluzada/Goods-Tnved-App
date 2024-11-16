namespace GoodsTnvedApp.Business.GoodsTnvedAppExceptions;

public class InvalidGoodCodeException : Exception
{
    public InvalidGoodCodeException()
    {
        
    }

    public InvalidGoodCodeException(string message) : base(message)
    {
        
    }
}