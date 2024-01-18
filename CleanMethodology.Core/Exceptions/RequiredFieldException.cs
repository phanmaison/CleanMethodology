namespace CleanMethodology.Core.Exceptions;

public class RequiredFieldException(string fieldName) : BusinessException($"The field {fieldName} is required")
{
}