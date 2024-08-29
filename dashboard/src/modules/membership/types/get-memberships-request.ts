import { SortOrder } from '@/types/sort-order';

export interface GetMembershipsRequest {
  yearPaid?: string;
  query?: string;
  sortStartDate?: SortOrder;
}