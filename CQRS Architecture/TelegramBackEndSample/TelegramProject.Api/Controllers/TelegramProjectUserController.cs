using MediatR;                                                          // IMediator |ishlashi uchun
using Microsoft.AspNetCore.Mvc;                                         // ControllerBase |ishlashi uchun
using TelegramProject.Application.UseCases.TelegramUser.Commands;       // CreateUserCommand |ishlashi uchun
using TelegramProject.Application.UseCases.TelegramUser.Queries;        // GetAllUsersQuery |ishlashi uchun
using TelegramProject.Domain.Entities.Models;                           // GetAllUsersQuery |ishlashi uchun

namespace TelegramProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramProjectUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TelegramProjectUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public string Create(CreateUserCommand command)
        {
            _mediator.Send(command);
            return "201: Created";
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _mediator.Send(new GetAllUsersQuery()).Result;
        }

        [HttpPut]
        public string Update(UpdateUserCommand command)
        {
            _mediator.Send(command);
            return "203: Updated";
        }

        [HttpDelete]
        public string Delete(DeleteUserCommand command)
        {
            _mediator.Send(command);
            return "204: Deleted";
        }
    }
}
