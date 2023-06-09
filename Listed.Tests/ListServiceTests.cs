using Listed.BLL.DTOs;
using Listed.BLL.Interfaces;
using Listed.BLL.Services;
using Listed.Tests.Classes;

namespace Listed.Tests
{
	[TestClass]
	public class ListServiceTests
	{
		[TestMethod]
		public void UpdateListItem_AddListItem_ListItemUpdated()
		{
			//Arrange
			int listItemId = 1;
			IList iList = new ListTestDAL();
			ListService listService = new(iList);

			UpdateListItemDTO updateListItemDTO = new()
			{
				AnimeEpisodes = 1,
				AnimeRating = 1,
				AnimeStatus = "watching"
			};

			//Act
			listService.UpdateListItem(listItemId, updateListItemDTO);
			var listItem = listService.GetListItemById(listItemId);

			//Assert
			Assert.AreEqual(listItem.Status, updateListItemDTO.AnimeStatus);
		}

		[TestMethod]
		public void UpdateListItem_AddListItem_ListItemFailedToUpdate()
		{
			//Arrange
			int listItemId = 1;
			IList iList = new ListTestDAL();
			ListService listService = new(iList);

			UpdateListItemDTO updateListItemDTO = new()
			{
				AnimeEpisodes = 11,
				AnimeRating = 1,
				AnimeStatus = "watching"
			};

			//Act & Assert
			Assert.ThrowsException<Exception>(() => listService.UpdateListItem(listItemId, updateListItemDTO));
		}
	}
}