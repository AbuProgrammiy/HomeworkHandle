using MediatR;                                                      // IRequestHandler |ishlashi uchun
using TelegramProject.Application.Abstractions;                     // IApplicationDbContext |ishlashi uchun
using TelegramProject.Application.Mapper;
using TelegramProject.Application.UseCases.TelegramUser.Commands;   // CreateUserCommand |ishlashi uchun
using TelegramProject.Domain.Entities.Models;                       // User |ishlashi uchun

namespace TelegramProject.Application.UseCases.TelegramUser.Handlers.CommandsHandler
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>  // Handle methodi qiymat qaytarmasligi kerak bolsa  AsyncRequestHandler ishlatiladi
    {
        private readonly IApplicationDbContext _appDbContext;

        public CreateUserCommandHandler(IApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        protected override Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = request.ConverTo<User>();           // Extension method Map uchun !)
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges(cancellationToken);
            return Task.CompletedTask;
        }
    }
}
