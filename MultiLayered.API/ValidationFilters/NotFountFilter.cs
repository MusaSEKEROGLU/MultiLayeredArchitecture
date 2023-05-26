using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiLayered.Core.Dtos;
using MultiLayered.Core.Models;
using MultiLayered.Core.Services;

namespace MultiLayered.API.ValidationFilters
{
    public class NotFountFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IGenericService<T> _genericService;
        public NotFountFilter(IGenericService<T> genericService)
        {
            _genericService = genericService;
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

            var anyEntity = await _genericService.AnyAsync(x => x.Id == id);

            if (anyEntity == true)
            {
                await next.Invoke();
                return;
            }
            else
            {
                context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>
                .Fail(404, $"{typeof(T).Name}({id}) not found"));
            }            
        }
    }
}
