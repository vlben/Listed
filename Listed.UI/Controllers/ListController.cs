using Listed.BLL.Interfaces;
using Listed.UI.Models.Viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Listed.UI.Controllers
{
	public class ListController : Controller
	{
		readonly IListService listService;

		public ListController(IListService listService)
		{
			this.listService = listService;
		}

		public IActionResult Index()
		{
			try
			{
				List<ListViewmodel> listViewmodels = new();

				foreach (var listItem in listService.GetListItems())
				{
					listViewmodels.Add(new ListViewmodel(listItem));
				}

				return View(listViewmodels);
			}

			catch (Exception exception)
			{
				return Content(exception.ToString());
			}
		}

		public IActionResult Details(int id)
		{
			try
			{
				List<ListOverviewModel> listOverviewModels = new();

				foreach (var listItem in listService.GetListItemsById(id))
				{
					listOverviewModels.Add(new ListOverviewModel(listItem));
				}

				return View(listOverviewModels);
			}

			catch (Exception exception)
			{
				return Content(exception.ToString());
			}
		}

		public IActionResult Edit(int id)
		{
			try
			{
				return View();
			}

			catch (Exception exception)
			{
				return Content(exception.ToString());
			}
		}

		public IActionResult DeleteListItem(int id)
		{
			listService.DeleteListItem(id);
			return RedirectToAction("Index");
		}
	}
}
