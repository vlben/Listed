using Listed.BLL.DTOs;

namespace Listed.BLL.Interfaces
{
	public interface IStudio
	{
		List<StudioDTO> GetStudios();
		List<StudioOverviewDTO> GetStudioById(int studioId);
	}
}
