using Listed.BLL.Classes;

namespace Listed.UI.Models.Viewmodels
{
	public class StudioViewmodel
	{
		public int StudioId { get; }
		public string StudioName { get; }

		public StudioViewmodel(Studio studio)
		{
			StudioId = studio.StudioId;
			StudioName = studio.StudioName;
		}
	}
}
