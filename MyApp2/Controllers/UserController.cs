using Elfie.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyApp2.Data;
using MyApp2.Models;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace MyApp2.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        ApplicationDbContext db;
        public UserController(ApplicationDbContext context) 
        {
            db = context;
        }
        
        public async Task<IActionResult> GetAllQuests()
        {
            /*var model = (from m in db.Tasks
                         join t in db.UsersAnswer
                         on m.Id equals t.QuestId
                         select new AllQuestsVeiwModel
                         {
                             Id = m.Id,
                             Title = m.Title,
                             Overdue = m.Overdue,
                             Description = m.Description,
                             Price = m.Price,

                             QuestId = t.QuestId,
                             TitleQuest = t.TitleQuest,
                             Answer = t.Answer,
                             Mark = t.Mark,
                             Comments = t.Comments,
                             AnsReceived = t.AnsReceived
                         }).ToList();*/
            return View(await db.Tasks.ToListAsync());
        }

        public async Task<IActionResult> GetSentAllQuests()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var items = await db.UsersAnswer.Where(f => f.UserId == currentUserID).AsNoTracking().ToListAsync();
            return View(items);
        }

        public IActionResult AddQuestAns()
        {
            var model = new QuestCreateViewModel();
            model.Titles = db.Tasks.Select(a => new SelectListItem()
            {
                Value = a.Title,
                Text = a.Title
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestAns(QuestCreateViewModel model)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var questId = (from b in db.Tasks where b.Title == model.UserAnswer.TitleQuest select b.Id).FirstOrDefault();
            var email = (from e in db.Users where e.Id == currentUserID select e.Email).FirstOrDefault();
            var userName = (from e in db.Users where e.Id == currentUserID select e.Name).FirstOrDefault();
            model.UserAnswer.Email = email;
            model.UserAnswer.Name = userName;
            model.UserAnswer.QuestId = questId;
            model.UserAnswer.AnsReceived = true;
            model.UserAnswer.UserId = currentUserID;
            model.UserAnswer.DepartureDate = DateTime.Now;
            var overdue = (from b in db.Tasks where b.Title == model.UserAnswer.TitleQuest select b.Overdue).FirstOrDefault();
            if(overdue < model.UserAnswer.DepartureDate)
            {
                model.UserAnswer.IsOverdue = false;
            }
            else
            {
                model.UserAnswer.IsOverdue = true;
            }

            db.UsersAnswer.Add(model.UserAnswer);
            await db.SaveChangesAsync();
            return RedirectToAction("GetAllQuests");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteQuest(int? id)
        {
            if (id != null)
            {
                Quest quest = new Quest { Id = id.Value };
                db.Entry(quest).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("GetAllQuests");
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
            return RedirectToAction("GetAllQuests");
        }
    }
}
