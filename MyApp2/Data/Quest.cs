using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp2.Data
{
    [Table("Task")]
    public class Quest
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Mark { get; set; }
        public string Overdue { get; set; }
    }
}
