using Janglee.Models;
using Janglee.Models.DAO;
using Janglee.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Janglee.Controllers
{
    public class HomeController : Controller
    {
        Database db = new Database();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login([Bind] User user)
        {
            int res = db.CheckLogin(user);
            if (res == 1)
            {
                return Json("success");
            }
            else
            {
                return Json("failed");
            }
        }

        [HttpPost]
        public JsonResult Register([Bind] User user)
        {
            try
            {
                int status = db.Register(user);
                if (status == 1)
                {
                    HttpContext.Session.SetString("username", user.Role);
                    return Json("success");
                }
                else
                    return Json("failed");
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    return Json("duplicate");
                }
                else
                {
                    return Json(e.Message);
                }
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
