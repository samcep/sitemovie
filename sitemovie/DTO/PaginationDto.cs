namespace sitemovie.DTO
{
    public class PaginationDto
    {
        public int Page { get; set; } = 1;
        
        private int rowsPerPage  = 10;
        private int TotalPages { get; set; } = 0;

        private readonly  int maxRowsPerPage  = 50;

        public int RowsPerPage
        {
            get => rowsPerPage;
            set
            {
                rowsPerPage = (value > maxRowsPerPage) ? maxRowsPerPage : value;
            }
        }


    }
}
