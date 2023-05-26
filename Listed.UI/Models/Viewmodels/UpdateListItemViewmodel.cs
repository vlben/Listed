using Listed.BLL.Classes;
using Listed.BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Listed.UI.Models.Viewmodels
{
	public class UpdateListItemViewmodel
	{
		public int? EpisodesWatched { get; set; }
		public int? UserRating { get; set; }
		public string Status { get; set; } = string.Empty;

		public UpdateListItemViewmodel() { 
		}
	}
}
