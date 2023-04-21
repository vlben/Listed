using Listed.BLL.Classes;

namespace Listed.UI.Models.Viewmodels
{
	public class ListViewmodel
	{
		public int ListItemId { get; set; }
		public string Status { get; set; }
		public byte[] AnimeCoverArt { get; set; }

		public ListViewmodel(List list)
		{
			ListItemId = list.ListItemId;
			Status = list.Status;
			AnimeCoverArt = list.AnimeCoverArt;
		}
	}
}
