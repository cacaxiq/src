using Base.Application.Interfaces;
using Base.Application.ViewModels;
using Base.Shared.Domain.Notification;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Base.WebApi.Controllers
{
    [Authorize("Bearer")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : ApiController
    {
        IUserAppService userAppService;

        public UsersController(
            IUserAppService userAppService,
            INotificationHandler<DomainNotification> notifications)
            : base(notifications)
        {
            this.userAppService = userAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(userAppService.GetAll());
        }

        [HttpGet("{userId}")]
        public IActionResult Get(Guid userId)
        {
            return Response(userAppService.GetById(userId));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            model = await userAppService.Create(model);

            return Response(model);
        }

        [HttpPut]
        public IActionResult Put([FromBody]UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            userAppService.Update(model);

            return Response(model);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            userAppService.Remove(id);
            return Response(id);
        }
    }
}