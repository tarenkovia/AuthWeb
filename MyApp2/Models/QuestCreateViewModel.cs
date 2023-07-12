using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp2.Data;

namespace MyApp2.Models
{
    public class QuestCreateViewModel
    {
        public UserAns UserAnswer { get; set; }
        public List<SelectListItem> Titles { get; set; }
        
    }
}
