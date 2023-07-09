using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp2.Data;

namespace MyApp2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuestInfoController : Controller
    {
        ApplicationDbContext db;
        public List<Quest> myList = new List<Quest>();
        [ActivatorUtilitiesConstructor]
        public QuestInfoController()
        {
            
        }
        public QuestInfoController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult AdminPanel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminPanel(Quest quest)
        {
            db.Tasks.Add(quest);
            myList.Add(quest);
            await db.SaveChangesAsync();
            return RedirectToAction("AdminPanel");
        }

        
    }
}
