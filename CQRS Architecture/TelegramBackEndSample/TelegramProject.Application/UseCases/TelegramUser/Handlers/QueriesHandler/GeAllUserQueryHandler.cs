using MediatR;                                                      // IRequestHandler |ishlashi uchun
using Microsoft.EntityFrameworkCore;
using TelegramProject.Application.Abstractions;                     // IApplicationDbContext |ishlashi uchun
using TelegramProject.Application.UseCases.TelegramUser.Queries;    // GetAllUsersQuery |ishlashi uchun
using TelegramProject.Domain.Entities.Models;                       // User |ishlashi uchun

namespace TelegramProject.Application.UseCases.TelegramUser.Handlers.QueriesHandler
{
    public class GeAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly IApplicationDbContext _appDbContext;

        public GeAllUserQueryHandler(IApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return _appDbContext.Users.ToListAsync().Result;
        }
    }
}
