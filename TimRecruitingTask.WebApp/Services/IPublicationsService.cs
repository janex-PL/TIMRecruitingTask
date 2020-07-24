using System.Threading.Tasks;
using TimRecruitingTask.WebApp.Models;

namespace TimRecruitingTask.WebApp.Services
{
    public interface IPublicationsService
    {
        public Task<PublicationCollectionViewModel> GetPublications(string query, string nextCursor);
    }
}
