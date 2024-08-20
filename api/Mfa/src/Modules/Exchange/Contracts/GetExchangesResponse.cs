namespace Mfa.Modules.Exchange;

public class GetExchangesResponse {
    public required int Id { get; set; }
    public required int Year { get; set; }
    public required ExchangeType ExchangeType { get; set; }
    public required int MemberId { get; set; }
    public MemberDto? Member { get; set; }

    public class MemberDto {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}