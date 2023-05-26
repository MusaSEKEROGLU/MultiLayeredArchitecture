using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiLayered.Core.Dtos;

namespace MultiLayered.API.ValidationFilters
{
    //Kendi hata sınıfımızı dönmek için bu sınıfı oluşturduk
    public class ValidatorFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid) // hata var ise
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400,errors));
            }
        }
    }
}
