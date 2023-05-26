using Listed.BLL.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Listed.UI.Models.Viewmodels
{
	[BindProperties]
	public class EditListVewmodel
	{
		public int? EpisodesWatched { get; set; }
		public int? UserRating { get; set; }
		public string Status { get; set; } = string.Empty;

		public EditListVewmodel() { }

		public EditListVewmodel(ListOverview listOverview)
		{
			Status = listOverview.Status;
			UserRating = listOverview.UserRating;
			EpisodesWatched = listOverview.EpisodesWatched;
		}
	}
}
