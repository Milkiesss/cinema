namespace cinema.Application.Pagination;

public interface IPaginationRequest
{
    public PageRequest? Page { get; set; }
}