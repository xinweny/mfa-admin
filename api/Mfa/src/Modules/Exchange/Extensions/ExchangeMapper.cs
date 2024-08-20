namespace Mfa.Modules.Exchange;

public static class ExchangeMapper {
    public static GetExchangesResponse ToGetExchangesResponse(this ExchangeModel exchange) {
        var member = exchange.Member;

        return new GetExchangesResponse {
            Id = exchange.Id,
            Year = exchange.Year,
            ExchangeType = exchange.ExchangeType,
            MemberId = exchange.MemberId,
            Member = member != null
                ? new GetExchangesResponse.MemberDto {
                    Id = member.Id,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                }
                : null,
        };
    }

    public static GetMemberExchangesResponse ToGetMemberExchangesResponse(this ExchangeModel exchange) {
        return new GetMemberExchangesResponse {
            Id = exchange.Id,
            Year = exchange.Year,
            ExchangeType = exchange.ExchangeType,
            MemberId = exchange.MemberId,
        };
    }

    public static ExchangeModel ToExchange(this CreateExchangeRequest req) {
        return new ExchangeModel {
            Year = req.Year,
            ExchangeType = req.ExchangeType,
            MemberId = req.MemberId,
        };
    }
}