using Listed.BLL.Classes;

namespace Listed.BLL.Interfaces
{
    public interface IStudioService
    {
        List<StudioOverview> GetStudioById(int studioId);
        List<Studio> GetStudios();
    }
}