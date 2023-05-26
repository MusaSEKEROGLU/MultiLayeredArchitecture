using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiLayered.Core.Dtos;
using MultiLayered.Core.Models;
using MultiLayered.Core.Services;

namespace MultiLayered.WebApp.Exceptions
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IGenericService<T> _service;
        public NotFoundFilter(IGenericService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;

            var anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity == true)
            {
                await next.Invoke();
                return;
            }
            var errorVievModel = new ErrorViewModel();
            errorVievModel.Errors.Add($"{typeof(T).Name}({id}) not found");

            context.Result = new RedirectToActionResult("Error", "Home", errorVievModel);
        }
    }
}
