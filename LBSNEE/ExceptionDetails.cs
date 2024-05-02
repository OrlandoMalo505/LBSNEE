
namespace LBSNEE;

public partial class GlobalExceptionHandler
{
    internal record ExceptionDetails(
    int Status,
    string Title,
    string Type,
    IEnumerable<object?> Errors);
}
