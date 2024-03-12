using MediatR;                              // IRequest|ishlashi uchun

namespace TelegramProject.Application.UseCases.TelegramUser.Commands
{
    public class CreateUserCommand:IRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public string PhotoPath { get; set; }
        public bool isDeleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
