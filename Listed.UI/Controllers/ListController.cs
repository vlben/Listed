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
				var result = listService.GetListItemById(id);
				ListOverviewModel listOverviewModels = new(result);

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
				var item = listService.GetListItemById(id);

				EditListVewmodel editListVewmodel = new(item);

				return View(editListVewmodel);
			}

			catch (Exception exception)
			{
				return Content(exception.ToString());
			}
		}

		[HttpPost]
		public IActionResult PostFormData(EditListVewmodel model)
		{
			/*
			listService.UpdateListItem(editListVewmodel.Id, editListVewmodel);

			return RedirectToAction(Edit(editListVewmodel.Id));
			*/

			return RedirectToAction("Index");
		}

		public IActionResult DeleteListItem(int id)
		{
			listService.DeleteListItem(id);
			return RedirectToAction("Index");
		}
	}
}
