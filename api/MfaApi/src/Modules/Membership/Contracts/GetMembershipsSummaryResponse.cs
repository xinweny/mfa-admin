namespace MfaApi.Modules.Membership;

public class GetMembershipsSummaryResponse {
    public long? TotalDues { get; set; }
    public long? TotalDuesPaid { get; set; }
    public int? TotalCount { get; set; }
    public MembershipTypeCountsDto? MembershipTypeCounts { get; set; }

    public class MembershipTypeCountsDto {
        public int Single { get; set; }
        public int Family { get; set; }
        public int Honorary { get; set; }
    }
}