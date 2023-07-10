using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyApp2.Data;

namespace MyApp2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuestInfoController : Controller
    {
        ApplicationDbContext db;
        public QuestInfoController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult CreateNewTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewTask(Quest quest)
        {
            db.Tasks.Add(quest);
            await db.SaveChangesAsync();
            return RedirectToAction("CreateNewTask");
        }
        public async Task<IActionResult> GetTaskToRate(int? id)
        {
            if (id != null)
            {
                UserAns? userAns = await db.UsersAnswer.FirstOrDefaultAsync(p => p.Id == id);
                if (userAns != null) return View(userAns);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> GetTaskToRate(UserAns userAns)
        {
            var dbUser = db.UsersAnswer.FirstOrDefault(s => s.Id == userAns.Id);
            dbUser.Name = userAns.Name;
            dbUser.Email = userAns.Email;
            dbUser.TitleQuest = userAns.TitleQuest;
            dbUser.Answer = userAns.Answer;
            dbUser.Mark = userAns.Mark;
            dbUser.Comments = userAns.Comments;
            db.SaveChanges();
            return RedirectToAction("AdminPanel");
        }

        public async Task<IActionResult> AdminPanel()
        {
            return View(await db.UsersAnswer.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                UserAns userAns = new UserAns { Id = id.Value };
                db.Entry(userAns).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("AdminPanel");
            }

            return NotFound();
        }
    }
}
