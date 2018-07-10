using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Application.Interfaces;
using Base.Application.ViewModels;
using Base.Shared.Domain.Notification;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.WebApi.Controllers
{
    [Authorize("Bearer")]
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

        [HttpGet]
        public IActionResult Get()
        {
            return Response(intentionAppService.GetAll());
        }

        [HttpGet("{userEmail}")]
        public IActionResult Get(string userEmail)
        {
            return Response(intentionAppService.GetAllByUserEmail(userEmail));
        }

        [HttpGet("{prospectId}")]
        public IActionResult Get(Guid prospectId)
        {
            return Response(intentionAppService.GetAllByProspect(prospectId));
        }

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

        [HttpPut]
        public IActionResult Put([FromBody]IntentionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            intentionAppService.Update(model);

            return Response(model);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            intentionAppService.Remove(id);
            return Response(id);
        }
    }
}