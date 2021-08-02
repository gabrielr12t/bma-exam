using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bma.Presentation.Framework.Mvc.Filters
{
    public sealed class RequestValidatorAttribute : TypeFilterAttribute
    {
        public RequestValidatorAttribute() : base(typeof(RequestValidatorFilter)) { }

        public class RequestValidatorFilter : IAsyncActionFilter
        {
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!context.ModelState.IsValid)
                {
                    var errorModelState = context.ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage));

                    var errors = errorModelState.SelectMany(p => p.Value);

                    context.Result = new BadRequestObjectResult(errors);
                    return;
                }

                await next();
            }
        }
    }
}