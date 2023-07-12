using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp2.Data
{
    [Table("UsersAnswer")]
    public class UserAns
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public string? TitleQuest { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Answer { get; set; }
        public string? Mark { get; set; }
        public string? Comments { get; set; }
        public bool AnsReceived { get; set; }
    }
}
