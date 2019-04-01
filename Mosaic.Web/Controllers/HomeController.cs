using Mosaic.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<ActionResult> SetStatus(int id, bool status, CancellationToken cancellationToken)
        {
            await _toDoService.ChangeStatus(id, status).ConfigureAwait(false);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public async Task<ActionResult> RemoveTask(int id, CancellationToken cancellationToken)
        {
            await _toDoService.RemoveTask(id, cancellationToken).ConfigureAwait(false);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public async Task<ActionResult> AddTask(string name, CancellationToken cancellationToken)
        {
            await _toDoService.AddTask(name, cancellationToken).ConfigureAwait(false);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var items = await _toDoService.LoadItems(cancellationToken).ConfigureAwait(false);
            return View(items);
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