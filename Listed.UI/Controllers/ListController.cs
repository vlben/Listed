using Listed.BLL.Classes;
using Listed.BLL.DTOs;
using Listed.BLL.Interfaces;
using Listed.UI.Models.Viewmodels;
using Microsoft.AspNetCore.Mvc;
using System;

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
				var listItemDetails = listService.GetListItemById(id);
				ListOverviewModel listOverviewModels = new(listItemDetails);

				return View(listOverviewModels);
			}

			catch (Exception exception)
			{
				return Content($"{exception.Message}");
			}
		}

		public IActionResult Edit(int id)
		{
			try
			{
				var listItem = listService.GetListItemById(id);
				int MAX_EPISODES = listService.GetListItemEpisodes(id);

				EditListVewmodel editListVewmodel = new(listItem, MAX_EPISODES);

				return View(editListVewmodel);
			}

			catch (Exception exception)
			{
				return Content($"{exception.Message}");
			}
		}

		[HttpPost]
		public IActionResult PostFormData(int id, UpdateListItemViewmodel updateListItemViewmodel)
		{
			try
			{
				UpdateListItemDTO updateListItemDTO = new UpdateListItemDTO()
				{
					AnimeEpisodes = updateListItemViewmodel.EpisodesWatched,
					AnimeRating = updateListItemViewmodel.UserRating,
					AnimeStatus = updateListItemViewmodel.Status
				};

				listService.UpdateListItem(id, updateListItemDTO);

				return RedirectToAction("Index");
			}
			catch (Exception exception)
			{
				return Content($"{exception.InnerException}");
			}
		}

		public IActionResult DeleteListItem(int id)
		{
			try
			{
				listService.DeleteListItem(id);
				return RedirectToAction("Index");
			}
			catch (Exception exception)
			{
				return Content($"{exception.Message}");
			}
		}
	}
}
