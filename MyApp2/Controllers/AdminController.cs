using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyApp2.Data;
using MyApp2.Models;
using MyApp2.Services;

namespace MyApp2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext db;
        private readonly IFileService _fileService;
        public AdminController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult CreateNewQuest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewQuest(Quest quest)
        {
            
            db.Tasks.Add(quest);
            await db.SaveChangesAsync();
            return RedirectToAction("CreateNewQuest");
        }
        public async Task<IActionResult> GetQuestToRate(int? id)
        {
            if (id != null)
            {
                UserAns? userAns = await db.UsersAnswer.FirstOrDefaultAsync(p => p.Id == id);
                if (userAns != null) return View(userAns);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> GetQuestToRate(UserAns userAns)
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
        public async Task<IActionResult> DeleteUserAns(int? id)
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
