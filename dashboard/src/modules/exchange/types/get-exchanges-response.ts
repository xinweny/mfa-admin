import { ExchangeType } from "./exchange-type";

export interface GetExchangesResponse {
  id: string;
  year: number;
  exchangeType: ExchangeType;
  memberId: string;
  member: {
    id: string;
    firstName: string;
    lastName: string;
  } | null;
}