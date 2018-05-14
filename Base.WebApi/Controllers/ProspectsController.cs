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
    public class ProspectsController : ApiController
    {
        IProspectAppService prospectAppService;

        public ProspectsController(
            IProspectAppService prospectAppService,
            INotificationHandler<DomainNotification> notifications) : base(
                notifications)
        {
            this.prospectAppService = prospectAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(prospectAppService.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProspectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            prospectAppService.Create(model);

            return Response(model);
        }

        [HttpPut]
        public IActionResult Put([FromBody]ProspectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            prospectAppService.Update(model);

            return Response(model);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            prospectAppService.Remove(id);
            return Response(id);
        }
    }
}