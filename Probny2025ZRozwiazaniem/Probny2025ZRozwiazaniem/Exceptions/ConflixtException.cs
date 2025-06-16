namespace Probny2025ZRozwiazaniem.Exceptions;

public class ConflixtException : Exception
{
    public ConflixtException()
    {
        
    }

    public ConflixtException(string? message) : base(message)
    {
        
    }

    public ConflixtException(string? message, Exception? innerException) : base(message, innerException)
    {
        
    }
}