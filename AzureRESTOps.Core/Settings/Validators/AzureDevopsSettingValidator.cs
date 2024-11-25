namespace AzureRESTOps.Core.Settings.Validators;

public class AzureDevopsSettingValidator : IValidateOptions<AzureDevopsSettings>
{
    public ValidateOptionsResult Validate(string name, AzureDevopsSettings options)
    {
        var isValid = true;
        var validationResult = "Invalid configuration details: ";

        if (string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            isValid = false;
            validationResult += $"{nameof(AzureDevopsSettings)}.BaseUrl is required. ";
        }
        
        if (string.IsNullOrWhiteSpace(options.Organization))
        {
            isValid = false;
            validationResult += $"{nameof(AzureDevopsSettings)}.Organization is required. ";
        }
        
        if (string.IsNullOrWhiteSpace(options.Project))
        {
            isValid = false;
            validationResult += $"{nameof(AzureDevopsSettings)}.Project is required. ";
        }
        
        if (string.IsNullOrWhiteSpace(options.Token))
        {
            isValid = false;
            validationResult += $"{nameof(AzureDevopsSettings)}.Token is required. ";
        }

        if (string.IsNullOrWhiteSpace(options.QueryId))
        {
            isValid = false;
            validationResult += $"{nameof(AzureDevopsSettings)}.QueryId is required. ";
        }
        
        return isValid ? ValidateOptionsResult.Success : ValidateOptionsResult.Fail(validationResult);
    }
}