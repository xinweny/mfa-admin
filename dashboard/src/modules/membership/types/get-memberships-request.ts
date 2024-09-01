import { SortOrder } from '@/types/sort-order';

import { MembershipType } from './membership-type';

export interface GetMembershipsRequest {
  yearPaid: number;
  query: string | null;
  membershipType: MembershipType | null;
  sortStartDate: SortOrder | null;
}