namespace MyFace.Models.Request
{
    public class SearchRequestModel
    {
        private string _search;
        
        public string Search
        {
            get => _search?.ToLower();
            set => _search = value;
        }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 100;
    }
}