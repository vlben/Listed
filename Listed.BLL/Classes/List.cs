using Listed.BLL.DTOs;

namespace Listed.BLL.Classes
{
	public class List
	{
		private readonly int listItemId;

		public int ListItemId
		{
			get { return listItemId; }
		}

		private readonly string status;

		public string Status
		{
			get { return status; }
		}

		private readonly byte[] animeCoverArt;

		public byte[] AnimeCoverArt
		{
			get { return animeCoverArt; }
		}

		public List(ListDTO listDTO)
		{
			this.listItemId = listDTO.ListItemId;
			this.status = listDTO.Status;
			this.animeCoverArt = listDTO.AnimeCoverArt;
		}
	}
}

