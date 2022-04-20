namespace HappyBday.API.Models
{
    public class PaginationHeader
    {
        public int CurrentPage { get; set; }

        public int ItemsPerPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public PaginationHeader(int currentPages, int itemPerPages, int totalItems, int totalPages)
        {
            this.CurrentPage = currentPages;
            this.ItemsPerPage = itemPerPages;
            this.TotalItems = totalItems;
            this.TotalPages = totalPages;
        }
    }
}