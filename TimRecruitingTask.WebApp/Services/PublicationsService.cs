using System.Linq;
using System.Threading.Tasks;
using EuropePmcService;
using TimRecruitingTask.WebApp.Models;

namespace TimRecruitingTask.WebApp.Services
{
    public class PublicationsService : IPublicationsService
    {
        private readonly WSCitationImpl _service;

        public PublicationsService(WSCitationImpl service)
        {
            _service = service;
        }

        public async Task<PublicationCollectionViewModel> GetPublications(string query, string nextCursor)
        {
            var response = await _service.searchPublicationsAsync(new searchPublicationsRequest()
            {
                queryString = query,
                cursorMark = nextCursor

            });

            return new PublicationCollectionViewModel()
            {
                SearchQuery = query,
                NextCursor = response.@return.nextCursorMark,
                PublicationItems = response.@return.resultList
                    .Select(x => new PublicationItemViewModel(x.title, x.authorString, x.firstPublicationDate)).ToList()
            };
        }
    }
}
