using Listed.BLL.Classes;
using Listed.BLL.DTOs;
using Listed.BLL.Interfaces;

namespace Listed.BLL.Services
{
    public class StudioService : IStudioService
    {
        readonly IStudio iStudio;

        public StudioService(IStudio iStudio)
        {
            this.iStudio = iStudio;
        }

        public List<Studio> GetStudios()
        {
            List<Studio> studios = new();

            try
            {
                List<StudioDTO> studioDTOs = iStudio.GetStudios();
                foreach (StudioDTO studioDTO in studioDTOs)
                {
                    studios.Add(new Studio(studioDTO));
                }
            }

            catch (Exception exception)
            {
                throw new Exception("Can't add animes to collection", exception);
            }

            return studios;
        }

        public List<StudioOverview> GetStudioById(int studioId)
        {
            List<StudioOverview> studioOverviews = new();

            try
            {
                List<StudioOverviewDTO> studioOverviewDTOs = iStudio.GetStudioById(studioId);
                foreach (StudioOverviewDTO studioOverviewDTO in studioOverviewDTOs)
                {
                    studioOverviews.Add(new StudioOverview(studioOverviewDTO));
                }
            }

            catch (Exception exception)
            {
                throw new Exception("Can't add animes to collection", exception);
            }

            return studioOverviews;
        }
    }
}
