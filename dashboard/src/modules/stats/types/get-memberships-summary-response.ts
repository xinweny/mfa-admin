export interface GetMembershipsSummaryResponse {
  totalDues: number;
  totalDuesPaid: number;
  totalCount: number;
  membershipTypeCounts: {
    single: number;
    family: number;
    honorary: number;
  }
}