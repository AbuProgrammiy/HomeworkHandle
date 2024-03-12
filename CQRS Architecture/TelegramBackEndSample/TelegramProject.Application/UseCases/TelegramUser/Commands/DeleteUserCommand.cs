using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramProject.Application.UseCases.TelegramUser.Commands
{
    public class DeleteUserCommand:IRequest
    {
        public int Id { get; set; }
    }
}
