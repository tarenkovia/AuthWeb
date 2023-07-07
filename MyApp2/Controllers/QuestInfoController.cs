using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApp2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuestInfoController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
