using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace MyApp2.Data
{
    [Table("Task")]
    public class Quest
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Overdue { get; set; }
        public string Description { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }
        public string? QuestPicture { get; set; }
    }
}
