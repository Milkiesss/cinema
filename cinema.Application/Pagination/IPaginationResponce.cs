namespace cinema.Application.Pagination;

public interface IPaginationResponce<TType>
{
    public ICollection<TType> Items { get; set; }
    public PageResponce? Page { get; set; }
}