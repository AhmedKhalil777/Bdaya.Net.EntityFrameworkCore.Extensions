using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bdaya.Net.Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bdaya.Net.EntityFrameworkCore.Extensions
{
    public static class MappingExtensions
    {
        /// <summary>
        /// working for paginate a list comming from db
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
              => PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);


        /// <summary>
        /// Working with auto mapper to project the paginated response
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
            => queryable.ProjectTo<TDestination>(configuration).ToListAsync();
    }
}
