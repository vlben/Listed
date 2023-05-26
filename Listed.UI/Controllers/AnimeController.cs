using Listed.BLL.Interfaces;
using Listed.BLL.Services;
using Listed.UI.Models.Viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Listed.UI.Controllers
{
	public class AnimeController : Controller
	{
		private readonly IAnimeService animeService;

		public AnimeController(IAnimeService iAnimeService)
		{
			this.animeService = iAnimeService;
		}

		public IActionResult Index()
		{
			try
			{
				List<AnimeViewmodel> animeViewmodels = new();

				foreach (var anime in animeService.GetAllAnimes())
				{
					animeViewmodels.Add(new AnimeViewmodel(anime));
				}

				return View(animeViewmodels);
			}

			catch (Exception exception)
			{
				return Content($"{exception.Message}");
			}
		}

		public IActionResult Details(int id)
		{
			try
			{
				var animeDetails = animeService.GetAnimeById(id);
				AnimeOverviewModel animeOverviewModel = new(animeDetails);

				return View(animeOverviewModel);
			}

			catch (Exception exception)
			{
				return Content($"{exception.Message}");
			}
		}

		public IActionResult AddAnimeToList(int id)
		{
			try
			{
				animeService.AddAnimeToList(id);
				return RedirectToAction("Index", "List");
			}
			catch (Exception exception)
			{
				return Content($"{exception.InnerException}");
			}
		}
	}
}
