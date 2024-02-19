using System.ComponentModel.DataAnnotations.Schema;

namespace Homework2.Models
{
    public class StudentsWithDishes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LaunchDish { get; set; }
        public string DinnerDish { get; set; }
    }
}
