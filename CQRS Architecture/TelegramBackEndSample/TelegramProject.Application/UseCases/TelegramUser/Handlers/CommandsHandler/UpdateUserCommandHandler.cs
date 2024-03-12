using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramProject.Application.Abstractions;
using TelegramProject.Application.Mapper;
using TelegramProject.Application.UseCases.TelegramUser.Commands;
using TelegramProject.Domain.Entities.Models;

namespace TelegramProject.Application.UseCases.TelegramUser.Handlers.CommandsHandler
{
    public class UpdateUserCommandHandler:AsyncRequestHandler<UpdateUserCommand>
    {
        public readonly IApplicationDbContext _appDbContext;

        public UpdateUserCommandHandler(IApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        protected override Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _appDbContext.Users.Update(request.ConverTo<User>());    // Extension method Map uchun !)
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
