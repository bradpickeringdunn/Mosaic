using Mosaic.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mosaic.Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly IToDoService _toDoService;

        public HomeController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var items = await _toDoService.LoadItems(cancellationToken).ConfigureAwait(false);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}