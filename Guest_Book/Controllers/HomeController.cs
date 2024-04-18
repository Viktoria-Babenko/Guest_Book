using Guest_Book.Models;
using Guest_Book.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Guest_Book.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IRepository repo;
        public HomeController(ILogger<HomeController> logger, IRepository r)
        {
            _logger = logger;
            repo = r;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetMesseges()
        {
            if (repo.GetMessegesList() == null)
                return Problem("The message list is empty!");
            List<MessegesModel> list = repo.GetMessegesList();
            List<Messege> mes = new List<Messege>();
            foreach (var item in list)
            {
                Messege messege = new Messege();
                messege.Messeges = item.Messeges;
                messege.MessegeDate = item.MessegeDate.ToString();
                messege.User = item?.User?.FirstName;
                mes.Add(messege);
            }
            string response = JsonConvert.SerializeObject(mes);
            return Json(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertMesseges(MessegesModel mess)
        {
            if (ModelState.IsValid)
            {
                if (mess.Messeges != null)
                {
                    MessegesModel messege = new MessegesModel();
                    messege.MessegeDate = DateTime.Now;
                    UserModel? user = await repo.GetUser(mess.UserId);
                    messege.User = user;
                    messege.UserId = user.Id;
                    messege.Messeges = mess.Messeges;
                    await repo.CreateMessege(messege, user);
                    await repo.Save();
                    string response = "Message added successfully!";
                    return Json(response);
                }
                return Problem("Problems adding a message!");
            }
            return Problem("Problems adding a message!");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
