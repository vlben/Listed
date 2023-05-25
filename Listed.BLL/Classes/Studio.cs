using Listed.BLL.DTOs;

namespace Listed.BLL.Classes
{
	public class Studio
	{
		private readonly int studioId;

		public int StudioId
		{
			get { return studioId; }
		}

		private readonly string studioName;

		public string StudioName
		{
			get { return studioName; }
		}

		public Studio(StudioDTO studioDTO)
		{
			if (studioDTO == null)
			{
				throw new NullReferenceException("StudioDTO needs to be filled");
			}

			this.studioId = studioDTO.StudioId;
			this.studioName = studioDTO.StudioName;
		}
	}
}
