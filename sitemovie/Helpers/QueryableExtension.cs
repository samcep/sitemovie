using sitemovie.DTO;

namespace sitemovie.Helpers
{
    public static class QueryableExtension
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable , PaginationDto paginationDto)
        {
            return queryable
                   .Skip((paginationDto.Page - 1) * paginationDto.RowsPerPage)
                   .Take((paginationDto.RowsPerPage));
        }
    }
}
