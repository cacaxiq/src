using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Application.Interfaces;
using Base.Application.ViewModels;
using Base.Shared.Domain.Notification;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class IntentionsController : ApiController
    {
        IIntentionAppService intentionAppService;

        public IntentionsController(
            IIntentionAppService intentionAppService,
            INotificationHandler<DomainNotification> notifications) : base(
                notifications)
        {
            this.intentionAppService = intentionAppService;
        }

        //[HttpPost]
        //public IActionResult CreateIntention([FromBody]IntentionViewModel model)
        //{
        //    intentionAppService.Create(model);
        //    return Ok();
        //}

        [HttpPost]
        public IActionResult Post([FromBody]IntentionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            intentionAppService.Create(model);

            return Response(model);
        }
    }
}