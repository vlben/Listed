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
                return View(exception);
            }
        }

        public IActionResult Details(int listItemId)
        {
            try
            {
                List<ListOverviewModel> listOverviewModels = new();

                foreach (var listItem in listService.GetListItemsById(listItemId))
                {
                    listOverviewModels.Add(new ListOverviewModel(listItem));
                }

                return View(listOverviewModels);
            }

            catch (Exception exception)
            {
                return View(exception);
            }
        }

        public IActionResult DeleteListItem(int listItemId)
        {
            listService.DeleteListItem(listItemId);
            return RedirectToAction("Index");
        }
    }
}
