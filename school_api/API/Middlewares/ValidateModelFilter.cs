
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using school_api.API.DTOs;
using school_api.Core.Errors;


public class ValidateModelAttribute : ActionFilterAttribute
{

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            List<ModelStateErrorDTO> errorsList = context.ModelState
                .Where(ms => ms.Value!.Errors.Any())
                .SelectMany(ms => ms.Value!.Errors.Select(error => new ModelStateErrorDTO { Field = ms.Key, Error = error.ErrorMessage }))
                .ToList();

            throw new ModelStateError("The model is invalid", errorsList);
        }
    }
}