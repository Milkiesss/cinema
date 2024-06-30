namespace cinema.Application.Pagination;

public class PaginationExtension
{
    public static TResponce GetPageResponce<T, TResponce, TItem>(IQueryable<T> query, IPaginationRequest request, Func<T, TItem> selector) 
        where T : class 
        where TResponce : IPaginationResponce<TItem>, new() 
        where TItem : class
    {
        var totalCount = query.Count();
        var items = query.Skip((request.Page!.PageNumber - 1) * request.Page.PageSize)
            .Take(request.Page.PageSize)
            .Select(selector)
            .ToList();
        var totalPages = (int)Math.Ceiling(totalCount / (double)request.Page.PageSize);
        return new TResponce
        {
            Items = items,
            Page = new PageResponce
            {
                TotalItems = totalPages,
                CurreingPage = request.Page.PageNumber,
                TotalPAge = totalCount
            }
        };
    }
}