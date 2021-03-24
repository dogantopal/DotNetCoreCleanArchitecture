namespace Infrastructure.SearchParams
{
    public class VisitSearchParams : BaseSearchParams
    {
        public int? UserId { get; set; }
        public VisitStatus Status { get; set; } = VisitStatus.All;
    }
}
