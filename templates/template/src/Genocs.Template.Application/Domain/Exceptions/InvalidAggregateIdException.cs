namespace Genocs.Template.Application.Domain.Exceptions;

public class InvalidAggregateIdException : DomainException
{
    public InvalidAggregateIdException() : base($"Invalid aggregate id.")
    {
    }
}