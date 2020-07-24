using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimRecruitingTask.WebApp.Extensions;
using TimRecruitingTask.WebApp.Models;
using TimRecruitingTask.WebApp.Services;

namespace TimRecruitingTask.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPublicationsService _service;

        public HomeController(IPublicationsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return RedirectToAction("Index");

            var result = await _service.GetPublications(searchQuery, string.Empty);

            return View(result);
        }
        public IActionResult PublicationsList(List<PublicationItemViewModel> publications)
        {
            return PartialView(publications);
        }

        public async Task<IActionResult> LoadNextPublications(string searchQuery, string nextCursor)
        {
            var result = await _service.GetPublications(searchQuery, nextCursor);
            return Json(new PublicationJsonResponse()
            {
                HtmlString = await this.RenderViewToStringAsync("PublicationsList", result.PublicationItems),
                NextCursor = result.PublicationItems.Count == 25 ? result.NextCursor : null
            });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
