namespace MVCSportStore.ViewModels
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int PageItems { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageItems);
    }
}
