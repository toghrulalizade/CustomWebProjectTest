using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcWEB.Filters;
using MvcWEB.Models;

namespace MvcWEB.Controllers
{
    [AuthenticationFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(ResultMessage model)
        {
            if (string.IsNullOrEmpty(model.Message))
            {
                model = new ResultMessage
                {
                    AlertStatus = "success",
                    Message = "Hesabiniza Xos gelmisiniz! Sistem Sizi Xatirladi!"
                };
            }
            return View(model);
        }
    }
}
