using MediatR;                                              // IRequest |ishlashi uchun
using TelegramProject.Domain.Entities.Models;               // User |ishlashi uchun

namespace TelegramProject.Application.UseCases.TelegramUser.Queries
{
    public class GetAllUsersQuery:IRequest<IEnumerable<User>>
    {
    }
}
