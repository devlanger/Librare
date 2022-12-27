using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Core;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class BaseApiController : Controller
    {
        private IMediator mediator;
        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null)
            {
                return NotFound();
            }

            if (result.IsSuccess)
            {
                if (result.NotNull)
                {
                    return Ok(result.Value);
                }
                else
                {
                    return NotFound();
                }
            }

            return BadRequest(result.Error);
        }
    }
}

