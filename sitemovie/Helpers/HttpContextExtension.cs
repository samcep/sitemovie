using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace sitemovie.Helpers
{
    public static class HttpContextExtension
    {

        public async static  Task InsertParamsPagination<T>(this HttpContext httpContext , 
            IQueryable<T> queryable ,  int rowsPerPage )
        {

            double totalsRows = await queryable.CountAsync();
            double totalsPage = Math.Ceiling( totalsRows  /rowsPerPage );
            httpContext.Response.Headers.Add("totalsPage", totalsPage.ToString());
        }
    }
}
