namespace WSEleccionesSSMA.Models
{
    public class SearchParams : PaginationParams
    {
        public string? OrderBy { get; set; }
        public string? SearchTerm { get; set; }
        public string? ColumnFilters { get; set; }
    }

    public class PaginationParams
    {
        private const int MaxPageSize = 100;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 6;
        public int PageSize { get { return _pageSize; } set { _pageSize = value > MaxPageSize ? MaxPageSize : value; } }
    }


    public class ColumnFilter
    {
        public string id { get; set; }
        public string value { get; set; }
    }
    public class ColumnSorting
    {
        public string? id { get; set; }
        public bool desc { get; set; }
    }

}
