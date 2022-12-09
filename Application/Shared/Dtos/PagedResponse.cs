namespace Application.Shared.Dtos
{
    public class PagedResponse<T>
    {
        public int TotalCount { get; set; }
        public int PageSize { private get; set; }
        public int PageNumber { get; set; }
        public int CountOfItems { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;
        public List<T> Items { get; set; }
    }
}
