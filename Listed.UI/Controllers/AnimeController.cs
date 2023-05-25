using Listed.BLL.Interfaces;
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
				return View(exception);
			}
		}

		public IActionResult Details(int id)
		{
			try
			{
				List<AnimeOverviewModel> animeOverViewmodels = new();

				foreach (var anime in animeService.GetAnimeById(id))
				{
					animeOverViewmodels.Add(new AnimeOverviewModel(anime));
				}

				return View(animeOverViewmodels);
			}

			catch (Exception exception)
			{
				return View(exception);
			}
		}

		public IActionResult AddAnimeToList(int id)
		{
			animeService.AddAnimeToList(id);
			return RedirectToAction("Index", "List");
		}
	}
}
