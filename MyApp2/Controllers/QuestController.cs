using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApp2.Controllers
{
    [Authorize]
    public class QuestController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
