namespace Academy.Domain.Entities;

public class UserPlace : BaseEntity
{
    public Guid PlaceId { get; set; }
    public Guid UserId { get; set; }
    public Place Place { get; set; }
    public User User { get; set; }
}