namespace DotCache.Abstractions.Common;

public interface IExpires
{
    DateTime? ExpiryDate { get; set; }
}