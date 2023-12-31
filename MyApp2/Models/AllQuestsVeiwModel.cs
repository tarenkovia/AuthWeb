﻿using Microsoft.EntityFrameworkCore;
using MyApp2.Data;

namespace MyApp2.Models
{
    public class AllQuestsVeiwModel
    {
        //public Quest Quest { get; set; }
        //public UserAns UserAnswer { get; set; }

        //UserAns
        public int Id { get; set; }
        public int QuestId { get; set; }
        public string? UserId { get; set; }
        public string? TitleQuest { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Answer { get; set; }
        public string? Mark { get; set; }
        public string? Comments { get; set; }
        public bool AnsReceived { get; set; }

        //Quest
        public int IdQuest { get; set; }
        public string? Title { get; set; }
        public DateTime? Overdue { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? QuestPicture { get; set; }
    }
}
