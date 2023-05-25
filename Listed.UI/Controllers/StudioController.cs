using Listed.BLL.Interfaces;
using Listed.UI.Models.Viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Listed.UI.Controllers
{
	public class StudioController : Controller
	{
		private readonly IStudioService studioService;

		public StudioController(IStudioService studioService)
		{
			this.studioService = studioService;
		}

		public IActionResult Index()
		{
			try
			{
				List<StudioViewmodel> studioViewmodels = new();

				foreach (var studio in studioService.GetStudios())
				{
					studioViewmodels.Add(new StudioViewmodel(studio));
				}

				return View(studioViewmodels);
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
				List<StudioOverviewModel> studioOverviewModels = new();

				foreach (var studio in studioService.GetStudioById(id))
				{
					studioOverviewModels.Add(new StudioOverviewModel(studio));
				}

				return View(studioOverviewModels);
			}

			catch (Exception exception)
			{
				return View(exception);
			}
		}
	}
}