using System.Collections.Generic;

namespace TimRecruitingTask.WebApp.Models
{
    public class PublicationCollectionViewModel
    {
        public List<PublicationItemViewModel> PublicationItems { get; set; }
        public string NextCursor { get; set; }
        public string SearchQuery { get; set; }
    }
}
