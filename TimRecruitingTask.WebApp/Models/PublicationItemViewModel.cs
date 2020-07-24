namespace TimRecruitingTask.WebApp.Models
{
    public class PublicationItemViewModel
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public string FirstPublicationDate { get; set; }

        public PublicationItemViewModel(string title, string authors, string creationDate)
        {
            Title = title;
            Authors = authors;
            FirstPublicationDate = creationDate;
        }
    }
}
