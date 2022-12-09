using Application.Shared.Dtos;
using Application.Shared.Helpers;

namespace Application.Extensions
{
    public static class Extensions
    {
        public static PagedResponse<T> ToPagedResponse<T>(this PagedList<T> pagedList)
        {
            return new PagedResponse<T>()
            {
                TotalCount = pagedList.TotalCount,
                CountOfItems = pagedList.Count,
                PageNumber = pagedList.CurrentPage,
                PageSize = pagedList.PageSize,
                Items = pagedList
            };
        }
    }
}
