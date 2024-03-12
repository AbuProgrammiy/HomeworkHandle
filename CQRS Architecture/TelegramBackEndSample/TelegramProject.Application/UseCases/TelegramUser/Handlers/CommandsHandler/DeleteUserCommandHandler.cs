using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramProject.Application.Abstractions;
using TelegramProject.Application.UseCases.TelegramUser.Commands;

namespace TelegramProject.Application.UseCases.TelegramUser.Handlers.CommandsHandler
{
    public class DeleteUserCommandHandler : AsyncRequestHandler<DeleteUserCommand>
    {
        private readonly IApplicationDbContext _appDbContext;

        public DeleteUserCommandHandler(IApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        protected override Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _appDbContext.Users.Remove(_appDbContext.Users.FirstOrDefault(x=>x.Id==request.Id));
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
