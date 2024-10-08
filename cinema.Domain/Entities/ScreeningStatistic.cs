namespace cinema.Domain.Entities;

public class ScreeningStatistic 
{
    public Guid ScreeningId { get; set; }
    public Screening Screening { get; set; }
    public DateTime ScreeningDate { get; set; }
    public int SeatOccupancy { get; set; }
}