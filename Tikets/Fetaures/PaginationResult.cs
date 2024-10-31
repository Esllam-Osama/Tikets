using Tikets.Models;

namespace Tikets.Fetaures
{
    public class PaginationResult<T>
    {
        public List<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PagesNumber { get; set; }
        public PaginationResult(List<T> items, int pageNum, int pagesNum)
        {
            this.Items = items;
            this.PageNumber = pageNum;
            this.PagesNumber = pagesNum;
        }

    }
}
