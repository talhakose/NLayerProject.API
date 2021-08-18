using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.API.Dtos;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;

namespace NLayerProject.API.Filters
{
    public class GenericNotFoundFilter<TEntity>:IAsyncActionFilter where TEntity:class
    {
        private readonly IService<TEntity> _service;

        public GenericNotFoundFilter(IService<TEntity> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (int) context.ActionArguments.Values.FirstOrDefault();
            var entry = await _service.GetByIdAsync(id);

            if (entry != null)
                await next();
            
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"id'si {id} olan nesne veritabanında bulunamadı.");
                context.Result = new NotFoundObjectResult(errorDto);
            }
            
        }

    }
}
