using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramProject.Domain.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber {  get; set; }
        public string Bio { get; set; }
        public string PhotoPath { get; set; }
        public bool isDeleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
