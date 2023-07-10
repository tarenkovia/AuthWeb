using Elfie.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyApp2.Data;
using System.Net;
using System.Security.Cryptography.Xml;

namespace MyApp2.Controllers
{
    [Authorize]
    public class QuestController : Controller
    {
        ApplicationDbContext db;
        public QuestController(ApplicationDbContext context) 
        {
            db = context;
        }
        
        public async Task<IActionResult> GetAll()
        {
            return View(await db.Tasks.ToListAsync());
        }

        public IActionResult QuestDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> QuestDetail(UserAns userAns)
        {
            db.UsersAnswer.Add(userAns);
            await db.SaveChangesAsync();
            return RedirectToAction("GetAll");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Quest quest = new Quest { Id = id.Value };
                db.Entry(quest).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("GetAll");
            }

            return NotFound();
        }

        public async Task<IActionResult> EditQuest(int? id)
        {
            if (id != null)
            {
                Quest? quest = await db.Tasks.FirstOrDefaultAsync(p => p.Id == id);
                if (quest != null) return View(quest);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditQuest(Quest quest)
        {
            db.Tasks.Update(quest);
            await db.SaveChangesAsync();
            return RedirectToAction("GetAll");
        }
    }
}
