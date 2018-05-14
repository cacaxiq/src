using Base.Shared.Domain.Notification;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.WebApi.Controllers
{
    [Authorize("Bearer")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : ApiController
    {
        protected UsersController(INotificationHandler<DomainNotification> notifications)
            : base(notifications)
        {
        }
    }
}